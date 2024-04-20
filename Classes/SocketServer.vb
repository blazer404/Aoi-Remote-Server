Imports TSRC.Interfaces
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets


Public Class SocketServer

    Private Property Server As Socket = Nothing
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
        Try
            Listener.OnUpdateLog("Create server")
            DestroyServer()
            If IsValidAddress() = False Then
                Listener.OnCloseConnection()
                Exit Sub
            End If
            Dim parsedIp As IPAddress = IPAddress.Parse(Ip)
            Dim endpoint As New IPEndPoint(parsedIp, Port)
            Listener.OnUpdateLog("Endpoint: " & endpoint.ToString)
            Server = New Socket(parsedIp.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            Server.Bind(endpoint)
            Server.Listen(10)
            Listener.OnOpenConnection()
            While IsRunning And Server IsNot Nothing
                Dim client As Socket = Server.Accept()
                Task.Run(Function() ProcessRequest(client))
            End While
        Catch ex As SocketException
            If ex.ErrorCode <> 10004 Then
                Listener.OnUpdateLog("☻ Exception: " & ex.Message)
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
    ''' Проверка валидности сокета
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidAddress()
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
    Private Async Function ProcessRequest(client As Socket) As Task
        Try
            Dim params As Dictionary(Of String, Object) = ParseRequest(client)
            If Await IsValidClient(client, params) = False Then
                Exit Function
            End If
            Dim target As String = params("T").ToString()
            Dim command As Integer = Convert.ToInt32(params("C"))
            Listener.OnCommandReceived(target, command)
            Await SetResponse(client, JsonResponse(True, 200, "OK"))
        Catch ex As Exception
            Dim unused = SetResponse(client, JsonResponse(True, 500, ex.Message))
        End Try
    End Function

    ''' <summary>
    ''' Парсим запрос
    ''' </summary>
    ''' <param name="client"></param>
    ''' <returns></returns>
    Private Function ParseRequest(client As Socket)
        Dim bytes As Byte() = New Byte(1023) {}
        Dim bytesRec As Integer = client.Receive(bytes)
        Dim data As String = Encoding.UTF8.GetString(bytes, 0, bytesRec).ToString
        Listener.OnUpdateLog("vbNewLine" & data)
        Dim lines() As String = data.Split("&")
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
    Private Async Function IsValidClient(client As Socket, params As Dictionary(Of String, Object)) As Task(Of Boolean)
        Dim authToken As String = If(params.ContainsKey("P"), params("P"), Nothing)
        If authToken Is Nothing Then
            Await SetResponse(client, JsonResponse(False, 401, "Unauthorized"))
            Listener.OnUpdateLog(JsonResponse(False, 401, "Unauthorized 1"))
            Return False
        End If
        If authToken <> Token Then
            Await SetResponse(client, JsonResponse(False, 401, "Unauthorized"))
            Listener.OnUpdateLog(JsonResponse(False, 401, "Unauthorized 2"))
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Отправка ответа клиенту
    ''' </summary>
    ''' <param name="client"></param>
    ''' <param name="message"></param>
    Private Async Function SetResponse(client As Socket, ByVal message As String) As Task
        Dim response As Byte() = Encoding.UTF8.GetBytes(message)
        client.Send(response)
        Await Task.Delay(2000)
        client.Shutdown(SocketShutdown.Both)
        client.Close()
    End Function

End Class
