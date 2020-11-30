<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListReqATK
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.TransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReqNoDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaKaryawan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KodeBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Satuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MainTransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReqNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaSite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StorerKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TglTransaksi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InputBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApprovalBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuApprove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRevisi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNotApprove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFollowUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbCreated = New System.Windows.Forms.RadioButton()
        Me.rbClose = New System.Windows.Forms.RadioButton()
        Me.rbWait = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbApproved = New System.Windows.Forms.RadioButton()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.btnFollowUp = New System.Windows.Forms.Button()
        Me.btnNotApprove = New System.Windows.Forms.Button()
        Me.btnRevisi = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbSite = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransID, Me.ReqNoDet, Me.NamaKaryawan, Me.KodeBarang, Me.NamaBarang, Me.Satuan, Me.Qty, Me.Keterangan})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView2.Location = New System.Drawing.Point(4, 4)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView2.Name = "DataGridView2"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView2.Size = New System.Drawing.Size(1287, 262)
        Me.DataGridView2.TabIndex = 1
        '
        'TransID
        '
        Me.TransID.DataPropertyName = "TransID"
        Me.TransID.HeaderText = "TransID"
        Me.TransID.Name = "TransID"
        Me.TransID.ReadOnly = True
        Me.TransID.Visible = False
        '
        'ReqNoDet
        '
        Me.ReqNoDet.DataPropertyName = "ReqNo"
        Me.ReqNoDet.HeaderText = "NomorPermintaan"
        Me.ReqNoDet.Name = "ReqNoDet"
        Me.ReqNoDet.Width = 150
        '
        'NamaKaryawan
        '
        Me.NamaKaryawan.DataPropertyName = "NamaKaryawan"
        Me.NamaKaryawan.HeaderText = "NamaKaryawan"
        Me.NamaKaryawan.Name = "NamaKaryawan"
        Me.NamaKaryawan.ReadOnly = True
        Me.NamaKaryawan.Width = 150
        '
        'KodeBarang
        '
        Me.KodeBarang.DataPropertyName = "KodeBarang"
        Me.KodeBarang.HeaderText = "KodeBarang"
        Me.KodeBarang.Name = "KodeBarang"
        Me.KodeBarang.ReadOnly = True
        Me.KodeBarang.Visible = False
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
        'Keterangan
        '
        Me.Keterangan.DataPropertyName = "Keterangan"
        Me.Keterangan.HeaderText = "Keterangan"
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.ReadOnly = True
        Me.Keterangan.Width = 200
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MainTransID, Me.ReqNo, Me.NamaSite, Me.StorerKey, Me.TglTransaksi, Me.Status, Me.InputBy, Me.ApprovalBy})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.Location = New System.Drawing.Point(4, 25)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1287, 210)
        Me.DataGridView1.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.DataGridView1, "Klik Kanan Untuk Lihat Menu")
        '
        'MainTransID
        '
        Me.MainTransID.DataPropertyName = "TransID"
        Me.MainTransID.HeaderText = "TransID"
        Me.MainTransID.Name = "MainTransID"
        Me.MainTransID.Visible = False
        '
        'ReqNo
        '
        Me.ReqNo.DataPropertyName = "ReqNo"
        Me.ReqNo.HeaderText = "NomorPermintaan"
        Me.ReqNo.Name = "ReqNo"
        Me.ReqNo.ReadOnly = True
        Me.ReqNo.Width = 150
        '
        'NamaSite
        '
        Me.NamaSite.DataPropertyName = "NamaSite"
        Me.NamaSite.HeaderText = "NamaSite"
        Me.NamaSite.Name = "NamaSite"
        Me.NamaSite.ReadOnly = True
        Me.NamaSite.Width = 150
        '
        'StorerKey
        '
        Me.StorerKey.DataPropertyName = "StorerKey"
        Me.StorerKey.HeaderText = "StorerKey"
        Me.StorerKey.Name = "StorerKey"
        Me.StorerKey.ReadOnly = True
        Me.StorerKey.Width = 150
        '
        'TglTransaksi
        '
        Me.TglTransaksi.DataPropertyName = "TglTransaksi"
        Me.TglTransaksi.HeaderText = "TglTransaksi"
        Me.TglTransaksi.Name = "TglTransaksi"
        Me.TglTransaksi.ReadOnly = True
        Me.TglTransaksi.Width = 150
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 150
        '
        'InputBy
        '
        Me.InputBy.DataPropertyName = "InputBy"
        Me.InputBy.HeaderText = "InputBy"
        Me.InputBy.Name = "InputBy"
        '
        'ApprovalBy
        '
        Me.ApprovalBy.DataPropertyName = "ApprovalBy"
        Me.ApprovalBy.HeaderText = "ApprovalBy"
        Me.ApprovalBy.Name = "ApprovalBy"
        Me.ApprovalBy.ReadOnly = True
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
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(16, 89)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView2)
        Me.SplitContainer1.Panel2MinSize = 75
        Me.SplitContainer1.Size = New System.Drawing.Size(1295, 512)
        Me.SplitContainer1.SplitterDistance = 238
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(8, 5)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(411, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Klik barisnya untuk lihat detail, terus klik kanan untuk action-nya"
        Me.Label1.Visible = False
        '
        'rbCreated
        '
        Me.rbCreated.AutoSize = True
        Me.rbCreated.Location = New System.Drawing.Point(8, 18)
        Me.rbCreated.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbCreated.Name = "rbCreated"
        Me.rbCreated.Size = New System.Drawing.Size(79, 21)
        Me.rbCreated.TabIndex = 4
        Me.rbCreated.Text = "Created"
        Me.rbCreated.UseVisualStyleBackColor = True
        '
        'rbClose
        '
        Me.rbClose.AutoSize = True
        Me.rbClose.Location = New System.Drawing.Point(443, 18)
        Me.rbClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbClose.Name = "rbClose"
        Me.rbClose.Size = New System.Drawing.Size(129, 21)
        Me.rbClose.TabIndex = 5
        Me.rbClose.Text = "Closed Request"
        Me.rbClose.UseVisualStyleBackColor = True
        '
        'rbWait
        '
        Me.rbWait.AutoSize = True
        Me.rbWait.Checked = True
        Me.rbWait.Location = New System.Drawing.Point(127, 18)
        Me.rbWait.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbWait.Name = "rbWait"
        Me.rbWait.Size = New System.Drawing.Size(161, 21)
        Me.rbWait.TabIndex = 6
        Me.rbWait.TabStop = True
        Me.rbWait.Text = "Waiting For Approval"
        Me.rbWait.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbApproved)
        Me.GroupBox1.Controls.Add(Me.rbCreated)
        Me.GroupBox1.Controls.Add(Me.rbWait)
        Me.GroupBox1.Controls.Add(Me.rbClose)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 32)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(601, 49)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'rbApproved
        '
        Me.rbApproved.AutoSize = True
        Me.rbApproved.Location = New System.Drawing.Point(315, 18)
        Me.rbApproved.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbApproved.Name = "rbApproved"
        Me.rbApproved.Size = New System.Drawing.Size(90, 21)
        Me.rbApproved.TabIndex = 7
        Me.rbApproved.Text = "Approved"
        Me.rbApproved.UseVisualStyleBackColor = True
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(652, 30)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(163, 28)
        Me.btnApprove.TabIndex = 8
        Me.btnApprove.Text = "&Approve on Selected Item"
        Me.btnApprove.UseVisualStyleBackColor = True
        Me.btnApprove.Visible = False
        '
        'btnFollowUp
        '
        Me.btnFollowUp.Location = New System.Drawing.Point(992, 30)
        Me.btnFollowUp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnFollowUp.Name = "btnFollowUp"
        Me.btnFollowUp.Size = New System.Drawing.Size(161, 28)
        Me.btnFollowUp.TabIndex = 9
        Me.btnFollowUp.Text = "&Follow Up on Selected Item"
        Me.btnFollowUp.UseVisualStyleBackColor = True
        Me.btnFollowUp.Visible = False
        '
        'btnNotApprove
        '
        Me.btnNotApprove.Location = New System.Drawing.Point(823, 30)
        Me.btnNotApprove.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNotApprove.Name = "btnNotApprove"
        Me.btnNotApprove.Size = New System.Drawing.Size(161, 28)
        Me.btnNotApprove.TabIndex = 11
        Me.btnNotApprove.Text = "&Not Approve on Selected Item"
        Me.btnNotApprove.UseVisualStyleBackColor = True
        Me.btnNotApprove.Visible = False
        '
        'btnRevisi
        '
        Me.btnRevisi.Location = New System.Drawing.Point(1161, 30)
        Me.btnRevisi.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRevisi.Name = "btnRevisi"
        Me.btnRevisi.Size = New System.Drawing.Size(123, 28)
        Me.btnRevisi.TabIndex = 13
        Me.btnRevisi.Text = "&Revisi"
        Me.btnRevisi.UseVisualStyleBackColor = True
        Me.btnRevisi.Visible = False
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Klik Kanan"
        '
        'cbSite
        '
        Me.cbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSite.Enabled = False
        Me.cbSite.FormattingEnabled = True
        Me.cbSite.Location = New System.Drawing.Point(73, 5)
        Me.cbSite.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbSite.Name = "cbSite"
        Me.cbSite.Size = New System.Drawing.Size(292, 24)
        Me.cbSite.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 9)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 17)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Site :"
        '
        'frmListReqATK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1327, 615)
        Me.Controls.Add(Me.cbSite)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnRevisi)
        Me.Controls.Add(Me.btnNotApprove)
        Me.Controls.Add(Me.btnFollowUp)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmListReqATK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List Permintaan ATK"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents rbCreated As System.Windows.Forms.RadioButton
    Friend WithEvents rbClose As System.Windows.Forms.RadioButton
    Friend WithEvents rbWait As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbApproved As System.Windows.Forms.RadioButton
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents btnFollowUp As System.Windows.Forms.Button
    Friend WithEvents btnNotApprove As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuApprove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRevisi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNotApprove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFollowUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRevisi As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TransID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReqNoDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamaKaryawan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KodeBarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamaBarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Satuan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Keterangan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MainTransID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReqNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamaSite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StorerKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TglTransaksi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InputBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovalBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbSite As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
