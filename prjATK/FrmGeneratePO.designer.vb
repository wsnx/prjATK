<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGeneratePO
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGeneratePO))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.TransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KodeVendor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TglTransaksi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnGeneratePO = New System.Windows.Forms.ToolStripButton()
        Me.KodeBarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstTotPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGeneratePO, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 431)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1194, 27)
        Me.ToolStrip1.TabIndex = 59
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 27)
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(13, 13)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(297, 24)
        Me.ComboBox1.TabIndex = 60
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransID, Me.PONo, Me.PRNo, Me.KodeVendor, Me.TglTransaksi, Me.Status})
        Me.DataGridView1.Location = New System.Drawing.Point(13, 44)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1163, 145)
        Me.DataGridView1.TabIndex = 61
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KodeBarang, Me.Description, Me.UOM, Me.Qty, Me.LastPrice, Me.EstTotPrice})
        Me.DataGridView2.Location = New System.Drawing.Point(13, 195)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(1163, 219)
        Me.DataGridView2.TabIndex = 62
        '
        'TransID
        '
        Me.TransID.DataPropertyName = "TransID"
        Me.TransID.HeaderText = "TransID"
        Me.TransID.Name = "TransID"
        Me.TransID.ReadOnly = True
        Me.TransID.Visible = False
        '
        'PONo
        '
        Me.PONo.DataPropertyName = "PONo"
        Me.PONo.HeaderText = "PO No"
        Me.PONo.Name = "PONo"
        Me.PONo.ReadOnly = True
        Me.PONo.Width = 57
        '
        'PRNo
        '
        Me.PRNo.DataPropertyName = "PRNo"
        Me.PRNo.HeaderText = "PR No"
        Me.PRNo.Name = "PRNo"
        Me.PRNo.ReadOnly = True
        Me.PRNo.Width = 56
        '
        'KodeVendor
        '
        Me.KodeVendor.DataPropertyName = "KodeVendor"
        Me.KodeVendor.HeaderText = "Kode Vendor"
        Me.KodeVendor.Name = "KodeVendor"
        Me.KodeVendor.ReadOnly = True
        Me.KodeVendor.Width = 110
        '
        'TglTransaksi
        '
        Me.TglTransaksi.DataPropertyName = "TglTransaksi"
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.TglTransaksi.DefaultCellStyle = DataGridViewCellStyle4
        Me.TglTransaksi.HeaderText = "Tgl Transaksi"
        Me.TglTransaksi.Name = "TglTransaksi"
        Me.TglTransaksi.ReadOnly = True
        Me.TglTransaksi.Width = 113
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 77
        '
        'btnGeneratePO
        '
        Me.btnGeneratePO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGeneratePO.Image = CType(resources.GetObject("btnGeneratePO.Image"), System.Drawing.Image)
        Me.btnGeneratePO.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGeneratePO.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGeneratePO.Name = "btnGeneratePO"
        Me.btnGeneratePO.Size = New System.Drawing.Size(96, 24)
        Me.btnGeneratePO.Text = "Generate PO"
        Me.btnGeneratePO.ToolTipText = "Generate PO"
        '
        'KodeBarang
        '
        Me.KodeBarang.DataPropertyName = "KodeBarang"
        Me.KodeBarang.HeaderText = "Kode Barang"
        Me.KodeBarang.Name = "KodeBarang"
        Me.KodeBarang.ReadOnly = True
        Me.KodeBarang.Width = 120
        '
        'Description
        '
        Me.Description.DataPropertyName = "NamaBarang"
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 108
        '
        'UOM
        '
        Me.UOM.DataPropertyName = "UOM"
        Me.UOM.HeaderText = "UOM"
        Me.UOM.Name = "UOM"
        Me.UOM.ReadOnly = True
        Me.UOM.Width = 69
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 59
        '
        'LastPrice
        '
        Me.LastPrice.DataPropertyName = "LastPrice"
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.LastPrice.DefaultCellStyle = DataGridViewCellStyle5
        Me.LastPrice.HeaderText = "Harga Satuan"
        Me.LastPrice.Name = "LastPrice"
        Me.LastPrice.ReadOnly = True
        Me.LastPrice.Width = 125
        '
        'EstTotPrice
        '
        Me.EstTotPrice.DataPropertyName = "EstTotPrice"
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.EstTotPrice.DefaultCellStyle = DataGridViewCellStyle6
        Me.EstTotPrice.HeaderText = "Jumlah"
        Me.EstTotPrice.Name = "EstTotPrice"
        Me.EstTotPrice.ReadOnly = True
        Me.EstTotPrice.Width = 82
        '
        'FrmGeneratePO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 458)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmGeneratePO"
        Me.Text = "Generate PO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnGeneratePO As ToolStripButton
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TransID As DataGridViewTextBoxColumn
    Friend WithEvents PONo As DataGridViewTextBoxColumn
    Friend WithEvents PRNo As DataGridViewTextBoxColumn
    Friend WithEvents KodeVendor As DataGridViewTextBoxColumn
    Friend WithEvents TglTransaksi As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents KodeBarang As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents UOM As DataGridViewTextBoxColumn
    Friend WithEvents Qty As DataGridViewTextBoxColumn
    Friend WithEvents LastPrice As DataGridViewTextBoxColumn
    Friend WithEvents EstTotPrice As DataGridViewTextBoxColumn
End Class
