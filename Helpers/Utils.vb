Public Class Utils

    ''' <summary>
    ''' Добавление строки в TextBox
    ''' </summary>
    ''' <param name="textBox"></param>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateTextBox(textBox As TextBox, text As String)
        If textBox.Lines.Length > 1000 Then
            textBox.Text = textBox.Text.Substring(textBox.Text.IndexOf(vbNewLine) + 1)
        End If
        Dim time = DateTime.Now.ToString("HH:mm:ss")
        textBox.AppendText("<" & time & "> " & text & vbNewLine)
    End Sub

    ''' <summary>
    ''' Очистка текста в TextBox
    ''' </summary>
    ''' <param name="textBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub ClearTextBox(textBox As TextBox)
        textBox.Text = ""
    End Sub

    ''' <summary>
    ''' Генерируем ключ по алфавиту
    ''' </summary>
    ''' <param name="maxLenght"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GenerateKey(maxLenght As Integer)
        Dim chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim random As New Random()
        Dim key As String = ""
        For i As Integer = 1 To maxLenght
            Dim index As Integer = random.Next(0, chars.Length)
            key &= chars(index)
        Next
        Return key
    End Function

    ''' <summary>
    ''' Генерируем случайный порт в диапазоне от 10000 до 65535
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GeneratePort()
        Return (New Random).Next(1024, 65535)
    End Function

End Class