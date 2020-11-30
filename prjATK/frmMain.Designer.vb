<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DbConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SKUMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddressMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransaksi = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPR = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPRApproval = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CreatePOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GRPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportPRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintGRPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintGRResultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.labelVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.DataMasterToolStripMenuItem, Me.mnuTransaksi, Me.mnuReports, Me.WindowsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1409, 49)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLogin, Me.ChangePasswordToolStripMenuItem, Me.mnuLogout, Me.ConfigToolStripMenuItem, Me.mnuExit})
        Me.FileToolStripMenuItem.Image = CType(resources.GetObject("FileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(77, 45)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'mnuLogin
        '
        Me.mnuLogin.Name = "mnuLogin"
        Me.mnuLogin.Size = New System.Drawing.Size(199, 26)
        Me.mnuLogin.Text = "&Log&in"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.ChangePasswordToolStripMenuItem.Text = "Change Password"
        '
        'mnuLogout
        '
        Me.mnuLogout.Enabled = False
        Me.mnuLogout.Name = "mnuLogout"
        Me.mnuLogout.Size = New System.Drawing.Size(199, 26)
        Me.mnuLogout.Text = "Log&out"
        '
        'ConfigToolStripMenuItem
        '
        Me.ConfigToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DbConfigToolStripMenuItem, Me.UserConfigToolStripMenuItem})
        Me.ConfigToolStripMenuItem.Name = "ConfigToolStripMenuItem"
        Me.ConfigToolStripMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.ConfigToolStripMenuItem.Text = "&Config"
        '
        'DbConfigToolStripMenuItem
        '
        Me.DbConfigToolStripMenuItem.Name = "DbConfigToolStripMenuItem"
        Me.DbConfigToolStripMenuItem.Size = New System.Drawing.Size(161, 26)
        Me.DbConfigToolStripMenuItem.Text = "dbConfig"
        '
        'UserConfigToolStripMenuItem
        '
        Me.UserConfigToolStripMenuItem.Enabled = False
        Me.UserConfigToolStripMenuItem.Name = "UserConfigToolStripMenuItem"
        Me.UserConfigToolStripMenuItem.Size = New System.Drawing.Size(161, 26)
        Me.UserConfigToolStripMenuItem.Text = "User Config"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(199, 26)
        Me.mnuExit.Text = "E&xit"
        '
        'DataMasterToolStripMenuItem
        '
        Me.DataMasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SKUMasterToolStripMenuItem, Me.AddressMasterToolStripMenuItem})
        Me.DataMasterToolStripMenuItem.Image = CType(resources.GetObject("DataMasterToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DataMasterToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DataMasterToolStripMenuItem.Name = "DataMasterToolStripMenuItem"
        Me.DataMasterToolStripMenuItem.Size = New System.Drawing.Size(136, 45)
        Me.DataMasterToolStripMenuItem.Text = "Master Data"
        '
        'SKUMasterToolStripMenuItem
        '
        Me.SKUMasterToolStripMenuItem.Name = "SKUMasterToolStripMenuItem"
        Me.SKUMasterToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.SKUMasterToolStripMenuItem.Text = "SKU"
        '
        'AddressMasterToolStripMenuItem
        '
        Me.AddressMasterToolStripMenuItem.Name = "AddressMasterToolStripMenuItem"
        Me.AddressMasterToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.AddressMasterToolStripMenuItem.Text = "Address"
        '
        'mnuTransaksi
        '
        Me.mnuTransaksi.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.mnuPR, Me.ToolStripSeparator2, Me.mnuPRApproval, Me.ToolStripSeparator3, Me.CreatePOToolStripMenuItem, Me.GRPOToolStripMenuItem})
        Me.mnuTransaksi.Enabled = False
        Me.mnuTransaksi.Image = CType(resources.GetObject("mnuTransaksi.Image"), System.Drawing.Image)
        Me.mnuTransaksi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuTransaksi.Name = "mnuTransaksi"
        Me.mnuTransaksi.Size = New System.Drawing.Size(129, 45)
        Me.mnuTransaksi.Text = "Transaction"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(189, 6)
        '
        'mnuPR
        '
        Me.mnuPR.Enabled = False
        Me.mnuPR.Name = "mnuPR"
        Me.mnuPR.Size = New System.Drawing.Size(192, 26)
        Me.mnuPR.Text = "PR"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(189, 6)
        '
        'mnuPRApproval
        '
        Me.mnuPRApproval.Enabled = False
        Me.mnuPRApproval.Name = "mnuPRApproval"
        Me.mnuPRApproval.Size = New System.Drawing.Size(192, 26)
        Me.mnuPRApproval.Text = "List PR Approval"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(189, 6)
        '
        'CreatePOToolStripMenuItem
        '
        Me.CreatePOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainPOToolStripMenuItem, Me.EditPOToolStripMenuItem})
        Me.CreatePOToolStripMenuItem.Enabled = False
        Me.CreatePOToolStripMenuItem.Name = "CreatePOToolStripMenuItem"
        Me.CreatePOToolStripMenuItem.Size = New System.Drawing.Size(192, 26)
        Me.CreatePOToolStripMenuItem.Text = "PO"
        '
        'MainPOToolStripMenuItem
        '
        Me.MainPOToolStripMenuItem.Name = "MainPOToolStripMenuItem"
        Me.MainPOToolStripMenuItem.Size = New System.Drawing.Size(140, 26)
        Me.MainPOToolStripMenuItem.Text = "Main PO"
        '
        'EditPOToolStripMenuItem
        '
        Me.EditPOToolStripMenuItem.Enabled = False
        Me.EditPOToolStripMenuItem.Name = "EditPOToolStripMenuItem"
        Me.EditPOToolStripMenuItem.Size = New System.Drawing.Size(140, 26)
        Me.EditPOToolStripMenuItem.Text = "Edit PO"
        '
        'GRPOToolStripMenuItem
        '
        Me.GRPOToolStripMenuItem.Enabled = False
        Me.GRPOToolStripMenuItem.Name = "GRPOToolStripMenuItem"
        Me.GRPOToolStripMenuItem.Size = New System.Drawing.Size(192, 26)
        Me.GRPOToolStripMenuItem.Text = "GR PO"
        '
        'mnuReports
        '
        Me.mnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportPRToolStripMenuItem, Me.ReportPOToolStripMenuItem, Me.PrintGRPOToolStripMenuItem, Me.PrintGRResultToolStripMenuItem})
        Me.mnuReports.Enabled = False
        Me.mnuReports.Image = CType(resources.GetObject("mnuReports.Image"), System.Drawing.Image)
        Me.mnuReports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuReports.Name = "mnuReports"
        Me.mnuReports.Size = New System.Drawing.Size(108, 45)
        Me.mnuReports.Text = "Reports"
        '
        'ReportPRToolStripMenuItem
        '
        Me.ReportPRToolStripMenuItem.Name = "ReportPRToolStripMenuItem"
        Me.ReportPRToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.ReportPRToolStripMenuItem.Text = "PR"
        '
        'ReportPOToolStripMenuItem
        '
        Me.ReportPOToolStripMenuItem.Name = "ReportPOToolStripMenuItem"
        Me.ReportPOToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.ReportPOToolStripMenuItem.Text = "PO"
        '
        'PrintGRPOToolStripMenuItem
        '
        Me.PrintGRPOToolStripMenuItem.Name = "PrintGRPOToolStripMenuItem"
        Me.PrintGRPOToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.PrintGRPOToolStripMenuItem.Text = "Print GR Form"
        '
        'PrintGRResultToolStripMenuItem
        '
        Me.PrintGRResultToolStripMenuItem.Name = "PrintGRResultToolStripMenuItem"
        Me.PrintGRResultToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.PrintGRResultToolStripMenuItem.Text = "Print GR Result"
        '
        'WindowsToolStripMenuItem
        '
        Me.WindowsToolStripMenuItem.Image = CType(resources.GetObject("WindowsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WindowsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem"
        Me.WindowsToolStripMenuItem.Size = New System.Drawing.Size(116, 45)
        Me.WindowsToolStripMenuItem.Text = "Wi&ndows"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.ToolStripStatusLabel1, Me.labelVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 738)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1409, 25)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(88, 20)
        Me.lblStatus.Text = "Logged Out"
        '
        'labelVersion
        '
        Me.labelVersion.Name = "labelVersion"
        Me.labelVersion.Size = New System.Drawing.Size(177, 20)
        Me.labelVersion.Text = "EProcuremenet versi 1.0.1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(29, 20)
        Me.ToolStripStatusLabel1.Text = "     "
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1409, 763)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.Text = "e-Procurement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLogout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTransaksi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPRApproval As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DbConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CreatePOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SKUMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddressMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportPRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportPOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintGRPOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GRPOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintGRResultToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainPOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditPOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents labelVersion As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
End Class
