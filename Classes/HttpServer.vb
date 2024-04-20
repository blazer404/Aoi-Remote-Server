Imports TSRC.Interfaces
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Text.RegularExpressions


Public Class HttpServer

    Private Property Server As HttpListener = Nothing
    Private Property ServerThread As Thread = Nothing
    Public Property IsRunning As Boolean = False
    Public Property Ip As String = Nothing
    Public Property Port As String = Nothing
    Public Property Token As String = Nothing
    Public Property Listener As IMessageListener = Nothing


    ''' <summary>
    ''' Запуск сервера
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Start()
        Try
            Listener.OnUpdateLog("Open connection")
            If Not IsRunning Then
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
    Public Sub Close()
        Try
            Listener.OnUpdateLog("Close connection")
            If IsRunning Then
                DestroyServer()
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
    Private Sub CreateServer()
        Listener.OnUpdateLog("Create server")
        DestroyServer()
        If IsValidSocket() = False Then
            Listener.OnCloseConnection()
            Exit Sub
        End If
        Ip = If(Ip = "0.0.0.0", "*", Ip)
        Dim endpoint As String = "http://" & Ip & ":" & Port & "/"
        Listener.OnUpdateLog("Endpoint: " & endpoint)
        Server = New HttpListener
        Server.Prefixes.Add(endpoint)
        Server.Start()
        Listener.OnOpenConnection()
        While IsRunning And Server IsNot Nothing
            Dim context As HttpListenerContext = Server.GetContext()
                Task.Run(Function() ProcessRequest(context))
        End While
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
    ''' Проверка валидности сокета
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidSocket()
        Dim err As String
        If Ip = "" Then
            err = "IP address is empty"
            Listener.OnUpdateLog(err)
            Listener.OnShowError(err)
            Return False
        End If
        If Port = "" Or Port = 0 Then
            err = "Port is empty or invalid"
            Listener.OnUpdateLog(err)
            Listener.OnShowError(err)
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Обработка запроса от клиента
    ''' </summary>
    ''' <remarks></remarks>
    Private Async Function ProcessRequest(context) As Task
        Try
            If Await IsValidClient(context) = False Then
                Exit Function
            End If
            Dim request = JsonParse(Await GetRequest(context))
            Dim player As String = request("player").ToString()
            Dim command As Integer = Convert.ToInt32(request("command"))
            Listener.OnCommandReceived(player, command)
            Await SetResponse(context, JsonResponse(True, 200, "OK"))
        Catch ex As Exception
            Dim unused = SetResponse(context, JsonResponse(True, 500, ex.Message))
        End Try
    End Function

    ''' <summary>
    ''' Валидация клиента
    ''' </summary>
    ''' <param name="context"></param>
    ''' <returns></returns>
    Private Async Function IsValidClient(context As HttpListenerContext) As Task(Of Boolean)
        Dim request As HttpListenerRequest = context.Request
        Dim authHeader As String = request.Headers("Authorization")
        If String.IsNullOrEmpty(authHeader) OrElse Not authHeader.StartsWith("Bearer ") Then
            Await SetResponse(context, JsonResponse(False, 401, "Unauthorized"))
            Return False
        End If
        Dim authToken As String = authHeader.Substring(7)
        If authToken <> Token Then
            Await SetResponse(context, JsonResponse(False, 401, "Unauthorized"))
            Return False
        End If
        If request.HttpMethod.ToLower <> "post" Then
            Await SetResponse(context, JsonResponse(False, 405, "Method not allowed"))
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Чтение сообщения запроса
    ''' </summary>
    ''' <returns></returns>
    Private Async Function GetRequest(context As HttpListenerContext) As Task(Of String)
        Dim request As HttpListenerRequest = context.Request
        Dim reader As New StreamReader(request.InputStream)
        Dim body As String = Await reader.ReadToEndAsync()
        body = body.Replace(vbLf, "")
        body = Regex.Replace(body, "\s+", " ")
        Listener.OnUpdateLog("Request: " & body)
        Return body
    End Function

    ''' <summary>
    ''' Отправка ответа клиенту
    ''' </summary>
    ''' <param name="context"></param>
    ''' <param name="message"></param>
    Private Async Function SetResponse(context As HttpListenerContext, ByVal message As String) As Task
        Dim buffer As Byte() = Encoding.UTF8.GetBytes(message)
        Dim response As HttpListenerResponse = context.Response
        response.ContentType = "application/json"
        response.ContentLength64 = buffer.Length
        response.AddHeader("Access-Control-Allow-Origin", "*")
        response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS")
        response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization")
        Await response.OutputStream.WriteAsync(buffer, 0, buffer.Length)
        response.OutputStream.Close()
        response.Close()
    End Function

End Class
