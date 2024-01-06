Imports System.Net


Public Class Settings
    Public use_ip_v6 As Boolean = False

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
        MainForm.AutorunAppCheckbox.Checked = WindowsStartup.IsActive
        ' Сервер
        MainForm.IpInput.SelectedItem = GetIp()
        MainForm.PortInput.Text = GetPort()
        MainForm.Ipv6CheckBox.Checked = My.Settings.UseIPv6
        MainForm.AccessKeyInput.Text = My.Settings.AccessKey
        MainForm.AutorunServerCheckBox.Checked = My.Settings.AutorunTcpServer
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
        If MainForm.IpInput.Text <> "" Then
            My.Settings.UserIp = MainForm.IpInput.Text
        End If
        If MainForm.PortInput.Text <> "" Then
            My.Settings.UserPort = MainForm.PortInput.Text
        End If
        My.Settings.UseIPv6 = MainForm.Ipv6CheckBox.Checked
        My.Settings.AutorunTcpServer = MainForm.AutorunServerCheckBox.Checked
        My.Settings.AccessKey = MainForm.AccessKeyInput.Text
        ' Приложения
        If MainForm.AimpInput.Text <> "" Then
            My.Settings.AimpPath = MainForm.AimpInput.Text
        End If
        If MainForm.MpcInput.Text <> "" Then
            My.Settings.MpcPath = MainForm.MpcInput.Text
        End If

        My.Settings.Save()
    End Sub


    ''' <summary>
    ''' Получение IP
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetIp()
        If My.Settings.UserIp <> "" Then
            Return My.Settings.UserIp
        Else
            Return My.Settings.DefaultIp
        End If
    End Function

    ''' <summary>
    ''' Полученеи порта
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPort()
        If My.Settings.UserPort Then
            Return My.Settings.UserPort
        Else
            Return My.Settings.DefaultPort
        End If
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
        MainForm.IpInput.Items.Add("127.0.0.1")
        For Each address As IPAddress In addresses
            If use_ip_v6 = True Or address.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                MainForm.IpInput.Items.Add(address.ToString())
            End If
        Next
    End Sub

End Class
