Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading


Public Class TCPServer

    Public isRunning As Boolean = False

    Private Server As TcpListener = Nothing
    Private ServerThread As Thread = Nothing
    Private Client As TcpClient = Nothing
    Private Listener As DataListener = Nothing

    ''' <summary>
    ''' Интерфейс для отловки сообщений
    ''' </summary>
    ''' <remarks></remarks>
    Interface DataListener
        Sub OnCloseConnection()
        Sub OnOpenConnection()
        Sub OnClientConnected()
        Sub OnClientDisconnected()
        Sub OnDataReceived(ByVal data As String)
        Sub OnUpdateLog(ByVal data As String)
        Sub OnShowError(ByVal data As String)
    End Interface

    ''' <summary>
    ''' Установка слушателя для получения сообщений
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub SetListener(ByVal obj As Object)
        Listener = obj
    End Sub

    ''' <summary>
    ''' Запуск сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenConnection()
        Try
            Listener.OnUpdateLog("Open connection")
            If Not isRunning Then
                DestroyServerThread()
                ServerThread = New Thread(AddressOf CreateServer)
                ServerThread.Start()
            End If
        Catch ex As Exception
            Listener.OnUpdateLog("☻ Exception: " & ex.Message)
            Listener.OnCloseConnection()
        End Try
    End Sub

    ''' <summary>
    ''' Отключение сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseConnection()
        Try
            Listener.OnUpdateLog("Close connection")
            If isRunning Then
                DestroyServer()
                DestroyClient()
                DestroyServerThread()
            End If
        Catch ex As Exception
            Listener.OnUpdateLog("☻ Exception: " & ex.Message)
        Finally
            Listener.OnCloseConnection()
        End Try
    End Sub

    ''' <summary>
    ''' Создание сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateServer()
        Try
            Listener.OnUpdateLog("Create server")
            DestroyServer()
            Dim settings As New Settings
            Dim ip = settings.GetIp()
            Dim port = settings.GetPort()
            If ValidateSocket(ip, port) = False Then
                Listener.OnCloseConnection()
                Exit Sub
            End If
            Listener.OnUpdateLog("Using socket " & ip & ":" & port)
            Server = New TcpListener(IPAddress.Parse(ip), Integer.Parse(port))
            Server.Start()
            Listener.OnOpenConnection()
            While True
                If Server Is Nothing Then
                    Exit While
                End If
                Client = Server.AcceptTcpClient()
                ProcessClient(Client)
            End While
        Catch ex As SocketException
            If ex.ErrorCode = 10048 Then
                Dim err As String = "Port is busy"
                Listener.OnUpdateLog(err)
                Listener.OnShowError(err)
            Else
                Listener.OnUpdateLog("☻ Exception: " & ex.Message)
            End If
            Listener.OnCloseConnection()
        End Try
    End Sub

    ''' <summary>
    ''' Чтение полученных данных от клиента и последующая обработка
    ''' </summary>
    ''' <param name="client"></param>
    ''' <remarks></remarks>
    Private Sub ProcessClient(client As TcpClient)
        Listener.OnClientConnected()
        Dim bytes(1024) As Byte
        Dim data As String = Nothing
        Dim stream As NetworkStream = client.GetStream()
        Dim i As Integer = stream.Read(bytes, 0, bytes.Length)
        While i <> 0
            data = Encoding.UTF8.GetString(bytes, 0, i)
            Listener.OnUpdateLog("Received: " & data.ToString())
            'todo обработать действия от клиента
            i = stream.Read(bytes, 0, bytes.Length)
        End While
        DestroyClient()
        Listener.OnClientDisconnected()
    End Sub

    ''' <summary>
    ''' Уничтожение сервера
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DestroyServer()
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

    ''' <summary>
    ''' Проверяем сокет на пустоту
    ''' </summary>
    ''' <param name="ip"></param>
    ''' <param name="port"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValidateSocket(ByVal ip As String, ByVal port As String)
        Dim err As String
        If ip = "" Then
            err = "IP address is empty"
            Listener.OnUpdateLog(err)
            Listener.OnShowError(err)
            Return False
        End If
        If port = "" Or port = 0 Then
            err = "Port is empty or invalid"
            Listener.OnUpdateLog(err)
            Listener.OnShowError(err)
            Return False
        End If
        Return True
    End Function

End Class
