Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class MainForm

    Private TCPServer As TCPServer

    ''' <summary>
    ''' Загрузка программы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Application.ProductName + " v." + Application.ProductVersion
        TCPServer = New TCPServer()
    End Sub

    ''' <summary>
    ''' Закрытие программы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TCPServer.CloseConnection()
    End Sub

    ''' <summary>
    ''' Нажатие на кнопку сервера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ServerBtn_Click(sender As Object, e As EventArgs) Handles ServerBtn.Click
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
    Private Sub ClientBtn_Click(sender As Object, e As EventArgs) Handles ClientBtn.Click
        Try
            ' Подключение к серверу.
            Dim client As TcpClient = New TcpClient(Settings.GetIp, Settings.GetPort)
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
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles LogBtn.Click
        Utils.ClearTextBox(Me, Me.LogBox)
    End Sub

End Class
