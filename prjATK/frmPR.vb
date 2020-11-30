Public Class frmPR

    Private Function Validasi() As Boolean
        Dim hasil As Boolean = False
        If Me.cbSite.Text.Trim = "" Then
            MsgBox("Silahkan pilih Site dulu")
            Me.cbSite.Focus()
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
        Me.cbCustomer.SelectedIndex = -1
        Me.cbNamaBarang.SelectedIndex = -1
        Me.txtQty.Text = 0
        Me.cbUOM.SelectedIndex = -1
        Me.txtKeterangan.Text = ""
    End Sub


    Private Sub INSERTDATAMASTER()
        Me.txtPRNo.Text = G_MaxPRNo(G_KodeWH(Me.cbSite.Text.Trim))

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "INSERT INTO tbATKPRMain (PRNo,NamaSite,Name,Designation,TglTransaksi,DateRequired,StorerKey,EndUserLocation,Status,InputBy) VALUES (@PRNo,@NamaSite,@Name,@Designation,@TglTransaksi,@DateRequired,@StorerKey,@EndUserLocation,1,@InputBy)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.txtPRNo.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Name", Me.cbNama.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Designation", Me.cbJabatan.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Me.dtTglTrans.Value, "yyyy/MM/dd")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("DateRequired", Format(Me.dtpDateReq.Value, "yyyy/MM/dd")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("StorerKey", Me.cbCustomer.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserLocation", Me.cbLocation.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("InputBy", strUserName))

                Try
                    cmd.ExecuteNonQuery()

                    Dim dr As SqlClient.SqlDataReader
                    cmd.CommandText = "Select max(TransID) as TransID from tbATKPRMain"

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
    Private Sub UpdateDataMaster()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Update tbATKPRMain set NamaSite=@NamaSite,Name=@Name,Designation=@Designation,TglTransaksi=@TglTransaksi,DateRequired=@DateRequired,StorerKey=@StorerKey,EndUserLocation=@EndUserLocation where PRNo=@PRNo "
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.txtPRNo.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Name", Me.cbNama.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Designation", Me.cbJabatan.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Me.dtTglTrans.Value, "yyyy/MM/dd")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("DateRequired", Format(Me.dtpDateReq.Value, "yyyy/MM/dd")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("StorerKey", Me.cbCustomer.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserLocation", Me.cbLocation.Text))
              
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub btnAddDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDetails.Click
     
        If Cek_Master(Me.cbNamaBarang.Text) = False Then
            MsgBox("Nama Barang belum terdaftar")
            Me.cbNamaBarang.Focus()
            Exit Sub
        End If

        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            If Me.DataGridView1.Item("KodeBarang", i).Value = Me.cbNamaBarang.SelectedValue Then
                MsgBox("Nama Barang sudah ada dalam list")
                Me.cbNamaBarang.Focus()
                Exit Sub
            End If
        Next

        If Validasi() = False Then
            Exit Sub
        End If

        Dim ht As Hashtable
        ht = G_ItemDetails()

        If Me.txtStatus.Text = "" Then
            Me.DataGridView1.RowCount = Me.DataGridView1.RowCount + 1
            Me.DataGridView1.Item("KodeBarang", Me.DataGridView1.RowCount - 1).Value = Me.cbNamaBarang.SelectedValue
            Me.DataGridView1.Item("NamaBarang", Me.DataGridView1.RowCount - 1).Value = Me.cbNamaBarang.Text
            Me.DataGridView1.Item("UOM", Me.DataGridView1.RowCount - 1).Value = cbUOM.SelectedValue
            Me.DataGridView1.Item("Qty", Me.DataGridView1.RowCount - 1).Value = Me.txtQty.Text
            Me.DataGridView1.Item("Keterangan", Me.DataGridView1.RowCount - 1).Value = Me.txtKeterangan.Text.Trim
            Me.DataGridView1.Item("LastPrice", Me.DataGridView1.RowCount - 1).Value = ht("LastPrice")
            Me.DataGridView1.Item("EstTotPrice", Me.DataGridView1.RowCount - 1).Value = Me.txtQty.Text * ht("LastPrice")
            If Me.ckYes.Checked = True Then
                Me.DataGridView1.Item("PurchasedbyGA", Me.DataGridView1.RowCount - 1).Value = 1
            Else
                Me.DataGridView1.Item("PurchasedbyGA", Me.DataGridView1.RowCount - 1).Value = 0
            End If
        Else
            Using cn As New SqlClient.SqlConnection(strCOnnLocal)
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = cn
                    cn.Open()
                    Try
                        cmd.CommandText =
                        "INSERT INTO tbATKPRDetails (PRNo,KodeBarang, UOM, Qty, Keterangan,LastPrice,EstTotPrice,PurchasedbyGA) VALUES (@PRNo,@KodeBarang, @UOM, @Qty, @Keterangan,@LastPrice,@LastPrice*@Qty,@PurchasedbyGA)"
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.txtPRNo.Text.Trim))
                        'cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserName", Me.cbCustomer.SelectedValue))
                        'cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserLocation", Me.cbLocation.SelectedValue))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.cbNamaBarang.SelectedValue))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", cbUOM.SelectedValue))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.txtQty.Text))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", Me.txtKeterangan.Text.Trim))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("LastPrice", ht("LastPrice")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("EstTotPrice", Me.txtQty.Text * ht("LastPrice")))
                        If Me.ckYes.Checked = True Then
                            cmd.Parameters.Add(New SqlClient.SqlParameter("PurchasedbyGA", 1))
                        Else
                            cmd.Parameters.Add(New SqlClient.SqlParameter("PurchasedbyGA", 0))
                        End If
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End Using
            End Using
            G_DataPRDetail(Me.txtPRNo.Text.Trim, Me.DataGridView1)
        End If

        Me.cbNamaBarang.Text = ""
        Me.txtQty.Text = 0
        Me.cbHarga.Text = ""



    End Sub
    Private Sub INSERTDATADETAILS()
        Dim ht As New Hashtable

        ht = G_ItemDetails()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                    With Me.DataGridView1
                        If IsDBNull(.Item("TransID", i).Value) Or .Item("TransID", i).Value = Nothing Then
                            cmd.CommandText =
                            "INSERT INTO tbATKPRDetails (PRNo,KodeBarang, UOM, Qty, Keterangan,LastPrice,EstTotPrice,PurchasedbyGA) VALUES (@PRNo,@KodeBarang, @UOM, @Qty, @Keterangan,@LastPrice,@LastPrice*@Qty,@PurchasedbyGA)"
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.txtPRNo.Text.Trim))
                            'cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserName", Me.cbCustomer.SelectedValue))
                            'cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserLocation", Me.cbLocation.SelectedValue))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", .Item("KodeBarang", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", .Item("UOM", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", .Item("Qty", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", .Item("Keterangan", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("LastPrice", .Item("LastPrice", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("EstTotPrice", .Item("Qty", i).Value * .Item("LastPrice", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("PurchasedbyGA", .Item("PurchasedbyGA", i).Value))
                        Else
                            cmd.CommandText =
                            "Update tbATKPRDetails set KodeBarang=@KodeBarang,UOM=@UOM,Qty=@Qty,Keterangan=@Keterangan,LastPrice=@LastPrice,EstTotPrice=@EstTotPrice,PurchasedbyGA=@PurchasedbyGA where TransID=@TransID"
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.txtPRNo.Text.Trim))
                            'cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserName", Me.cbCustomer.SelectedValue))
                            'cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserLocation", Me.cbLocation.SelectedValue))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", .Item("KodeBarang", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", .Item("UOM", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", .Item("Qty", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", .Item("Keterangan", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("LastPrice", .Item("LastPrice", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("EstTotPrice", .Item("EstTotPrice", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("PurchasedbyGA", .Item("PurchasedbyGA", i).Value))
                        End If

                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End With
                Next
            End Using
        End Using
    End Sub
    Private Sub UPDATEDATADETAILS()
        'Dim ht As New Hashtable

        'ht = G_ItemDetails()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                    With Me.DataGridView1
                        If IsDBNull(.Item("TransID", i).Value) Or .Item("TransID", i).Value = Nothing Then
                            cmd.CommandText =
                            "INSERT INTO tbATKPRDetails (PRNo,KodeBarang, UOM, Qty, Keterangan,LastPrice,EstTotPrice,PurchasedbyGA) VALUES (@PRNo,@KodeBarang, @UOM, @Qty, @Keterangan,@LastPrice,@LastPrice*@Qty,@PurchasedbyGA)"
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.txtPRNo.Text.Trim))
                            'cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserName", Me.cbCustomer.SelectedValue))
                            'cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserLocation", Me.cbLocation.SelectedValue))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", .Item("KodeBarang", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", .Item("UOM", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", .Item("Qty", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", .Item("Keterangan", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("LastPrice", .Item("LastPrice", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("EstTotPrice", .Item("Qty", i).Value * .Item("LastPrice", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("PurchasedbyGA", .Item("PurchasedbyGA", i).Value))
                        Else
                            cmd.CommandText =
                            "Update tbATKPRDetails set KodeBarang=@KodeBarang,UOM=@UOM,Qty=@Qty,Keterangan=@Keterangan,LastPrice=@LastPrice,EstTotPrice=@EstTotPrice,PurchasedbyGA=@PurchasedbyGA where TransID=@TransID"
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.txtPRNo.Text.Trim))
                            'cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserName", Me.cbCustomer.SelectedValue))
                            'cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserLocation", Me.cbLocation.SelectedValue))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", .Item("KodeBarang", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", .Item("UOM", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", .Item("Qty", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", .Item("Keterangan", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("LastPrice", .Item("LastPrice", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("EstTotPrice", .Item("EstTotPrice", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("PurchasedbyGA", .Item("PurchasedbyGA", i).Value))
                            cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", .Item("TransID", i).Value))
                        End If

                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End With
                Next
            End Using
        End Using
    End Sub
    Private Function G_ItemDetails() As Hashtable
        Dim ht As New Hashtable

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Select * from tbATKmstbrg Where KodeBarang=@KodeBarang"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.cbNamaBarang.SelectedValue))

                Try
                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        ht.Clear()
                        ht.Add("KodeBarang", dr!KodeBarang)
                        ht.Add("NamaBarang", dr!NamaBarang)
                        ht.Add("UOM", dr!UOM)
                        ht.Add("MinStock", dr!MinStock)
                        ht.Add("ReOrderQty", dr!ReOrderQty)
                        ht.Add("LastPrice", dr!LastPrice)
                    End If

                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ht
    End Function

    Private Sub ShowDataMaster(ByVal TransID As Integer)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                Try
                    cmd.CommandText =
                    "Select a.TransID,isnull(a.PRNo,'') as PRNo,NamaSite, StorerKey,isnull(Name,'')Name,NamaSite,isnull(Designation,'')Designation, " &
                    "isnull(DateRequired,TglTransaksi)DateRequired,TglTransaksi,case isnull(Status,1) when 1 then 'Created' when 2 then 'Waiting for Approval' " &
                    "when 3 then 'Approved' when 4 then 'Waiting 2nd Approval'when 5 then 'Approved' when 9 then 'Cancelled' end as Status,isnull(a.EndUserLocation,b.EndUserLocation)EndUserLocation,a.Storerkey EndUserName " &
                    ",a.InputBy from tbATKPRMain a inner join tbatkprdetails b on a.PRNo=b.PRNo where a.TransID=@TransID and NamaSite=@NamaSite and a.inputby=@inputby"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", TransID))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("inputby", strUserName))


                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        Me.txtTransID.Text = dr!TransID
                        Me.txtPRNo.Text = dr!PRNo
                        Me.cbCustomer.SelectedValue = dr!StorerKey
                        Me.dtTglTrans.Value = dr!TglTransaksi
                        Me.txtStatus.Text = dr!Status
                        Me.cbNama.Text = dr!Name
                        Me.dtpDateReq.Value = dr!DateRequired
                        Me.cbJabatan.SelectedValue = dr!Designation
                        Me.cbLocation.Text = dr!EndUserLocation
                        Me.cbCustomer.Text = dr!EndUserName
                        Me.TxtInputBy.Text = dr!InputBy

                    End If
                Catch ex As Exception

                    Me.txtTransID.Text = ""
                    Me.txtPRNo.Text = ""
                    Me.cbCustomer.SelectedValue = ""
                    Me.dtTglTrans.Value = DateTime.Now
                    Me.txtStatus.Text = ""
                    Me.cbNama.Text = ""
                    Me.dtpDateReq.Value = DateTime.Now
                    Me.cbJabatan.SelectedValue = ""
                    Me.cbLocation.Text = ""
                    Me.cbCustomer.Text = ""
                    Me.TxtInputBy.Text = Me.TxtInputBy.Text
                End Try
            End Using
        End Using

        If Me.txtStatus.Text.Trim = "Approved" Or Me.txtStatus.Text.Trim = "Closed" Or Me.txtStatus.Text.Trim = "Cancelled" Or Me.txtStatus.Text.Trim = "Waiting 2nd Approval" Then
            Me.btnApproval.Enabled = False
            Me.btnAddDetails.Enabled = False
            Me.btnPrint.Enabled = True
        Else
            Me.btnApproval.Enabled = True
            Me.btnAddDetails.Enabled = True
            Me.btnPrint.Enabled = False
        End If
    End Sub
    Private Sub ShowDataMaster1()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                Try
                    cmd.CommandText =
                     "Select a.TransID,isnull(a.PRNo,'') as PRNo,NamaSite, StorerKey,isnull(Name,'')Name,isnull(Designation,'')Designation, " &
                    "isnull(DateRequired,TglTransaksi)DateRequired,TglTransaksi,case isnull(Status,1) when 1 then 'Created' when 2 then 'Waiting for Approval' " &
                    "when 3 then 'Approved' when 4 then 'Closed' when 5 then 'Revisi' when 6 then 'Waiting 2nd Approval' when 9 then 'Cancelled' end as Status,isnull(a.EndUserLocation,b.EndUserLocation)EndUserLocation,a.Storerkey EndUserName " &
                    "from tbATKPRMain a inner join tbatkprdetails b on a.PRNo=b.PRNo where a.PRNo=@PRNo "
                    cmd.Parameters.Clear()
                    'cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.txtPRNo.Text.Trim))

                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        Me.txtTransID.Text = dr!TransID
                        Me.txtPRNo.Text = dr!PRNo
                        Me.cbSite.Text = dr!NameSite
                        Me.cbCustomer.Text = dr!StorerKey
                        Me.cbNama.Text = dr!Name
                        Me.cbJabatan.SelectedValue = dr!Designation
                        Me.dtpDateReq.Value = dr!DateRequired
                        Me.dtTglTrans.Value = dr!TglTransaksi
                        Me.txtStatus.Text = dr!Status
                        Me.cbLocation.Text = dr!EndUserLocation
                        Me.cbCustomer.Text = dr!EndUserName
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        If Me.txtStatus.Text.Trim = "Approved" Or Me.txtStatus.Text.Trim = "Closed" Or Me.txtStatus.Text.Trim = "Cancelled" Then
            Me.btnApproval.Enabled = False
            Me.btnAddDetails.Enabled = False
        Else
            Me.btnApproval.Enabled = True
            Me.btnAddDetails.Enabled = True
        End If
    End Sub
    'Private Sub ShowDataDetails()
    '    Using cn As New SqlClient.SqlConnection(strConnLocal)
    '        Using cmd As New SqlClient.SqlCommand
    '            cmd.Connection = cn
    '            cn.Open()
    '            '1502030001'
    '            Try
    '                cmd.CommandText = _
    '                    "Select a.TransID, a.KodeBarang, b.NamaBarang, a.UOM, a.Qty, a.Keterangan,isnull(a.LastPrice,0) LastPrice,isnull(a.EstTotPrice,0) EstTotPrice,PurchasedByGA from tbATKPRDetails a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where PRNo=@PRNo order by a.TransID desc"
    '                cmd.Parameters.Clear()

    '                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.txtPRNo.Text.Trim))


    '                Dim da As New SqlClient.SqlDataAdapter(cmd)
    '                Dim ds As New DataSet
    '                da.Fill(ds, "hasil")
    '                Me.DataGridView1.DataSource = ds.Tables(0)
    '            Catch ex As Exception

    '                MsgBox(ex.Message)
    '            End Try
    '        End Using
    '    End Using
    'End Sub

    'Private Sub ShowDataDetailsBlank()
    '    Using cn As New SqlClient.SqlConnection(strCOnnLocal)
    '        Using cmd As New SqlClient.SqlCommand
    '            cmd.Connection = cn
    '            cn.Open()
    '            '1502030001'
    '            Try
    '                cmd.CommandText = _
    '                    "Select a.TransID, a.KodeBarang, b.NamaBarang, a.UOM, a.Qty, a.Keterangan,isnull(a.LastPrice,0) LastPrice,isnull(a.EstTotPrice,0) EstTotPrice from tbATKPRDetails a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where 1>2 order by a.TransID desc"
    '                cmd.Parameters.Clear()

    '                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.txtTransID.Text.Trim))


    '                Dim da As New SqlClient.SqlDataAdapter(cmd)
    '                Dim ds As New DataSet
    '                da.Fill(ds, "hasil")
    '                Me.DataGridView1.DataSource = ds.Tables(0)
    '            Catch ex As Exception

    '                MsgBox(ex.Message)
    '            End Try
    '        End Using
    '    End Using
    'End Sub


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

    

    Private Sub frmTransaksiATK_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        IsiNamaSite(Me.cbLocation)
        Me.dtpDateReq.Value = DateAdd(DateInterval.Day, 14, Me.dtTglTrans.Value)
        Me.dtTglTrans.Value = Now.Date

        'CreateDirectory()
    End Sub

    Public Sub CreateDirectory()
        If IO.Directory.Exists(Application.StartupPath.ToString.Trim & "\excelfile") = False Then
            IO.Directory.CreateDirectory(Application.StartupPath.ToString.Trim & "\excelfile")
        End If
    End Sub

    Private Sub SetUOM()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
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
    Private Sub cbNamaBarang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNamaBarang.SelectedIndexChanged

        'On Error Resume Next
        If Me.cbNamaBarang.Text = "System.Data.DataRowView" Then Exit Sub
        If Me.cbNamaBarang.Text.Trim = "" Then Exit Sub
        If Me.cbNamaBarang.SelectedIndex = -1 Then Exit Sub

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select a.UOM,a.UOM+'_'+cast(Conversi as varchar(10)) as UOM1,isnull(LastPrice,0)LastPrice from tbATKuombrg a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where a.KodeBarang=@KodeBarang"

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.cbNamaBarang.SelectedValue))

                Dim ds As New DataSet
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    da.Fill(ds, "hasil")
                    Me.cbUOM.DataSource = ds.Tables(0)
                    Me.cbUOM.DisplayMember = ds.Tables(0).Columns(0).ColumnName
                    Me.cbUOM.ValueMember = ds.Tables(0).Columns(0).ColumnName

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        SetUOM()
        ShowHarga()
    End Sub
    Private Sub ShowHarga()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select isnull(LastPrice,0)LastPrice from tbATKmstbrg where KodeBarang=@KodeBarang"

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.cbNamaBarang.SelectedValue))

                Dim ds As New DataSet
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    da.Fill(ds, "hasil")
                    Me.cbHarga.DataSource = ds.Tables(0)
                    Me.cbHarga.DisplayMember = ds.Tables(0).Columns(0).ColumnName

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub frmTransaksiATK_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.cbSite.Text = "JKT - NSO" Then
            IsiDept(Me.cbCustomer)
        ElseIf Me.cbSite.Text = "JKT - Office Halim" Then
            IsiDept(Me.cbCustomer)
        Else
            IsiCustomer(Me.cbCustomer)
            Me.cbCustomer.SelectedValue = htUser("storerkey") 'GetSetting("ATKCL", "Config", "Customer")
        End If


        IsiNamaSite(Me.cbSite)

            Me.cbSite.SelectedValue = G_KodeWH(htUser("site"))

        'IsiNamaSite(Me.cbLocation)

        'IsiMasterBarang(Me.cbNamaBarang)
        'IsiKaryawan()
        Me.cbNamaBarang.SelectedIndex = -1

        'ShowData()
        Me.WindowState = FormWindowState.Maximized

        btnLast_Click(Nothing, Nothing)

        If strUserType.ToLower = "manager" Or strUserType.ToLower = "deputy manager" Or strUserType.ToLower = "adminatk" Then
            Me.cbSite.Enabled = True
        Else
            Me.cbSite.Enabled = False
        End If

        If strUserName.ToLower = "vero" Or strUserName.ToLower = "farimbayu" Then
            BtnNewMaster.Enabled = True
        Else
            BtnNewMaster.Enabled = False
        End If

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Anda yakin akan menghapus Transaksi ini", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Using cn As New SqlClient.SqlConnection(strCOnnLocal)
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cn.Open()
                        cmd.CommandText = "Delete from tbATKPRDetails where TransID=@TransID"
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

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        'frmCari.ShowDialog()
        'If Me.txtTransID.Text = "" Then
        '    btnLast_Click(Nothing, Nothing)
        'Else
        'ShowDataMaster1()
        '    G_DataPRDetail(Me.txtPRNo.Text, Me.DataGridView1)
        'End If

        Dim strNoPR As String = ""
        Dim strTransID As Integer
        strNoPR = InputBox("No. PR : ", "Input No PR yang dicari", "")
        If strNoPR.Trim = "" Then
            Exit Sub
        Else
            strTransID = G_NoPR(strNoPR)
            If strTransID <> -1 Then
                Me.txtPRNo.Text = strNoPR
                Me.txtTransID.Text = strTransID
                IsiDataPR()
            End If
        End If

        If Me.txtStatus.Text.Trim = "Approved" Or Me.txtStatus.Text.Trim = "Closed" Then
            Me.btnApproval.Enabled = False
            Me.btnAddDetails.Enabled = False
            Me.btnPrint.Enabled = True
        Else
            Me.btnApproval.Enabled = True
            Me.btnAddDetails.Enabled = True
            Me.btnPrint.Enabled = False
        End If
    End Sub
    Public Sub IsiDataPR()
        Dim ht As New Hashtable
        ht = G_DatasplMain(Me.txtTransID.Text)

        If ht.Count > 0 Then

            Me.txtTransID.Text = ht("TransID")
            Me.txtPRNo.Text = ht("PRNo")
            Me.cbSite.SelectedValue = G_KodeWH(ht("NamaSite"))
            Me.cbCustomer.Text = KodeCustomer(ht("Storerkey"))
            Me.cbNama.Text = ht("Name")
            Me.cbJabatan.Text = ht("Designation")
            Me.dtTglTrans.Value = ht("TglTransaksi")
            Me.dtpDateReq.Value = ht("DateRequired")
            Me.cbLocation.Text = ht("EndUserLocation")
            Me.TxtInputBy.Text = ht("InputBy")

            Select Case ht("Status")
                Case "Created"
                    Me.txtStatus.Text = "Created"
                    Me.dtTglTrans.Enabled = True
                Case "Waiting for Approval"
                    Me.txtStatus.Text = "Waiting for Approval"
                    Me.dtTglTrans.Enabled = False
                Case "Waiting 2nd Approval"
                    Me.txtStatus.Text = "Waiting 2nd Approval"
                    Me.dtTglTrans.Enabled = False
                Case "Approved"
                    Me.txtStatus.Text = "Approved"
                    Me.dtTglTrans.Enabled = False
                Case "Closed"
                    Me.txtStatus.Text = "Closed"
                    Me.dtTglTrans.Enabled = False
                Case "Revisi"
                    Me.txtStatus.Text = "Revisi"
                    Me.dtTglTrans.Enabled = False
                Case "Submitted PO"
                    Me.txtStatus.Text = "Submitted PO"
                    Me.dtTglTrans.Enabled = False
                Case "Cancelled"
                    Me.txtStatus.Text = "Cancelled"
                    Me.dtTglTrans.Enabled = False
            End Select

        End If
        G_DataPRDetail(Me.txtPRNo.Text, Me.DataGridView1)

        Application.DoEvents()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.txtTransID.Text = ""
        Me.txtPRNo.Text = ""
        Me.cbSite.SelectedValue = G_KodeWH(htUser("site"))
        If Me.cbSite.Text = "JKT - NSO" Then
            IsiDept(Me.cbCustomer)
            Me.cbCustomer.SelectedValue = htUser("department")
        ElseIf Me.cbSite.Text = "JKT - Office Halim" Then
            IsiDept(Me.cbCustomer)
            Me.cbCustomer.SelectedValue = htUser("department")
        Else
            Me.cbCustomer.SelectedValue = htUser("storerkey")
            End if
            'ShowDataDetailsBlank()
            Me.dtTglTrans.Value = Now.Date
        Me.dtpDateReq.Value = DateAdd(DateInterval.Day, 14, Me.dtTglTrans.Value)

        Me.btnApproval.Enabled = True
        Me.btnPrint.Enabled = False
        'Me.DataGridView1.RowCount = 0
        Me.TxtInputBy.Text = strUserName
        Me.txtStatus.Text = "New"
        GridKosong()
        Me.btnAddDetails.Enabled = True
    End Sub
    Private Sub GridKosong()
        Me.DataGridView1.RowCount = 0
    End Sub
    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        Dim intRec As Integer
        intRec = G_FirstRec()
        ShowDataMaster(intRec)
        G_DataPRDetail(Me.txtPRNo.Text.Trim, Me.DataGridView1)
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Dim intRec As Integer
        If Me.txtTransID.Text.Trim = "" Then
            btnLast_Click(Nothing, Nothing)
        Else
            intRec = G_PrevRec(Me.txtTransID.Text)
            ShowDataMaster(intRec)
            G_DataPRDetail(Me.txtPRNo.Text, Me.DataGridView1)
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim intRec As Integer
        If Me.txtTransID.Text.Trim = "" Then
            btnLast_Click(Nothing, Nothing)
        Else
            intRec = G_NextRec(Me.txtTransID.Text)
            ShowDataMaster(intRec)
            G_DataPRDetail(Me.txtPRNo.Text.Trim, Me.DataGridView1)
        End If
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        Dim intRec As Integer
        Dim strUser As String
        strUser = strUserName
        intRec = G_LastRec()
        ShowDataMaster(intRec)
        If Me.txtPRNo.Text = "" Then

        Else
            G_DataPRDetail(Me.txtPRNo.Text.Trim, Me.DataGridView1)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Yakin mau di-DELETE data ini ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            UpdateStatus(Me.txtTransID.Text, 9)
            btnLast_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproval.Click
        If Me.txtPRNo.Text = "" Then
            MsgBox("Nomor PR masih kosong" & vbCrLf & "Pastikan data di-Save terlebih dahulu")
            Exit Sub
        End If

        Dim ws As New WebReference.WebService
        Dim dsTO As New DataSet
        Dim dsCC As New DataSet
        Dim dsBCC As New DataSet
        Dim hasil As String = ""
        Dim detail As String = ""
        Dim summary As String = ""
        Dim strHeader1 As String = ""
        Dim strFooter As String = ""
        strHeader1 = "<tr>" &
                    "<th bgcolor=#00BFFF align=center>Nama Barang</th>" &
                    "<th bgcolor=#00BFFF align=center>Satuan</th>" &
                    "<th bgcolor=#00BFFF align=center>Qty</th>" &
                    "<th bgcolor=#00BFFF align=center>LastPrice</th>" &
                    "<th bgcolor=#00BFFF align=center>EstTotPrice</th>" &
                    "<th bgcolor=#00BFFF align=center>Keterangan</th>" &
                    "<th bgcolor=#00BFFF align=center>Di Tagihkan ke Customer</th>" &
                   "</tr>"
        Dim ds As New DataSet
        ds = ShowDataHarga(Me.txtPRNo.Text)

        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            With Me.DataGridView1
                detail = detail & "<tr>"

                detail = detail & "<td>" & .Item("NamaBarang", i).Value
                detail = detail & "</td>"

                detail = detail & "<td>" & .Item("UOM", i).Value
                detail = detail & "</td>"

                detail = detail & "<td>" & .Item("Qty", i).Value
                detail = detail & "</td>"

                detail = detail & "<td>" & Format(.Item("LastPrice", i).Value, "##,##0")
                detail = detail & "</td>"

                detail = detail & "<td>" & Format(.Item("EstTotPrice", i).Value, "##,##0")
                detail = detail & "</td>"

                detail = detail & "<td>" & .Item("Keterangan", i).Value
                detail = detail & "</td>"

                detail = detail & "<td>" & IIf(.Item("PurchasedbyGA", i).Value = 1, "Ya", "Tidak")
                detail = detail & "</td>"
                detail = detail & "</tr>"
            End With
        Next
        strFooter = "<tr>" & _
                      "<th bgcolor=#CCCCCC align=center>Total Price : Rp. " & IIf(IsDBNull(Format(ds.Tables(0).Rows(0)("EstTotPrice"), "##,##0")), "0", Format(ds.Tables(0).Rows(0)("EstTotPrice"), "##,##0")) & "</th></tr>"
        'summary = summary & "<td>" &
        'summary = summary & "</td>"

        Dim ht As New Hashtable
        ht = G_PRProfile(Me.txtPRNo.Text)
        If ht("department") = "Kaizen" Then
            hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
            hasil = hasil & "Dear " & ht("apptittle") & " " & ht("prappname") & ",<br /><br />Mohon Approvalnya untuk PR ATK No : " & Me.txtPRNo.Text & " dengan detail sebagai berikut : <br />"
            hasil = hasil & "<table border='0' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>"
            hasil = hasil & "<tr><td align='right'>Transaction Date     : </td><td>" & Format(Me.dtTglTrans.Value, "dd-MMM-yyyy") & "</td></tr>"
            hasil = hasil & "<tr><td align='right'>Name of Applicant    : </td><td>" & Me.cbNama.Text.Trim & "</td></tr>"
            hasil = hasil & "<tr><td align='right'>End User Name        : </td><td>" & Me.cbCustomer.Text & "</td></tr>"
            hasil = hasil & "<tr><td align='right'>End User Location    : </td><td>" & Me.cbLocation.Text & "</td></tr>"
            hasil = hasil & "<tr><td align='right'>Type PR              : </td><td>PROJECT</td></tr></table></p>"
        Else
            hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
            hasil = hasil & "Dear " & ht("apptittle") & " " & ht("prappname") & ",<br /><br />Mohon Approvalnya untuk PR ATK No : " & Me.txtPRNo.Text & " dengan detail sebagai berikut : <br />"
            hasil = hasil & "<table border='0' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>"
            hasil = hasil & "<tr><td align='right'>Transaction Date     : </td><td>" & Format(Me.dtTglTrans.Value, "dd-MMM-yyyy") & "</td></tr>"
            hasil = hasil & "<tr><td align='right'>Name of Applicant    : </td><td>" & Me.cbNama.Text.Trim & "</td></tr>"
            hasil = hasil & "<tr><td align='right'>End User Name        : </td><td>" & Me.cbCustomer.Text & "</td></tr>"
            hasil = hasil & "<tr><td align='right'>End User Location    : </td><td>" & Me.cbLocation.Text & "</td></tr>"
            hasil = hasil & "<tr><td align='right'>Type PR              : </td><td></td>Non Project</td></tr></table></p>"
        End If


        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail & strFooter
        hasil = hasil & "</table> <br /><br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Silahkan klik <a href='http://10.130.12.190/eproc/prapproval.aspx?n=" & Me.txtPRNo.Text & "&apr=1'>disini</a> untuk proses approval.<br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Requested By : " & strUserName & "</b><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Do Not Reply</b><br /></p>"


        dsTO = Me.G_EmailAddressTo(ht("prapproval"))
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC("atk")

        UpdateStatus(Me.txtTransID.Text, 2)
        Me.txtStatus.Text = "Waiting for Approval"
        If SendEmail("[Purchase Request] Approval Request for PR No. " & Me.txtPRNo.Text, hasil, "", dsTO, dsCC, dsBCC) = False Then
            MsgBox("[Purchase Request] Approval Request is succesfully but unsend email ")
        Else
            MsgBox("Send ''[Purchase Request] Approval Request'' Successfully")
        End If

    End Sub

    Private Function SendEmail(ByVal strSubject As String, ByVal strMsg As String, ByVal strAttach As String, ByVal dsTo As Data.DataSet, ByVal dsCC As Data.DataSet, ByVal dsBCC As Data.DataSet) As Boolean
        Dim ws As New WebReference.WebService
        Dim hasil As Boolean = True

        Try
            ws.Timeout = 30000
            ws.SendEmailNew(strSubject, strMsg, strAttach, "PR_Noreply@agility.com", dsTo, dsCC, dsBCC)
            'sr.SendErrorEmail(strSubject, strMsg, dsTo)
            hasil = True
        Catch ex As Exception
            hasil = False
        End Try

        Return hasil

    End Function
    Private Sub UpdateStatus(ByVal TransID As Integer, ByVal strStatus As Integer)
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal


                cmd.Connection = cn
                cn.Open()

                strSQL = "Update tbATKPRMain set Status=@Status Where TransID=@TransID"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", TransID))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Status", strStatus))
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub

    Private Function G_EmailAddressTo(ByVal strTO As String) As DataSet
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal


                cmd.Connection = cn
                cn.Open()

                strSQL = "Select '" & strTO & "' as EmailAddress"

                'If RequestType = "PRApproval" Then
                '    strSQL = "Select '" & GetSetting("ATKCL", "Config", "PRApproval") & "' as EmailAddress"
                'ElseIf RequestType = "PRApproved" Then
                '    strSQL = "Select '" & GetSetting("ATKCL", "Config", "AdminATK") & "' as EmailAddress"
                'End If

                'strSQL = "Select 'farimbayu@agility.com' as EmailAddress"

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

                If Microsoft.VisualBasic.Right(ht("copypr"), 1) <> ";" Then
                    emails = ht("copypr") & ";"
                Else
                    emails = ht("copypr")
                End If
                While InStr(emails, ";") > 0
                    strCC = strCC & "union select '" & Microsoft.VisualBasic.Left(emails, InStr(emails, ";") - 1) & "' as EmailAddress "
                    emails = Mid(emails, InStr(emails, ";") + 1)
                End While

                strSQL = "Select '" & ht("emailaddress") & "' as  EmailAddress " & strCC

                'strSQL = "Select 'farimbayu@agility.com' as EmailAddress"
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

    Private Function G_EmailAddressBCC(ByVal strReportType As String) As DataSet
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal

                cmd.Connection = cn
                cn.Open()
                'strSQL = "Select EmailAddress from tbEmailReceiver where ReportType='" & strReportType & "' and isbcc=1"
                strSQL = "Select 'farimbayu@agility.com' as EmailAddress"
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

    Private Function G_FirstRec() As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select min(TransID) from tbATKPRMain WHERE NamaSite=@NamaSite and inputby=@inputby"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("inputby", strUserName))


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
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(max(TransID),-1) from tbATKPRMain Where TransID < " & CurrRec & " and NamaSite=@NamaSite and inputby=@inputby"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("inputby", strUserName))


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
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(min(TransID),-1) from tbATKPRMain Where TransID > " & CurrRec & " and NamaSite=@NamaSite and inputby=@inputby"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("inputby", strUserName))


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
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(max(TransID),0) from tbATKPRMain Where NamaSite=@NamaSite and inputby=@inputby"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("inputby", strUserName.ToString()))

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(Me.TxtInputBy.Text.Trim)
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Private Sub cbNama_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNama.SelectedIndexChanged
        Jabatan()
    End Sub
    Private Sub Jabatan()
        Using cn As New SqlClient.SqlConnection(strConnPusat)
            Using cmd As New SqlClient.SqlCommand("select Jabatan from tbAbsMst where Status_Karyawan='1' and EmployeeName='" & Me.cbNama.Text & "' and Location='" & Me.cbSite.Text & "' Order by Jabatan asc ", cn)
                cn.Open()
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Dim ds As New DataSet
                Try
                    da.Fill(ds, "hasil")
                    Me.cbJabatan.DataSource = ds.Tables(0)
                    Me.cbJabatan.ValueMember = ds.Tables(0).Columns("Jabatan").ColumnName
                    Me.cbJabatan.DisplayMember = ds.Tables(0).Columns("Jabatan").ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub cbSite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSite.SelectedIndexChanged
        'SaveSetting("ATKCL", "Config", "Site", Me.cbSite.Text)
        NamaKaryawan()
        'Me.btnLast_Click(Nothing, Nothing)
    End Sub
    Private Sub NamaKaryawan()
        If Me.cbSite.Text = "JKT - NSO" Or Me.cbSite.Text = "JKT - Office Halim" Then
            Using cn As New SqlClient.SqlConnection(strConnPusat)
                Using cmd As New SqlClient.SqlCommand("select EmployeeName from tbAbsMst where Location in ('JKT - Office Halim','JKT - Office Halim-Tj.Priok','JKT - Office Aldiron') Order by EmployeeName asc ", cn)
                    cn.Open()
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    Try
                        da.Fill(ds, "hasil")
                        Me.cbNama.DataSource = ds.Tables(0)
                        Me.cbNama.ValueMember = ds.Tables(0).Columns("EmployeeName").ColumnName
                        Me.cbNama.DisplayMember = ds.Tables(0).Columns("EmployeeName").ColumnName
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End Using
            End Using
        Else
            Using cn As New SqlClient.SqlConnection(strConnPusat)
                Using cmd As New SqlClient.SqlCommand("select EmployeeName from tbAbsMst where Status_Karyawan='1' and Location='" & Me.cbSite.Text & "' Order by EmployeeName asc ", cn)
                    cn.Open()
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    Try
                        da.Fill(ds, "hasil")
                        Me.cbNama.DataSource = ds.Tables(0)
                        Me.cbNama.ValueMember = ds.Tables(0).Columns("EmployeeName").ColumnName
                        Me.cbNama.DisplayMember = ds.Tables(0).Columns("EmployeeName").ColumnName
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub BtnNewMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewMaster.Click
        Dim From As New frmMasterData
        From.ShowDialog()
        From.Dispose()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'If Validasi() = False Then
        '    Exit Sub
        'End If

        If Me.txtPRNo.Text.Trim = "" Then
            'INSERTDATA
            INSERTDATAMASTER()
            INSERTDATADETAILS()
        Else
            UpdateDataMaster()
            UPDATEDATADETAILS()
        End If

        G_DataPRDetail(Me.txtPRNo.Text.Trim, Me.DataGridView1)
        ClearDataDetail()

        btnLast_Click(Nothing, Nothing)
    End Sub


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim frm As New frmPrintPR
        frm.strPRNo = Me.txtPRNo.Text.Trim
        frm.strNamaSite = Me.cbSite.SelectedValue
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub DataGridView1_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Me.DataGridView1.Item("TransID", Me.DataGridView1.CurrentRow.Index).Value = Nothing Then
                Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.CurrentRow.Index)
            ElseIf MsgBox("Anda yakin akan menghapus Transaksi ini", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Using cn As New SqlClient.SqlConnection(strCOnnLocal)
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cn.Open()
                        cmd.CommandText = "Delete from tbATKPRDetails where TransID=@TransID"
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

    Private Sub txtPRNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPRNo.TextChanged

    End Sub

    Private Sub cbUOM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUOM.SelectedIndexChanged

    End Sub

    Private Sub cbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged
        If Me.cbCategory.SelectedIndex = 0 Then
            IsiMasterBarang_ALL(Me.cbNamaBarang)
        Else
            IsiMasterBarang(Me.cbNamaBarang, Me.cbCategory.Text)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class