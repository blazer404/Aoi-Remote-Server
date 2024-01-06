Imports System.Net.Sockets
Imports System.Text


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
        Try
            ' Подключение к серверу.
            Dim ip = Settings.GetIp()
            Dim port = Settings.GetPort()
            If ip = "" Or ip = "0.0.0.0" Then
                ip = "127.0.0.1"
            End If
            Dim client As TcpClient = New TcpClient(ip, port)
            Dim stream As NetworkStream = client.GetStream()
            ' Отправка данных серверу.
            Dim message As String = "Hello from client"
            Dim data As Byte() = Encoding.UTF8.GetBytes(message)
            stream.Write(data, 0, data.Length)
            Utils.UpdateTextBox(Me, Me.LogBox, "Sent: " + message)
            ' Получение ответа от сервера.
            data = New Byte(256) {}
            Dim bytes As Integer = stream.Read(data, 0, data.Length)
            Dim responseData As String = Encoding.UTF8.GetString(data, 0, bytes)
            Utils.UpdateTextBox(Me, Me.LogBox, "Received: " + responseData)
            ' Закрытие соединения.
            client.Close()
        Catch ex As Exception
            Utils.UpdateTextBox(Me, Me.LogBox, "Exception: " + ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Нажатие на кнопку лога
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ClearLogButton_Click(sender As Object, e As EventArgs) Handles ClearLogButton.Click
        Utils.ClearTextBox(Me, Me.LogBox)
    End Sub

End Class
