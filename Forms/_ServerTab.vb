Partial Public Class MainForm

    ''' <summary>
    ''' Нажатие на чекбокс использования IPv6
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Ipc6CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles Ipv6CheckBox.CheckedChanged
        If Ipv6CheckBox.Checked = True Then
            Settings.UseIpv6 = True
        Else
            Settings.UseIpv6 = False
        End If
        Dim selectedItem = IpInput.SelectedItem
        Settings.GetIpList()
        IpInput.SelectedItem = selectedItem
        If IpInput.SelectedItem Is Nothing Then
            IpInput.SelectedIndex = 0
        End If
    End Sub

    ''' <summary>
    ''' Валидируем поле порта при изменении текста
    ''' Только цифры и не длинее 5 символов
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PortInput_TextChanged(sender As Object, e As EventArgs) Handles PortInput.TextChanged
        Dim currentText As String = PortInput.Text
        Dim newText As String = ""
        For Each character As Char In currentText
            If Char.IsDigit(character) Then
                newText += character
            End If
        Next
        If newText.Length >= 5 AndAlso CInt(newText) > 65535 Then
            newText = newText.Substring(0, 4)
        End If
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


End Class
