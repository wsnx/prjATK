<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formPR
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtPRNo = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbSite = New System.Windows.Forms.ComboBox()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTransID = New System.Windows.Forms.TextBox()
        Me.dtTglTrans = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtPRNo)
        Me.Panel2.Controls.Add(Me.btnBrowse)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cbSite)
        Me.Panel2.Controls.Add(Me.cbCustomer)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtTransID)
        Me.Panel2.Controls.Add(Me.dtTglTrans)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(13, 135)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(496, 162)
        Me.Panel2.TabIndex = 22
        '
        'txtPRNo
        '
        Me.txtPRNo.Location = New System.Drawing.Point(161, 9)
        Me.txtPRNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPRNo.Name = "txtPRNo"
        Me.txtPRNo.ReadOnly = True
        Me.txtPRNo.Size = New System.Drawing.Size(252, 22)
        Me.txtPRNo.TabIndex = 61
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(419, 7)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(32, 28)
        Me.btnBrowse.TabIndex = 27
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(87, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "No. PR :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(75, 105)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Customer :"
        '
        'cbSite
        '
        Me.cbSite.Enabled = False
        Me.cbSite.FormattingEnabled = True
        Me.cbSite.Items.AddRange(New Object() {"JKT - Halim", "JKT - Pondok Ungu", "JKT - JB V", "JKT - Murinda", "JKT - Delta Silicon", "JKT - Latumenten", "JKT - Marunda", "SRG - Candi", "SRG - Marina", "SBY - Kenjeran", "WH - Denpasar", "BPN - Tuperware", "BPN - Blackwood", "MES - Tupperware", "MES - Dupont", "UPG - Dupont Herbalife"})
        Me.cbSite.Location = New System.Drawing.Point(161, 38)
        Me.cbSite.Margin = New System.Windows.Forms.Padding(4)
        Me.cbSite.Name = "cbSite"
        Me.cbSite.Size = New System.Drawing.Size(292, 24)
        Me.cbSite.TabIndex = 0
        '
        'cbCustomer
        '
        Me.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomer.Enabled = False
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(161, 101)
        Me.cbCustomer.Margin = New System.Windows.Forms.Padding(4)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(292, 24)
        Me.cbCustomer.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(109, 42)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 17)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Site :"
        '
        'txtTransID
        '
        Me.txtTransID.Location = New System.Drawing.Point(399, 69)
        Me.txtTransID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTransID.Name = "txtTransID"
        Me.txtTransID.ReadOnly = True
        Me.txtTransID.Size = New System.Drawing.Size(55, 22)
        Me.txtTransID.TabIndex = 19
        Me.txtTransID.Visible = False
        '
        'dtTglTrans
        '
        Me.dtTglTrans.Enabled = False
        Me.dtTglTrans.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTglTrans.Location = New System.Drawing.Point(161, 71)
        Me.dtTglTrans.Margin = New System.Windows.Forms.Padding(4)
        Me.dtTglTrans.Name = "dtTglTrans"
        Me.dtTglTrans.Size = New System.Drawing.Size(141, 22)
        Me.dtTglTrans.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(48, 79)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Tgl Transaksi :"
        '
        'formPR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1244, 517)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "formPR"
        Me.Text = "formPR"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtPRNo As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbSite As System.Windows.Forms.ComboBox
    Friend WithEvents cbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTransID As System.Windows.Forms.TextBox
    Friend WithEvents dtTglTrans As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
