Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading


Public Class TCPServer

    Public isRunning As Boolean = False

    Private Server As TcpListener = Nothing
    Private ServerThread As Thread = Nothing
    Private Client As TcpClient = Nothing
    Private ClientStream As NetworkStream = Nothing
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
        Sub OnUpdateLog(ByVal data As String)
        Sub OnShowError(ByVal data As String)
        Sub OnCommandReceived(ByVal playerName As String, ByVal command As String)
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
                ProcessClient()
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
    ''' <remarks></remarks>
    Private Sub ProcessClient()
        Try
            Listener.OnClientConnected()
            Dim bytes(1024) As Byte
            Dim data As String = Nothing
            ClientStream = Client.GetStream()
            Dim i As Integer = ClientStream.Read(bytes, 0, bytes.Length)
            While i <> 0
                data = Encoding.UTF8.GetString(bytes, 0, i)
                ClientRequestHandler(data.ToString)
                i = ClientStream.Read(bytes, 0, bytes.Length)
            End While
            DestroyClient()
            Listener.OnClientDisconnected()
        Catch ex As Exception
            DestroyClient()
            Listener.OnClientDisconnected()
        End Try
    End Sub

    ''' <summary>
    ''' Отправка сообщения клиенту
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub SendMessage(ByVal text)
        If isRunning Then
            Dim data As [Byte]() = Encoding.UTF8.GetBytes(text)
            ClientStream.Write(data, 0, data.Length)
        End If
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


    ''' <summary>
    ''' Обработка запроса от клиента с последующей отправкой команды проигрывателю
    ''' </summary>
    ''' <param name="request"></param>
    ''' <remarks>
    ''' Пример валидного запроса: "N=[player_name];C=[command];P=[access_key]" (необязательно в этом порядке)
    ''' </remarks>
    Private Sub ClientRequestHandler(ByVal request As String)
        Listener.OnUpdateLog("Received: " & request)
        request = request.Replace(" ", "")
        Dim pairsArr As String() = request.Split(";")
        Dim result As New Dictionary(Of String, String)()
        For Each pair As String In pairsArr
            Dim item() As String = pair.Split("=")
            If item.Length = 2 Then
                result(item(0)) = item(1)
            End If
        Next
        Dim playerName As String = result("N")
        Dim command As String = result("C")
        Dim accessKey As String = result("P")
        If IsValidAccessKey(accessKey) <> True OrElse IsValidCommand(playerName, command) <> True Then
            Listener.OnUpdateLog("Invalid client. Connection rejected")
            Exit Sub
        End If
        Listener.OnCommandReceived(playerName, command)
        SendMessage(Utils.JsonResponse(True, 200, "OK"))
    End Sub

    ''' <summary>
    ''' Валидация пароля
    ''' </summary>
    ''' <param name="accessKey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidAccessKey(accessKey)
        If accessKey <> My.Settings.AccessKey Then
            SendMessage(Utils.JsonResponse(False, 403, "Wrong password"))
            DestroyClient()
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Валидация команды проигрывателя
    ''' </summary>
    ''' <param name="playerName"></param>
    ''' <param name="command"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidCommand(ByVal playerName As String, ByVal command As String)
        If Not MediaPlayer.APP_COMMANDS.ContainsKey(playerName) Or Not MediaPlayer.APP_COMMANDS(playerName).Contains(command) Then
            SendMessage(Utils.JsonResponse(False, 404, "Wrong command"))
            DestroyClient()
            Return False
        End If
        Return True
    End Function

End Class
