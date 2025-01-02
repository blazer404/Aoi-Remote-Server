Partial Public Class MainForm

    ''' <summary>
    ''' Переход на GitHub приложения
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GitHubLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GitHubLink.LinkClicked
        Process.Start(My.Settings.AuthorUrl)
    End Sub

End Class
