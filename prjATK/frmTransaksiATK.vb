Public Class frmTransaksiATK

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Validasi() = False Then
            Exit Sub
        End If
        If Me.txtTransID.Text.Trim = "" Then
            'INSERTDATA
            Me.INSERTDATA()
        Else
            'UPDATEData
            Me.UPDATEDATA()
        End If

        ShowData()
        ClearData()
    End Sub

    Private Function Validasi() As Boolean
        Dim hasil As Boolean = False
        If Me.cbSite.Text.Trim = "" Then
            MsgBox("Silahkan pilih Site dulu")
            Me.cbSite.Focus()
            Return False

        End If
        If Me.cbNamaKaryawan.Text = "" Then
            MsgBox("Silahkan isi Nama Karyawan dulu")
            Me.cbNamaKaryawan.Focus()
            Return False
        End If

        If IsKaryawanExist(Me.cbSite.Text.Trim, Me.cbNamaKaryawan.Text.Trim) = -1 Then
            MsgBox("Nama Karyawan belum terdaftar")
            Me.cbNamaKaryawan.Focus()
            Return False
        End If
        If Me.cbCustomer.SelectedIndex = -1 Then
            MsgBox("Silahkan isi Customer dulu")
            Me.cbCustomer.Focus()
            Return False
        End If
        If Me.cbNamaBarang.SelectedIndex = -1 Then
            MsgBox("Silahkan isi Nama Barang dulu")
            Me.cbNamaBarang.Focus()
            Return False
        End If
        If Me.txtQty.Text.Trim = "" Then
            MsgBox("Silahkan isi Qty dulu")
            Me.txtQty.Focus()
            Return False
        End If
        If Me.cbUOM.SelectedIndex = -1 Then
            MsgBox("Silahkan isi Satuan dulu")
            Me.cbUOM.Focus()
            Return False
        End If
        If Me.txtKeterangan.Text = "" Then
            MsgBox("Silahkan isi Keterangan dulu")
            Me.txtKeterangan.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub ClearData()
        Me.txtTransID.Text = ""
        Me.cbNamaKaryawan.Text = ""
        Me.cbCustomer.SelectedIndex = -1
        Me.cbNamaBarang.SelectedIndex = -1
        Me.txtQty.Text = 1
        Me.cbUOM.SelectedIndex = -1
        Me.txtKeterangan.Text = ""
    End Sub


    Private Sub INSERTDATA()
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "INSERT INTO tbATKmain (NamaSite,TglTransaksi, NamaKaryawan, StorerKey, KodeBarang, UOM, JenisTrans, Qty, Keterangan) VALUES (@NamaSite,@TglTransaksi, @NamaKaryawan, @StorerKey, @KodeBarang, @UOM, @JenisTrans, @Qty, @Keterangan)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Me.dtTglTrans.Value, "yyyy/MM/dd")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaKaryawan", Me.cbNamaKaryawan.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("StorerKey", Me.cbCustomer.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.cbNamaBarang.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", Me.cbUOM.SelectedValue))
                If Me.rbWithdrawl.Checked() Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("JenisTrans", "W"))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * (-1) * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))
                Else
                    cmd.Parameters.Add(New SqlClient.SqlParameter("JenisTrans", "D"))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))
                End If
                'cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", Me.txtKeterangan.Text.Trim))
                Try
                    cmd.ExecuteNonQuery()

                    Dim dr As SqlClient.SqlDataReader
                    cmd.CommandText = "Select max(TransID) as TransID from tbATKmain"

                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        Me.txtTransID.Text = dr(0)
                    End If
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub UPDATEDATA()
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Update tbATKmain Set NamaSite=@NamaSite,TglTransaksi=@TglTransaksi, NamaKaryawan=@NamaKaryawan, StorerKey=@StorerKey, KodeBarang=@KodeBarang, UOM=@UOM, JenisTrans=@JenisTrans, Qty=@Qty, Keterangan=@Keterangan WHERE TransID=@TransID"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", Me.txtTransID.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Me.dtTglTrans.Value, "yyyy/MM/dd")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaKaryawan", Me.cbNamaKaryawan.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("StorerKey", Me.cbCustomer.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.cbNamaBarang.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", Me.cbUOM.SelectedValue))
                If Me.rbWithdrawl.Checked() Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("JenisTrans", "W"))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * (-1) * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))
                Else
                    cmd.Parameters.Add(New SqlClient.SqlParameter("JenisTrans", "D"))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))
                End If
                'cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text))

                cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", Me.txtKeterangan.Text.Trim))
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ShowData()
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Select a.TransID,a.TglTransaksi, a.NamaKaryawan, a.StorerKey, a.KodeBarang, b.NamaBarang, a.UOM, case a.JenisTrans when 'D' then 'Deposit' when 'W' then 'Withdrawl' end as JenisTrans, a.Qty, a.Keterangan from tbATKmain a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where TglTransaksi=@TglTransaksi and NamaSite=@NamaSite order by a.TransID desc"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Me.dtTglTrans.Value, "yyyy/MM/dd")))

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "hasil")
                    Me.DataGridView1.DataSource = ds.Tables(0)
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub cbSite_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSite.SelectedIndexChanged
        SaveSetting("ATKCL", "Config", "Site", Me.cbSite.Text)
    End Sub

    Private Sub frmTransaksiATK_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        Me.dtTglTrans.Value = Now.Date

        'CreateDirectory()
    End Sub

    Public Sub CreateDirectory()
        If IO.Directory.Exists(Application.StartupPath.ToString.Trim & "\excelfile") = False Then
            IO.Directory.CreateDirectory(Application.StartupPath.ToString.Trim & "\excelfile")
        End If
    End Sub

    Private Sub IsiKaryawan()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select NIK,EmployeeName from tbabsmst WHERE lower(location)='" & Me.cbSite.Text.Trim.ToLower & "' order by EmployeeName"


                Dim ds As New DataSet
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    da.Fill(ds, "hasil")
                    Me.cbNamaKaryawan.DataSource = ds.Tables(0)
                    Me.cbNamaKaryawan.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                    Me.cbNamaKaryawan.ValueMember = ds.Tables(0).Columns(0).ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub


    Private Sub IsiMasterBarang()
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select KodeBarang,NamaBarang from tbATKmstbrg union select 0 as KodeBarang,'' as NamaBarang order by NamaBarang"


                Dim ds As New DataSet
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    da.Fill(ds, "hasil")
                    Me.cbNamaBarang.DataSource = ds.Tables(0)
                    Me.cbNamaBarang.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                    Me.cbNamaBarang.ValueMember = ds.Tables(0).Columns(0).ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub


    Private Sub SetUOM()
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select top 1 UOM from tbATKuombrg Where Conversi=1 and KodeBarang=@KodeBarang"

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.cbNamaBarang.SelectedValue))

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        Me.cbUOM.SelectedValue = dr(0)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub


    Private Sub cbNamaBarang_DataSourceChanged(sender As Object, e As System.EventArgs) Handles cbNamaBarang.DataSourceChanged

    End Sub

    Private Sub cbNamaBarang_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbNamaBarang.SelectedIndexChanged
        'On Error Resume Next
        If Me.cbNamaBarang.Text = "System.Data.DataRowView" Then Exit Sub
        If Me.cbNamaBarang.Text.Trim = "" Then Exit Sub
        If Me.cbNamaBarang.SelectedIndex = -1 Then Exit Sub

        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select UOM,UOM+'_'+cast(Conversi as varchar(10)) as UOM1 from tbATKuombrg where KodeBarang=@KodeBarang"

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.cbNamaBarang.SelectedValue))

                Dim ds As New DataSet
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    da.Fill(ds, "hasil")
                    Me.cbUOM.DataSource = ds.Tables(0)
                    Me.cbUOM.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                    Me.cbUOM.ValueMember = ds.Tables(0).Columns(0).ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        SetUOM()
    End Sub

    Private Sub frmTransaksiATK_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        IsiCustomer(Me.cbCustomer)
        Me.cbCustomer.SelectedValue = htUser("storerkey")

        IsiNamaSite(Me.cbSite)
        Me.cbSite.SelectedValue = G_KodeWH(htUser("site"))

        IsiMasterBarang()
        IsiKaryawan()
        Me.cbNamaBarang.SelectedIndex = -1

        ShowData()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cbNamaBarang_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbNamaBarang.SelectedValueChanged

    End Sub

    Private Sub cbNamaBarang_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbNamaBarang.Validating

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Me.txtTransID.Text = Me.DataGridView1.Item("TransID", Me.DataGridView1.CurrentRow.Index).Value
        Me.dtTglTrans.Value = Me.DataGridView1.Item("TglTransaksi", Me.DataGridView1.CurrentRow.Index).Value
        If Me.DataGridView1.Item("JenisTrans", Me.DataGridView1.CurrentRow.Index).Value = "Withdrawl" Then
            Me.rbWithdrawl.Checked = True
            Me.rbDeposit.Checked = False
            Me.txtQty.Text = (Me.DataGridView1.Item("Qty", Me.DataGridView1.CurrentRow.Index).Value) * -1
        Else
            Me.rbDeposit.Checked = True
            Me.rbWithdrawl.Checked = False
            Me.txtQty.Text = Me.DataGridView1.Item("Qty", Me.DataGridView1.CurrentRow.Index).Value
        End If
        Me.cbNamaKaryawan.Text = Me.DataGridView1.Item("NamaKaryawan", Me.DataGridView1.CurrentRow.Index).Value
        Me.cbCustomer.SelectedValue = Me.DataGridView1.Item("StorerKey", Me.DataGridView1.CurrentRow.Index).Value
        Me.cbNamaBarang.SelectedValue = Me.DataGridView1.Item("KodeBarang", Me.DataGridView1.CurrentRow.Index).Value

        Me.cbUOM.SelectedValue = Me.DataGridView1.Item("Satuan", Me.DataGridView1.CurrentRow.Index).Value
        Me.txtKeterangan.Text = Me.DataGridView1.Item("Keterangan", Me.DataGridView1.CurrentRow.Index).Value

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Anda yakin akan menghapus Transaksi ini", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Using cn As New SqlClient.SqlConnection(strConnLocal)
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cn.Open()
                        cmd.CommandText = "Delete from tbATKmain where TransID=@TransID"
                        cmd.Parameters.Clear()

                        cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", Me.DataGridView1.Item("TransID", Me.DataGridView1.CurrentRow.Index).Value))

                        Try
                            cmd.ExecuteNonQuery()

                            Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.CurrentRow.Index)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End Using
                End Using
            End If
        End If
    End Sub

    Private Sub DataGridView1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles DataGridView1.KeyPress

    End Sub
End Class