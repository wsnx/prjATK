<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCari
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
        Me.txtGRNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInvNo = New System.Windows.Forms.TextBox()
        Me.dtpTglTerima = New System.Windows.Forms.DateTimePicker()
        Me.dtpPlan = New System.Windows.Forms.DateTimePicker()
        Me.dtpActual = New System.Windows.Forms.DateTimePicker()
        Me.txtInternalReff = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtGRNo
        '
        Me.txtGRNo.Enabled = False
        Me.txtGRNo.Location = New System.Drawing.Point(12, 12)
        Me.txtGRNo.Name = "txtGRNo"
        Me.txtGRNo.Size = New System.Drawing.Size(304, 22)
        Me.txtGRNo.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Invoice No :"
        '
        'txtInvNo
        '
        Me.txtInvNo.Location = New System.Drawing.Point(138, 47)
        Me.txtInvNo.Name = "txtInvNo"
        Me.txtInvNo.Size = New System.Drawing.Size(275, 22)
        Me.txtInvNo.TabIndex = 16
        '
        'dtpTglTerima
        '
        Me.dtpTglTerima.CustomFormat = "yyyy/MM/dd"
        Me.dtpTglTerima.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTglTerima.Location = New System.Drawing.Point(138, 76)
        Me.dtpTglTerima.Name = "dtpTglTerima"
        Me.dtpTglTerima.Size = New System.Drawing.Size(200, 22)
        Me.dtpTglTerima.TabIndex = 18
        '
        'dtpPlan
        '
        Me.dtpPlan.CustomFormat = "yyyy/MM/dd"
        Me.dtpPlan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPlan.Location = New System.Drawing.Point(138, 104)
        Me.dtpPlan.Name = "dtpPlan"
        Me.dtpPlan.Size = New System.Drawing.Size(200, 22)
        Me.dtpPlan.TabIndex = 19
        '
        'dtpActual
        '
        Me.dtpActual.CustomFormat = "yyyy/MM/dd"
        Me.dtpActual.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpActual.Location = New System.Drawing.Point(138, 132)
        Me.dtpActual.Name = "dtpActual"
        Me.dtpActual.Size = New System.Drawing.Size(200, 22)
        Me.dtpActual.TabIndex = 20
        '
        'txtInternalReff
        '
        Me.txtInternalReff.Location = New System.Drawing.Point(138, 160)
        Me.txtInternalReff.Name = "txtInternalReff"
        Me.txtInternalReff.Size = New System.Drawing.Size(275, 22)
        Me.txtInternalReff.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 17)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Receive Date :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 17)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Payment Plan :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 17)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Payment Actual :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 17)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Internal Reff :"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(138, 188)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmCari
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 222)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtInternalReff)
        Me.Controls.Add(Me.dtpActual)
        Me.Controls.Add(Me.dtpPlan)
        Me.Controls.Add(Me.dtpTglTerima)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtInvNo)
        Me.Controls.Add(Me.txtGRNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCari"
        Me.ShowIcon = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtGRNo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtInvNo As TextBox
    Friend WithEvents dtpTglTerima As DateTimePicker
    Friend WithEvents dtpPlan As DateTimePicker
    Friend WithEvents dtpActual As DateTimePicker
    Friend WithEvents txtInternalReff As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
End Class
