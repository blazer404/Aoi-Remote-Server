Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading


Public Class TCPServer

    Public isRunning As Boolean = False

    Private Server As TcpListener = Nothing
    Private ServerThread As Thread = Nothing
    Private Client As TcpClient = Nothing
    Private Listener As OnReceiveDataListener = Nothing

    ''' <summary>
    ''' Интерфейс для отловки сообщений
    ''' </summary>
    ''' <remarks></remarks>
    Interface OnReceiveDataListener
        Sub UpdateLog(ByVal data As String)
        Sub OnDataReceived(ByVal data As String)
    End Interface

    ''' <summary>
    ''' Установка слушателя для получения сообщений
    ''' </summary>
    ''' <param name="listenerObject"></param>
    ''' <remarks></remarks>
    Public Sub SetListener(ByVal listenerObject As Object)
        Listener = listenerObject
    End Sub

    ''' <summary>
    ''' Запуск сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenConnection()
        Try
            If Not isRunning Then
                DestroyServerThread()
                ServerThread = New Thread(AddressOf CreateServer)
                ServerThread.Start()
                isRunning = True
                Listener.UpdateLog("Server is running")
                MainForm.RunServerButton.Text = "Stop Server"
                MainForm.ServerStatusLabel.Text = "Server is running"
                MainForm.ServerStatusLabel.ForeColor = Color.Green
                MainForm.CloseButton.Text = My.Resources.s_Hide
            End If
        Catch ex As Exception
            Listener.UpdateLog("OpenConnection Exception: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Отключение сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseConnection()
        Try
            If isRunning Then
                DestroyServer()
                DestroyClient()
                DestroyServerThread()
                isRunning = False
                Listener.UpdateLog("Server is stopped")
                MainForm.RunServerButton.Text = "Start Server"
                MainForm.ServerStatusLabel.Text = "Server is stopped"
                MainForm.ServerStatusLabel.ForeColor = Color.IndianRed
                MainForm.CloseButton.Text = My.Resources.s_Exit
            End If
        Catch ex As Exception
            Listener.UpdateLog("CloseConnection exception: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Создание сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateServer()
        Try
            Dim settings As New Settings
            Dim ip As IPAddress = IPAddress.Parse(settings.GetIp())
            Dim port As Integer = Integer.Parse(settings.GetPort())
            Server = New TcpListener(ip, port)
            Server.Start()
            While True
                If Server Is Nothing Then
                    Exit While
                End If
                Client = Server.AcceptTcpClient()
                ProcessClient(Client)
            End While
        Catch ex As Exception
            'Listener.UpdateLog("CreateServer exception: " & ex.Message)
            'Listener.UpdateLog("CreateServer exception: " & ex.StackTrace)
        Finally
            DestroyServer()
        End Try
    End Sub

    ''' <summary>
    ''' Чтение полученных данных от клиента
    ''' </summary>
    ''' <param name="client"></param>
    ''' <remarks></remarks>
    Private Sub ProcessClient(client As TcpClient)
        Listener.UpdateLog("Client connected")
        Console.Beep()
        Dim bytes(1024) As Byte
        Dim data As String = Nothing
        Dim stream As NetworkStream = client.GetStream()
        Dim i As Integer = stream.Read(bytes, 0, bytes.Length)
        While i <> 0
            data = System.Text.Encoding.UTF8.GetString(bytes, 0, i)
            Listener.UpdateLog("Received: " & data.ToString())
            'todo обработать действия от клиента
            i = stream.Read(bytes, 0, bytes.Length)
        End While
        DestroyClient()
    End Sub

    ''' <summary>
    ''' Уничтожение сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DestroyServer()
        If Server IsNot Nothing Then
            Server.Stop()
            Server = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Уничтожение потока сервера
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DestroyServerThread()
        If ServerThread IsNot Nothing Then
            ServerThread.Abort()
            ServerThread = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Уничтожение клиента
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DestroyClient()
        If Client IsNot Nothing Then
            Client.Close()
            Client = Nothing
        End If
    End Sub

End Class
