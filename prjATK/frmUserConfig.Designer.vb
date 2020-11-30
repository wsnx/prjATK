<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserConfig))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtAdminGA = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbSite = New System.Windows.Forms.ComboBox()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.txtUpdatedBy = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtLastUpdate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCopyPR = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCopyReq = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPRApproval = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtReqApproval = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAdminATK = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmailAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Site = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StorerKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdminATK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdminGA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReqApproval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRApproval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CopyReq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CopyPR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTransID = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.toolStripSeparator1, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1792, 27)
        Me.ToolStrip1.TabIndex = 29
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.Image = Global.prjATKPr.My.Resources.Resources.Add_8x_16x
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(63, 24)
        Me.NewToolStripButton.Text = "&New"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.prjATKPr.My.Resources.Resources.Edit_grey_16x
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 24)
        Me.ToolStripButton1.Text = "Edit"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.txtTransID)
        Me.Panel1.Controls.Add(Me.txtAdminGA)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.cbSite)
        Me.Panel1.Controls.Add(Me.cbCustomer)
        Me.Panel1.Controls.Add(Me.txtUpdatedBy)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtLastUpdate)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtCopyPR)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtCopyReq)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtPRApproval)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtReqApproval)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtAdminATK)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtEmailAddress)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtUserID)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1792, 191)
        Me.Panel1.TabIndex = 30
        '
        'txtAdminGA
        '
        Me.txtAdminGA.Location = New System.Drawing.Point(598, 47)
        Me.txtAdminGA.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAdminGA.Name = "txtAdminGA"
        Me.txtAdminGA.Size = New System.Drawing.Size(196, 22)
        Me.txtAdminGA.TabIndex = 53
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(510, 52)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 17)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Admin GA :"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSave.Location = New System.Drawing.Point(543, 140)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(252, 39)
        Me.btnSave.TabIndex = 51
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'cbSite
        '
        Me.cbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSite.FormattingEnabled = True
        Me.cbSite.Location = New System.Drawing.Point(131, 84)
        Me.cbSite.Margin = New System.Windows.Forms.Padding(4)
        Me.cbSite.Name = "cbSite"
        Me.cbSite.Size = New System.Drawing.Size(292, 24)
        Me.cbSite.TabIndex = 49
        '
        'cbCustomer
        '
        Me.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(131, 116)
        Me.cbCustomer.Margin = New System.Windows.Forms.Padding(4)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(292, 24)
        Me.cbCustomer.TabIndex = 50
        '
        'txtUpdatedBy
        '
        Me.txtUpdatedBy.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtUpdatedBy.Enabled = False
        Me.txtUpdatedBy.Location = New System.Drawing.Point(1207, 153)
        Me.txtUpdatedBy.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUpdatedBy.Name = "txtUpdatedBy"
        Me.txtUpdatedBy.Size = New System.Drawing.Size(132, 22)
        Me.txtUpdatedBy.TabIndex = 48
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1105, 153)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 17)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Updated By :"
        '
        'txtLastUpdate
        '
        Me.txtLastUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLastUpdate.Enabled = False
        Me.txtLastUpdate.Location = New System.Drawing.Point(927, 149)
        Me.txtLastUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLastUpdate.Name = "txtLastUpdate"
        Me.txtLastUpdate.Size = New System.Drawing.Size(132, 22)
        Me.txtLastUpdate.TabIndex = 46
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(825, 153)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 17)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Last Update :"
        '
        'txtCopyPR
        '
        Me.txtCopyPR.Location = New System.Drawing.Point(927, 90)
        Me.txtCopyPR.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCopyPR.Multiline = True
        Me.txtCopyPR.Name = "txtCopyPR"
        Me.txtCopyPR.Size = New System.Drawing.Size(412, 56)
        Me.txtCopyPR.TabIndex = 44
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(846, 94)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 17)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Copy PR :"
        '
        'txtCopyReq
        '
        Me.txtCopyReq.Location = New System.Drawing.Point(927, 20)
        Me.txtCopyReq.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCopyReq.Multiline = True
        Me.txtCopyReq.Name = "txtCopyReq"
        Me.txtCopyReq.Size = New System.Drawing.Size(412, 67)
        Me.txtCopyReq.TabIndex = 42
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(813, 23)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 17)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Copy Request :"
        '
        'txtPRApproval
        '
        Me.txtPRApproval.Location = New System.Drawing.Point(598, 105)
        Me.txtPRApproval.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPRApproval.Name = "txtPRApproval"
        Me.txtPRApproval.Size = New System.Drawing.Size(196, 22)
        Me.txtPRApproval.TabIndex = 40
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(493, 108)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 17)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "PR Approval :"
        '
        'txtReqApproval
        '
        Me.txtReqApproval.Location = New System.Drawing.Point(598, 76)
        Me.txtReqApproval.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReqApproval.Name = "txtReqApproval"
        Me.txtReqApproval.Size = New System.Drawing.Size(196, 22)
        Me.txtReqApproval.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(459, 80)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 17)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Request Approval :"
        '
        'txtAdminATK
        '
        Me.txtAdminATK.Location = New System.Drawing.Point(598, 20)
        Me.txtAdminATK.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAdminATK.Name = "txtAdminATK"
        Me.txtAdminATK.Size = New System.Drawing.Size(196, 22)
        Me.txtAdminATK.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(502, 23)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 17)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Admin ATK :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 119)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Customer :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(73, 87)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 17)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Site :"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Location = New System.Drawing.Point(131, 52)
        Me.txtEmailAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(217, 22)
        Me.txtEmailAddress.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 17)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Email Address :"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(131, 20)
        Me.txtUserID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(217, 22)
        Me.txtUserID.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 17)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "UserID :"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 218)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1792, 351)
        Me.Panel2.TabIndex = 31
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransID, Me.UserID, Me.EmailAddress, Me.Site, Me.StorerKey, Me.AdminATK, Me.AdminGA, Me.ReqApproval, Me.PRApproval, Me.CopyReq, Me.CopyPR})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1792, 351)
        Me.DataGridView1.TabIndex = 1
        '
        'TransID
        '
        Me.TransID.DataPropertyName = "TransID"
        Me.TransID.HeaderText = "TransID"
        Me.TransID.Name = "TransID"
        Me.TransID.ReadOnly = True
        Me.TransID.Visible = False
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "UserID"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'EmailAddress
        '
        Me.EmailAddress.DataPropertyName = "EmailAddress"
        Me.EmailAddress.HeaderText = "EmailAddress"
        Me.EmailAddress.Name = "EmailAddress"
        Me.EmailAddress.ReadOnly = True
        '
        'Site
        '
        Me.Site.DataPropertyName = "Site"
        Me.Site.HeaderText = "Site"
        Me.Site.Name = "Site"
        Me.Site.ReadOnly = True
        '
        'StorerKey
        '
        Me.StorerKey.DataPropertyName = "StorerKey"
        Me.StorerKey.HeaderText = "StorerKey"
        Me.StorerKey.Name = "StorerKey"
        Me.StorerKey.ReadOnly = True
        '
        'AdminATK
        '
        Me.AdminATK.DataPropertyName = "AdminATK"
        Me.AdminATK.HeaderText = "AdminATK"
        Me.AdminATK.Name = "AdminATK"
        Me.AdminATK.ReadOnly = True
        '
        'AdminGA
        '
        Me.AdminGA.DataPropertyName = "AdminGA"
        Me.AdminGA.HeaderText = "AdminGA"
        Me.AdminGA.Name = "AdminGA"
        Me.AdminGA.ReadOnly = True
        '
        'ReqApproval
        '
        Me.ReqApproval.DataPropertyName = "ReqApproval"
        Me.ReqApproval.HeaderText = "ReqApproval"
        Me.ReqApproval.Name = "ReqApproval"
        Me.ReqApproval.ReadOnly = True
        '
        'PRApproval
        '
        Me.PRApproval.DataPropertyName = "PRApproval"
        Me.PRApproval.HeaderText = "PRApproval"
        Me.PRApproval.Name = "PRApproval"
        Me.PRApproval.ReadOnly = True
        '
        'CopyReq
        '
        Me.CopyReq.DataPropertyName = "CopyReq"
        Me.CopyReq.HeaderText = "CopyReq"
        Me.CopyReq.Name = "CopyReq"
        Me.CopyReq.ReadOnly = True
        '
        'CopyPR
        '
        Me.CopyPR.DataPropertyName = "CopyPR"
        Me.CopyPR.HeaderText = "CopyPR"
        Me.CopyPR.Name = "CopyPR"
        Me.CopyPR.ReadOnly = True
        '
        'txtTransID
        '
        Me.txtTransID.Location = New System.Drawing.Point(1367, 153)
        Me.txtTransID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTransID.Name = "txtTransID"
        Me.txtTransID.Size = New System.Drawing.Size(196, 22)
        Me.txtTransID.TabIndex = 54
        '
        'frmUserConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1792, 569)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmUserConfig"
        Me.Text = "User Config"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents NewToolStripButton As ToolStripButton
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtAdminGA As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents cbSite As ComboBox
    Friend WithEvents cbCustomer As ComboBox
    Friend WithEvents txtUpdatedBy As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtLastUpdate As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCopyPR As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCopyReq As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPRApproval As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtReqApproval As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAdminATK As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEmailAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TransID As DataGridViewTextBoxColumn
    Friend WithEvents UserID As DataGridViewTextBoxColumn
    Friend WithEvents EmailAddress As DataGridViewTextBoxColumn
    Friend WithEvents Site As DataGridViewTextBoxColumn
    Friend WithEvents StorerKey As DataGridViewTextBoxColumn
    Friend WithEvents AdminATK As DataGridViewTextBoxColumn
    Friend WithEvents AdminGA As DataGridViewTextBoxColumn
    Friend WithEvents ReqApproval As DataGridViewTextBoxColumn
    Friend WithEvents PRApproval As DataGridViewTextBoxColumn
    Friend WithEvents CopyReq As DataGridViewTextBoxColumn
    Friend WithEvents CopyPR As DataGridViewTextBoxColumn
    Friend WithEvents txtTransID As TextBox
End Class
