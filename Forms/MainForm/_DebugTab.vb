'Imports System.Net.Sockets
'Imports System.Text


Partial Public Class MainForm

    ''' <summary>
    ''' Нажатие на кнопку запуска/остановки сервера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RunServerButton_Click(sender As Object, e As EventArgs) Handles RunServerButton.Click
        If Not TCPServer.isRunning Then
            TCPServer.OpenConnection()
        Else
            TCPServer.CloseConnection()
        End If
    End Sub

    ''' <summary>
    ''' Нажатие на кнопку клиента
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TestClientButton_Click(sender As Object, e As EventArgs) Handles TestClientButton.Click
        TestClientForm.Show()
    End Sub

    ''' <summary>
    ''' Нажатие на кнопку лога
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ClearLogButton_Click(sender As Object, e As EventArgs) Handles ClearLogButton.Click
        Utils.ClearDebugLog()
    End Sub

End Class
