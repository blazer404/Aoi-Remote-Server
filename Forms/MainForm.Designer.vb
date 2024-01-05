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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ServerButtom = New System.Windows.Forms.Button()
        Me.ClientButton = New System.Windows.Forms.Button()
        Me.ClearLogButton = New System.Windows.Forms.Button()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TrayMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TrayMenuShowApp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TrayMenuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.AutorunServerCheckBox = New System.Windows.Forms.CheckBox()
        Me.IpInput = New System.Windows.Forms.ComboBox()
        Me.IpLabel = New System.Windows.Forms.Label()
        Me.PortLabel = New System.Windows.Forms.Label()
        Me.AccessKeyLabel = New System.Windows.Forms.Label()
        Me.TabPanel = New System.Windows.Forms.TabControl()
        Me.SettingsTab = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PortInput = New System.Windows.Forms.TextBox()
        Me.AccessKeyInput = New System.Windows.Forms.TextBox()
        Me.AutorunAppCheckbot = New System.Windows.Forms.CheckBox()
        Me.Ipv6CheckBox = New System.Windows.Forms.CheckBox()
        Me.GitHubLink = New System.Windows.Forms.LinkLabel()
        Me.AccessKeyButton = New System.Windows.Forms.Button()
        Me.PortButton = New System.Windows.Forms.Button()
        Me.AppsTab = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MpcButton = New System.Windows.Forms.Button()
        Me.AimpButton = New System.Windows.Forms.Button()
        Me.MpcInput = New System.Windows.Forms.TextBox()
        Me.MpcLabel = New System.Windows.Forms.Label()
        Me.AimpInput = New System.Windows.Forms.TextBox()
        Me.AimpLabel = New System.Windows.Forms.Label()
        Me.DebugTab = New System.Windows.Forms.TabPage()
        Me.LogBox = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TrayMenu.SuspendLayout()
        Me.TabPanel.SuspendLayout()
        Me.SettingsTab.SuspendLayout()
        Me.AppsTab.SuspendLayout()
        Me.DebugTab.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ServerButtom
        '
        Me.ServerButtom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ServerButtom.Location = New System.Drawing.Point(6, 162)
        Me.ServerButtom.Name = "ServerButtom"
        Me.ServerButtom.Size = New System.Drawing.Size(85, 23)
        Me.ServerButtom.TabIndex = 1
        Me.ServerButtom.Text = "Start Server"
        Me.ServerButtom.UseVisualStyleBackColor = True
        '
        'ClientButton
        '
        Me.ClientButton.Enabled = False
        Me.ClientButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ClientButton.Location = New System.Drawing.Point(97, 162)
        Me.ClientButton.Name = "ClientButton"
        Me.ClientButton.Size = New System.Drawing.Size(85, 23)
        Me.ClientButton.TabIndex = 2
        Me.ClientButton.Text = "Test Client"
        Me.ClientButton.UseVisualStyleBackColor = True
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
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "TrayMenu"
        Me.TrayIcon.Visible = True
        '
        'TrayMenu
        '
        Me.TrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayMenuShowApp, Me.ToolStripMenuItem1, Me.TrayMenuExit})
        Me.TrayMenu.Name = "TrayMenu"
        Me.TrayMenu.Size = New System.Drawing.Size(125, 54)
        '
        'TrayMenuShowApp
        '
        Me.TrayMenuShowApp.Name = "TrayMenuShowApp"
        Me.TrayMenuShowApp.Size = New System.Drawing.Size(124, 22)
        Me.TrayMenuShowApp.Text = "Показать"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(121, 6)
        '
        'TrayMenuExit
        '
        Me.TrayMenuExit.Name = "TrayMenuExit"
        Me.TrayMenuExit.Size = New System.Drawing.Size(124, 22)
        Me.TrayMenuExit.Text = "Выход"
        '
        'SaveButton
        '
        Me.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.SaveButton.Location = New System.Drawing.Point(138, 229)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(75, 23)
        Me.SaveButton.TabIndex = 100
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.CloseButton.Location = New System.Drawing.Point(219, 229)
        Me.CloseButton.Margin = New System.Windows.Forms.Padding(3, 3, 4, 3)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 101
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'AutorunServerCheckBox
        '
        Me.AutorunServerCheckBox.AutoSize = True
        Me.AutorunServerCheckBox.Location = New System.Drawing.Point(6, 145)
        Me.AutorunServerCheckBox.Name = "AutorunServerCheckBox"
        Me.AutorunServerCheckBox.Size = New System.Drawing.Size(121, 17)
        Me.AutorunServerCheckBox.TabIndex = 7
        Me.AutorunServerCheckBox.Text = "Autorun TCP Server"
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
        Me.TabPanel.Controls.Add(Me.SettingsTab)
        Me.TabPanel.Controls.Add(Me.AppsTab)
        Me.TabPanel.Controls.Add(Me.DebugTab)
        Me.TabPanel.Location = New System.Drawing.Point(11, 6)
        Me.TabPanel.Name = "TabPanel"
        Me.TabPanel.SelectedIndex = 0
        Me.TabPanel.Size = New System.Drawing.Size(284, 217)
        Me.TabPanel.TabIndex = 0
        '
        'SettingsTab
        '
        Me.SettingsTab.Controls.Add(Me.Label1)
        Me.SettingsTab.Controls.Add(Me.PortInput)
        Me.SettingsTab.Controls.Add(Me.AccessKeyInput)
        Me.SettingsTab.Controls.Add(Me.AutorunAppCheckbot)
        Me.SettingsTab.Controls.Add(Me.Ipv6CheckBox)
        Me.SettingsTab.Controls.Add(Me.GitHubLink)
        Me.SettingsTab.Controls.Add(Me.AutorunServerCheckBox)
        Me.SettingsTab.Controls.Add(Me.AccessKeyButton)
        Me.SettingsTab.Controls.Add(Me.PortButton)
        Me.SettingsTab.Controls.Add(Me.IpInput)
        Me.SettingsTab.Controls.Add(Me.AccessKeyLabel)
        Me.SettingsTab.Controls.Add(Me.IpLabel)
        Me.SettingsTab.Controls.Add(Me.PortLabel)
        Me.SettingsTab.Location = New System.Drawing.Point(4, 22)
        Me.SettingsTab.Name = "SettingsTab"
        Me.SettingsTab.Padding = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.SettingsTab.Size = New System.Drawing.Size(276, 191)
        Me.SettingsTab.TabIndex = 0
        Me.SettingsTab.Text = "Settings"
        Me.SettingsTab.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label1.Location = New System.Drawing.Point(142, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "TODO"
        '
        'PortInput
        '
        Me.PortInput.Location = New System.Drawing.Point(77, 36)
        Me.PortInput.Name = "PortInput"
        Me.PortInput.Size = New System.Drawing.Size(116, 20)
        Me.PortInput.TabIndex = 18
        '
        'AccessKeyInput
        '
        Me.AccessKeyInput.Location = New System.Drawing.Point(77, 62)
        Me.AccessKeyInput.Name = "AccessKeyInput"
        Me.AccessKeyInput.Size = New System.Drawing.Size(116, 20)
        Me.AccessKeyInput.TabIndex = 17
        '
        'AutorunAppCheckbot
        '
        Me.AutorunAppCheckbot.AutoSize = True
        Me.AutorunAppCheckbot.Location = New System.Drawing.Point(6, 168)
        Me.AutorunAppCheckbot.Name = "AutorunAppCheckbot"
        Me.AutorunAppCheckbot.Size = New System.Drawing.Size(143, 17)
        Me.AutorunAppCheckbot.TabIndex = 8
        Me.AutorunAppCheckbot.Text = "Run on Windows startup"
        Me.AutorunAppCheckbot.UseVisualStyleBackColor = True
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
        'GitHubLink
        '
        Me.GitHubLink.AutoSize = True
        Me.GitHubLink.Location = New System.Drawing.Point(230, 169)
        Me.GitHubLink.Name = "GitHubLink"
        Me.GitHubLink.Size = New System.Drawing.Size(40, 13)
        Me.GitHubLink.TabIndex = 9
        Me.GitHubLink.TabStop = True
        Me.GitHubLink.Text = "GitHub"
        '
        'AccessKeyButton
        '
        Me.AccessKeyButton.BackColor = System.Drawing.Color.Transparent
        Me.AccessKeyButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.AccessKeyButton.Location = New System.Drawing.Point(199, 60)
        Me.AccessKeyButton.Name = "AccessKeyButton"
        Me.AccessKeyButton.Size = New System.Drawing.Size(70, 23)
        Me.AccessKeyButton.TabIndex = 6
        Me.AccessKeyButton.Text = "Generate"
        Me.AccessKeyButton.UseVisualStyleBackColor = True
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
        Me.AppsTab.Controls.Add(Me.Label4)
        Me.AppsTab.Controls.Add(Me.Label3)
        Me.AppsTab.Controls.Add(Me.MpcButton)
        Me.AppsTab.Controls.Add(Me.AimpButton)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label4.Location = New System.Drawing.Point(219, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "TODO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label3.Location = New System.Drawing.Point(219, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "TODO"
        '
        'MpcButton
        '
        Me.MpcButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.MpcButton.Location = New System.Drawing.Point(247, 33)
        Me.MpcButton.Name = "MpcButton"
        Me.MpcButton.Size = New System.Drawing.Size(23, 20)
        Me.MpcButton.TabIndex = 4
        Me.MpcButton.Text = "..."
        Me.MpcButton.UseVisualStyleBackColor = True
        '
        'AimpButton
        '
        Me.AimpButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.AimpButton.Location = New System.Drawing.Point(247, 7)
        Me.AimpButton.Name = "AimpButton"
        Me.AimpButton.Size = New System.Drawing.Size(23, 20)
        Me.AimpButton.TabIndex = 2
        Me.AimpButton.Text = "..."
        Me.AimpButton.UseVisualStyleBackColor = True
        '
        'MpcInput
        '
        Me.MpcInput.Location = New System.Drawing.Point(57, 33)
        Me.MpcInput.Name = "MpcInput"
        Me.MpcInput.ReadOnly = True
        Me.MpcInput.Size = New System.Drawing.Size(184, 20)
        Me.MpcInput.TabIndex = 3
        '
        'MpcLabel
        '
        Me.MpcLabel.AutoSize = True
        Me.MpcLabel.Location = New System.Drawing.Point(6, 37)
        Me.MpcLabel.Name = "MpcLabel"
        Me.MpcLabel.Size = New System.Drawing.Size(48, 13)
        Me.MpcLabel.TabIndex = 21
        Me.MpcLabel.Text = "MPC-HC"
        Me.MpcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AimpInput
        '
        Me.AimpInput.Location = New System.Drawing.Point(57, 7)
        Me.AimpInput.Name = "AimpInput"
        Me.AimpInput.ReadOnly = True
        Me.AimpInput.Size = New System.Drawing.Size(184, 20)
        Me.AimpInput.TabIndex = 1
        '
        'AimpLabel
        '
        Me.AimpLabel.AutoSize = True
        Me.AimpLabel.Location = New System.Drawing.Point(6, 12)
        Me.AimpLabel.Name = "AimpLabel"
        Me.AimpLabel.Size = New System.Drawing.Size(33, 13)
        Me.AimpLabel.TabIndex = 19
        Me.AimpLabel.Text = "AIMP"
        Me.AimpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DebugTab
        '
        Me.DebugTab.Controls.Add(Me.LogBox)
        Me.DebugTab.Controls.Add(Me.ClientButton)
        Me.DebugTab.Controls.Add(Me.ClearLogButton)
        Me.DebugTab.Controls.Add(Me.ServerButtom)
        Me.DebugTab.Location = New System.Drawing.Point(4, 22)
        Me.DebugTab.Name = "DebugTab"
        Me.DebugTab.Padding = New System.Windows.Forms.Padding(3)
        Me.DebugTab.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DebugTab.Size = New System.Drawing.Size(276, 191)
        Me.DebugTab.TabIndex = 1
        Me.DebugTab.Text = "Debug"
        Me.DebugTab.UseVisualStyleBackColor = True
        '
        'LogBox
        '
        Me.LogBox.Location = New System.Drawing.Point(3, 3)
        Me.LogBox.Multiline = True
        Me.LogBox.Name = "LogBox"
        Me.LogBox.ReadOnly = True
        Me.LogBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LogBox.Size = New System.Drawing.Size(270, 150)
        Me.LogBox.TabIndex = 1
        Me.LogBox.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.TabPanel)
        Me.FlowLayoutPanel1.Controls.Add(Me.CloseButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.SaveButton)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(304, 265)
        Me.FlowLayoutPanel1.TabIndex = 16
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(304, 265)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "%APP_TITLE%"
        Me.TrayMenu.ResumeLayout(False)
        Me.TabPanel.ResumeLayout(False)
        Me.SettingsTab.ResumeLayout(False)
        Me.SettingsTab.PerformLayout()
        Me.AppsTab.ResumeLayout(False)
        Me.AppsTab.PerformLayout()
        Me.DebugTab.ResumeLayout(False)
        Me.DebugTab.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ServerButtom As System.Windows.Forms.Button
    Friend WithEvents ClientButton As System.Windows.Forms.Button
    Friend WithEvents ClearLogButton As System.Windows.Forms.Button
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents AutorunServerCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IpInput As System.Windows.Forms.ComboBox
    Friend WithEvents IpLabel As System.Windows.Forms.Label
    Friend WithEvents PortLabel As System.Windows.Forms.Label
    Friend WithEvents AccessKeyLabel As System.Windows.Forms.Label
    Friend WithEvents TabPanel As System.Windows.Forms.TabControl
    Friend WithEvents SettingsTab As System.Windows.Forms.TabPage
    Friend WithEvents AccessKeyButton As System.Windows.Forms.Button
    Friend WithEvents PortButton As System.Windows.Forms.Button
    Friend WithEvents DebugTab As System.Windows.Forms.TabPage
    Friend WithEvents AppsTab As System.Windows.Forms.TabPage
    Friend WithEvents LogBox As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents MpcButton As System.Windows.Forms.Button
    Friend WithEvents AimpButton As System.Windows.Forms.Button
    Friend WithEvents MpcInput As System.Windows.Forms.TextBox
    Friend WithEvents MpcLabel As System.Windows.Forms.Label
    Friend WithEvents AimpInput As System.Windows.Forms.TextBox
    Friend WithEvents AimpLabel As System.Windows.Forms.Label
    Friend WithEvents Ipv6CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GitHubLink As System.Windows.Forms.LinkLabel
    Friend WithEvents AutorunAppCheckbot As System.Windows.Forms.CheckBox
    Friend WithEvents TrayMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TrayMenuShowApp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TrayMenuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents AccessKeyInput As System.Windows.Forms.TextBox
    Friend WithEvents PortInput As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
