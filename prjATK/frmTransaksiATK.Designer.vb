<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransaksiATK
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbWithdrawl = New System.Windows.Forms.RadioButton()
        Me.rbDeposit = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.cbUOM = New System.Windows.Forms.ComboBox()
        Me.cbNamaBarang = New System.Windows.Forms.ComboBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbNamaKaryawan = New System.Windows.Forms.ComboBox()
        Me.cbSite = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtTglTrans = New System.Windows.Forms.DateTimePicker()
        Me.txtTransID = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TglTransaksi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaKaryawan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StorerKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KodeBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Satuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JenisTrans = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Jenis Transaksi :"
        '
        'rbWithdrawl
        '
        Me.rbWithdrawl.AutoSize = True
        Me.rbWithdrawl.Checked = True
        Me.rbWithdrawl.Location = New System.Drawing.Point(106, 58)
        Me.rbWithdrawl.Name = "rbWithdrawl"
        Me.rbWithdrawl.Size = New System.Drawing.Size(119, 17)
        Me.rbWithdrawl.TabIndex = 2
        Me.rbWithdrawl.TabStop = True
        Me.rbWithdrawl.Text = "PengeluaranBarang"
        Me.rbWithdrawl.UseVisualStyleBackColor = True
        '
        'rbDeposit
        '
        Me.rbDeposit.AutoSize = True
        Me.rbDeposit.Location = New System.Drawing.Point(242, 58)
        Me.rbDeposit.Name = "rbDeposit"
        Me.rbDeposit.Size = New System.Drawing.Size(118, 17)
        Me.rbDeposit.TabIndex = 3
        Me.rbDeposit.Text = "Pemasukan Barang"
        Me.rbDeposit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nama Karyawan :"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(106, 160)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(70, 20)
        Me.txtQty.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(71, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Qty :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(53, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Satuan :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "NamaBarang :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Customer :"
        '
        'cbCustomer
        '
        Me.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(106, 106)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(220, 21)
        Me.cbCustomer.TabIndex = 5
        '
        'cbUOM
        '
        Me.cbUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUOM.FormattingEnabled = True
        Me.cbUOM.Location = New System.Drawing.Point(106, 186)
        Me.cbUOM.Name = "cbUOM"
        Me.cbUOM.Size = New System.Drawing.Size(121, 21)
        Me.cbUOM.TabIndex = 8
        '
        'cbNamaBarang
        '
        Me.cbNamaBarang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNamaBarang.FormattingEnabled = True
        Me.cbNamaBarang.Location = New System.Drawing.Point(106, 133)
        Me.cbNamaBarang.Name = "cbNamaBarang"
        Me.cbNamaBarang.Size = New System.Drawing.Size(222, 21)
        Me.cbNamaBarang.TabIndex = 6
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(253, 237)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 17
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(172, 237)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel1.Controls.Add(Me.cbNamaKaryawan)
        Me.Panel1.Controls.Add(Me.cbSite)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtKeterangan)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dtTglTrans)
        Me.Panel1.Controls.Add(Me.txtTransID)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.rbWithdrawl)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.rbDeposit)
        Me.Panel1.Controls.Add(Me.cbNamaBarang)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbUOM)
        Me.Panel1.Controls.Add(Me.cbCustomer)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtQty)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(372, 263)
        Me.Panel1.TabIndex = 19
        '
        'cbNamaKaryawan
        '
        Me.cbNamaKaryawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbNamaKaryawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbNamaKaryawan.FormattingEnabled = True
        Me.cbNamaKaryawan.Location = New System.Drawing.Point(106, 81)
        Me.cbNamaKaryawan.Name = "cbNamaKaryawan"
        Me.cbNamaKaryawan.Size = New System.Drawing.Size(220, 21)
        Me.cbNamaKaryawan.TabIndex = 25
        '
        'cbSite
        '
        Me.cbSite.FormattingEnabled = True
        Me.cbSite.Location = New System.Drawing.Point(106, 5)
        Me.cbSite.Name = "cbSite"
        Me.cbSite.Size = New System.Drawing.Size(235, 21)
        Me.cbSite.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(75, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Site"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Keterangan :"
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Location = New System.Drawing.Point(106, 213)
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(220, 20)
        Me.txtKeterangan.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Tgl Transaksi :"
        '
        'dtTglTrans
        '
        Me.dtTglTrans.Enabled = False
        Me.dtTglTrans.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTglTrans.Location = New System.Drawing.Point(106, 32)
        Me.dtTglTrans.Name = "dtTglTrans"
        Me.dtTglTrans.Size = New System.Drawing.Size(107, 20)
        Me.dtTglTrans.TabIndex = 1
        '
        'txtTransID
        '
        Me.txtTransID.Location = New System.Drawing.Point(3, 6)
        Me.txtTransID.Name = "txtTransID"
        Me.txtTransID.ReadOnly = True
        Me.txtTransID.Size = New System.Drawing.Size(66, 20)
        Me.txtTransID.TabIndex = 19
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransID, Me.TglTransaksi, Me.NamaKaryawan, Me.StorerKey, Me.KodeBarang, Me.NamaBarang, Me.Satuan, Me.JenisTrans, Me.Qty, Me.Keterangan})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 281)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1023, 134)
        Me.DataGridView1.TabIndex = 0
        '
        'TransID
        '
        Me.TransID.DataPropertyName = "TransID"
        Me.TransID.HeaderText = "TransID"
        Me.TransID.Name = "TransID"
        Me.TransID.ReadOnly = True
        Me.TransID.Visible = False
        '
        'TglTransaksi
        '
        Me.TglTransaksi.DataPropertyName = "TglTransaksi"
        Me.TglTransaksi.HeaderText = "TglTransaksi"
        Me.TglTransaksi.Name = "TglTransaksi"
        Me.TglTransaksi.ReadOnly = True
        '
        'NamaKaryawan
        '
        Me.NamaKaryawan.DataPropertyName = "NamaKaryawan"
        Me.NamaKaryawan.HeaderText = "NamaKaryawan"
        Me.NamaKaryawan.Name = "NamaKaryawan"
        Me.NamaKaryawan.ReadOnly = True
        '
        'StorerKey
        '
        Me.StorerKey.DataPropertyName = "StorerKey"
        Me.StorerKey.HeaderText = "StorerKey"
        Me.StorerKey.Name = "StorerKey"
        Me.StorerKey.ReadOnly = True
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
        'JenisTrans
        '
        Me.JenisTrans.DataPropertyName = "JenisTrans"
        Me.JenisTrans.HeaderText = "JenisTransaksi"
        Me.JenisTrans.Name = "JenisTrans"
        Me.JenisTrans.ReadOnly = True
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
        '
        'frmTransaksiATK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 427)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmTransaksiATK"
        Me.Text = "Transaksi ATK"
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbWithdrawl As System.Windows.Forms.RadioButton
    Friend WithEvents rbDeposit As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents cbUOM As System.Windows.Forms.ComboBox
    Friend WithEvents cbNamaBarang As System.Windows.Forms.ComboBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtTransID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtTglTrans As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents cbSite As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TransID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TglTransaksi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamaKaryawan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StorerKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KodeBarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamaBarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Satuan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JenisTrans As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Keterangan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbNamaKaryawan As System.Windows.Forms.ComboBox
End Class
