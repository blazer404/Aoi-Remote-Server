Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading


Public Class TCPServer

    Public isRunning As Boolean = False
    Private server As TcpListener = Nothing
    Private serverThread As Thread

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
        End If
    End Sub

    ''' <summary>
    ''' Создание и запуск TCP слушателя
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StartListener()
        Try
            server = New TcpListener(IPAddress.Parse(Settings.GetIp), Settings.GetPort)
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
            Utils.UpdateTextBox(MainForm, MainForm.LogBox, "Received: " + responseData)
            ' Отправка данных клиенту.
            Dim msg As Byte() = Encoding.UTF8.GetBytes("Hello from server")
            stream.Write(msg, 0, msg.Length)
            ' Закрытие соединения.
            client.Close()
        End Using
    End Sub

    ''' <summary>
    ''' Остановка сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseConnection()
        If isRunning Then
            server.Stop()
            isRunning = False
            Utils.UpdateTextBox(MainForm, MainForm.LogBox, "Server is stopped...")
        End If
    End Sub

End Class
