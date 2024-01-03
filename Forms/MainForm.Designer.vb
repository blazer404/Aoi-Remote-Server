<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ServerBtn = New System.Windows.Forms.Button()
        Me.ClientBtn = New System.Windows.Forms.Button()
        Me.LogBox = New System.Windows.Forms.RichTextBox()
        Me.LogBtn = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SuspendLayout()
        '
        'ServerBtn
        '
        Me.ServerBtn.Location = New System.Drawing.Point(12, 12)
        Me.ServerBtn.Name = "ServerBtn"
        Me.ServerBtn.Size = New System.Drawing.Size(75, 23)
        Me.ServerBtn.TabIndex = 0
        Me.ServerBtn.Text = "Server"
        Me.ServerBtn.UseVisualStyleBackColor = True
        '
        'ClientBtn
        '
        Me.ClientBtn.Location = New System.Drawing.Point(93, 12)
        Me.ClientBtn.Name = "ClientBtn"
        Me.ClientBtn.Size = New System.Drawing.Size(75, 23)
        Me.ClientBtn.TabIndex = 1
        Me.ClientBtn.Text = "Client"
        Me.ClientBtn.UseVisualStyleBackColor = True
        '
        'LogBox
        '
        Me.LogBox.Location = New System.Drawing.Point(12, 41)
        Me.LogBox.Name = "LogBox"
        Me.LogBox.Size = New System.Drawing.Size(392, 301)
        Me.LogBox.TabIndex = 2
        Me.LogBox.Text = ""
        '
        'LogBtn
        '
        Me.LogBtn.Location = New System.Drawing.Point(329, 12)
        Me.LogBtn.Name = "LogBtn"
        Me.LogBtn.Size = New System.Drawing.Size(75, 23)
        Me.LogBtn.TabIndex = 3
        Me.LogBtn.Text = "ClearLog"
        Me.LogBtn.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 354)
        Me.Controls.Add(Me.LogBtn)
        Me.Controls.Add(Me.LogBox)
        Me.Controls.Add(Me.ClientBtn)
        Me.Controls.Add(Me.ServerBtn)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ServerBtn As System.Windows.Forms.Button
    Friend WithEvents ClientBtn As System.Windows.Forms.Button
    Friend WithEvents LogBox As System.Windows.Forms.RichTextBox
    Friend WithEvents LogBtn As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon

End Class
