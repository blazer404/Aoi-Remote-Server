Imports System.Net.Sockets
Imports System.Text


Public Class TestClientForm

    Dim Settings As Settings
    Dim Ip As String
    Dim Port As String


    ''' <summary>
    ''' Загрузка формы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TestClientForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings = New Settings

        ' Настройки подключения к серверу
        Ip = Settings.GetIp
        Port = Settings.GetPort
        If Ip = "" Or Ip = "0.0.0.0" Then
            Ip = "127.0.0.1"
        End If
    End Sub

    Private Sub TestClientForm_Closing(sender As Object, e As EventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub SenHelloButton_Click(sender As Object, e As EventArgs) Handles SenHelloButton.Click
        Try
            ' Подключение к серверу
            Dim client As TcpClient = New TcpClient(Ip, Port)
            Dim stream As NetworkStream = client.GetStream()
            ' Отправка данных серверу
            Dim message As String = "Hello from client"
            Dim data As Byte() = Encoding.UTF8.GetBytes(message)
            stream.Write(data, 0, data.Length)
            Utils.UpdateDebugLog("Sent: " + message)
            ' Получение ответа от сервера
            data = New Byte(256) {}
            Dim bytes As Integer = stream.Read(data, 0, data.Length)
            Dim responseData As String = Encoding.UTF8.GetString(data, 0, bytes)
            Utils.UpdateDebugLog("Received: " + responseData)
            client.Close()
        Catch ex As Exception
            Utils.UpdateDebugLog("Exception: " + ex.Message)
        End Try
    End Sub

End Class