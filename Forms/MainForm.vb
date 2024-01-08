Partial Public Class MainForm : Implements TCPServer.OnReceiveDataListener

    Private TCPServer As TCPServer
    Private Settings As Settings

    Sub UpdateLog(ByVal data As String) Implements TCPServer.OnReceiveDataListener.UpdateLog
        LogBox.Invoke(New Action(Of String)(AddressOf UpdateLogText), data)
    End Sub

    Sub OnDataReceived(ByVal data As String) Implements TCPServer.OnReceiveDataListener.OnDataReceived
        LogBox.Invoke(New Action(Of String)(AddressOf UpdateLogText), data)
    End Sub

    ''' <summary>
    ''' Обновление лога
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>
    Private Sub UpdateLogText(ByVal data As String)
        Utils.UpdateTextBox(LogBox, data)
    End Sub

    ''' <summary>
    ''' Загрузка приложения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Upgrade()
        Settings = New Settings
        Settings.Load()
        TCPServer = New TCPServer
        TCPServer.SetListener(Me)
        If My.Settings.AutorunTcpServer Then
            TCPServer.OpenConnection()
        End If
        If My.Settings.AutorunTcpServer = True Then
            Me.CloseButton.Text = My.Resources.s_Hide
            Me.Opacity = 0 ' Очень важный костыль - не трогай
        Else
            Me.TrayMenuShowApp.Text = My.Resources.s_Hide
        End If
    End Sub

    ''' <summary>
    ''' Обработка события после показа главной формы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If My.Settings.AutorunTcpServer = True Then
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
        Utils.UpdateTextBox(LogBox, "Settings is saved")
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
