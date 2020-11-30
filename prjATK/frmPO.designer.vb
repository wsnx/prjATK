<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPO
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPO))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.txtNOtes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTransID = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ckAttn = New System.Windows.Forms.CheckBox()
        Me.TxtAttnTo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ckTelp = New System.Windows.Forms.CheckBox()
        Me.txtTlp = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ckAddress3 = New System.Windows.Forms.CheckBox()
        Me.ckAddress2 = New System.Windows.Forms.CheckBox()
        Me.txtAddress3 = New System.Windows.Forms.TextBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.cbCompany = New System.Windows.Forms.ComboBox()
        Me.ckAddress1 = New System.Windows.Forms.CheckBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Dgv2 = New System.Windows.Forms.DataGridView()
        Me.ID_PO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SKU_PO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description_PO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRNo_PO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_PO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Price_PO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total_PO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_PR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Dgv = New System.Windows.Forms.DataGridView()
        Me.IdPR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KodeBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM_PR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstTotPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PurchasedByGA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnAdd = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnShow = New System.Windows.Forms.Button()
        Me.BtnAddNew = New System.Windows.Forms.ToolStripButton()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton()
        Me.BtnFirst = New System.Windows.Forms.ToolStripButton()
        Me.BtnPrev = New System.Windows.Forms.ToolStripButton()
        Me.BtnNext = New System.Windows.Forms.ToolStripButton()
        Me.BtnLast = New System.Windows.Forms.ToolStripButton()
        Me.btnMintaApproval = New System.Windows.Forms.ToolStripButton()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.Dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.ComboBox1)
        Me.Panel3.Controls.Add(Me.txtNOtes)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtTransID)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.ckAttn)
        Me.Panel3.Controls.Add(Me.TxtAttnTo)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.ckTelp)
        Me.Panel3.Controls.Add(Me.txtTlp)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.ckAddress3)
        Me.Panel3.Controls.Add(Me.ckAddress2)
        Me.Panel3.Controls.Add(Me.txtAddress3)
        Me.Panel3.Controls.Add(Me.txtAddress2)
        Me.Panel3.Controls.Add(Me.cbCompany)
        Me.Panel3.Controls.Add(Me.ckAddress1)
        Me.Panel3.Controls.Add(Me.txtAddress1)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Location = New System.Drawing.Point(12, 114)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1741, 309)
        Me.Panel3.TabIndex = 63
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(280, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 17)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Job Type"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"GII", "GIP"})
        Me.ComboBox1.Location = New System.Drawing.Point(353, 164)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox1.TabIndex = 88
        '
        'txtNOtes
        '
        Me.txtNOtes.Location = New System.Drawing.Point(91, 200)
        Me.txtNOtes.Multiline = True
        Me.txtNOtes.Name = "txtNOtes"
        Me.txtNOtes.Size = New System.Drawing.Size(562, 91)
        Me.txtNOtes.TabIndex = 84
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 200)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 17)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Notes :"
        '
        'txtTransID
        '
        Me.txtTransID.Location = New System.Drawing.Point(274, 135)
        Me.txtTransID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTransID.Name = "txtTransID"
        Me.txtTransID.ReadOnly = True
        Me.txtTransID.Size = New System.Drawing.Size(97, 22)
        Me.txtTransID.TabIndex = 83
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(558, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 23)
        Me.Button1.TabIndex = 82
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ckAttn
        '
        Me.ckAttn.AutoSize = True
        Me.ckAttn.Location = New System.Drawing.Point(559, 157)
        Me.ckAttn.Name = "ckAttn"
        Me.ckAttn.Size = New System.Drawing.Size(54, 21)
        Me.ckAttn.TabIndex = 81
        Me.ckAttn.Text = "Edit"
        Me.ckAttn.UseVisualStyleBackColor = True
        '
        'TxtAttnTo
        '
        Me.TxtAttnTo.Enabled = False
        Me.TxtAttnTo.Location = New System.Drawing.Point(91, 166)
        Me.TxtAttnTo.Name = "TxtAttnTo"
        Me.TxtAttnTo.Size = New System.Drawing.Size(176, 22)
        Me.TxtAttnTo.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(22, 167)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 17)
        Me.Label15.TabIndex = 79
        Me.Label15.Text = "Attn To :"
        '
        'ckTelp
        '
        Me.ckTelp.AutoSize = True
        Me.ckTelp.Location = New System.Drawing.Point(559, 131)
        Me.ckTelp.Name = "ckTelp"
        Me.ckTelp.Size = New System.Drawing.Size(54, 21)
        Me.ckTelp.TabIndex = 78
        Me.ckTelp.Text = "Edit"
        Me.ckTelp.UseVisualStyleBackColor = True
        '
        'txtTlp
        '
        Me.txtTlp.Enabled = False
        Me.txtTlp.Location = New System.Drawing.Point(91, 135)
        Me.txtTlp.Name = "txtTlp"
        Me.txtTlp.Size = New System.Drawing.Size(176, 22)
        Me.txtTlp.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(40, 135)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 17)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Telp :"
        '
        'ckAddress3
        '
        Me.ckAddress3.AutoSize = True
        Me.ckAddress3.Location = New System.Drawing.Point(559, 108)
        Me.ckAddress3.Name = "ckAddress3"
        Me.ckAddress3.Size = New System.Drawing.Size(54, 21)
        Me.ckAddress3.TabIndex = 75
        Me.ckAddress3.Text = "Edit"
        Me.ckAddress3.UseVisualStyleBackColor = True
        '
        'ckAddress2
        '
        Me.ckAddress2.AutoSize = True
        Me.ckAddress2.Location = New System.Drawing.Point(559, 83)
        Me.ckAddress2.Name = "ckAddress2"
        Me.ckAddress2.Size = New System.Drawing.Size(54, 21)
        Me.ckAddress2.TabIndex = 74
        Me.ckAddress2.Text = "Edit"
        Me.ckAddress2.UseVisualStyleBackColor = True
        '
        'txtAddress3
        '
        Me.txtAddress3.Enabled = False
        Me.txtAddress3.Location = New System.Drawing.Point(91, 109)
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(460, 22)
        Me.txtAddress3.TabIndex = 3
        '
        'txtAddress2
        '
        Me.txtAddress2.Enabled = False
        Me.txtAddress2.Location = New System.Drawing.Point(91, 83)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(460, 22)
        Me.txtAddress2.TabIndex = 2
        '
        'cbCompany
        '
        Me.cbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCompany.FormattingEnabled = True
        Me.cbCompany.Location = New System.Drawing.Point(92, 32)
        Me.cbCompany.Name = "cbCompany"
        Me.cbCompany.Size = New System.Drawing.Size(460, 24)
        Me.cbCompany.TabIndex = 0
        '
        'ckAddress1
        '
        Me.ckAddress1.AutoSize = True
        Me.ckAddress1.Location = New System.Drawing.Point(559, 58)
        Me.ckAddress1.Name = "ckAddress1"
        Me.ckAddress1.Size = New System.Drawing.Size(54, 21)
        Me.ckAddress1.TabIndex = 70
        Me.ckAddress1.Text = "Edit"
        Me.ckAddress1.UseVisualStyleBackColor = True
        '
        'txtAddress1
        '
        Me.txtAddress1.Enabled = False
        Me.txtAddress1.Location = New System.Drawing.Point(91, 58)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(460, 22)
        Me.txtAddress1.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 109)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 17)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Address 3 :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 84)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 17)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Address 2 :"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(738, 26)
        Me.Panel5.TabIndex = 61
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(310, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Vendor :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 58)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 17)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "Address 1 :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 32)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 17)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Company :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 29)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 17)
        Me.Label11.TabIndex = 63
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblStatus)
        Me.Panel2.Controls.Add(Me.txtPONo)
        Me.Panel2.Controls.Add(Me.btnBrowse)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(13, 58)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1741, 49)
        Me.Panel2.TabIndex = 64
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(1080, 10)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(119, 39)
        Me.lblStatus.TabIndex = 63
        Me.lblStatus.Text = "Status"
        '
        'txtPONo
        '
        Me.txtPONo.Location = New System.Drawing.Point(78, 12)
        Me.txtPONo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.ReadOnly = True
        Me.txtPONo.Size = New System.Drawing.Size(252, 22)
        Me.txtPONo.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "PO No :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnAddNew, Me.ToolStripSeparator1, Me.BtnSave, Me.ToolStripSeparator4, Me.BtnPrint, Me.ToolStripSeparator2, Me.btnMintaApproval, Me.ToolStripSeparator5, Me.btnCancel, Me.ToolStripSeparator6, Me.BtnFirst, Me.BtnPrev, Me.BtnNext, Me.BtnLast})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1765, 50)
        Me.ToolStrip1.TabIndex = 65
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'Dgv2
        '
        Me.Dgv2.AllowUserToAddRows = False
        Me.Dgv2.AllowUserToDeleteRows = False
        Me.Dgv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_PO, Me.SKU_PO, Me.Description_PO, Me.PRNo_PO, Me.Qty_PO, Me.UOM, Me.Price_PO, Me.Total_PO, Me.ID_PR, Me.Delete})
        Me.Dgv2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Dgv2.Location = New System.Drawing.Point(12, 762)
        Me.Dgv2.Name = "Dgv2"
        Me.Dgv2.ReadOnly = True
        Me.Dgv2.RowHeadersWidth = 51
        Me.Dgv2.RowTemplate.Height = 24
        Me.Dgv2.Size = New System.Drawing.Size(1741, 271)
        Me.Dgv2.TabIndex = 67
        '
        'ID_PO
        '
        Me.ID_PO.DataPropertyName = "TransID"
        Me.ID_PO.HeaderText = "ID_PO"
        Me.ID_PO.MinimumWidth = 6
        Me.ID_PO.Name = "ID_PO"
        Me.ID_PO.ReadOnly = True
        Me.ID_PO.Width = 78
        '
        'SKU_PO
        '
        Me.SKU_PO.DataPropertyName = "KodeBarang"
        Me.SKU_PO.HeaderText = "SKU PO"
        Me.SKU_PO.MinimumWidth = 6
        Me.SKU_PO.Name = "SKU_PO"
        Me.SKU_PO.ReadOnly = True
        Me.SKU_PO.Width = 89
        '
        'Description_PO
        '
        Me.Description_PO.DataPropertyName = "Description"
        Me.Description_PO.HeaderText = "Description_PO"
        Me.Description_PO.MinimumWidth = 6
        Me.Description_PO.Name = "Description_PO"
        Me.Description_PO.ReadOnly = True
        Me.Description_PO.Width = 136
        '
        'PRNo_PO
        '
        Me.PRNo_PO.DataPropertyName = "PRNo"
        Me.PRNo_PO.HeaderText = "PRNo"
        Me.PRNo_PO.MinimumWidth = 6
        Me.PRNo_PO.Name = "PRNo_PO"
        Me.PRNo_PO.ReadOnly = True
        Me.PRNo_PO.Width = 74
        '
        'Qty_PO
        '
        Me.Qty_PO.DataPropertyName = "Qty"
        Me.Qty_PO.HeaderText = "Qty_PO"
        Me.Qty_PO.MinimumWidth = 6
        Me.Qty_PO.Name = "Qty_PO"
        Me.Qty_PO.ReadOnly = True
        Me.Qty_PO.Width = 87
        '
        'UOM
        '
        Me.UOM.DataPropertyName = "UOM"
        Me.UOM.HeaderText = "UOM"
        Me.UOM.MinimumWidth = 6
        Me.UOM.Name = "UOM"
        Me.UOM.ReadOnly = True
        Me.UOM.Width = 69
        '
        'Price_PO
        '
        Me.Price_PO.DataPropertyName = "LastPrice"
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Price_PO.DefaultCellStyle = DataGridViewCellStyle7
        Me.Price_PO.HeaderText = "Price by Unit"
        Me.Price_PO.MinimumWidth = 6
        Me.Price_PO.Name = "Price_PO"
        Me.Price_PO.ReadOnly = True
        Me.Price_PO.Width = 117
        '
        'Total_PO
        '
        Me.Total_PO.DataPropertyName = "EstTotPrice"
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Total_PO.DefaultCellStyle = DataGridViewCellStyle8
        Me.Total_PO.HeaderText = "Total Price"
        Me.Total_PO.MinimumWidth = 6
        Me.Total_PO.Name = "Total_PO"
        Me.Total_PO.ReadOnly = True
        Me.Total_PO.Width = 105
        '
        'ID_PR
        '
        Me.ID_PR.DataPropertyName = "ID_PR"
        Me.ID_PR.HeaderText = "ID_PR"
        Me.ID_PR.MinimumWidth = 6
        Me.ID_PR.Name = "ID_PR"
        Me.ID_PR.ReadOnly = True
        Me.ID_PR.Width = 77
        '
        'Delete
        '
        Me.Delete.DataPropertyName = "BtnDelete"
        Me.Delete.HeaderText = "Delete"
        Me.Delete.MinimumWidth = 6
        Me.Delete.Name = "Delete"
        Me.Delete.ReadOnly = True
        Me.Delete.Visible = False
        Me.Delete.Width = 55
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Dgv
        '
        Me.Dgv.AllowUserToAddRows = False
        Me.Dgv.AllowUserToDeleteRows = False
        Me.Dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdPR, Me.PONo, Me.PRNo, Me.Customer, Me.KodeBarang, Me.NamaBarang, Me.UOM_PR, Me.Qty, Me.LastPrice, Me.EstTotPrice, Me.PurchasedByGA, Me.BtnAdd})
        Me.Dgv.Location = New System.Drawing.Point(12, 478)
        Me.Dgv.Name = "Dgv"
        Me.Dgv.RowHeadersWidth = 51
        Me.Dgv.RowTemplate.Height = 24
        Me.Dgv.Size = New System.Drawing.Size(1741, 245)
        Me.Dgv.TabIndex = 0
        '
        'IdPR
        '
        Me.IdPR.DataPropertyName = "TransID"
        Me.IdPR.HeaderText = "TransID"
        Me.IdPR.MinimumWidth = 6
        Me.IdPR.Name = "IdPR"
        Me.IdPR.ReadOnly = True
        Me.IdPR.Visible = False
        Me.IdPR.Width = 87
        '
        'PONo
        '
        Me.PONo.DataPropertyName = "PONo"
        Me.PONo.HeaderText = "PONo"
        Me.PONo.MinimumWidth = 6
        Me.PONo.Name = "PONo"
        Me.PONo.Width = 75
        '
        'PRNo
        '
        Me.PRNo.DataPropertyName = "PRNo"
        Me.PRNo.HeaderText = "PRNo"
        Me.PRNo.MinimumWidth = 6
        Me.PRNo.Name = "PRNo"
        Me.PRNo.ReadOnly = True
        Me.PRNo.Width = 74
        '
        'Customer
        '
        Me.Customer.DataPropertyName = "EndUserName"
        Me.Customer.HeaderText = "Customer"
        Me.Customer.MinimumWidth = 6
        Me.Customer.Name = "Customer"
        Me.Customer.Width = 97
        '
        'KodeBarang
        '
        Me.KodeBarang.DataPropertyName = "KodeBarang"
        Me.KodeBarang.HeaderText = "KodeBarang"
        Me.KodeBarang.MinimumWidth = 6
        Me.KodeBarang.Name = "KodeBarang"
        Me.KodeBarang.Width = 116
        '
        'NamaBarang
        '
        Me.NamaBarang.DataPropertyName = "NamaBarang"
        Me.NamaBarang.HeaderText = "NamaBarang"
        Me.NamaBarang.MinimumWidth = 6
        Me.NamaBarang.Name = "NamaBarang"
        Me.NamaBarang.Width = 120
        '
        'UOM_PR
        '
        Me.UOM_PR.DataPropertyName = "UOM"
        Me.UOM_PR.HeaderText = "UOM"
        Me.UOM_PR.MinimumWidth = 6
        Me.UOM_PR.Name = "UOM_PR"
        Me.UOM_PR.Width = 69
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        Me.Qty.HeaderText = "Qty"
        Me.Qty.MinimumWidth = 6
        Me.Qty.Name = "Qty"
        Me.Qty.Width = 59
        '
        'LastPrice
        '
        Me.LastPrice.DataPropertyName = "LastPrice"
        Me.LastPrice.HeaderText = "LastPrice"
        Me.LastPrice.MinimumWidth = 6
        Me.LastPrice.Name = "LastPrice"
        Me.LastPrice.Width = 96
        '
        'EstTotPrice
        '
        Me.EstTotPrice.DataPropertyName = "EstTotPrice"
        Me.EstTotPrice.HeaderText = "EstTotPrice"
        Me.EstTotPrice.MinimumWidth = 6
        Me.EstTotPrice.Name = "EstTotPrice"
        Me.EstTotPrice.Width = 110
        '
        'PurchasedByGA
        '
        Me.PurchasedByGA.DataPropertyName = "PurchasedByGA"
        Me.PurchasedByGA.HeaderText = "PurchasedByGA"
        Me.PurchasedByGA.MinimumWidth = 6
        Me.PurchasedByGA.Name = "PurchasedByGA"
        Me.PurchasedByGA.Width = 141
        '
        'BtnAdd
        '
        Me.BtnAdd.DataPropertyName = "BtnAdd"
        Me.BtnAdd.HeaderText = "Add"
        Me.BtnAdd.MinimumWidth = 6
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Width = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 443)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(234, 17)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "- List PR yang belum di-buatkan PO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 726)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 17)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "- List PO"
        '
        'BtnShow
        '
        Me.BtnShow.BackColor = System.Drawing.Color.PapayaWhip
        Me.BtnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnShow.Location = New System.Drawing.Point(262, 439)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(156, 34)
        Me.BtnShow.TabIndex = 85
        Me.BtnShow.Text = "Show data Pending"
        Me.BtnShow.UseVisualStyleBackColor = False
        '
        'BtnAddNew
        '
        Me.BtnAddNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BtnAddNew.Image = Global.prjATKPr.My.Resources.Resources.Add_8x_16x
        Me.BtnAddNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAddNew.Name = "BtnAddNew"
        Me.BtnAddNew.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.BtnAddNew.Size = New System.Drawing.Size(57, 47)
        Me.BtnAddNew.Text = "Add"
        Me.BtnAddNew.Visible = False
        '
        'BtnSave
        '
        Me.BtnSave.Image = Global.prjATKPr.My.Resources.Resources.saveHS
        Me.BtnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(73, 32)
        Me.BtnSave.Text = "Save"
        '
        'BtnPrint
        '
        Me.BtnPrint.Image = Global.prjATKPr.My.Resources.Resources.PrintHS
        Me.BtnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(73, 32)
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.Visible = False
        '
        'BtnFirst
        '
        Me.BtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnFirst.Image = Global.prjATKPr.My.Resources.Resources.MoveFirsHS
        Me.BtnFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFirst.Name = "BtnFirst"
        Me.BtnFirst.Size = New System.Drawing.Size(23, 32)
        Me.BtnFirst.Text = "First"
        Me.BtnFirst.Visible = False
        '
        'BtnPrev
        '
        Me.BtnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPrev.Image = Global.prjATKPr.My.Resources.Resources.MovePreviousHS
        Me.BtnPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrev.Name = "BtnPrev"
        Me.BtnPrev.Size = New System.Drawing.Size(23, 22)
        Me.BtnPrev.Text = "Prev"
        Me.BtnPrev.Visible = False
        '
        'BtnNext
        '
        Me.BtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNext.Image = Global.prjATKPr.My.Resources.Resources.MoveNextHS
        Me.BtnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(23, 22)
        Me.BtnNext.Text = "Next"
        Me.BtnNext.Visible = False
        '
        'BtnLast
        '
        Me.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnLast.Image = Global.prjATKPr.My.Resources.Resources.MoveLastHS
        Me.BtnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnLast.Name = "BtnLast"
        Me.BtnLast.Size = New System.Drawing.Size(23, 22)
        Me.BtnLast.Text = "Last"
        Me.BtnLast.Visible = False
        '
        'btnMintaApproval
        '
        Me.btnMintaApproval.Image = Global.prjATKPr.My.Resources.Resources.SendEmail_16x
        Me.btnMintaApproval.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnMintaApproval.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMintaApproval.Name = "btnMintaApproval"
        Me.btnMintaApproval.Size = New System.Drawing.Size(169, 32)
        Me.btnMintaApproval.Text = "Minta Approval"
        Me.btnMintaApproval.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Image = Global.prjATKPr.My.Resources.Resources.Exit_16x
        Me.btnCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 32)
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.Visible = False
        '
        'btnBrowse
        '
        Me.btnBrowse.FlatAppearance.BorderSize = 0
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(338, 4)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(42, 45)
        Me.btnBrowse.TabIndex = 27
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'frmPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1765, 1045)
        Me.Controls.Add(Me.BtnShow)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Dgv2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Dgv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmPO"
        Me.Text = "PO"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.Dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ckAttn As System.Windows.Forms.CheckBox
    Friend WithEvents TxtAttnTo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ckTelp As System.Windows.Forms.CheckBox
    Friend WithEvents txtTlp As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ckAddress3 As System.Windows.Forms.CheckBox
    Friend WithEvents ckAddress2 As System.Windows.Forms.CheckBox
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents cbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents ckAddress1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnAddNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents Dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents Dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTransID As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnMintaApproval As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents BtnShow As Button
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents txtNOtes As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ID_PO As DataGridViewTextBoxColumn
    Friend WithEvents SKU_PO As DataGridViewTextBoxColumn
    Friend WithEvents Description_PO As DataGridViewTextBoxColumn
    Friend WithEvents PRNo_PO As DataGridViewTextBoxColumn
    Friend WithEvents Qty_PO As DataGridViewTextBoxColumn
    Friend WithEvents UOM As DataGridViewTextBoxColumn
    Friend WithEvents Price_PO As DataGridViewTextBoxColumn
    Friend WithEvents Total_PO As DataGridViewTextBoxColumn
    Friend WithEvents ID_PR As DataGridViewTextBoxColumn
    Friend WithEvents Delete As DataGridViewButtonColumn
    Friend WithEvents IdPR As DataGridViewTextBoxColumn
    Friend WithEvents PONo As DataGridViewTextBoxColumn
    Friend WithEvents PRNo As DataGridViewTextBoxColumn
    Friend WithEvents Customer As DataGridViewTextBoxColumn
    Friend WithEvents KodeBarang As DataGridViewTextBoxColumn
    Friend WithEvents NamaBarang As DataGridViewTextBoxColumn
    Friend WithEvents UOM_PR As DataGridViewTextBoxColumn
    Friend WithEvents Qty As DataGridViewTextBoxColumn
    Friend WithEvents LastPrice As DataGridViewTextBoxColumn
    Friend WithEvents EstTotPrice As DataGridViewTextBoxColumn
    Friend WithEvents PurchasedByGA As DataGridViewTextBoxColumn
    Friend WithEvents BtnAdd As DataGridViewButtonColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Public WithEvents ToolStrip1 As ToolStrip
End Class
