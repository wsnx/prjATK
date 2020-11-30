<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRptPO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptPO))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpdateInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtpTglSampai = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpTglDari = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnShow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RequiredDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusPODoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypePO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VendorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyToReceive = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyGR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Difference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TglTerimaInv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DueDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DayLeft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentPlan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentAct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InternalReff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateInvoiceToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(154, 28)
        '
        'UpdateInvoiceToolStripMenuItem
        '
        Me.UpdateInvoiceToolStripMenuItem.Name = "UpdateInvoiceToolStripMenuItem"
        Me.UpdateInvoiceToolStripMenuItem.Size = New System.Drawing.Size(153, 24)
        Me.UpdateInvoiceToolStripMenuItem.Text = "Update Invoice"
        '
        'dtpTglSampai
        '
        Me.dtpTglSampai.CustomFormat = "yyyy/MM/dd"
        Me.dtpTglSampai.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTglSampai.Location = New System.Drawing.Point(101, 73)
        Me.dtpTglSampai.Name = "dtpTglSampai"
        Me.dtpTglSampai.Size = New System.Drawing.Size(200, 22)
        Me.dtpTglSampai.TabIndex = 71
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 17)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Sampai :"
        '
        'dtpTglDari
        '
        Me.dtpTglDari.CustomFormat = "yyyy/MM/dd"
        Me.dtpTglDari.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTglDari.Location = New System.Drawing.Point(101, 45)
        Me.dtpTglDari.Name = "dtpTglDari"
        Me.dtpTglDari.Size = New System.Drawing.Size(200, 22)
        Me.dtpTglDari.TabIndex = 69
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Mulai :"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.dtpTglSampai)
        Me.Panel1.Controls.Add(Me.dtpTglDari)
        Me.Panel1.Location = New System.Drawing.Point(12, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(404, 141)
        Me.Panel1.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Cari :"
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"5. All Data"})
        Me.ComboBox1.Location = New System.Drawing.Point(101, 11)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(200, 24)
        Me.ComboBox1.TabIndex = 72
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1601, 187)
        Me.Panel2.TabIndex = 73
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnShow, Me.ToolStripSeparator1, Me.btnExport, Me.ToolStripSeparator4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 160)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1601, 27)
        Me.ToolStrip1.TabIndex = 73
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnShow
        '
        Me.btnShow.Image = Global.prjATKPr.My.Resources.Resources.FindResults_16x_32
        Me.btnShow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(73, 24)
        Me.btnShow.Text = "Search"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'btnExport
        '
        Me.btnExport.Image = Global.prjATKPr.My.Resources.Resources.ExportToExcel_16x_32
        Me.btnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(120, 24)
        Me.btnExport.Text = "Export to CSV"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 27)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 187)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1601, 499)
        Me.Panel3.TabIndex = 74
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RequiredDate, Me.PRNo, Me.PONo, Me.CustomerName, Me.StatusPODoc, Me.StatusPO, Me.TypePO, Me.Item, Me.VendorName, Me.QtyToReceive, Me.QtyGR, Me.Difference, Me.GRNo, Me.GRDate, Me.InvoiceNo, Me.TglTerimaInv, Me.DueDate, Me.DayLeft, Me.PaymentPlan, Me.PaymentAct, Me.InternalReff})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1601, 499)
        Me.DataGridView1.TabIndex = 64
        '
        'RequiredDate
        '
        Me.RequiredDate.DataPropertyName = "RequiredDate"
        Me.RequiredDate.HeaderText = "Required Date"
        Me.RequiredDate.Name = "RequiredDate"
        Me.RequiredDate.ReadOnly = True
        Me.RequiredDate.Width = 118
        '
        'PRNo
        '
        Me.PRNo.DataPropertyName = "PRNo"
        Me.PRNo.HeaderText = "PR No"
        Me.PRNo.Name = "PRNo"
        Me.PRNo.ReadOnly = True
        Me.PRNo.Width = 56
        '
        'PONo
        '
        Me.PONo.DataPropertyName = "PONo"
        Me.PONo.HeaderText = "PO No"
        Me.PONo.Name = "PONo"
        Me.PONo.ReadOnly = True
        Me.PONo.Width = 57
        '
        'CustomerName
        '
        Me.CustomerName.DataPropertyName = "CustomerName"
        Me.CustomerName.HeaderText = "CustomerName"
        Me.CustomerName.Name = "CustomerName"
        Me.CustomerName.ReadOnly = True
        Me.CustomerName.Width = 134
        '
        'StatusPODoc
        '
        Me.StatusPODoc.DataPropertyName = "StatusPODoc"
        Me.StatusPODoc.HeaderText = "Status PO Doc"
        Me.StatusPODoc.Name = "StatusPODoc"
        Me.StatusPODoc.ReadOnly = True
        Me.StatusPODoc.Width = 97
        '
        'StatusPO
        '
        Me.StatusPO.DataPropertyName = "StatusPO"
        Me.StatusPO.HeaderText = "Status PO"
        Me.StatusPO.Name = "StatusPO"
        Me.StatusPO.ReadOnly = True
        Me.StatusPO.Width = 93
        '
        'TypePO
        '
        Me.TypePO.DataPropertyName = "TypePO"
        Me.TypePO.HeaderText = "Type PO"
        Me.TypePO.Name = "TypePO"
        Me.TypePO.ReadOnly = True
        Me.TypePO.Width = 86
        '
        'Item
        '
        Me.Item.DataPropertyName = "Item"
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        Me.Item.Width = 63
        '
        'VendorName
        '
        Me.VendorName.DataPropertyName = "VendorName"
        Me.VendorName.HeaderText = "Vendor Name"
        Me.VendorName.Name = "VendorName"
        Me.VendorName.ReadOnly = True
        Me.VendorName.Width = 114
        '
        'QtyToReceive
        '
        Me.QtyToReceive.DataPropertyName = "QtyToReceive"
        Me.QtyToReceive.HeaderText = "QtyToReceive"
        Me.QtyToReceive.Name = "QtyToReceive"
        Me.QtyToReceive.ReadOnly = True
        Me.QtyToReceive.Width = 127
        '
        'QtyGR
        '
        Me.QtyGR.DataPropertyName = "QtyGR"
        Me.QtyGR.HeaderText = "Qty GR"
        Me.QtyGR.Name = "QtyGR"
        Me.QtyGR.ReadOnly = True
        Me.QtyGR.Width = 59
        '
        'Difference
        '
        Me.Difference.DataPropertyName = "Diff"
        Me.Difference.HeaderText = "Difference"
        Me.Difference.Name = "Difference"
        Me.Difference.ReadOnly = True
        Me.Difference.Width = 102
        '
        'GRNo
        '
        Me.GRNo.DataPropertyName = "GRNo"
        Me.GRNo.HeaderText = "GR No"
        Me.GRNo.Name = "GRNo"
        Me.GRNo.ReadOnly = True
        Me.GRNo.Width = 58
        '
        'GRDate
        '
        Me.GRDate.DataPropertyName = "GRDate"
        Me.GRDate.HeaderText = "GR Date"
        Me.GRDate.Name = "GRDate"
        Me.GRDate.ReadOnly = True
        Me.GRDate.Width = 85
        '
        'InvoiceNo
        '
        Me.InvoiceNo.DataPropertyName = "InvoiceNo"
        Me.InvoiceNo.HeaderText = "InvoiceNo"
        Me.InvoiceNo.Name = "InvoiceNo"
        Me.InvoiceNo.ReadOnly = True
        Me.InvoiceNo.Width = 99
        '
        'TglTerimaInv
        '
        Me.TglTerimaInv.DataPropertyName = "TglTerimaInv"
        Me.TglTerimaInv.HeaderText = "Invoice Received Date"
        Me.TglTerimaInv.Name = "TglTerimaInv"
        Me.TglTerimaInv.ReadOnly = True
        Me.TglTerimaInv.Width = 136
        '
        'DueDate
        '
        Me.DueDate.DataPropertyName = "DueDate"
        Me.DueDate.HeaderText = "DueDate"
        Me.DueDate.Name = "DueDate"
        Me.DueDate.ReadOnly = True
        Me.DueDate.Width = 93
        '
        'DayLeft
        '
        Me.DayLeft.DataPropertyName = "DayLeft"
        Me.DayLeft.HeaderText = "DayLeft"
        Me.DayLeft.Name = "DayLeft"
        Me.DayLeft.ReadOnly = True
        Me.DayLeft.Width = 86
        '
        'PaymentPlan
        '
        Me.PaymentPlan.DataPropertyName = "PaymentPlan"
        Me.PaymentPlan.HeaderText = "Payment Plan Date"
        Me.PaymentPlan.Name = "PaymentPlan"
        Me.PaymentPlan.ReadOnly = True
        Me.PaymentPlan.Width = 118
        '
        'PaymentAct
        '
        Me.PaymentAct.DataPropertyName = "PaymentAct"
        Me.PaymentAct.HeaderText = "Payment Actual Date"
        Me.PaymentAct.Name = "PaymentAct"
        Me.PaymentAct.ReadOnly = True
        Me.PaymentAct.Width = 127
        '
        'InternalReff
        '
        Me.InternalReff.DataPropertyName = "InternalReff"
        Me.InternalReff.HeaderText = "InternalReff"
        Me.InternalReff.Name = "InternalReff"
        Me.InternalReff.ReadOnly = True
        Me.InternalReff.Width = 110
        '
        'FrmRptPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1601, 686)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmRptPO"
        Me.Text = "PO Report"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpTglSampai As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpTglDari As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents UpdateInvoiceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnShow As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnExport As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents RequiredDate As DataGridViewTextBoxColumn
    Friend WithEvents PRNo As DataGridViewTextBoxColumn
    Friend WithEvents PONo As DataGridViewTextBoxColumn
    Friend WithEvents CustomerName As DataGridViewTextBoxColumn
    Friend WithEvents StatusPODoc As DataGridViewTextBoxColumn
    Friend WithEvents StatusPO As DataGridViewTextBoxColumn
    Friend WithEvents TypePO As DataGridViewTextBoxColumn
    Friend WithEvents Item As DataGridViewTextBoxColumn
    Friend WithEvents VendorName As DataGridViewTextBoxColumn
    Friend WithEvents QtyToReceive As DataGridViewTextBoxColumn
    Friend WithEvents QtyGR As DataGridViewTextBoxColumn
    Friend WithEvents Difference As DataGridViewTextBoxColumn
    Friend WithEvents GRNo As DataGridViewTextBoxColumn
    Friend WithEvents GRDate As DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNo As DataGridViewTextBoxColumn
    Friend WithEvents TglTerimaInv As DataGridViewTextBoxColumn
    Friend WithEvents DueDate As DataGridViewTextBoxColumn
    Friend WithEvents DayLeft As DataGridViewTextBoxColumn
    Friend WithEvents PaymentPlan As DataGridViewTextBoxColumn
    Friend WithEvents PaymentAct As DataGridViewTextBoxColumn
    Friend WithEvents InternalReff As DataGridViewTextBoxColumn
End Class
