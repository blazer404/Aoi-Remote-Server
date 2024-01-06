Partial Public Class MainForm

    ''' <summary>
    ''' Показываем диалог выбора файла
    ''' </summary>
    ''' <param name="pathInput"></param>
    ''' <remarks></remarks>
    Private Sub selectAppFile(defaultFilename As String, pathInput As TextBox)
        Dim fileDialog As New OpenFileDialog
        fileDialog.Filter = "Исполняемые файлы (*.exe)|*.exe"
        fileDialog.FileName = defaultFilename
        If (fileDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            pathInput.Text = fileDialog.FileName
        End If
        fileDialog.Dispose()
    End Sub

    ''' <summary>
    ''' Выбор пути AIMP
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AimpInput_TextClick(sender As Object, e As EventArgs) Handles AimpInput.Click
        selectAppFile("AIMP", AimpInput)
    End Sub

    ''' <summary>
    ''' Выбор пути MPC-HC
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MpcInput_TextClick(sender As Object, e As EventArgs) Handles MpcInput.Click
        selectAppFile("mpc-hc", MpcInput)
    End Sub

End Class
