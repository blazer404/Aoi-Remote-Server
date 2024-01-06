Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading


Public Class TCPServer

    Public isRunning As Boolean = False
    Private server As TcpListener = Nothing
    Private serverThread As Thread = Nothing

    ''' <summary>
    ''' Запуск сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenConnection()
        If Not isRunning Then
            serverThread = New Thread(AddressOf StartListener)
            serverThread.Start()
            isRunning = True
            Utils.UpdateTextBox(MainForm, MainForm.LogBox, "Server is running..." + vbNewLine + "Waiting for a connection...")
            MainForm.RunServerButton.Text = "Stop Server"
            MainForm.TestClientButton.Enabled = True
            MainForm.ServerStatusLabel.Text = "Server is running"
            MainForm.ServerStatusLabel.ForeColor = Color.Green
            MainForm.CloseButton.Text = My.Resources.s_Hide
        End If
    End Sub

    ''' <summary>
    ''' Остановка сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseConnection()
        If isRunning Then
            serverThread.Abort()
            server.Stop()
            isRunning = False
            Utils.UpdateTextBox(MainForm, MainForm.LogBox, "Server is stopped...")
            MainForm.RunServerButton.Text = "Start Server"
            MainForm.TestClientButton.Enabled = False
            MainForm.ServerStatusLabel.Text = "Server is stopped"
            MainForm.ServerStatusLabel.ForeColor = Color.IndianRed
            MainForm.CloseButton.Text = My.Resources.s_Exit
        End If
    End Sub

    ''' <summary>
    ''' Создание и запуск TCP слушателя
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StartListener()
        Try
            Dim settings = New Settings
            server = New TcpListener(IPAddress.Parse(settings.GetIp()), settings.GetPort())
            server.Start()
            ' Ожидание клиентов
            While True
                Dim client As TcpClient = server.AcceptTcpClient()
                Dim clientThread As New Thread(Sub() HandleClient(client))
                clientThread.Start()
            End While
        Catch e As SocketException
            Utils.UpdateTextBox(MainForm, MainForm.LogBox, "SocketException: " + e.Message)
        Finally
            server.Stop()
        End Try
    End Sub

    ''' <summary>
    ''' Хэндлер для обработки сообщений клиента
    ''' </summary>
    ''' <param name="client"></param>
    ''' <remarks></remarks>
    Private Sub HandleClient(client As TcpClient)
        Using stream As NetworkStream = client.GetStream()
            ' Обработка данных от клиента.
            Dim data As Byte() = New Byte(256) {}
            Dim bytesRead As Integer = stream.Read(data, 0, data.Length)
            Dim responseData As String = Encoding.UTF8.GetString(data, 0, bytesRead)
            ' Отправка данных клиенту.
            Dim message As Byte() = Encoding.UTF8.GetBytes("Hello from server")
            stream.Write(message, 0, message.Length)
            ' Закрытие соединения.
            client.Close()
        End Using
    End Sub

End Class
