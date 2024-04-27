Partial Public Class MainForm

    ''' <summary>
    ''' Нажатие на чекбокс использования IPv6
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Ipc6CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles Ipv6CheckBox.CheckedChanged
        Dim value_bak = IpInput.SelectedItem
        If Ipv6CheckBox.Checked = True Then
            Settings.UseIpv6 = True
        Else
            Settings.UseIpv6 = False
        End If
        Settings.GetIpList()
        IpInput.SelectedItem = value_bak
        If IpInput.SelectedItem Is Nothing Then
            IpInput.SelectedIndex = 0
        End If
    End Sub

    ''' <summary>
    ''' Валидируем поле порта при вводе
    ''' Только цифры и не длинее 5 символов
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PortInput_Input(sender As Object, e As KeyPressEventArgs) Handles PortInput.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        If Not Char.IsControl(e.KeyChar) AndAlso PortInput.Text.Length >= 5 Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Валидируем поле порта при вставке текста
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PortInput_TextChanged(sender As Object, e As EventArgs) Handles PortInput.TextChanged
        Dim newText As String = ""
        For Each character As Char In PortInput.Text
            If Char.IsDigit(character) Then
                newText += character
            End If
        Next
        PortInput.Text = newText
        PortInput.SelectionStart = PortInput.Text.Length
    End Sub

    ''' <summary>
    ''' Генерация случайного порта
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PortButton_Click(sender As Object, e As EventArgs) Handles PortButton.Click
        PortInput.Text = Utils.GeneratePort()
    End Sub

    ''' <summary>
    ''' Нажатие на кнопку генерации ключа доступа
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AuthTokenButton_Click(sender As Object, e As EventArgs) Handles AuthTokenButton.Click
        AuthTokenInput.Text = Utils.GenerateKey(8)
    End Sub

    ''' <summary>
    ''' Отображение вкладки отладки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShowDebugCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowDebugCheckBox.CheckedChanged
        Dim index As Integer = TabPanel.TabCount - 1
        If ShowDebugCheckBox.Checked = True Then
            TabPanel.TabPages.Insert(index, LogTab)
        Else
            TabPanel.TabPages.Remove(LogTab)
        End If
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

End Class
