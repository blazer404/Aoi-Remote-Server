Partial Public Class MainForm

    ''' <summary>
    ''' Клик ЛКМ по иконке в трее
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TrayIcon_MouseClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.WindowState = FormWindowState.Normal Then
                Me.WindowState = FormWindowState.Minimized
            Else
                Me.WindowState = FormWindowState.Normal
            End If
        End If
    End Sub

    ''' <summary>
    ''' Показ приложения через меню трея
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TrayMenuShowApp_Click(sender As Object, e As EventArgs) Handles TrayMenuShowApp.Click
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        Me.BringToFront()
        Me.Focus()
    End Sub

    ''' <summary>
    ''' Выход из приложения через меню трея
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TrayMenuExit_Click(sender As Object, e As EventArgs) Handles TrayMenuExit.Click
        Application.Exit()
    End Sub

End Class
