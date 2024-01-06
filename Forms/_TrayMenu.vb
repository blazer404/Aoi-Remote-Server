﻿Partial Public Class MainForm

    ''' <summary>
    ''' Показывает или скрывает приложение и меняет текст пункта меню в трее
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HideShowApp()
        If Me.Visible = False Then
            Me.Show()
            TrayMenuShowApp.Text = My.Resources.s_Hide
        Else
            Me.Hide()
            TrayMenuShowApp.Text = My.Resources.s_Show
        End If
    End Sub

    ''' <summary>
    ''' Клик ЛКМ по иконке в трее
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TrayIcon_MouseClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            HideShowApp()
        End If
    End Sub

    ''' <summary>
    ''' Показ приложения через меню трея
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TrayMenuShowApp_Click(sender As Object, e As EventArgs) Handles TrayMenuShowApp.Click
        HideShowApp()
    End Sub

    ''' <summary>
    ''' Выход из приложения через меню трея
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TrayMenuExit_Click(sender As Object, e As EventArgs) Handles TrayMenuExit.Click
        TCPServer.CloseConnection()
        Application.Exit()
    End Sub

End Class
