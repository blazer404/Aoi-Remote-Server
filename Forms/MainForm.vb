Imports TSRC.Interfaces


Partial Public Class MainForm : Implements IServerListener

    Private Property Server As SocketServer = Nothing
    Private Property Settings As Settings = Nothing
    Private Property MediaPlayer As New MediaPlayer

    '''''''''''' Rewrite Interface - START ''''''''''''

    Sub OnOpenConnection() Implements IServerListener.OnOpenConnection
        Me.Invoke(New Action(AddressOf OpenConnectionAction))
    End Sub

    Sub OnCloseConnection() Implements IServerListener.OnCloseConnection
        Me.Invoke(New Action(AddressOf CloseConnectionAction))
    End Sub

    Sub OnCommandReceived(ByVal target As String, ByVal command As String) Implements IServerListener.OnCommandReceived
        Me.Invoke(New Action(Of String, String)(AddressOf SendCommand), target, command)
    End Sub

    Sub OnUpdateLog(ByVal data As String) Implements IServerListener.OnUpdateLog
        Try
            Me.Invoke(New Action(Of String)(AddressOf UpdateLogText), data)
        Catch ex As Exception
        End Try
    End Sub

    Sub OnShowError(ByVal data As String) Implements IServerListener.OnShowError
        Me.Invoke(New Action(Of String)(AddressOf ShowErrorBox), data)
    End Sub

    ''' <summary>
    ''' Действие при успешном включении сервера
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenConnectionAction()
        Server.IsRunning = True
        UpdateLogText("Server is running")
        RunServerButton.Text = "Stop Server"
        ServerStatusLabel.Text = "Server is running"
        ServerStatusLabel.ForeColor = Color.Green
        CloseButton.Text = My.Resources.s_Hide
        IconsReload()
    End Sub

    ''' <summary>
    ''' Действие при отключении сервера
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CloseConnectionAction()
        Server.IsRunning = False
        UpdateLogText("Server is stopped")
        RunServerButton.Text = "Start Server"
        ServerStatusLabel.Text = "Server is stopped"
        ServerStatusLabel.ForeColor = Color.IndianRed
        CloseButton.Text = My.Resources.s_Exit
        IconsReload()
    End Sub

    ''' <summary>
    ''' Обновление лога
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub UpdateLogText(ByVal data As String)
        If ShowDebugCheckBox.Checked = True Then
            Utils.UpdateTextBox(LogBox, data)
        End If
    End Sub

    ''' <summary>
    ''' Показ сообщения об ошибке
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub ShowErrorBox(ByVal data As String)
        MessageBox.Show(data, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub

    ''' <summary>
    ''' Отправка полученной команды проигрывателю
    ''' </summary>
    ''' <param name="target"></param>
    ''' <param name="commandKey"></param>
    ''' <remarks></remarks>
    Private Async Sub SendCommand(ByVal target As String, ByVal commandKey As String)
        Await Task.Run(Sub() MediaPlayer.SendCommand(target, commandKey))
    End Sub

    '''''''''''' Rewrite Interface - END ''''''''''''


    ''' <summary>
    ''' Перезагрузка иконок в зависимости от статуса сервера
    ''' </summary>
    Private Sub IconsReload()
        If Server.IsRunning Then
            Me.Icon = My.Resources.icon_green_square
            TrayIcon.Icon = My.Resources.icon_green_circle
        Else
            Me.Icon = My.Resources.icon_orange_squae
            TrayIcon.Icon = My.Resources.icon_orange_circle
        End If
    End Sub

    ''' <summary>
    ''' Загрузка настроек
    ''' </summary>
    Private Sub LoadSettings(Optional ByVal needUpgrade As Boolean = True)
        If needUpgrade Then
            My.Settings.Upgrade()
        End If
        Settings = New Settings
        Settings.Load()
    End Sub

    ''' <summary>
    ''' Создание сервера
    ''' </summary>
    Private Sub CreateServer()
        Server = New SocketServer With {
             .Ip = Settings.GetIp(),
             .Port = Settings.GetPort(),
             .Token = Settings.GetAuthToken(),
             .Listener = Me
         }
    End Sub


    ''' <summary>
    ''' Загрузка приложения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Определяем начальное поведение
        TabPanel.TabPages.Remove(DebugTab)
        LoadSettings()
        CreateServer()
        If My.Settings.AutorunTcpServer = True Then
            Server.Start()
            Me.CloseButton.Text = My.Resources.s_Hide
        End If
        If My.Settings.RunMinimized Then
            Me.Opacity = 0 ' Очень важный костыль - не трогай
        Else
            Me.TrayMenuShowApp.Text = My.Resources.s_Hide
        End If
        IconsReload()

        'TODO delete this after add aimp api 
        AimpInput.Enabled = False
        AimpInput.Visible = False
        AimpLabel.Text &= "        [ функция недоступна или отключена ]"
    End Sub

    ''' <summary>
    ''' Обработка события после показа главной формы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If My.Settings.RunMinimized = True Then
            Me.Hide()
            Me.Opacity = 1
        End If
    End Sub

    ''' <summary>
    ''' Обработка события при закрытии формы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing AndAlso Server.isRunning Then
            e.Cancel = True
            Me.TrayMenuShowApp.Text = My.Resources.s_Show
            Me.Hide()
        End If
    End Sub

    ''' <summary>
    ''' Нажатие на кнопку закрытия
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Settings.Save()
        Me.Close()
    End Sub

    ''' <summary>
    ''' Сохранение и перезапуск сервера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Server.Close()
        Settings.Save()
        UpdateLogText("Settings is saved")
        CreateServer()
        If AutorunServerCheckBox.Checked = True Then
            Server.Start()
        End If
    End Sub

    ''' <summary>
    ''' Сброс настроек приложения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        Dim result = MessageBox.Show("Are you sure you want to reset?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If result = Windows.Forms.DialogResult.OK Then
            Server.Close()
            Settings.Reset()
            LoadSettings(False)
            CreateServer()
        End If
    End Sub

End Class
