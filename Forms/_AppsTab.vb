Partial Public Class MainForm

    ''' <summary>
    ''' Показываем диалог выбора файла
    ''' </summary>
    ''' <param name="pathInput"></param>
    ''' <remarks></remarks>
    Private Sub SelectAppFile(defaultFilename As String, pathInput As TextBox)
        Using fileDialog As New OpenFileDialog
            fileDialog.Filter = "Исполняемые файлы (*.exe)|*.exe"
            fileDialog.FileName = defaultFilename
            If (fileDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                pathInput.Text = fileDialog.FileName
            End If
            fileDialog.Dispose()
        End Using
    End Sub

    ''' <summary>
    ''' Выбор пути AIMP
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AimpInput_TextClick(sender As Object, e As EventArgs) Handles AimpInput.Click
        SelectAppFile("AIMP", AimpInput)
    End Sub

    ''' <summary>
    ''' Выбор пути MPC-HC
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MpcInput_TextClick(sender As Object, e As EventArgs) Handles MpcInput.Click
        SelectAppFile("mpc-hc", MpcInput)
    End Sub

End Class
