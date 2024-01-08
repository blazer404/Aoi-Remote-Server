Public Module Utils

    ''' <summary>
    ''' Добавление строки в TextBox
    ''' </summary>
    ''' <param name="textBox"></param>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub UpdateTextBox(textBox As TextBox, text As String)
        textBox.AppendText(text & vbNewLine)
    End Sub

    ''' <summary>
    ''' Очистка текста в TextBox
    ''' </summary>
    ''' <param name="textBox"></param>
    ''' <remarks></remarks>
    Public Sub ClearTextBox(textBox As TextBox)
        textBox.Text = ""
    End Sub


    ''' <summary>
    ''' Генерируем ключ по алфавиту
    ''' </summary>
    ''' <param name="maxLenght"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GenerateKey(maxLenght As Integer)
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
    Public Function GeneratePort()
        Dim random As New Random
        Return random.Next(10000, 65535)
    End Function

End Module