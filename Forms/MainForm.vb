Imports System.Net.Sockets
Imports System.Text


Public Class MainForm

    Private TCPServer As TCPServer
    Private Settings As Settings

    ''' <summary>
    ''' Загрузка программы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TODO remove this lines
        AutorunAppCheckbot.Enabled = False
        AimpButton.Enabled = False
        MpcButton.Enabled = False
        ' END TODO

        My.Settings.Upgrade()
        Settings = New Settings
        Settings.Load()
        TCPServer = New TCPServer
        If My.Settings.AutorunTcpServer Then
            TCPServer.OpenConnection()
        End If
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
    ''' Нажатие на кнопку закрытия
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Сохранение и перезапуск сервера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        TCPServer.CloseConnection()
        Settings.Save()
        TCPServer.OpenConnection()
    End Sub


    ''' <summary>
    ''' Нажатие на чекбокс использования IPv6
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Ipc6CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles Ipv6CheckBox.CheckedChanged
        Dim value_bak = IpInput.SelectedItem
        If Ipv6CheckBox.Checked = True Then
            Settings.use_ip_v6 = True
        Else
            Settings.use_ip_v6 = False
        End If
        Settings.GetIpList()
        IpInput.SelectedItem = value_bak
        If IpInput.SelectedItem Is Nothing Then
            IpInput.SelectedIndex = 0
        End If
    End Sub

    ''' <summary>
    ''' Валидируем поля ввода порта
    ''' Только цифры и не длинее 5 символов
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PortInput_Input(sender As Object, e As KeyPressEventArgs) Handles PortInput.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        If Not Char.IsControl(e.KeyChar) And PortInput.Text.Length >= 5 Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Генерация случайного порта
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub portButton_Click(sender As Object, e As EventArgs) Handles PortButton.Click
        Dim random As New Random
        PortInput.Text = random.Next(10000, 65535)
    End Sub

    ''' <summary>
    ''' Нажатие на кнопку генерации ключа доступа
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AccessKeyButton_Click(sender As Object, e As EventArgs) Handles AccessKeyButton.Click
        AccessKeyInput.Text = Utils.GenerateKey(8)
    End Sub

    ''' <summary>
    ''' Переход на GitHub приложения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GitHubLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GitHubLink.LinkClicked
        Process.Start(My.Settings.GitHubUrl)
    End Sub


    ''' <summary>
    ''' Нажатие на кнопку запуска/остановки сервера
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ServerBtn_Click(sender As Object, e As EventArgs) Handles ServerButtom.Click
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
    Private Sub ClientBtn_Click(sender As Object, e As EventArgs) Handles ClientButton.Click
        Try
            ' Подключение к серверу.
            Dim ip = Settings.GetIp()
            Dim port = Settings.GetPort()
            If ip = "" Or ip = "0.0.0.0" Then
                ip = "127.0.0.1"
            End If
            Dim client As TcpClient = New TcpClient(ip, port)
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
    Private Sub ClearLogButton_Click(sender As Object, e As EventArgs) Handles ClearLogButton.Click
        Utils.ClearTextBox(Me, Me.LogBox)
    End Sub


    ''' <summary>
    ''' Клик ЛКМ по иконке в трее
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TrayIcon_MouseClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.WindowState = FormWindowState.Normal Then
                Me.WindowState = FormWindowState.Minimized
            Else
                Me.WindowState = FormWindowState.Normal
            End If
        End If
    End Sub

    ''' <summary>
    ''' Показ приложения через меню трея
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TrayMenuShowApp_Click(sender As Object, e As EventArgs) Handles TrayMenuShowApp.Click
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        Me.BringToFront()
        Me.Focus()
    End Sub

    ''' <summary>
    ''' Выход из приложения через меню трея
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TrayMenuExit_Click(sender As Object, e As EventArgs) Handles TrayMenuExit.Click
        Application.Exit()
    End Sub

End Class
