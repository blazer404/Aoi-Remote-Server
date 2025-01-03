Imports AoiRemoteServer.Interfaces
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets


Public Class SocketServer

    Public Property Listener As IServerListener = Nothing
    Private Property Server As Socket = Nothing
    Private Property ServerThread As Thread = Nothing
    Public Property IsRunning As Boolean = False
    Public Property Ip As String = Nothing
    Public Property Port As String = Nothing
    Public Property Token As String = Nothing

    ''' <summary>
    ''' Запуск сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Start()
        Try
            Listener.OnUpdateLog(My.Resources.srv_OpenConnection)
            If Not IsRunning Then
                DestroyServerThread()
                ServerThread = New Thread(AddressOf CreateServer)
                ServerThread.Start()
            End If
        Catch ex As Exception
            Listener.OnUpdateLog(My.Resources.lbl_Exeption & ex.Message)
            Listener.OnCloseConnection()
        End Try
    End Sub

    ''' <summary>
    ''' Отключение сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()
        Try
            Listener.OnUpdateLog(My.Resources.srv_CloseConnection)
            If IsRunning Then
                DestroyServer()
                DestroyServerThread()
            End If
        Catch ex As Exception
            Listener.OnUpdateLog(My.Resources.lbl_Exeption & ex.Message)
        Finally
            Listener.OnCloseConnection()
        End Try
    End Sub

    ''' <summary>
    ''' Создание сервера
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateServer()
        Try
            Listener.OnUpdateLog(My.Resources.srv_Create)
            DestroyServer()
            Dim parsedIp As IPAddress = IPAddress.Parse(Ip)
            Dim endpoint As New IPEndPoint(parsedIp, Port)
            Listener.OnUpdateLog(My.Resources.lbl_Endpoint & endpoint.ToString)
            Server = New Socket(parsedIp.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            Server.Bind(endpoint)
            Server.Listen(10)
            Listener.OnOpenConnection()
            While IsRunning And Server IsNot Nothing
                Dim client As Socket = Server.Accept()
                Task.Run(Sub() ProcessRequest(client))
            End While
        Catch ex As SocketException
            If ex.ErrorCode <> 10004 Then
                Listener.OnUpdateLog(My.Resources.lbl_Exeption & ex.Message)
                Listener.OnCloseConnection()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Уничтожение сервера
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DestroyServer()
        If Server IsNot Nothing Then
            Server.Close()
            Server.Dispose()
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
    ''' Уничтожение подключения клиента
    ''' </summary>
    ''' <param name="client"></param>
    Private Sub DestroyClient(client As Socket)
        If client.Connected Then
            client.Shutdown(SocketShutdown.Both)
            client.Close()
        End If
    End Sub

    ''' <summary>
    ''' Обработка запроса от клиента
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcessRequest(client As Socket)
        Try
            client.ReceiveTimeout = 5000
            Dim params As Dictionary(Of String, Object) = ParseRequest(client)
            If params Is Nothing Then
                Exit Sub
            End If
            If IsValidClient(client, params) = False Then
                DestroyClient(client)
                Exit Sub
            End If
            Dim target As String = params("T").ToString()
            Dim command As Integer = Convert.ToInt32(params("C"))
            Listener.OnCommandReceived(target, command)
            SendResponse(client, Json.CreateResponse(True, 200, My.Resources.req_Ok))
        Catch ex As SocketException
            SendResponse(client, Json.CreateResponse(False, 500, My.Resources.req_500Timeout))
        Catch ex As Exception
            SendResponse(client, Json.CreateResponse(False, 500, My.Resources.req_500Internal))
        End Try
    End Sub

    ''' <summary>
    ''' Парсим запрос
    ''' </summary>
    ''' <param name="client"></param>
    ''' <returns></returns>
    Private Function ParseRequest(client As Socket)
        Dim bytes As Byte() = New Byte(1023) {}
        Dim bytesRec As Integer = client.Receive(bytes)
        Dim data As String = ExtractRequestBody(Encoding.UTF8.GetString(bytes, 0, bytesRec).ToString)
        Listener.OnUpdateLog(My.Resources.lbl_Request & data)
        If String.IsNullOrWhiteSpace(data) Then
            SendResponse(client, Json.CreateResponse(False, 422, My.Resources.req_422EmptyBody))
            Return Nothing
        End If
        Return ExtractRequestParams(data)
    End Function

    ''' <summary>
    ''' Извлекаем тело запроса
    ''' </summary>
    ''' <param name="request"></param>
    ''' <returns></returns>
    Private Function ExtractRequestBody(request As String) As String
        Dim lines() As String = request.Split(New String() {vbCrLf}, StringSplitOptions.None)
        For i As Integer = lines.Length - 1 To 0 Step -1
            If Not String.IsNullOrWhiteSpace(lines(i)) Then
                Return lines(i).Trim()
            End If
        Next
        Return ""
    End Function

    ''' <summary>
    ''' извлекаем параметры из тела запроса
    ''' </summary>
    ''' <param name="requestBody"></param>
    ''' <returns></returns>
    Private Function ExtractRequestParams(requestBody As String)
        Dim lines() As String = requestBody.Split("&")
        Dim params As New Dictionary(Of String, Object)()
        For Each line As String In lines
            If line.Trim() <> "" Then
                Dim linePair = line.Split("=")
                params.Add(linePair(0).Trim().ToUpper, linePair(1).Trim())
            End If
        Next
        Return params
    End Function

    ''' <summary>
    ''' Валидация клиента
    ''' </summary>
    ''' <param name="params"></param>
    ''' <returns></returns>
    Private Function IsValidClient(client As Socket, params As Dictionary(Of String, Object))
        Dim authToken As String = If(params.ContainsKey("P"), params("P"), Nothing)
        If authToken Is Nothing Then
            SendResponse(client, Json.CreateResponse(False, 401, My.Resources.req_401Unauthorized))
            Return False
        End If
        If authToken <> Token Then
            SendResponse(client, Json.CreateResponse(False, 401, My.Resources.req_401Unauthorized))
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Отправка ответа клиенту
    ''' </summary>
    ''' <param name="client"></param>
    ''' <param name="message"></param>
    Private Sub SendResponse(client As Socket, message As String)
        Task.Run(
            Sub()
                Dim response As String = ""
                response &= "HTTP/1.1 200 OK" & vbCrLf
                response &= "Content-Type: application/json; charset=utf-8" & vbCrLf
                response &= "Content-Length: " & message.Length & vbCrLf & vbCrLf
                response &= message
                Dim responseBytes As Byte() = Encoding.UTF8.GetBytes(response)
                client.Send(responseBytes)
                Task.Delay(300)
                DestroyClient(client)
            End Sub
            )
    End Sub

End Class
