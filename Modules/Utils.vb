Public Module Utils

    Private Delegate Sub UpdateRichTextBoxDelegate(ByVal form As Form, ByVal richTextBox As RichTextBox, ByVal text As String)
    Private Delegate Sub ClearRichTextBoxDelegate(ByVal form As Form, ByVal richTextBox As RichTextBox)

    ''' <summary>
    ''' Добавление строки в TextBox
    ''' </summary>
    ''' <param name="form"></param>
    ''' <param name="richTextBox"></param>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub UpdateTextBox(form As Form, richTextBox As RichTextBox, text As String)
        If richTextBox.InvokeRequired Then
            Dim handler As New UpdateRichTextBoxDelegate(AddressOf UpdateTextBox)
            form.Invoke(handler, richTextBox, text)
        Else
            richTextBox.AppendText(text & vbNewLine)
        End If
        richTextBox.SelectionStart = richTextBox.Text.Length
        richTextBox.ScrollToCaret()
    End Sub

    ''' <summary>
    ''' Очистка текста в TextBox
    ''' </summary>
    ''' <param name="form"></param>
    ''' <param name="richTextBox"></param>
    ''' <remarks></remarks>
    Public Sub ClearTextBox(form As Form, richTextBox As RichTextBox)
        If richTextBox.InvokeRequired Then
            Dim handler As New ClearRichTextBoxDelegate(AddressOf ClearTextBox)
            form.Invoke(handler, richTextBox, "")
        Else
            richTextBox.Text = ""
        End If
    End Sub

End Module