<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGR))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.txtGRNo = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnShow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFirst = New System.Windows.Forms.ToolStripButton()
        Me.btnPrev = New System.Windows.Forms.ToolStripButton()
        Me.btnNext = New System.Windows.Forms.ToolStripButton()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnLast = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTransID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTOP = New System.Windows.Forms.TextBox()
        Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpTglTerima = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSuratJalan = New System.Windows.Forms.TextBox()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.NoUrut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Storerkey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KodeBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SisaPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyGR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WHAsal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbPengataran = New System.Windows.Forms.ComboBox()
        Me.cbDeadLine = New System.Windows.Forms.ComboBox()
        Me.cbLampiran = New System.Windows.Forms.ComboBox()
        Me.cbSurat = New System.Windows.Forms.ComboBox()
        Me.cbKondisi = New System.Windows.Forms.ComboBox()
        Me.cbJumlah = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.NilaiPengantaran = New System.Windows.Forms.ComboBox()
        Me.NilaiDeadline = New System.Windows.Forms.ComboBox()
        Me.NilaiLampiran = New System.Windows.Forms.ComboBox()
        Me.NilaiSurat = New System.Windows.Forms.ComboBox()
        Me.NilaiKondisi = New System.Windows.Forms.ComboBox()
        Me.NilaiJml = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPONo)
        Me.GroupBox1.Controls.Add(Me.txtGRNo)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 26)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(447, 92)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(391, 23)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(42, 45)
        Me.btnBrowse.TabIndex = 28
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "PO No :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "GR No :"
        '
        'txtPONo
        '
        Me.txtPONo.Location = New System.Drawing.Point(109, 50)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(275, 22)
        Me.txtPONo.TabIndex = 6
        '
        'txtGRNo
        '
        Me.txtGRNo.Enabled = False
        Me.txtGRNo.Location = New System.Drawing.Point(109, 22)
        Me.txtGRNo.Name = "txtGRNo"
        Me.txtGRNo.Size = New System.Drawing.Size(275, 22)
        Me.txtGRNo.TabIndex = 5
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(129, 30)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(128, 26)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.ToolStripSeparator6, Me.btnShow, Me.ToolStripSeparator7, Me.BtnSave, Me.ToolStripSeparator1, Me.btnDelete, Me.ToolStripSeparator2, Me.btnClose, Me.ToolStripSeparator3, Me.btnPrint, Me.ToolStripSeparator4, Me.ToolStripButton1, Me.btnFirst, Me.btnPrev, Me.btnNext, Me.btnLast})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 545)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1240, 27)
        Me.ToolStrip1.TabIndex = 59
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = Global.prjATKPr.My.Resources.Resources.DocumentHS
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(95, 24)
        Me.btnNew.Text = "Add New"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 27)
        '
        'btnShow
        '
        Me.btnShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(24, 24)
        Me.btnShow.Text = "S&howData"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 27)
        '
        'BtnSave
        '
        Me.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSave.Image = Global.prjATKPr.My.Resources.Resources.saveHS
        Me.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(24, 24)
        Me.BtnSave.Text = "&Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = Global.prjATKPr.My.Resources.Resources.DeleteHS
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(24, 24)
        Me.btnDelete.Text = "Delete"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'btnClose
        '
        Me.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnClose.Image = Global.prjATKPr.My.Resources.Resources.RighsRestrictedHS
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(24, 24)
        Me.btnClose.Text = "&Close"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.prjATKPr.My.Resources.Resources.PrintHS
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(130, 24)
        Me.ToolStripButton1.Text = "Print GR Result"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 27)
        '
        'btnFirst
        '
        Me.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFirst.Image = Global.prjATKPr.My.Resources.Resources.MoveFirsHS
        Me.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(24, 24)
        Me.btnFirst.Text = "First"
        Me.btnFirst.Visible = False
        '
        'btnPrev
        '
        Me.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPrev.Image = Global.prjATKPr.My.Resources.Resources.DataContainer_MovePreviousHS
        Me.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(24, 24)
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.Visible = False
        '
        'btnNext
        '
        Me.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNext.Image = Global.prjATKPr.My.Resources.Resources.DataContainer_MoveNextHS
        Me.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(24, 24)
        Me.btnNext.Text = "Next"
        Me.btnNext.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.prjATKPr.My.Resources.Resources.PrintHS
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 24)
        Me.btnPrint.Text = "Print ITS"
        '
        'btnLast
        '
        Me.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLast.Image = Global.prjATKPr.My.Resources.Resources.DataContainer_MoveLastHS___Copy
        Me.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(24, 24)
        Me.btnLast.Text = "Last"
        Me.btnLast.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.txtTransID)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtSite)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtTOP)
        Me.GroupBox2.Controls.Add(Me.dtpDueDate)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dtpTglTerima)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtSuratJalan)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 126)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(496, 173)
        Me.GroupBox2.TabIndex = 54
        Me.GroupBox2.TabStop = False
        '
        'txtTransID
        '
        Me.txtTransID.Enabled = False
        Me.txtTransID.Location = New System.Drawing.Point(403, 17)
        Me.txtTransID.Name = "txtTransID"
        Me.txtTransID.Size = New System.Drawing.Size(86, 22)
        Me.txtTransID.TabIndex = 16
        Me.txtTransID.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(47, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "WH Asal :"
        '
        'txtSite
        '
        Me.txtSite.Enabled = False
        Me.txtSite.Location = New System.Drawing.Point(122, 17)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.Size = New System.Drawing.Size(275, 22)
        Me.txtSite.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(72, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "TOP :"
        '
        'txtTOP
        '
        Me.txtTOP.Enabled = False
        Me.txtTOP.Location = New System.Drawing.Point(122, 104)
        Me.txtTOP.Name = "txtTOP"
        Me.txtTOP.Size = New System.Drawing.Size(64, 22)
        Me.txtTOP.TabIndex = 12
        Me.txtTOP.Text = "0"
        '
        'dtpDueDate
        '
        Me.dtpDueDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpDueDate.Enabled = False
        Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDueDate.Location = New System.Drawing.Point(122, 134)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(200, 22)
        Me.dtpDueDate.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Tgl dibutuhkan :"
        '
        'dtpTglTerima
        '
        Me.dtpTglTerima.CustomFormat = "yyyy/MM/dd HH:mm"
        Me.dtpTglTerima.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTglTerima.Location = New System.Drawing.Point(122, 75)
        Me.dtpTglTerima.Name = "dtpTglTerima"
        Me.dtpTglTerima.Size = New System.Drawing.Size(200, 22)
        Me.dtpTglTerima.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Tgl Terima :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Surat Jalan :"
        '
        'txtSuratJalan
        '
        Me.txtSuratJalan.Location = New System.Drawing.Point(122, 47)
        Me.txtSuratJalan.Name = "txtSuratJalan"
        Me.txtSuratJalan.Size = New System.Drawing.Size(275, 22)
        Me.txtSuratJalan.TabIndex = 5
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NoUrut, Me.Storerkey, Me.KodeBarang, Me.NamaBarang, Me.UOM, Me.SisaPO, Me.QtyGR, Me.TOP, Me.WHAsal})
        Me.dgv1.Location = New System.Drawing.Point(16, 306)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.RowTemplate.Height = 24
        Me.dgv1.Size = New System.Drawing.Size(1169, 223)
        Me.dgv1.TabIndex = 60
        '
        'NoUrut
        '
        Me.NoUrut.DataPropertyName = "NoUrut"
        Me.NoUrut.HeaderText = "No"
        Me.NoUrut.Name = "NoUrut"
        Me.NoUrut.ReadOnly = True
        Me.NoUrut.Width = 55
        '
        'Storerkey
        '
        Me.Storerkey.DataPropertyName = "Storerkey"
        Me.Storerkey.HeaderText = "Storerkey"
        Me.Storerkey.Name = "Storerkey"
        Me.Storerkey.ReadOnly = True
        Me.Storerkey.Width = 98
        '
        'KodeBarang
        '
        Me.KodeBarang.DataPropertyName = "KodeBarang"
        Me.KodeBarang.HeaderText = "Item No"
        Me.KodeBarang.Name = "KodeBarang"
        Me.KodeBarang.ReadOnly = True
        Me.KodeBarang.Width = 85
        '
        'NamaBarang
        '
        Me.NamaBarang.DataPropertyName = "NamaBarang"
        Me.NamaBarang.HeaderText = "Description"
        Me.NamaBarang.Name = "NamaBarang"
        Me.NamaBarang.ReadOnly = True
        Me.NamaBarang.Width = 108
        '
        'UOM
        '
        Me.UOM.DataPropertyName = "UOM"
        Me.UOM.HeaderText = "UOM"
        Me.UOM.Name = "UOM"
        Me.UOM.ReadOnly = True
        Me.UOM.Width = 69
        '
        'SisaPO
        '
        Me.SisaPO.DataPropertyName = "SisaPO"
        Me.SisaPO.HeaderText = "Qty PO"
        Me.SisaPO.Name = "SisaPO"
        Me.SisaPO.ReadOnly = True
        Me.SisaPO.Width = 83
        '
        'QtyGR
        '
        Me.QtyGR.DataPropertyName = "QtyGR"
        Me.QtyGR.HeaderText = "Qty GR"
        Me.QtyGR.Name = "QtyGR"
        Me.QtyGR.Width = 84
        '
        'TOP
        '
        Me.TOP.DataPropertyName = "TOP"
        Me.TOP.HeaderText = "TOP"
        Me.TOP.Name = "TOP"
        Me.TOP.ReadOnly = True
        Me.TOP.Width = 66
        '
        'WHAsal
        '
        Me.WHAsal.DataPropertyName = "WHAsal"
        Me.WHAsal.HeaderText = "Site"
        Me.WHAsal.Name = "WHAsal"
        Me.WHAsal.ReadOnly = True
        Me.WHAsal.Width = 61
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.TextBox6)
        Me.GroupBox3.Controls.Add(Me.TextBox5)
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(520, 126)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(199, 173)
        Me.GroupBox3.TabIndex = 61
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Aspek Penilaian"
        '
        'TextBox6
        '
        Me.TextBox6.Enabled = False
        Me.TextBox6.Location = New System.Drawing.Point(17, 141)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(167, 22)
        Me.TextBox6.TabIndex = 21
        Me.TextBox6.Text = "Pengantaran"
        '
        'TextBox5
        '
        Me.TextBox5.Enabled = False
        Me.TextBox5.Location = New System.Drawing.Point(17, 116)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(167, 22)
        Me.TextBox5.TabIndex = 20
        Me.TextBox5.Text = "Deadline"
        '
        'TextBox4
        '
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(17, 92)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(167, 22)
        Me.TextBox4.TabIndex = 19
        Me.TextBox4.Text = "Lampiran PO"
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(17, 68)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(167, 22)
        Me.TextBox3.TabIndex = 18
        Me.TextBox3.Text = "Surat Jalan"
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(17, 44)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(167, 22)
        Me.TextBox2.TabIndex = 17
        Me.TextBox2.Text = "Kondisi seluruh barang"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(17, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(167, 22)
        Me.TextBox1.TabIndex = 16
        Me.TextBox1.Text = "Jumlah barang sesuai PO"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.cbPengataran)
        Me.GroupBox4.Controls.Add(Me.cbDeadLine)
        Me.GroupBox4.Controls.Add(Me.cbLampiran)
        Me.GroupBox4.Controls.Add(Me.cbSurat)
        Me.GroupBox4.Controls.Add(Me.cbKondisi)
        Me.GroupBox4.Controls.Add(Me.cbJumlah)
        Me.GroupBox4.Location = New System.Drawing.Point(727, 126)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(199, 173)
        Me.GroupBox4.TabIndex = 62
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Pilih Jawaban"
        '
        'cbPengataran
        '
        Me.cbPengataran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPengataran.FormattingEnabled = True
        Me.cbPengataran.Items.AddRange(New Object() {"BAIK", "TIDAK KOOPERATIF"})
        Me.cbPengataran.Location = New System.Drawing.Point(8, 142)
        Me.cbPengataran.Name = "cbPengataran"
        Me.cbPengataran.Size = New System.Drawing.Size(184, 24)
        Me.cbPengataran.TabIndex = 5
        '
        'cbDeadLine
        '
        Me.cbDeadLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDeadLine.FormattingEnabled = True
        Me.cbDeadLine.Items.AddRange(New Object() {"TEPAT WAKTU", "TERLAMBAT"})
        Me.cbDeadLine.Location = New System.Drawing.Point(8, 118)
        Me.cbDeadLine.Name = "cbDeadLine"
        Me.cbDeadLine.Size = New System.Drawing.Size(184, 24)
        Me.cbDeadLine.TabIndex = 4
        '
        'cbLampiran
        '
        Me.cbLampiran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLampiran.FormattingEnabled = True
        Me.cbLampiran.Items.AddRange(New Object() {"ADA", "TIDAK"})
        Me.cbLampiran.Location = New System.Drawing.Point(8, 93)
        Me.cbLampiran.Name = "cbLampiran"
        Me.cbLampiran.Size = New System.Drawing.Size(184, 24)
        Me.cbLampiran.TabIndex = 3
        '
        'cbSurat
        '
        Me.cbSurat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSurat.FormattingEnabled = True
        Me.cbSurat.Items.AddRange(New Object() {"ADA", "TIDAK"})
        Me.cbSurat.Location = New System.Drawing.Point(8, 68)
        Me.cbSurat.Name = "cbSurat"
        Me.cbSurat.Size = New System.Drawing.Size(184, 24)
        Me.cbSurat.TabIndex = 2
        '
        'cbKondisi
        '
        Me.cbKondisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbKondisi.FormattingEnabled = True
        Me.cbKondisi.Items.AddRange(New Object() {"BAIK", "BURUK"})
        Me.cbKondisi.Location = New System.Drawing.Point(8, 43)
        Me.cbKondisi.Name = "cbKondisi"
        Me.cbKondisi.Size = New System.Drawing.Size(184, 24)
        Me.cbKondisi.TabIndex = 1
        '
        'cbJumlah
        '
        Me.cbJumlah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbJumlah.FormattingEnabled = True
        Me.cbJumlah.Items.AddRange(New Object() {"YA", "TIDAK"})
        Me.cbJumlah.Location = New System.Drawing.Point(8, 17)
        Me.cbJumlah.Name = "cbJumlah"
        Me.cbJumlah.Size = New System.Drawing.Size(184, 24)
        Me.cbJumlah.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox5.Controls.Add(Me.NilaiPengantaran)
        Me.GroupBox5.Controls.Add(Me.NilaiDeadline)
        Me.GroupBox5.Controls.Add(Me.NilaiLampiran)
        Me.GroupBox5.Controls.Add(Me.NilaiSurat)
        Me.GroupBox5.Controls.Add(Me.NilaiKondisi)
        Me.GroupBox5.Controls.Add(Me.NilaiJml)
        Me.GroupBox5.Location = New System.Drawing.Point(934, 126)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(199, 173)
        Me.GroupBox5.TabIndex = 63
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Nilai"
        Me.GroupBox5.Visible = False
        '
        'NilaiPengantaran
        '
        Me.NilaiPengantaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NilaiPengantaran.FormattingEnabled = True
        Me.NilaiPengantaran.Items.AddRange(New Object() {"1. Sangat Buruk", "2. Buruk", "3. Biasa", "4. Baik", "5. Sangat Baik"})
        Me.NilaiPengantaran.Location = New System.Drawing.Point(8, 142)
        Me.NilaiPengantaran.Name = "NilaiPengantaran"
        Me.NilaiPengantaran.Size = New System.Drawing.Size(184, 24)
        Me.NilaiPengantaran.TabIndex = 5
        '
        'NilaiDeadline
        '
        Me.NilaiDeadline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NilaiDeadline.FormattingEnabled = True
        Me.NilaiDeadline.Items.AddRange(New Object() {"1. Sangat Buruk", "2. Buruk", "3. Biasa", "4. Baik", "5. Sangat Baik"})
        Me.NilaiDeadline.Location = New System.Drawing.Point(8, 116)
        Me.NilaiDeadline.Name = "NilaiDeadline"
        Me.NilaiDeadline.Size = New System.Drawing.Size(184, 24)
        Me.NilaiDeadline.TabIndex = 4
        '
        'NilaiLampiran
        '
        Me.NilaiLampiran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NilaiLampiran.FormattingEnabled = True
        Me.NilaiLampiran.Items.AddRange(New Object() {"1. Sangat Buruk", "2. Buruk", "3. Biasa", "4. Baik", "5. Sangat Baik"})
        Me.NilaiLampiran.Location = New System.Drawing.Point(8, 90)
        Me.NilaiLampiran.Name = "NilaiLampiran"
        Me.NilaiLampiran.Size = New System.Drawing.Size(184, 24)
        Me.NilaiLampiran.TabIndex = 3
        '
        'NilaiSurat
        '
        Me.NilaiSurat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NilaiSurat.FormattingEnabled = True
        Me.NilaiSurat.Items.AddRange(New Object() {"1. Sangat Buruk", "2. Buruk", "3. Biasa", "4. Baik", "5. Sangat Baik"})
        Me.NilaiSurat.Location = New System.Drawing.Point(8, 66)
        Me.NilaiSurat.Name = "NilaiSurat"
        Me.NilaiSurat.Size = New System.Drawing.Size(184, 24)
        Me.NilaiSurat.TabIndex = 2
        '
        'NilaiKondisi
        '
        Me.NilaiKondisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NilaiKondisi.FormattingEnabled = True
        Me.NilaiKondisi.Items.AddRange(New Object() {"1. Sangat Buruk", "2. Buruk", "3. Biasa", "4. Baik", "5. Sangat Baik"})
        Me.NilaiKondisi.Location = New System.Drawing.Point(8, 42)
        Me.NilaiKondisi.Name = "NilaiKondisi"
        Me.NilaiKondisi.Size = New System.Drawing.Size(184, 24)
        Me.NilaiKondisi.TabIndex = 1
        '
        'NilaiJml
        '
        Me.NilaiJml.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NilaiJml.FormattingEnabled = True
        Me.NilaiJml.Items.AddRange(New Object() {"1. Sangat Buruk", "2. Buruk", "3. Biasa", "4. Baik", "5. Sangat Baik"})
        Me.NilaiJml.Location = New System.Drawing.Point(8, 17)
        Me.NilaiJml.Name = "NilaiJml"
        Me.NilaiJml.Size = New System.Drawing.Size(184, 24)
        Me.NilaiJml.TabIndex = 0
        '
        'FrmGR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1240, 572)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmGR"
        Me.Text = "GR (Goods Received)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtGRNo As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents btnShow As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents BtnSave As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnClose As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnPrint As ToolStripButton
    Friend WithEvents txtPONo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSuratJalan As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTOP As TextBox
    Friend WithEvents dtpDueDate As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpTglTerima As DateTimePicker
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSite As TextBox
    Friend WithEvents NoUrut As DataGridViewTextBoxColumn
    Friend WithEvents Storerkey As DataGridViewTextBoxColumn
    Friend WithEvents KodeBarang As DataGridViewTextBoxColumn
    Friend WithEvents NamaBarang As DataGridViewTextBoxColumn
    Friend WithEvents UOM As DataGridViewTextBoxColumn
    Friend WithEvents SisaPO As DataGridViewTextBoxColumn
    Friend WithEvents QtyGR As DataGridViewTextBoxColumn
    Friend WithEvents TOP As DataGridViewTextBoxColumn
    Friend WithEvents WHAsal As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cbLampiran As ComboBox
    Friend WithEvents cbSurat As ComboBox
    Friend WithEvents cbKondisi As ComboBox
    Friend WithEvents cbJumlah As ComboBox
    Friend WithEvents cbPengataran As ComboBox
    Friend WithEvents cbDeadLine As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents NilaiPengantaran As ComboBox
    Friend WithEvents NilaiDeadline As ComboBox
    Friend WithEvents NilaiLampiran As ComboBox
    Friend WithEvents NilaiSurat As ComboBox
    Friend WithEvents NilaiKondisi As ComboBox
    Friend WithEvents NilaiJml As ComboBox
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnFirst As ToolStripButton
    Friend WithEvents btnPrev As ToolStripButton
    Friend WithEvents btnNext As ToolStripButton
    Friend WithEvents btnLast As ToolStripButton
    Friend WithEvents txtTransID As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents ToolStripButton1 As ToolStripButton
End Class
