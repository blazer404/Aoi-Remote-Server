Public Module Utils

    Private Delegate Sub UpdateRichTextBoxDelegate(ByVal form As Form, ByVal textBox As TextBox, ByVal text As String)
    Private Delegate Sub ClearRichTextBoxDelegate(ByVal form As Form, ByVal textBox As TextBox)

    ''' <summary>
    ''' Добавление строки в TextBox
    ''' </summary>
    ''' <param name="form"></param>
    ''' <param name="textBox"></param>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub UpdateTextBox(form As Form, textBox As TextBox, text As String)
        If textBox.InvokeRequired Then
            Dim handler As New UpdateRichTextBoxDelegate(AddressOf UpdateTextBox)
            form.Invoke(handler, textBox, text)
        Else
            textBox.AppendText(text & vbNewLine)
        End If
        textBox.SelectionStart = textBox.Text.Length
        textBox.ScrollToCaret()
    End Sub

    ''' <summary>
    ''' Очистка текста в TextBox
    ''' </summary>
    ''' <param name="form"></param>
    ''' <param name="textBox"></param>
    ''' <remarks></remarks>
    Public Sub ClearTextBox(form As Form, textBox As TextBox)
        If textBox.InvokeRequired Then
            Dim handler As New ClearRichTextBoxDelegate(AddressOf ClearTextBox)
            form.Invoke(handler, textBox, "")
        Else
            textBox.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' Генерируем ключ
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


End Module