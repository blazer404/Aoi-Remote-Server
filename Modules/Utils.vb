Public Module Utils

    Private Delegate Sub UpdateTextBoxDelegate(ByVal form As Form, ByVal textBox As TextBox, ByVal text As String)
    Private Delegate Sub ClearTextBoxDelegate(ByVal form As Form, ByVal textBox As TextBox)

    ''' <summary>
    ''' Добавление строки в TextBox
    ''' </summary>
    ''' <param name="form"></param>
    ''' <param name="textBox"></param>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub UpdateTextBox(form As Form, textBox As TextBox, text As String)
        If textBox.InvokeRequired Then
            Dim handler As New UpdateTextBoxDelegate(AddressOf UpdateTextBox)
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
            Dim handler As New ClearTextBoxDelegate(AddressOf ClearTextBox)
            form.Invoke(handler, textBox, "")
        Else
            textBox.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' Обновление лога
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub UpdateDebugLog(text As String)
        UpdateTextBox(MainForm, MainForm.LogBox, text)
    End Sub

    ''' <summary>
    ''' Очистка лога
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearDebugLog()
        ClearTextBox(MainForm, MainForm.LogBox)
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