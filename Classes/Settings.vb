Imports System.Net
Imports Microsoft.Win32
Imports Microsoft.Win32.Registry


Public Class Settings

    Public Property UseIpv6 As Boolean = False
    Private Property WinStartupIsActive As Boolean = False
    Private Property WinStartupRegSubKey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"
    Private Property FirewallKey As String = "SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\FirewallRules"


    ''' <summary>
    ''' Конструктор класса
    ''' </summary>
    Public Sub New()
        WinStartupIsActive = GetWinStartupStatus()
    End Sub

    ''' <summary>
    ''' Копируем настройки из старой версии
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Upgrade()
        If (My.Settings.NeedUpgrade = True) Then
            My.Settings.Upgrade()
            My.Settings.NeedUpgrade = False
            My.Settings.Save()
        End If
    End Sub

    ''' <summary>
    ''' Определение и применение всех необходимых настроек при загрузке приложения
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Load()
        AddFirewallRule()
        ' Основные
        GetIpList()
        MainForm.Text = Application.ProductName + " v" + Application.ProductVersion
        MainForm.TrayIcon.Text = Application.ProductName
        ' Сервер
        MainForm.IpInput.SelectedItem = GetIp()
        MainForm.PortInput.Text = GetPort()
        MainForm.Ipv6CheckBox.Checked = My.Settings.UseIPv6
        MainForm.AuthTokenInput.Text = My.Settings.AuthToken
        MainForm.AutorunServerCheckBox.Checked = My.Settings.AutorunTcpServer
        MainForm.AutorunAppCheckbox.Checked = WinStartupIsActive
        MainForm.RunMinimizedCheckBox.Checked = My.Settings.RunMinimized
        MainForm.ShowDebugCheckBox.Checked = My.Settings.ShowDebug
        ' Приложения
        MainForm.AimpInput.Text = My.Settings.AimpPath
        MainForm.MpcInput.Text = My.Settings.MpcPath
    End Sub

    ''' <summary>
    ''' Сохранение пользовательских настроек
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
        ' Основные
        If MainForm.AutorunAppCheckbox.Checked = True Then
            WinStartupAdd()
        Else
            WinStartupRemove()
        End If
        ' Сервер
        My.Settings.UserIp = MainForm.IpInput.Text
        My.Settings.UserPort = MainForm.PortInput.Text
        My.Settings.UseIPv6 = MainForm.Ipv6CheckBox.Checked
        My.Settings.AuthToken = MainForm.AuthTokenInput.Text
        My.Settings.AutorunTcpServer = MainForm.AutorunServerCheckBox.Checked
        My.Settings.RunMinimized = MainForm.RunMinimizedCheckBox.Checked
        My.Settings.ShowDebug = MainForm.ShowDebugCheckBox.Checked
        ' Приложения
        My.Settings.AimpPath = MainForm.AimpInput.Text
        My.Settings.MpcPath = MainForm.MpcInput.Text
        My.Settings.Save()
    End Sub

    ''' <summary>
    ''' Сброс всех настроек
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Reset()
        My.Settings.Reset()
        WinStartupRemove()
        UpdateTextBox(MainForm.LogBox, "Settings is reset")
    End Sub

    ''' <summary>
    ''' Получение IP
    ''' </summary>
    ''' <returns></returns>
    Public Function GetIp() As String
        Return If(My.Settings.UserIp <> "", My.Settings.UserIp.ToString, My.Settings.DefaultIp.ToString)
    End Function

    ''' <summary>
    ''' Полученеи порта
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPort() As String
        Return If(My.Settings.UserPort, My.Settings.UserPort.ToString, My.Settings.DefaultPort.ToString)
    End Function

    ''' <summary>
    ''' Получение пароля
    ''' </summary>
    ''' <returns></returns>
    Public Function GetAuthToken() As String
        Return My.Settings.AuthToken
    End Function

    ''' <summary>
    ''' Опредление списка IP адресов и вывод в выпадающий список
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetIpList()
        Dim hostName As String = Dns.GetHostName()
        Dim addresses() As IPAddress = Dns.GetHostAddresses(hostName)
        MainForm.IpInput.Items.Clear()
        MainForm.IpInput.Items.Add("0.0.0.0")
        For Each address As IPAddress In addresses
            If UseIpv6 = True Or address.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                MainForm.IpInput.Items.Add(address.ToString())
            End If
        Next
    End Sub

    ''' <summary>
    ''' Проверяем наличие ключа в реестре
    ''' </summary>
    ''' <param name="keyName"></param>
    ''' <returns></returns>
    Private Function RegKeyExists(keyName As String) As Boolean
        Dim regKey As RegistryKey = CurrentUser.OpenSubKey(keyName, False)
        Return regKey IsNot Nothing
    End Function

    ''' <summary>
    ''' Добавление приложения в автозагрузку системы
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub WinStartupAdd()
        If WinStartupIsActive = False AndAlso Not RegKeyExists(WinStartupRegSubKey) Then
            Dim regKey As RegistryKey = CurrentUser.OpenSubKey(WinStartupRegSubKey, True)
            regKey.SetValue(Application.ProductName, Application.ExecutablePath)
            regKey.Close()
        End If
    End Sub

    ''' <summary>
    ''' Удаление приложения из автозагрузки системы
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub WinStartupRemove()
        If WinStartupIsActive = True AndAlso RegKeyExists(WinStartupRegSubKey) Then
            Dim regKey As RegistryKey = CurrentUser.OpenSubKey(WinStartupRegSubKey, True)
            regKey.DeleteValue(Application.ProductName, False)
            regKey.Close()
        End If
    End Sub

    ''' <summary>
    ''' Проверка находится ли приложение в автозагрузке системы
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetWinStartupStatus() As Boolean
        Dim status As Boolean = False
        If RegKeyExists(WinStartupRegSubKey) Then
            Dim regKey As RegistryKey = CurrentUser.OpenSubKey(WinStartupRegSubKey, False)
            Dim value As Object = regKey.GetValue(Application.ProductName)
            status = value IsNot Nothing AndAlso value.ToString() = Application.ExecutablePath
            regKey.Close()
        End If
        Return status
    End Function

    Public Sub AddFirewallRule()
        'Dim appName = Application.ProductName.Replace(" ", "_")
        'Dim appPath As String = (Process.GetCurrentProcess().MainModule.FileName).ToLower
        'Dim proc As New Process()
        'proc.StartInfo.FileName = "netsh"
        'proc.StartInfo.Arguments = "advfirewall firewall add rule name=""" & appName & """ dir=in action=allow program=""" & appPath & """ enable=yes"
        'proc.StartInfo.Verb = "runas"
        'proc.Start()
        'proc.WaitForExit()
    End Sub

End Class
