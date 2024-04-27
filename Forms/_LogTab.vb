Partial Public Class MainForm

    ''' <summary>
    ''' Нажатие на кнопку лога
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ClearLogButton_Click(sender As Object, e As EventArgs) Handles ClearLogButton.Click
        Utils.ClearTextBox(LogBox)
    End Sub

End Class
