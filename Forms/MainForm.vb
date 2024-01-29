Partial Public Class MainForm : Implements TCPServer.DataListener

    Private TCPServer As TCPServer
    Private Settings As Settings

    '''''''''''' Rewrite Interface - START ''''''''''''

    Sub OnOpenConnection() Implements TCPServer.DataListener.OnOpenConnection
        Me.Invoke(New Action(AddressOf OpenConnectionAction))
    End Sub

    Sub OnCloseConnection() Implements TCPServer.DataListener.OnCloseConnection
        Me.Invoke(New Action(AddressOf CloseConnectionAction))
    End Sub

    Sub OnClientConnected() Implements TCPServer.DataListener.OnClientConnected
        Console.Beep()
        Me.Invoke(New Action(Of String)(AddressOf UpdateLogText), "Client connected")
    End Sub

    Sub OnClientDisconnected() Implements TCPServer.DataListener.OnClientDisconnected
        Console.Beep()
        Me.Invoke(New Action(Of String)(AddressOf UpdateLogText), "Client disconnected")
    End Sub

    Sub OnCommandReceived(ByVal playerName As String, ByVal command As String) Implements TCPServer.DataListener.OnCommandReceived
        Me.Invoke(New Action(Of String, String)(AddressOf SendCommand), playerName, command)
    End Sub

    Sub OnUpdateLog(ByVal data As String) Implements TCPServer.DataListener.OnUpdateLog
        Try
            Me.Invoke(New Action(Of String)(AddressOf UpdateLogText), data)
        Catch ex As Exception
        End Try
    End Sub

    Sub OnShowError(ByVal data As String) Implements TCPServer.DataListener.OnShowError
        Me.Invoke(New Action(Of String)(AddressOf ShowErrorBox), data)
    End Sub

    ''' <summary>
    ''' Действие при успешном включении сервера
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenConnectionAction()
        TCPServer.isRunning = True
        UpdateLogText("Server is running")
        RunServerButton.Text = "Stop Server"
        ServerStatusLabel.Text = "Server is running"
        ServerStatusLabel.ForeColor = Color.Green
        CloseButton.Text = My.Resources.s_Hide
    End Sub

    ''' <summary>
    ''' Действие при отключении сервера
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CloseConnectionAction()
        TCPServer.isRunning = False
        UpdateLogText("Server is stopped")
        RunServerButton.Text = "Start Server"
        ServerStatusLabel.Text = "Server is stopped"
        ServerStatusLabel.ForeColor = Color.IndianRed
        CloseButton.Text = My.Resources.s_Exit
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
    ''' <param name="name"></param>
    ''' <param name="command"></param>
    ''' <remarks></remarks>
    Private Sub SendCommand(ByVal name As String, ByVal command As String)
        MediaPlayer.SendCommand(name, command)
    End Sub

    '''''''''''' Rewrite Interface - END ''''''''''''

    ''' <summary>
    ''' Загрузка приложения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Определяем начальное поведение
        TabPanel.TabPages.Remove(DebugTab)
        ' Грузим настройки
        My.Settings.Upgrade()
        Settings = New Settings
        Settings.Load()
        ' Создаем сервера и запускаем если надо
        TCPServer = New TCPServer
        TCPServer.SetListener(Me)
        If My.Settings.AutorunTcpServer = True Then
            TCPServer.OpenConnection()
            Me.CloseButton.Text = My.Resources.s_Hide
        End If
        If My.Settings.RunMinimized Then
            Me.Opacity = 0 ' Очень важный костыль - не трогай
        Else
            Me.TrayMenuShowApp.Text = My.Resources.s_Hide
        End If

        'TODO delete this after add aimp api 
        AimpInput.Enabled = False
        AimpInput.Visible = False
        AimpLabel.Text &= "        [ недоступно в этой версии ]"
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
        If e.CloseReason = CloseReason.UserClosing AndAlso TCPServer.isRunning Then
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
        Settings.Load()
        Me.Close()
    End Sub

    ''' <summary>
    ''' Сохранение и перезапуск сервера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        TCPServer.CloseConnection()
        Settings.Save()
        UpdateLogText("Settings is saved")
        If AutorunServerCheckBox.Checked = True Then
            TCPServer.OpenConnection()
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
            TCPServer.CloseConnection()
            Settings.Reset()
            Settings.Load()
        End If
    End Sub

End Class
