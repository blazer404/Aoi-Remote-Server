﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.ClearLogButton = New System.Windows.Forms.Button()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TrayMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TrayMenuShowApp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TrayMenuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveSettingsButton = New System.Windows.Forms.Button()
        Me.AutorunServerCheckBox = New System.Windows.Forms.CheckBox()
        Me.IpInput = New System.Windows.Forms.ComboBox()
        Me.IpLabel = New System.Windows.Forms.Label()
        Me.PortLabel = New System.Windows.Forms.Label()
        Me.AccessKeyLabel = New System.Windows.Forms.Label()
        Me.TabPanel = New System.Windows.Forms.TabControl()
        Me.ServerTab = New System.Windows.Forms.TabPage()
        Me.RunMinimizedCheckBox = New System.Windows.Forms.CheckBox()
        Me.EnableLogCheckBox = New System.Windows.Forms.CheckBox()
        Me.ServerStatusLabel = New System.Windows.Forms.Label()
        Me.PortInput = New System.Windows.Forms.TextBox()
        Me.AuthTokenInput = New System.Windows.Forms.TextBox()
        Me.AutorunAppCheckbox = New System.Windows.Forms.CheckBox()
        Me.Ipv6CheckBox = New System.Windows.Forms.CheckBox()
        Me.AuthTokenButton = New System.Windows.Forms.Button()
        Me.PortButton = New System.Windows.Forms.Button()
        Me.AppsTab = New System.Windows.Forms.TabPage()
        Me.MpcInput = New System.Windows.Forms.TextBox()
        Me.MpcLabel = New System.Windows.Forms.Label()
        Me.AimpInput = New System.Windows.Forms.TextBox()
        Me.AimpLabel = New System.Windows.Forms.Label()
        Me.LogTab = New System.Windows.Forms.TabPage()
        Me.LogBox = New System.Windows.Forms.TextBox()
        Me.AboutTab = New System.Windows.Forms.TabPage()
        Me.GitHubLink = New System.Windows.Forms.LinkLabel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CancelSettingsButton = New System.Windows.Forms.Button()
        Me.ResetSettingsButton = New System.Windows.Forms.Button()
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.TrayMenu.SuspendLayout()
        Me.TabPanel.SuspendLayout()
        Me.ServerTab.SuspendLayout()
        Me.AppsTab.SuspendLayout()
        Me.LogTab.SuspendLayout()
        Me.AboutTab.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ClearLogButton
        '
        Me.ClearLogButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ClearLogButton.Location = New System.Drawing.Point(188, 162)
        Me.ClearLogButton.Name = "ClearLogButton"
        Me.ClearLogButton.Size = New System.Drawing.Size(85, 23)
        Me.ClearLogButton.TabIndex = 3
        Me.ClearLogButton.Text = "Clear Log"
        Me.ClearLogButton.UseVisualStyleBackColor = True
        '
        'TrayIcon
        '
        Me.TrayIcon.ContextMenuStrip = Me.TrayMenu
        Me.TrayIcon.Text = "TrayMenu"
        Me.TrayIcon.Visible = True
        '
        'TrayMenu
        '
        Me.TrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayMenuShowApp, Me.ToolStripMenuItem1, Me.TrayMenuExit})
        Me.TrayMenu.Name = "TrayMenu"
        Me.TrayMenu.Size = New System.Drawing.Size(104, 54)
        '
        'TrayMenuShowApp
        '
        Me.TrayMenuShowApp.Name = "TrayMenuShowApp"
        Me.TrayMenuShowApp.Size = New System.Drawing.Size(103, 22)
        Me.TrayMenuShowApp.Text = "Show"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(100, 6)
        '
        'TrayMenuExit
        '
        Me.TrayMenuExit.Name = "TrayMenuExit"
        Me.TrayMenuExit.Size = New System.Drawing.Size(103, 22)
        Me.TrayMenuExit.Text = "Exit"
        '
        'SaveSettingsButton
        '
        Me.SaveSettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SaveSettingsButton.Location = New System.Drawing.Point(139, 229)
        Me.SaveSettingsButton.Name = "SaveSettingsButton"
        Me.SaveSettingsButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveSettingsButton.TabIndex = 102
        Me.SaveSettingsButton.Text = "Save"
        Me.SaveSettingsButton.UseVisualStyleBackColor = True
        '
        'AutorunServerCheckBox
        '
        Me.AutorunServerCheckBox.AutoSize = True
        Me.AutorunServerCheckBox.Location = New System.Drawing.Point(6, 145)
        Me.AutorunServerCheckBox.Name = "AutorunServerCheckBox"
        Me.AutorunServerCheckBox.Size = New System.Drawing.Size(97, 17)
        Me.AutorunServerCheckBox.TabIndex = 8
        Me.AutorunServerCheckBox.Text = "Autorun Server"
        Me.AutorunServerCheckBox.UseVisualStyleBackColor = True
        '
        'IpInput
        '
        Me.IpInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IpInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.IpInput.FormattingEnabled = True
        Me.IpInput.Location = New System.Drawing.Point(77, 9)
        Me.IpInput.MaxDropDownItems = 20
        Me.IpInput.Name = "IpInput"
        Me.IpInput.Size = New System.Drawing.Size(116, 21)
        Me.IpInput.Sorted = True
        Me.IpInput.TabIndex = 1
        '
        'IpLabel
        '
        Me.IpLabel.AutoSize = True
        Me.IpLabel.Location = New System.Drawing.Point(6, 12)
        Me.IpLabel.Name = "IpLabel"
        Me.IpLabel.Size = New System.Drawing.Size(58, 13)
        Me.IpLabel.TabIndex = 11
        Me.IpLabel.Text = "IP Address"
        Me.IpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PortLabel
        '
        Me.PortLabel.AutoSize = True
        Me.PortLabel.Location = New System.Drawing.Point(6, 39)
        Me.PortLabel.Name = "PortLabel"
        Me.PortLabel.Size = New System.Drawing.Size(66, 13)
        Me.PortLabel.TabIndex = 12
        Me.PortLabel.Text = "Port Number"
        Me.PortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AccessKeyLabel
        '
        Me.AccessKeyLabel.AutoSize = True
        Me.AccessKeyLabel.Location = New System.Drawing.Point(8, 65)
        Me.AccessKeyLabel.Name = "AccessKeyLabel"
        Me.AccessKeyLabel.Size = New System.Drawing.Size(63, 13)
        Me.AccessKeyLabel.TabIndex = 13
        Me.AccessKeyLabel.Text = "Access Key"
        Me.AccessKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPanel
        '
        Me.TabPanel.Controls.Add(Me.ServerTab)
        Me.TabPanel.Controls.Add(Me.AppsTab)
        Me.TabPanel.Controls.Add(Me.LogTab)
        Me.TabPanel.Controls.Add(Me.AboutTab)
        Me.TabPanel.Location = New System.Drawing.Point(11, 6)
        Me.TabPanel.Name = "TabPanel"
        Me.TabPanel.SelectedIndex = 0
        Me.TabPanel.Size = New System.Drawing.Size(284, 217)
        Me.TabPanel.TabIndex = 0
        '
        'ServerTab
        '
        Me.ServerTab.Controls.Add(Me.RunMinimizedCheckBox)
        Me.ServerTab.Controls.Add(Me.EnableLogCheckBox)
        Me.ServerTab.Controls.Add(Me.ServerStatusLabel)
        Me.ServerTab.Controls.Add(Me.PortInput)
        Me.ServerTab.Controls.Add(Me.AuthTokenInput)
        Me.ServerTab.Controls.Add(Me.AutorunAppCheckbox)
        Me.ServerTab.Controls.Add(Me.Ipv6CheckBox)
        Me.ServerTab.Controls.Add(Me.AutorunServerCheckBox)
        Me.ServerTab.Controls.Add(Me.AuthTokenButton)
        Me.ServerTab.Controls.Add(Me.PortButton)
        Me.ServerTab.Controls.Add(Me.IpInput)
        Me.ServerTab.Controls.Add(Me.AccessKeyLabel)
        Me.ServerTab.Controls.Add(Me.IpLabel)
        Me.ServerTab.Controls.Add(Me.PortLabel)
        Me.ServerTab.Location = New System.Drawing.Point(4, 22)
        Me.ServerTab.Name = "ServerTab"
        Me.ServerTab.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.ServerTab.Size = New System.Drawing.Size(276, 191)
        Me.ServerTab.TabIndex = 0
        Me.ServerTab.Text = "Server"
        Me.ServerTab.UseVisualStyleBackColor = True
        '
        'RunMinimizedCheckBox
        '
        Me.RunMinimizedCheckBox.AutoSize = True
        Me.RunMinimizedCheckBox.Location = New System.Drawing.Point(173, 168)
        Me.RunMinimizedCheckBox.Name = "RunMinimizedCheckBox"
        Me.RunMinimizedCheckBox.Size = New System.Drawing.Size(94, 17)
        Me.RunMinimizedCheckBox.TabIndex = 11
        Me.RunMinimizedCheckBox.Text = "Run minimized"
        Me.RunMinimizedCheckBox.UseVisualStyleBackColor = True
        '
        'EnableLogCheckBox
        '
        Me.EnableLogCheckBox.AutoSize = True
        Me.EnableLogCheckBox.Location = New System.Drawing.Point(6, 168)
        Me.EnableLogCheckBox.Name = "EnableLogCheckBox"
        Me.EnableLogCheckBox.Size = New System.Drawing.Size(80, 17)
        Me.EnableLogCheckBox.TabIndex = 10
        Me.EnableLogCheckBox.Text = "Enable Log"
        Me.EnableLogCheckBox.UseVisualStyleBackColor = True
        '
        'ServerStatusLabel
        '
        Me.ServerStatusLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ServerStatusLabel.ForeColor = System.Drawing.Color.IndianRed
        Me.ServerStatusLabel.Location = New System.Drawing.Point(77, 100)
        Me.ServerStatusLabel.Name = "ServerStatusLabel"
        Me.ServerStatusLabel.Size = New System.Drawing.Size(116, 23)
        Me.ServerStatusLabel.TabIndex = 21
        Me.ServerStatusLabel.Text = "Server is stopped"
        Me.ServerStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PortInput
        '
        Me.PortInput.Location = New System.Drawing.Point(77, 36)
        Me.PortInput.MaxLength = 5
        Me.PortInput.Name = "PortInput"
        Me.PortInput.Size = New System.Drawing.Size(116, 20)
        Me.PortInput.TabIndex = 3
        '
        'AuthTokenInput
        '
        Me.AuthTokenInput.Location = New System.Drawing.Point(77, 62)
        Me.AuthTokenInput.Name = "AuthTokenInput"
        Me.AuthTokenInput.Size = New System.Drawing.Size(116, 20)
        Me.AuthTokenInput.TabIndex = 5
        '
        'AutorunAppCheckbox
        '
        Me.AutorunAppCheckbox.AutoSize = True
        Me.AutorunAppCheckbox.Location = New System.Drawing.Point(173, 145)
        Me.AutorunAppCheckbox.Name = "AutorunAppCheckbox"
        Me.AutorunAppCheckbox.Size = New System.Drawing.Size(96, 17)
        Me.AutorunAppCheckbox.TabIndex = 9
        Me.AutorunAppCheckbox.Text = "Run on startup"
        Me.AutorunAppCheckbox.UseVisualStyleBackColor = True
        '
        'Ipv6CheckBox
        '
        Me.Ipv6CheckBox.AutoSize = True
        Me.Ipv6CheckBox.Location = New System.Drawing.Point(199, 11)
        Me.Ipv6CheckBox.Name = "Ipv6CheckBox"
        Me.Ipv6CheckBox.Size = New System.Drawing.Size(70, 17)
        Me.Ipv6CheckBox.TabIndex = 2
        Me.Ipv6CheckBox.Text = "Use IPv6"
        Me.Ipv6CheckBox.UseVisualStyleBackColor = True
        '
        'AuthTokenButton
        '
        Me.AuthTokenButton.BackColor = System.Drawing.Color.Transparent
        Me.AuthTokenButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.AuthTokenButton.Location = New System.Drawing.Point(199, 60)
        Me.AuthTokenButton.Name = "AuthTokenButton"
        Me.AuthTokenButton.Size = New System.Drawing.Size(70, 23)
        Me.AuthTokenButton.TabIndex = 6
        Me.AuthTokenButton.Text = "Generate"
        Me.AuthTokenButton.UseVisualStyleBackColor = True
        '
        'PortButton
        '
        Me.PortButton.BackColor = System.Drawing.Color.Transparent
        Me.PortButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.PortButton.Location = New System.Drawing.Point(199, 34)
        Me.PortButton.Name = "PortButton"
        Me.PortButton.Size = New System.Drawing.Size(70, 23)
        Me.PortButton.TabIndex = 4
        Me.PortButton.Text = "Random"
        Me.PortButton.UseVisualStyleBackColor = True
        '
        'AppsTab
        '
        Me.AppsTab.Controls.Add(Me.MpcInput)
        Me.AppsTab.Controls.Add(Me.MpcLabel)
        Me.AppsTab.Controls.Add(Me.AimpInput)
        Me.AppsTab.Controls.Add(Me.AimpLabel)
        Me.AppsTab.Location = New System.Drawing.Point(4, 22)
        Me.AppsTab.Name = "AppsTab"
        Me.AppsTab.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.AppsTab.Size = New System.Drawing.Size(276, 191)
        Me.AppsTab.TabIndex = 2
        Me.AppsTab.Text = "Apps"
        Me.AppsTab.UseVisualStyleBackColor = True
        '
        'MpcInput
        '
        Me.MpcInput.Location = New System.Drawing.Point(57, 9)
        Me.MpcInput.Name = "MpcInput"
        Me.MpcInput.ReadOnly = True
        Me.MpcInput.Size = New System.Drawing.Size(213, 20)
        Me.MpcInput.TabIndex = 3
        '
        'MpcLabel
        '
        Me.MpcLabel.AutoSize = True
        Me.MpcLabel.Location = New System.Drawing.Point(6, 13)
        Me.MpcLabel.Name = "MpcLabel"
        Me.MpcLabel.Size = New System.Drawing.Size(48, 13)
        Me.MpcLabel.TabIndex = 21
        Me.MpcLabel.Text = "MPC-HC"
        Me.MpcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AimpInput
        '
        Me.AimpInput.Location = New System.Drawing.Point(57, 35)
        Me.AimpInput.Name = "AimpInput"
        Me.AimpInput.ReadOnly = True
        Me.AimpInput.Size = New System.Drawing.Size(213, 20)
        Me.AimpInput.TabIndex = 1
        '
        'AimpLabel
        '
        Me.AimpLabel.AutoSize = True
        Me.AimpLabel.Location = New System.Drawing.Point(6, 38)
        Me.AimpLabel.Name = "AimpLabel"
        Me.AimpLabel.Size = New System.Drawing.Size(33, 13)
        Me.AimpLabel.TabIndex = 19
        Me.AimpLabel.Text = "AIMP"
        Me.AimpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LogTab
        '
        Me.LogTab.Controls.Add(Me.LogBox)
        Me.LogTab.Controls.Add(Me.ClearLogButton)
        Me.LogTab.Location = New System.Drawing.Point(4, 22)
        Me.LogTab.Name = "LogTab"
        Me.LogTab.Padding = New System.Windows.Forms.Padding(3)
        Me.LogTab.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LogTab.Size = New System.Drawing.Size(276, 191)
        Me.LogTab.TabIndex = 1
        Me.LogTab.Text = "Log"
        Me.LogTab.UseVisualStyleBackColor = True
        '
        'LogBox
        '
        Me.LogBox.Location = New System.Drawing.Point(3, 3)
        Me.LogBox.Multiline = True
        Me.LogBox.Name = "LogBox"
        Me.LogBox.ReadOnly = True
        Me.LogBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.LogBox.Size = New System.Drawing.Size(270, 150)
        Me.LogBox.TabIndex = 1
        Me.LogBox.TabStop = False
        '
        'AboutTab
        '
        Me.AboutTab.Controls.Add(Me.VersionLabel)
        Me.AboutTab.Controls.Add(Me.GitHubLink)
        Me.AboutTab.Location = New System.Drawing.Point(4, 22)
        Me.AboutTab.Name = "AboutTab"
        Me.AboutTab.Size = New System.Drawing.Size(276, 191)
        Me.AboutTab.TabIndex = 3
        Me.AboutTab.Text = "About"
        Me.AboutTab.UseVisualStyleBackColor = True
        '
        'GitHubLink
        '
        Me.GitHubLink.AutoSize = True
        Me.GitHubLink.Location = New System.Drawing.Point(3, 170)
        Me.GitHubLink.Name = "GitHubLink"
        Me.GitHubLink.Size = New System.Drawing.Size(40, 13)
        Me.GitHubLink.TabIndex = 10
        Me.GitHubLink.TabStop = True
        Me.GitHubLink.Text = "GitHub"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.TabPanel)
        Me.FlowLayoutPanel1.Controls.Add(Me.CancelSettingsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.SaveSettingsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.ResetSettingsButton)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(304, 265)
        Me.FlowLayoutPanel1.TabIndex = 16
        '
        'CancelSettingsButton
        '
        Me.CancelSettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.CancelSettingsButton.Location = New System.Drawing.Point(220, 229)
        Me.CancelSettingsButton.Name = "CancelSettingsButton"
        Me.CancelSettingsButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelSettingsButton.TabIndex = 103
        Me.CancelSettingsButton.Text = "Cancel"
        Me.CancelSettingsButton.UseVisualStyleBackColor = True
        '
        'ResetSettingsButton
        '
        Me.ResetSettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ResetSettingsButton.Location = New System.Drawing.Point(11, 229)
        Me.ResetSettingsButton.Margin = New System.Windows.Forms.Padding(3, 3, 50, 3)
        Me.ResetSettingsButton.Name = "ResetSettingsButton"
        Me.ResetSettingsButton.Size = New System.Drawing.Size(75, 23)
        Me.ResetSettingsButton.TabIndex = 101
        Me.ResetSettingsButton.Text = "Reset"
        Me.ResetSettingsButton.UseVisualStyleBackColor = True
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.VersionLabel.Location = New System.Drawing.Point(3, 7)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(91, 16)
        Me.VersionLabel.TabIndex = 11
        Me.VersionLabel.Text = "%VERSION%"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(304, 265)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "%APP_TITLE%"
        Me.TopMost = True
        Me.TrayMenu.ResumeLayout(False)
        Me.TabPanel.ResumeLayout(False)
        Me.ServerTab.ResumeLayout(False)
        Me.ServerTab.PerformLayout()
        Me.AppsTab.ResumeLayout(False)
        Me.AppsTab.PerformLayout()
        Me.LogTab.ResumeLayout(False)
        Me.LogTab.PerformLayout()
        Me.AboutTab.ResumeLayout(False)
        Me.AboutTab.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ClearLogButton As System.Windows.Forms.Button
    Friend WithEvents SaveSettingsButton As System.Windows.Forms.Button
    Friend WithEvents AutorunServerCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IpInput As System.Windows.Forms.ComboBox
    Friend WithEvents IpLabel As System.Windows.Forms.Label
    Friend WithEvents PortLabel As System.Windows.Forms.Label
    Friend WithEvents AccessKeyLabel As System.Windows.Forms.Label
    Friend WithEvents TabPanel As System.Windows.Forms.TabControl
    Friend WithEvents ServerTab As System.Windows.Forms.TabPage
    Friend WithEvents AuthTokenButton As System.Windows.Forms.Button
    Friend WithEvents PortButton As System.Windows.Forms.Button
    Friend WithEvents LogTab As System.Windows.Forms.TabPage
    Friend WithEvents AppsTab As System.Windows.Forms.TabPage
    Friend WithEvents LogBox As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents MpcInput As System.Windows.Forms.TextBox
    Friend WithEvents MpcLabel As System.Windows.Forms.Label
    Friend WithEvents AimpInput As System.Windows.Forms.TextBox
    Friend WithEvents AimpLabel As System.Windows.Forms.Label
    Friend WithEvents Ipv6CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AutorunAppCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents TrayMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TrayMenuShowApp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TrayMenuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents AuthTokenInput As System.Windows.Forms.TextBox
    Friend WithEvents PortInput As System.Windows.Forms.TextBox
    Friend WithEvents ServerStatusLabel As System.Windows.Forms.Label
    Friend WithEvents ResetSettingsButton As System.Windows.Forms.Button
    Friend WithEvents EnableLogCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents RunMinimizedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AboutTab As System.Windows.Forms.TabPage
    Friend WithEvents GitHubLink As System.Windows.Forms.LinkLabel
    Friend WithEvents CancelSettingsButton As Button
    Friend WithEvents VersionLabel As Label
End Class
