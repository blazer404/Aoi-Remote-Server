Partial Public Class MainForm

    ''' <summary>
    ''' Нажатие на кнопку запуска/остановки сервера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RunServerButton_Click(sender As Object, e As EventArgs) Handles RunServerButton.Click
        If Not Server.isRunning Then
            Server.Start()
        Else
            Server.Close()
        End If
    End Sub

    ''' <summary>
    ''' Нажатие на кнопку лога
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ClearLogButton_Click(sender As Object, e As EventArgs) Handles ClearLogButton.Click
        ClearTextBox(LogBox)
    End Sub

End Class
