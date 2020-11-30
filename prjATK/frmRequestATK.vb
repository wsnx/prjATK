Public Class frmRequestATK

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Validasi() = False Then
            Exit Sub
        End If

        'Me.DataGridView1.RowCount = Me.DataGridView1.RowCount + 1

        'Me.DataGridView1.Item("NamaKaryawan", Me.DataGridView1.RowCount - 1).Value = Me.cbNamaKaryawan.Text
        'Me.DataGridView1.Item("KodeBarang", Me.DataGridView1.RowCount - 1).Value = Me.cbNamaBarang.SelectedValue
        'Me.DataGridView1.Item("NamaBarang", Me.DataGridView1.RowCount - 1).Value = Me.cbNamaBarang.Text
        'Me.DataGridView1.Item("Satuan", Me.DataGridView1.RowCount - 1).Value = Me.cbUOM.Text.Trim
        'Me.DataGridView1.Item("Qty", Me.DataGridView1.RowCount - 1).Value = Me.txtQty.Text
        'Me.DataGridView1.Item("Keterangan", Me.DataGridView1.RowCount - 1).Value = Me.txtKeterangan.Text.Trim

        If Me.txtTransID.Text.Trim = "" Then
            'INSERTDATA
            Me.INSERTDATAMASTER()
            INSERTDATADETAILS()

        Else
            INSERTDATADETAILS
        End If

        ShowDataDetails()
        ClearDataDetail()
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

    Private Sub ClearDataDetail()
        'Me.txtTransID.Text = ""
        Me.cbNamaKaryawan.Text = ""
        'Me.cbCustomer.SelectedIndex = -1
        Me.cbNamaBarang.SelectedIndex = -1
        Me.txtQty.Text = 1
        Me.cbUOM.SelectedIndex = -1
        Me.txtKeterangan.Text = ""
    End Sub


    Private Sub INSERTDATAMASTER()
        Dim strReqNo As String = ""

        strReqNo = G_MaxReqNo(G_KodeWH(Me.cbSite.Text.Trim))
        Me.txtReqNo.Text = strReqNo
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "INSERT INTO tbATKReqMain (ReqNo,NamaSite,TglTransaksi, StorerKey,Status,InputBy) VALUES (@ReqNo,@NamaSite,@TglTransaksi, @StorerKey,1,@InputBy)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("ReqNo", strReqNo))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Me.dtTglTrans.Value, "yyyy/MM/dd")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("StorerKey", Me.cbCustomer.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("InputBy", strUserName))

                Try
                    cmd.ExecuteNonQuery()

                    Dim dr As SqlClient.SqlDataReader
                    cmd.CommandText = "Select max(TransID) as TransID from tbATKReqMain"

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

    Private Sub INSERTDATADETAILS()
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "INSERT INTO tbATKReqDetails (ReqNo, NamaKaryawan, KodeBarang, UOM, Qty, Keterangan) VALUES (@ReqNo,@NamaKaryawan, @KodeBarang, @UOM, @Qty, @Keterangan)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("ReqNo", Me.txtReqNo.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaKaryawan", Me.cbNamaKaryawan.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.cbNamaBarang.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", Me.cbUOM.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))

                'cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", Me.txtKeterangan.Text.Trim))
                Try
                    cmd.ExecuteNonQuery()

                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub


    'Private Sub GetMaxReqNo()
    '    Using cn As New SqlClient.SqlConnection(strConnLocal)
    '        Using cmd As New SqlClient.SqlCommand
    '            cmd.Connection = cn
    '            cn.Open()
    '            '1502030001'
    '            cmd.CommandText = _
    '                "INSERT INTO tbATKmain (NamaSite,TglTransaksi, NamaKaryawan, StorerKey, KodeBarang, UOM, JenisTrans, Qty, Keterangan) VALUES (@NamaSite,@TglTransaksi, @NamaKaryawan, @StorerKey, @KodeBarang, @UOM, @JenisTrans, @Qty, @Keterangan)"
    '            cmd.Parameters.Clear()
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Me.dtTglTrans.Value, "yyyy/MM/dd")))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("NamaKaryawan", Me.cbNamaKaryawan.Text.Trim))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("StorerKey", Me.cbCustomer.SelectedValue))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.cbNamaBarang.SelectedValue))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", Me.cbUOM.SelectedValue))
    '            If Me.rbWithdrawl.Checked() Then
    '                cmd.Parameters.Add(New SqlClient.SqlParameter("JenisTrans", "W"))
    '                cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * (-1) * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))
    '            Else
    '                cmd.Parameters.Add(New SqlClient.SqlParameter("JenisTrans", "D"))
    '                cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))
    '            End If
    '            'cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", Me.txtKeterangan.Text.Trim))
    '            Try
    '                cmd.ExecuteNonQuery()

    '                Dim dr As SqlClient.SqlDataReader
    '                cmd.CommandText = "Select max(TransID) as TransID from tbATKmain"

    '                dr = cmd.ExecuteReader
    '                If dr.Read() Then
    '                    Me.txtTransID.Text = dr(0)
    '                End If
    '            Catch ex As Exception

    '                MsgBox(ex.Message)
    '            End Try
    '        End Using
    '    End Using
    'End Sub

    'Private Sub UPDATEDATA()
    '    Using cn As New SqlClient.SqlConnection(strConnLocal)
    '        Using cmd As New SqlClient.SqlCommand
    '            cmd.Connection = cn
    '            cn.Open()
    '            '1502030001'
    '            cmd.CommandText = _
    '                "Update tbATKmain Set NamaSite=@NamaSite,TglTransaksi=@TglTransaksi, NamaKaryawan=@NamaKaryawan, StorerKey=@StorerKey, KodeBarang=@KodeBarang, UOM=@UOM, JenisTrans=@JenisTrans, Qty=@Qty, Keterangan=@Keterangan WHERE TransID=@TransID"
    '            cmd.Parameters.Clear()
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", Me.txtTransID.Text.Trim))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Me.dtTglTrans.Value, "yyyy/MM/dd")))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("NamaKaryawan", Me.cbNamaKaryawan.Text.Trim))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("StorerKey", Me.cbCustomer.SelectedValue))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.cbNamaBarang.SelectedValue))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", Me.cbUOM.SelectedValue))
    '            If Me.rbWithdrawl.Checked() Then
    '                cmd.Parameters.Add(New SqlClient.SqlParameter("JenisTrans", "W"))
    '                cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * (-1) * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))
    '            Else
    '                cmd.Parameters.Add(New SqlClient.SqlParameter("JenisTrans", "D"))
    '                cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text * CInt(Mid(cbUOM.Text, InStr(1, cbUOM.Text, "_") + 1))))
    '            End If
    '            'cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text))

    '            cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", Me.txtKeterangan.Text.Trim))
    '            Try
    '                cmd.ExecuteNonQuery()
    '            Catch ex As Exception

    '                MsgBox(ex.Message)
    '            End Try
    '        End Using
    '    End Using
    'End Sub

    Private Sub ShowDataMaster(ByVal ReqNo As Integer)
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                Try
                    cmd.CommandText = _
                        "Select TransID,ReqNo,NamaSite, StorerKey, TglTransaksi,case isnull(Status,1) when 1 then 'Created' when 2 then 'Waiting for Approval' when 3 then 'Approved' when 4 then 'Closed' when 5 then 'Revisi' when 9 then 'Cancelled' end as Status,InputBy from tbATKReqMain where TransID=@TransID and NamaSite=@NamaSite"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", ReqNo))


                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        Me.txtTransID.Text = dr!TransID
                        Me.txtReqNo.Text = dr!ReqNo
                        Me.dtTglTrans.Value = dr!TglTransaksi
                        Me.cbCustomer.SelectedValue = dr!StorerKey
                        Me.txtStatus.Text = dr!Status
                        Me.txtInputBy.Text = dr!InputBy
                    End If
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        If Me.txtStatus.Text.Trim = "Approved" Or Me.txtStatus.Text.Trim = "Closed" Or Me.txtStatus.Text.Trim = "Cancelled" Then
            Me.btnApproval.Enabled = False
        Else
            Me.btnApproval.Enabled = True
        End If

    End Sub

    Private Sub ShowDataDetails()
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                Try
                    cmd.CommandText = _
                        "Select a.TransID,a.NamaKaryawan, a.KodeBarang, b.NamaBarang, a.UOM, a.Qty, a.Keterangan from tbATKReqDetails a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where ReqNo=@ReqNo order by a.TransID desc"
                    cmd.Parameters.Clear()

                    cmd.Parameters.Add(New SqlClient.SqlParameter("ReqNo", Me.txtReqNo.Text.Trim))


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

    Private Sub ShowDataDetailsBlank()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                Try
                    cmd.CommandText = _
                        "Select a.TransID,a.NamaKaryawan, a.KodeBarang, b.NamaBarang, a.UOM, a.Qty, a.Keterangan from tbATKReqDetails a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where 1>2 order by a.TransID desc"
                    cmd.Parameters.Clear()

                    cmd.Parameters.Add(New SqlClient.SqlParameter("ReqNo", Me.txtTransID.Text.Trim))


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

    Private Sub DeleteDataMaster(ByVal ReqNo As Integer)
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                Try
                    cmd.CommandText = _
                        "DELETE tbATKReqMain where TransID=@TransID and NamaSite=@NamaSite"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", ReqNo))

                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub DeleteDataDetail(ByVal ReqNo As Integer)
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                Try
                    cmd.CommandText = _
                        "DELETE tbATKReqDetails where ReqNo=@ReqNo and NamaSite=@NamaSite"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("ReqNo", ReqNo))

                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub cbSite_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSite.SelectedIndexChanged
        SaveSetting("ATKCL", "Config", "Site", Me.cbSite.Text)
        Me.btnLast_Click(Nothing, Nothing)
    End Sub

    Private Sub frmRequestATK_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.dtTglTrans.Value = Now.Date

        'CreateDirectory()
        If strUserType.ToLower = "manager" Or strUserType.ToLower = "deputy manager" Then
            Me.cbSite.Enabled = True
        Else
            Me.cbSite.Enabled = False
        End If

    End Sub

    Public Sub CreateDirectory()
        If IO.Directory.Exists(Application.StartupPath.ToString.Trim & "\excelfile") = False Then
            IO.Directory.CreateDirectory(Application.StartupPath.ToString.Trim & "\excelfile")
        End If
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
        Me.cbCustomer.SelectedValue = htUser("storerkey") 'GetSetting("ATKCL", "Config", "Customer")

         
        IsiNamaSite(Me.cbSite)
        Me.cbSite.SelectedValue = G_KodeWH(htUser("site"))

        'IsiMasterBarang(cbNamaBarang)
        IsiKaryawan(Me.cbSite.Text.Trim.ToLower, cbNamaKaryawan)
        Me.cbNamaBarang.SelectedIndex = -1

        'ShowData()
        Me.WindowState = FormWindowState.Maximized

        btnLast_Click(Nothing, Nothing)
    End Sub

    Private Sub cbNamaBarang_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbNamaBarang.SelectedValueChanged

    End Sub

    Private Sub cbNamaBarang_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbNamaBarang.Validating

    End Sub

     

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Me.txtStatus.Text.Trim = "Approved" Or Me.txtStatus.Text.Trim = "Cancelled" Or Me.txtStatus.Text.Trim = "Closed" Then
                MsgBox("Data Request tidak bisa di-perbaharui lagi")
                e.SuppressKeyPress = True
                Exit Sub
            End If
            If MsgBox("Anda yakin akan menghapus Transaksi ini", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Using cn As New SqlClient.SqlConnection(strCOnnLocal)
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cn.Open()
                        cmd.CommandText = "Delete from tbATKReqDetails where TransID=@TransID"
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

    Private Sub cbCustomer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbCustomer.SelectedIndexChanged

    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label9_Click(sender As System.Object, e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        frmListReqATK.ShowDialog()
    End Sub
 
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Me.txtTransID.Text = ""
        Me.txtReqNo.Text = ""

        Me.cbSite.SelectedValue = G_KodeWH(htUser("site"))
        'Me.cbSite.SelectedItem = htUser("site")
        Me.cbCustomer.SelectedValue = htUser("storerkey")
        Me.txtInputBy.Text = strUserName
        Me.dtTglTrans.Value = Now.Date
        ShowDataDetailsBlank()
        Me.btnApproval.Enabled = True
    End Sub

    Private Sub btnFirst_Click(sender As System.Object, e As System.EventArgs) Handles btnFirst.Click
        Dim intRec As Integer
        intRec = G_FirstRec()
        ShowDataMaster(intRec)
        ShowDataDetails()
    End Sub

    Private Sub btnPrev_Click(sender As System.Object, e As System.EventArgs) Handles btnPrev.Click
        Dim intRec As Integer
        If Me.txtTransID.Text.Trim = "" Then
            btnLast_Click(Nothing, Nothing)
        Else
            intRec = G_PrevRec(Me.txtTransID.Text)
            ShowDataMaster(intRec)
            ShowDataDetails()
        End If
    End Sub

    Private Sub btnNext_Click(sender As System.Object, e As System.EventArgs) Handles btnNext.Click
        Dim intRec As Integer
        If Me.txtTransID.Text.Trim = "" Then
            btnLast_Click(Nothing, Nothing)
        Else
            intRec = G_NextRec(Me.txtTransID.Text)
            ShowDataMaster(intRec)
            ShowDataDetails()
        End If
    End Sub

    Private Sub btnLast_Click(sender As System.Object, e As System.EventArgs) Handles btnLast.Click
        Dim intRec As Integer
        intRec = G_LastRec()
        ShowDataMaster(intRec)
        ShowDataDetails()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Yakin mau di-DELETE data ini ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            DeleteDataDetail(Me.txtTransID.Text)
            DeleteDataMaster(Me.txtTransID.Text)

            btnLast_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnApproval_Click(sender As System.Object, e As System.EventArgs) Handles btnApproval.Click
        If Me.txtReqNo.Text.Trim = "" Then
            MsgBox("Minta Approval Gagal")
            Exit Sub
        End If

        If Me.DataGridView1.RowCount = 0 Then
            MsgBox("Minta Approval Gagal")
            Exit Sub
        End If

        If Me.txtStatus.Text.Trim <> "Created" Then
            If Me.txtStatus.Text.Trim <> "Waiting for Approval" Then
                If Me.txtStatus.Text.Trim <> "Revisi" Then
                    MsgBox("Request ATK tidak bisa dimintakan Approvalnya lagi")
                    Exit Sub
                End If
            End If
        End If
        Dim ws As New WebReference.WebService
        Dim dsTO As New DataSet
        Dim dsCC As New DataSet
        Dim dsBCC As New DataSet
        Dim hasil As String = ""
        Dim detail As String = ""
        Dim strHeader1 As String = ""
        strHeader1 = "<tr>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Karyawan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Barang</th>" & _
                    "<th bgcolor=#00BFFF align=center>Satuan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>Keterangan</th>" & _
                   "</tr>"

        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            detail = detail & "<tr>"
            For j As Integer = 0 To Me.DataGridView1.ColumnCount - 1
                If Me.DataGridView1.Columns(j).Name = "NamaKaryawan" Then
                    detail = detail & "<td>" & Me.DataGridView1.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView1.Columns(j).Name = "NamaBarang" Then
                    detail = detail & "<td>" & Me.DataGridView1.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView1.Columns(j).Name = "Satuan" Then
                    detail = detail & "<td>" & Me.DataGridView1.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView1.Columns(j).Name = "Qty" Then
                    detail = detail & "<td>" & Me.DataGridView1.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView1.Columns(j).Name = "Keterangan" Then
                    detail = detail & "<td>" & Me.DataGridView1.Item(j, i).Value
                    detail = detail & "</td>"
                End If
            Next

            detail = detail & "</tr>"
        Next

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear Pak,<br /><br />Mohon Approvalnya untuk Request ATK No : " & Me.txtReqNo.Text & " dengan detail sebagai berikut : <br /><br /></p>"
        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br /><br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Requested By : " & strUserName & "</b><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"

        Dim ht As New Hashtable
        ht = G_ReqProfile(Me.txtReqNo.Text)

        dsTO = Me.G_EmailAddressTo(ht("reqapproval"))
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC()
        If SendEmail("[ATK] Approval Request", hasil, "", dsTO, dsCC, dsBCC) = False Then
            MsgBox("Kesalahan bukan pada komputer anda")
        Else
            UpdateStatus(Me.txtTransID.Text)
            MsgBox("Send ''Minta Approval'' Sukses")
            Me.txtStatus.Text = "Waiting for Approval"
        End If

    End Sub


    Private Sub UpdateStatus(ByVal TransID As Integer)
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strConnLocal


                cmd.Connection = cn
                cn.Open()

                strSQL = "Update tbATKReqMain set Status=2 Where TransID=@TransID"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", TransID))
                Try

                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub

    Private Function G_EmailAddressTo(ByVal strTo As String) As DataSet
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal


                cmd.Connection = cn
                cn.Open()

                strSQL = "Select '" & strTo & "' as EmailAddress"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL

                Try

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception
                    'MsgBox("Outbound" & vbCrLf & ex.Message)
                    ds = New DataSet
                End Try
            End Using
        End Using
        Return ds
    End Function

    Private Function G_EmailAddressCC(ByVal ht As Hashtable) As DataSet
        Dim ds As DataSet = New DataSet
        Dim emails As String = ""
        Dim strCC As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal
                cmd.Connection = cn
                cn.Open()

                If Microsoft.VisualBasic.Right(ht("copyreq"), 1) <> ";" Then
                    emails = ht("copyreq") & ";"
                Else
                    emails = ht("copyreq")
                End If
                While InStr(emails, ";") > 0
                    strCC = strCC & "union select '" & Microsoft.VisualBasic.Left(emails, InStr(emails, ";") - 1) & "' as EmailAddress "
                    emails = Mid(emails, InStr(emails, ";") + 1)
                End While

                strSQL = "Select '" & ht("emailaddress") & "' as EmailAddress " & strCC
                'strSQL = "Select 'rfaisal@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL

                Try

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception
                    'MsgBox("Outbound" & vbCrLf & ex.Message)
                    ds = New DataSet
                End Try
            End Using
        End Using
        Return ds
    End Function

    Private Function G_EmailAddressBCC() As DataSet
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal

                cmd.Connection = cn
                cn.Open()

                strSQL = "Select 'rfaisal@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL

                Try

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception
                    'MsgBox("Outbound" & vbCrLf & ex.Message)
                    ds = New DataSet
                End Try
            End Using
        End Using
        Return ds
    End Function

    Private Function SendEmail(ByVal strSubject As String, ByVal strMsg As String, ByVal strAttach As String, ByVal dsTo As Data.DataSet, ByVal dsCC As Data.DataSet, ByVal dsBCC As Data.DataSet) As Boolean
        Dim ws As New WebReference.WebService
        Dim hasil As Boolean = True
 
        Try
            ws.Timeout = 6000
            ws.SendEmailNew(strSubject, strMsg, strAttach, "atk_noreply@agility.com", dsTo, dsCC, dsBCC)
            'sr.SendErrorEmail(strSubject, strMsg, dsTo)

            hasil = True
        Catch ex As Exception
            hasil = False
        End Try

        Return hasil

    End Function

    Private Function G_FirstRec() As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(min(TransID),-1) from tbATKReqMain WHERE NamaSite=@NamaSite"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))


                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Private Function G_PrevRec(ByVal CurrRec As Integer) As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(max(TransID),-1) from tbATKReqMain Where TransID < " & CurrRec & " and NamaSite=@NamaSite"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))


                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Private Function G_NextRec(ByVal CurrRec As Integer) As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(min(TransID),-1) from tbATKReqMain Where TransID > " & CurrRec & " and NamaSite=@NamaSite"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))


                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Private Function G_LastRec() As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(max(TransID),-1) from tbATKReqMain Where NamaSite=@NamaSite"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click

    End Sub
End Class