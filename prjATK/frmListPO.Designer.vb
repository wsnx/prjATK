<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListPO
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cbSite = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnRevisi = New System.Windows.Forms.Button()
        Me.btnNotApprove = New System.Windows.Forms.Button()
        Me.btnFollowUp = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdWait2 = New System.Windows.Forms.RadioButton()
        Me.rbApproved = New System.Windows.Forms.RadioButton()
        Me.rbCreated = New System.Windows.Forms.RadioButton()
        Me.rbWait = New System.Windows.Forms.RadioButton()
        Me.rbClose = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MainTransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaSite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StorerKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TglTransaksi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InputBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApprovedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.TransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRNoDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KodeBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Satuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstTotPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiBeliOlehGA = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuApprove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRevisi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNotApprove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFollowUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbSite
        '
        Me.cbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSite.Enabled = False
        Me.cbSite.FormattingEnabled = True
        Me.cbSite.Location = New System.Drawing.Point(78, 6)
        Me.cbSite.Margin = New System.Windows.Forms.Padding(4)
        Me.cbSite.Name = "cbSite"
        Me.cbSite.Size = New System.Drawing.Size(292, 24)
        Me.cbSite.TabIndex = 34
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 9)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 17)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Site :"
        '
        'btnRevisi
        '
        Me.btnRevisi.Location = New System.Drawing.Point(1143, 15)
        Me.btnRevisi.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRevisi.Name = "btnRevisi"
        Me.btnRevisi.Size = New System.Drawing.Size(123, 28)
        Me.btnRevisi.TabIndex = 33
        Me.btnRevisi.Text = "&Revisi"
        Me.btnRevisi.UseVisualStyleBackColor = True
        Me.btnRevisi.Visible = False
        '
        'btnNotApprove
        '
        Me.btnNotApprove.Location = New System.Drawing.Point(891, 15)
        Me.btnNotApprove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNotApprove.Name = "btnNotApprove"
        Me.btnNotApprove.Size = New System.Drawing.Size(111, 28)
        Me.btnNotApprove.TabIndex = 32
        Me.btnNotApprove.Text = "&Not Approve on Selected Item"
        Me.btnNotApprove.UseVisualStyleBackColor = True
        Me.btnNotApprove.Visible = False
        '
        'btnFollowUp
        '
        Me.btnFollowUp.Location = New System.Drawing.Point(1010, 15)
        Me.btnFollowUp.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFollowUp.Name = "btnFollowUp"
        Me.btnFollowUp.Size = New System.Drawing.Size(125, 28)
        Me.btnFollowUp.TabIndex = 31
        Me.btnFollowUp.Text = "&Follow Up on Selected Item"
        Me.btnFollowUp.UseVisualStyleBackColor = True
        Me.btnFollowUp.Visible = False
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(796, 15)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(87, 28)
        Me.btnApprove.TabIndex = 30
        Me.btnApprove.Text = "&Approve on Selected Item"
        Me.btnApprove.UseVisualStyleBackColor = True
        Me.btnApprove.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdWait2)
        Me.GroupBox1.Controls.Add(Me.rbApproved)
        Me.GroupBox1.Controls.Add(Me.rbCreated)
        Me.GroupBox1.Controls.Add(Me.rbWait)
        Me.GroupBox1.Controls.Add(Me.rbClose)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 35)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(770, 49)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'rdWait2
        '
        Me.rdWait2.AutoSize = True
        Me.rdWait2.Enabled = False
        Me.rdWait2.Location = New System.Drawing.Point(308, 18)
        Me.rdWait2.Margin = New System.Windows.Forms.Padding(4)
        Me.rdWait2.Name = "rdWait2"
        Me.rdWait2.Size = New System.Drawing.Size(189, 21)
        Me.rdWait2.TabIndex = 8
        Me.rdWait2.Text = "Waiting For 2nd Approval"
        Me.rdWait2.UseVisualStyleBackColor = True
        '
        'rbApproved
        '
        Me.rbApproved.AutoSize = True
        Me.rbApproved.Location = New System.Drawing.Point(516, 18)
        Me.rbApproved.Margin = New System.Windows.Forms.Padding(4)
        Me.rbApproved.Name = "rbApproved"
        Me.rbApproved.Size = New System.Drawing.Size(90, 21)
        Me.rbApproved.TabIndex = 7
        Me.rbApproved.Text = "Approved"
        Me.rbApproved.UseVisualStyleBackColor = True
        '
        'rbCreated
        '
        Me.rbCreated.AutoSize = True
        Me.rbCreated.Location = New System.Drawing.Point(8, 18)
        Me.rbCreated.Margin = New System.Windows.Forms.Padding(4)
        Me.rbCreated.Name = "rbCreated"
        Me.rbCreated.Size = New System.Drawing.Size(79, 21)
        Me.rbCreated.TabIndex = 4
        Me.rbCreated.Text = "Created"
        Me.rbCreated.UseVisualStyleBackColor = True
        '
        'rbWait
        '
        Me.rbWait.AutoSize = True
        Me.rbWait.Checked = True
        Me.rbWait.Location = New System.Drawing.Point(127, 18)
        Me.rbWait.Margin = New System.Windows.Forms.Padding(4)
        Me.rbWait.Name = "rbWait"
        Me.rbWait.Size = New System.Drawing.Size(161, 21)
        Me.rbWait.TabIndex = 6
        Me.rbWait.TabStop = True
        Me.rbWait.Text = "Waiting For Approval"
        Me.rbWait.UseVisualStyleBackColor = True
        '
        'rbClose
        '
        Me.rbClose.AutoSize = True
        Me.rbClose.Location = New System.Drawing.Point(630, 18)
        Me.rbClose.Margin = New System.Windows.Forms.Padding(4)
        Me.rbClose.Name = "rbClose"
        Me.rbClose.Size = New System.Drawing.Size(129, 21)
        Me.rbClose.TabIndex = 5
        Me.rbClose.Text = "Closed Request"
        Me.rbClose.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MainTransID, Me.PONo, Me.NamaSite, Me.StorerKey, Me.TglTransaksi, Me.Status, Me.InputBy, Me.ApprovedBy})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(18, 92)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Size = New System.Drawing.Size(1417, 242)
        Me.DataGridView1.TabIndex = 36
        '
        'MainTransID
        '
        Me.MainTransID.DataPropertyName = "TransID"
        Me.MainTransID.HeaderText = "TransID"
        Me.MainTransID.Name = "MainTransID"
        Me.MainTransID.ReadOnly = True
        Me.MainTransID.Visible = False
        Me.MainTransID.Width = 83
        '
        'PONo
        '
        Me.PONo.DataPropertyName = "PONo"
        Me.PONo.HeaderText = "PONo"
        Me.PONo.Name = "PONo"
        Me.PONo.ReadOnly = True
        Me.PONo.Width = 75
        '
        'NamaSite
        '
        Me.NamaSite.DataPropertyName = "NamaSite"
        Me.NamaSite.HeaderText = "NamaSite"
        Me.NamaSite.Name = "NamaSite"
        Me.NamaSite.ReadOnly = True
        Me.NamaSite.Width = 98
        '
        'StorerKey
        '
        Me.StorerKey.DataPropertyName = "StorerKey"
        Me.StorerKey.HeaderText = "StorerKey"
        Me.StorerKey.Name = "StorerKey"
        Me.StorerKey.ReadOnly = True
        '
        'TglTransaksi
        '
        Me.TglTransaksi.DataPropertyName = "TglTransaksi"
        Me.TglTransaksi.HeaderText = "TglTransaksi"
        Me.TglTransaksi.Name = "TglTransaksi"
        Me.TglTransaksi.ReadOnly = True
        Me.TglTransaksi.Width = 119
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 77
        '
        'InputBy
        '
        Me.InputBy.DataPropertyName = "InputBy"
        Me.InputBy.HeaderText = "InputBy"
        Me.InputBy.Name = "InputBy"
        Me.InputBy.ReadOnly = True
        Me.InputBy.Width = 84
        '
        'ApprovedBy
        '
        Me.ApprovedBy.DataPropertyName = "ApprovedBy"
        Me.ApprovedBy.HeaderText = "Approved By"
        Me.ApprovedBy.Name = "ApprovedBy"
        Me.ApprovedBy.ReadOnly = True
        Me.ApprovedBy.Width = 118
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransID, Me.PRNoDet, Me.KodeBarang, Me.NamaBarang, Me.Satuan, Me.Qty, Me.LastPrice, Me.EstTotPrice, Me.Keterangan, Me.DiBeliOlehGA})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView2.Location = New System.Drawing.Point(18, 342)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView2.Size = New System.Drawing.Size(1417, 339)
        Me.DataGridView2.TabIndex = 37
        '
        'TransID
        '
        Me.TransID.DataPropertyName = "TransID"
        Me.TransID.HeaderText = "TransID"
        Me.TransID.Name = "TransID"
        Me.TransID.ReadOnly = True
        Me.TransID.Visible = False
        '
        'PRNoDet
        '
        Me.PRNoDet.DataPropertyName = "PRNo"
        Me.PRNoDet.HeaderText = "PRNo"
        Me.PRNoDet.Name = "PRNoDet"
        Me.PRNoDet.ReadOnly = True
        Me.PRNoDet.Width = 150
        '
        'KodeBarang
        '
        Me.KodeBarang.DataPropertyName = "KodeBarang"
        Me.KodeBarang.HeaderText = "KodeBarang"
        Me.KodeBarang.Name = "KodeBarang"
        Me.KodeBarang.ReadOnly = True
        Me.KodeBarang.Visible = False
        Me.KodeBarang.Width = 150
        '
        'NamaBarang
        '
        Me.NamaBarang.DataPropertyName = "NamaBarang"
        Me.NamaBarang.HeaderText = "NamaBarang"
        Me.NamaBarang.Name = "NamaBarang"
        Me.NamaBarang.ReadOnly = True
        Me.NamaBarang.Width = 150
        '
        'Satuan
        '
        Me.Satuan.DataPropertyName = "UOM"
        Me.Satuan.HeaderText = "Satuan"
        Me.Satuan.Name = "Satuan"
        Me.Satuan.ReadOnly = True
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        '
        'LastPrice
        '
        Me.LastPrice.DataPropertyName = "LastPrice"
        DataGridViewCellStyle5.Format = "N0"
        Me.LastPrice.DefaultCellStyle = DataGridViewCellStyle5
        Me.LastPrice.HeaderText = "LastPrice"
        Me.LastPrice.Name = "LastPrice"
        Me.LastPrice.ReadOnly = True
        '
        'EstTotPrice
        '
        Me.EstTotPrice.DataPropertyName = "EstTotPrice"
        DataGridViewCellStyle6.Format = "N0"
        Me.EstTotPrice.DefaultCellStyle = DataGridViewCellStyle6
        Me.EstTotPrice.HeaderText = "EstTotPrice"
        Me.EstTotPrice.Name = "EstTotPrice"
        Me.EstTotPrice.ReadOnly = True
        '
        'Keterangan
        '
        Me.Keterangan.DataPropertyName = "Keterangan"
        Me.Keterangan.HeaderText = "Keterangan"
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.ReadOnly = True
        Me.Keterangan.Width = 200
        '
        'DiBeliOlehGA
        '
        Me.DiBeliOlehGA.DataPropertyName = "PurchasedByGA"
        Me.DiBeliOlehGA.HeaderText = "DiBeliOlehGA"
        Me.DiBeliOlehGA.Name = "DiBeliOlehGA"
        Me.DiBeliOlehGA.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuApprove, Me.mnuRevisi, Me.mnuNotApprove, Me.mnuFollowUp})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(183, 108)
        '
        'mnuApprove
        '
        Me.mnuApprove.Name = "mnuApprove"
        Me.mnuApprove.Size = New System.Drawing.Size(182, 26)
        Me.mnuApprove.Text = "Disetujui"
        '
        'mnuRevisi
        '
        Me.mnuRevisi.Name = "mnuRevisi"
        Me.mnuRevisi.Size = New System.Drawing.Size(182, 26)
        Me.mnuRevisi.Text = "Revisi"
        '
        'mnuNotApprove
        '
        Me.mnuNotApprove.Name = "mnuNotApprove"
        Me.mnuNotApprove.Size = New System.Drawing.Size(182, 26)
        Me.mnuNotApprove.Text = "Tidak Disetujui"
        '
        'mnuFollowUp
        '
        Me.mnuFollowUp.Name = "mnuFollowUp"
        Me.mnuFollowUp.Size = New System.Drawing.Size(182, 26)
        Me.mnuFollowUp.Text = "Follow-up"
        '
        'frmListPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1448, 694)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cbSite)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnRevisi)
        Me.Controls.Add(Me.btnNotApprove)
        Me.Controls.Add(Me.btnFollowUp)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmListPO"
        Me.Text = "frmListPO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbSite As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnRevisi As System.Windows.Forms.Button
    Friend WithEvents btnNotApprove As System.Windows.Forms.Button
    Friend WithEvents btnFollowUp As System.Windows.Forms.Button
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdWait2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbApproved As System.Windows.Forms.RadioButton
    Friend WithEvents rbCreated As System.Windows.Forms.RadioButton
    Friend WithEvents rbWait As System.Windows.Forms.RadioButton
    Friend WithEvents rbClose As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents MainTransID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamaSite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StorerKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TglTransaksi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InputBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents TransID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRNoDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KodeBarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamaBarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Satuan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstTotPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Keterangan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiBeliOlehGA As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents mnuApprove As ToolStripMenuItem
    Friend WithEvents mnuRevisi As ToolStripMenuItem
    Friend WithEvents mnuNotApprove As ToolStripMenuItem
    Friend WithEvents mnuFollowUp As ToolStripMenuItem
End Class
