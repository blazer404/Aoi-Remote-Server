Imports System.Net


Public Class Settings

    Public Property UseIpv6 As Boolean = False
    Private Property WindowsStartup As New WindowsStartup


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
        MainForm.AutorunAppCheckbox.Checked = WindowsStartup.IsActive
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
            WindowsStartup.Add()
        Else
            WindowsStartup.Remove()
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
        WindowsStartup.Remove()
        UpdateTextBox(MainForm.LogBox, "Settings is reset")
    End Sub

    ''' <summary>
    ''' Получение IP
    ''' </summary>
    ''' <returns></returns>
    Public Function GetIp() As String
        If My.Settings.UserIp <> "" Then
            Return My.Settings.UserIp.ToString
        Else
            Return My.Settings.DefaultIp.ToString
        End If
    End Function

    ''' <summary>
    ''' Полученеи порта
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPort() As String
        If My.Settings.UserPort Then
            Return My.Settings.UserPort.ToString
        Else
            Return My.Settings.DefaultPort.ToString
        End If
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
        For Each address As IPAddress In addresses
            If UseIpv6 = True Or address.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                MainForm.IpInput.Items.Add(address.ToString())
            End If
        Next
    End Sub

End Class
