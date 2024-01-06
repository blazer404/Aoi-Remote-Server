Partial Public Class MainForm

    Private TCPServer As TCPServer
    Private Settings As Settings

    ''' <summary>
    ''' Загрузка программы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Upgrade()
        Settings = New Settings
        Settings.Load()
        TCPServer = New TCPServer
        If My.Settings.AutorunTcpServer Then
            TCPServer.OpenConnection()
        End If
    End Sub

    ''' <summary>
    ''' Закрытие программы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TCPServer.CloseConnection()
    End Sub

    ''' <summary>
    ''' Нажатие на кнопку закрытия
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
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
        Utils.UpdateTextBox(Me, Me.LogBox, "Settings is saved")
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
        TCPServer.CloseConnection()
        Settings.Reset()
        Settings.Load()
    End Sub

End Class
