Public Class frmPO

    Private Sub frmPO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowMasterCompany()
    End Sub
    Private Sub ShowDataPR()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText = _
                    "select a.TransID,c.NamaSite,a.KodeBarang,NamaBarang,Qty,a.LastPrice,EstTotPrice,Keterangan,a.PRNo,isnull(CekPO,0)Cek,'Add'BtnAdd from tbatkprdetails a inner join [dbo].[tbATKmstbrg] b on a.KodeBarang=b.KodeBarang  " & _
                    "inner join tbATKPRMain c on a.PrNo=c.PRNo where c.status='3' and isnull(CekPO,0)='0' and cast(floor(cast(c.ApproveDate as float))as datetime)>='2018/04/01' " & _
                    "order by NamaBarang,c.NamaSite,a.PRNo "
                    Dim ds As New DataSet
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    Me.Dgv.DataSource = ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub DgvKosong()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText = _
                    "select a.TransID,c.NamaSite,a.KodeBarang,NamaBarang,Qty,a.LastPrice,EstTotPrice,Keterangan,a.PRNo,isnull(CekPO,0)Cek,'Add'BtnAdd from tbatkprdetails a inner join [dbo].[tbATKmstbrg] b on a.KodeBarang=b.KodeBarang  " & _
                    "inner join tbATKPRMain c on a.PrNo=c.PRNo where c.status='3' and isnull(CekPO,0)='5' and cast(floor(cast(c.ApproveDate as float))as datetime)>='2018/04/01' " & _
                    "order by NamaBarang,c.NamaSite,a.PRNo "
                    Dim ds As New DataSet
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    Me.Dgv.DataSource = ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Function G_ItemDetails(ByVal strSKU As String) As Hashtable
        Dim ht As New Hashtable

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Select * from tbATKmstbrg Where KodeBarang=@KodeBarang"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", strSKU))

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
    Private Sub InsertDataPODetails(ByRef dgv As DataGridView)

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()

                Dim ht As Hashtable
                ht = G_ItemDetails(Me.Dgv.Item("SkuPR", Me.Dgv.CurrentRow.Index).Value)

                cmd.CommandText = "INSERT INTO tbATKPODetails (PONo,Description,KodeBarang,Qty,PRNo,LastPrice,EstTotPrice,ID_PR) VALUES (@PONo,@Description,@KodeBarang,@Qty,@PRNo,@LastPrice,@EstTotPrice,@ID_PR)"

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", txtPONo.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Description", Me.Dgv.Item("DescriptionPR", Me.Dgv.CurrentRow.Index).Value))
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.Dgv.Item("SkuPR", Me.Dgv.CurrentRow.Index).Value))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", Me.Dgv.Item("QtyPR", Me.Dgv.CurrentRow.Index).Value))
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.Dgv.Item("PRNo", Me.Dgv.CurrentRow.Index).Value))
                cmd.Parameters.Add(New SqlClient.SqlParameter("LastPrice", ht("LastPrice")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("EstTotPrice", Me.Dgv.Item("QtyPR", Me.Dgv.CurrentRow.Index).Value * ht("LastPrice")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("ID_PR", Me.Dgv.Item("idPR", Me.Dgv.CurrentRow.Index).Value))

                Try
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub UpdateDataPR(ByRef dgv As DataGridView)

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()


                cmd.CommandText = "update tbATKPRDetails set CekPO=@CekPO where TransID=@TransID"

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", Me.Dgv.Item("IdPR", Me.Dgv.CurrentRow.Index).Value))
                cmd.Parameters.Add(New SqlClient.SqlParameter("CekPO", Me.Dgv.Item("Cek", Me.Dgv.CurrentRow.Index).Value))
               
                Try
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End Using
        End Using
        ShowDataPR()
    End Sub
    Private Sub ShowDataPODetails()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText = "Select TransID,KodeBarang,Description,Qty,PRNo,LastPrice,EstTotPrice,ID_PR,'Delete' as BtnDelete from tbATKPODetails where PONo ='" & Me.txtPONo.Text & "' Order By TransID desc "
                    Dim ds As New DataSet
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    Me.Dgv2.DataSource = ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub Dgv2Kosong()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText = "Select TransID,KodeBarang,Description,Qty,PRNo,LastPrice,EstTotPrice,ID_PR,'Delete' as BtnDelete from tbATKPODetails where PONo ='1' Order By TransID desc "
                    Dim ds As New DataSet
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    Me.Dgv2.DataSource = ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub Dgv_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv.CellClick

        If e.ColumnIndex = Me.Dgv.Columns("BtnAdd").Index Then
            If Me.txtPONo.Text = "" Then
                MsgBox("PO No tidak boleh kosong")
                Exit Sub
            Else
                InsertDataPODetails(Me.Dgv)
                ShowDataPODetails()
                
                Me.Dgv.Item("Cek", Me.Dgv.CurrentRow.Index).Value = 1
                UpdateDataPR(Me.Dgv)

            End If
        End If
    End Sub

    Private Sub Dgv2_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv2.CellClick
        If e.ColumnIndex = Me.Dgv2.Columns("Delete").Index Then
            If MsgBox("Anda yakin akan menghapus Transaksi ini", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'Delete PO Details
                Using cn As New SqlClient.SqlConnection(strCOnnLocal)
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cn.Open()
                        cmd.CommandText = "Delete from tbATKPODetails where TransID=@TransID"
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", Me.Dgv2.Item("ID_PO", Me.Dgv2.CurrentRow.Index).Value))
                        Try
                            cmd.ExecuteNonQuery()
                            Me.Dgv.Rows.RemoveAt(Me.Dgv.CurrentRow.Index)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End Using
                End Using

                'Uncheck in PR Details
                Using cn As New SqlClient.SqlConnection(strCOnnLocal)
                    Using cmd As New SqlClient.SqlCommand()
                        cmd.Connection = cn
                        cn.Open()
                        cmd.CommandText = "update tbATKPRDetails set CekPO=@CekPO where TransID=@TransID"
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", Me.Dgv2.Item("ID_PR", Me.Dgv2.CurrentRow.Index).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("CekPO", 0))
                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End Using
                End Using
            End If
            ShowDataPODetails()
            ShowDataPR()
        End If

       

    End Sub
    Private Sub frmPO_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        BtnLast_Click(Nothing, Nothing)
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub ShowMasterCompany()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand("select Company from [dbo].[tbMasterCompany] union Select ''Company order by Company ", cn)
                cn.Open()
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Dim ds As New DataSet
                Try
                    da.Fill(ds, "hasil")
                    Me.cbCompany.DataSource = ds.Tables(0)
                    Me.cbCompany.DisplayMember = ds.Tables(0).Columns("Company").ColumnName
                    Me.cbCompany.ValueMember = ds.Tables(0).Columns("Company").ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbCompany.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim ds As New DataSet
            ds = Company(Me.cbCompany.Text)
            Me.txtAddress1.Text = ds.Tables(0).Rows(0)("Address1")
            Me.txtAddress2.Text = ds.Tables(0).Rows(0)("Address2")
            Me.txtAddress3.Text = ds.Tables(0).Rows(0)("Address3")
            Me.txtTlp.Text = ds.Tables(0).Rows(0)("Tlp")
            Me.TxtAttnTo.Text = ds.Tables(0).Rows(0)("Attn")
        End If
    End Sub
    Private Function Company(ByVal strCompany As String) As DataSet
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                Try
                    cn.Open()
                    cmd.Connection = cn
                    cmd.CommandText = _
                    "select * from tbMasterCompany where Company ='" & strCompany & "'"
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception
                    ds = New DataSet
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ds
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbCompany.SelectedIndexChanged
        Dim ds As New DataSet
        ds = Company(Me.cbCompany.Text)
        If Me.cbCompany.SelectedIndex <> 0 Then
            Me.txtAddress1.Text = ds.Tables(0).Rows(0)("Address1")
            Me.txtAddress2.Text = ds.Tables(0).Rows(0)("Address2")
            Me.txtAddress3.Text = ds.Tables(0).Rows(0)("Address3")
            Me.txtTlp.Text = ds.Tables(0).Rows(0)("Tlp")
            Me.TxtAttnTo.Text = ds.Tables(0).Rows(0)("Attn")
        Else
            Me.txtAddress1.Text = ""
            Me.txtAddress2.Text = ""
            Me.txtAddress3.Text = ""
            Me.txtTlp.Text = ""
            Me.TxtAttnTo.Text = ""
        End If
    End Sub

    Private Sub BtnAddNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnAddNew.Click
        Me.txtPONo.Text = G_MaxPONo()
        ShowMasterCompany()
        Me.txtAddress1.Text = ""
        Me.txtAddress2.Text = ""
        Me.txtAddress3.Text = ""
        Me.txtTransID.Text = ""
        Me.txtNOtes.Text = ""
        Me.lblStatus.Text = "Created"
        GridKosong_Dgv()
        'GridKosong_Dgv2()
        BtnSave.Enabled = True
        BtnPrint.Enabled = True
        btnMintaApproval.Enabled = True
        BtnShow.Enabled = True
        Rules()

    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmMain.AddressMasterToolStripMenuItem.PerformClick()
    End Sub
    Private Sub GridKosong_Dgv()
        Me.Dgv2.RowCount = 0
        'Me.Dgv.RowCount = 0
        GridKosong_Dgv1()
    End Sub
    Private Sub GridKosong_Dgv2()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                Try
                    cmd.Connection = cn
                    cn.Open()
                    cmd.CommandText = _
                    "Select TransID,KodeBarang,Description,Qty,PRNo,LastPrice,EstTotPrice,ID_PR,'Delete' as BtnDelete from tbATKPODetails where PONo ='0' Order By TransID desc "
                    Dim ds As New DataSet
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    Dgv2.DataSource = ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub GridKosong_Dgv1()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                Try
                    cmd.Connection = cn
                    cn.Open()
                    cmd.CommandText = _
                    "select a.TransID,c.NamaSite,a.KodeBarang,NamaBarang,Qty,a.LastPrice,EstTotPrice,Keterangan,a.PRNo,isnull(CekPO,0)Cek,'Add'BtnAdd from tbatkprdetails a inner join [dbo].[tbATKmstbrg] b on a.KodeBarang=b.KodeBarang  " & _
                    "inner join tbATKPRMain c on a.PrNo=c.PRNo where c.status='3' and isnull(CekPO,0)='4' " & _
                    "order by NamaBarang,c.NamaSite,a.PRNo "
                    Dim ds As New DataSet
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    Dgv.DataSource = ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub Dgv2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv2.CellContentClick

    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        If Me.txtPONo.Text = "" Then
            MsgBox("PO No tidak boleh kosong")
            Exit Sub
        Else
            INSERTDATAMASTER()
            MsgBox("Saved")
        End If

    End Sub
    Private Function cekData(ByVal strPONo As String) As Boolean

        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText = _
                "Select TransID from tbATKPOMain  WHERE PONo='" & strPONo & "' "

                Try

                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = True
                    End If

                Catch ex As Exception
                    hasil = False
                    MsgBox(ex.Message)
                End Try

            End Using
        End Using
        Return hasil
    End Function
    Private Sub INSERTDATAMASTER()

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                If cekData(Me.txtPONo.Text.Trim) = False Then
                    cmd.CommandText = _
                        "INSERT INTO tbATKPOMain (PONo,Company,Address1,Address2,Address3,TglTransaksi,Status,InputBy,Notes) VALUES (@PONo,@Company,@Address1,@Address2,@Address3,@TglTransaksi,@Status,@InputBy,@Notes)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", Me.txtPONo.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Company", Me.cbCompany.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address1", Me.txtAddress1.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address2", Me.txtAddress2.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address3", Me.txtAddress3.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Now.Date, "yyyy/MM/dd")))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Status", "0"))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("InputBy", strUserName))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Notes", Me.txtNOtes.Text))
                Else
                    cmd.CommandText = _
                        "Update tbATKPOMain set Company=@Company,Address1=@Address1,Address2=@Address2,Address3=@Address3,TglTransaksi=@TglTransaksi,InputBy=@InputBy,Notes=@Notes where PONo=@PONo "
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", Me.txtPONo.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Company", Me.cbCompany.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address1", Me.txtAddress1.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address2", Me.txtAddress2.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address3", Me.txtAddress3.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Now.Date, "yyyy/MM/dd")))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("InputBy", strUserName))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Notes", Me.txtNOtes.Text))
                End If
                Try
                    cmd.ExecuteNonQuery()

                    Dim dr As SqlClient.SqlDataReader
                    cmd.CommandText = "Select max(TransID) as TransID from tbATKPOMain"

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
    Private Function G_NextRec(ByVal CurrRec As Integer) As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(min(TransID),-1) from tbATKPOMain Where TransID > " & CurrRec & " "
                cmd.Parameters.Clear()

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
    Private Sub ShowDataMaster(ByVal TransID As Integer)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                Try
                    cmd.CommandText = _
                    "Select isnull(a.TransID,'0')TransID,a.PONo,Company,Address1,Address2,Address3,case isnull(Status,0) when 0 then 'Created' when 1 then 'Waiting Approval'when 9 then 'Cancel' else 'Approved' end Status,InputBy,isnull(Notes,'')Notes from tbATkPOMain a where  a.TransID=@TransID "
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", TransID))


                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        Me.txtTransID.Text = dr!TransID
                        Me.txtPONo.Text = dr!PONo
                        Me.cbCompany.SelectedValue = dr!Company
                        Me.txtAddress1.Text = dr!Address1
                        Me.txtAddress2.Text = dr!Address2
                        Me.txtAddress3.Text = dr!Address3
                        Me.lblStatus.Text = dr!Status
                        Me.txtNOtes.Text = dr!Notes
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Rules()

    End Sub
    Private Sub Rules()
        If Me.lblStatus.Text.Trim = "Approved" Then
            BtnPrint.Enabled = True
            BtnSave.Enabled = True
            btnMintaApproval.Enabled = False
            Me.BtnShow.Enabled = False
            Me.Dgv.Enabled = False
            Me.Dgv2.Enabled = False
            Me.cbCompany.Enabled = False
        ElseIf Me.lblStatus.Text.Trim = "Cancel" Then
            BtnPrint.Enabled = False
            BtnSave.Enabled = False
            btnMintaApproval.Enabled = False
            Me.BtnShow.Enabled = False
            Me.Dgv.Enabled = False
            Me.Dgv2.Enabled = False
            Me.cbCompany.Enabled = False
        Else
            Me.cbCompany.Enabled = True
            BtnPrint.Enabled = False
            BtnSave.Enabled = True
            btnMintaApproval.Enabled = True
            Me.BtnShow.Enabled = True
            Me.Dgv.Enabled = True
            Me.Dgv2.Enabled = True
        End If
    End Sub
    Private Sub BtnNext_Click(sender As System.Object, e As System.EventArgs) Handles BtnNext.Click
        Dim intRec As Integer
        If Me.txtTransID.Text.Trim = "" Then
            BtnLast_Click(Nothing, Nothing)
        Else
            intRec = G_NextRec(Me.txtTransID.Text)
            ShowDataMaster(intRec)
            G_DataDetail(Me.txtPONo.Text.Trim, Me.Dgv2)
            'DataPRDetails(Me.txtPONo.Text.Trim, Me.Dgv2)
            GridKosong_Dgv1()
        End If
    End Sub

    Private Sub BtnFirst_Click(sender As System.Object, e As System.EventArgs) Handles BtnFirst.Click
        Dim intRec As Integer
        intRec = G_FirstRec()
        ShowDataMaster(intRec)
        G_DataDetail(Me.txtPONo.Text.Trim, Me.Dgv2)
        GridKosong_Dgv1()
    End Sub

    Private Function G_FirstRec() As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select min(TransID) from tbATKPOMain "
                cmd.Parameters.Clear()

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
    Private Sub BtnPrev_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrev.Click
        Dim intRec As Integer
        If Me.txtTransID.Text.Trim = "" Then
            BtnLast_Click(Nothing, Nothing)
        Else
            intRec = G_PrevRec(Me.txtTransID.Text)
            ShowDataMaster(intRec)
            G_DataDetail(Me.txtPONo.Text, Me.Dgv2)
            GridKosong_Dgv1()
        End If
    End Sub
    Private Function G_PrevRec(ByVal CurrRec As Integer) As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(max(TransID),-1) from tbATKPOMain Where TransID < " & CurrRec & " "


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

    Private Sub BtnLast_Click(sender As System.Object, e As System.EventArgs) Handles BtnLast.Click
        Dim intRec As Integer
        intRec = G_LastRec()
        ShowDataMaster(intRec)
        G_DataDetail(Me.txtPONo.Text.Trim, Me.Dgv2)
        GridKosong_Dgv1()
    End Sub
    Private Function G_LastRec() As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select max(TransID) from tbATKPOMain "
                cmd.Parameters.Clear()
                ' cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))

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
    Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles BtnShow.Click

        ShowDataPR()


    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        CancelData()
        BtnLast_Click(Nothing, Nothing)
    End Sub
    Private Sub CancelData()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText = "Update tbATKPOMain set Status='9' where PONo='" & Me.txtPONo.Text & "'"
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    For i As Integer = 0 To Me.Dgv2.RowCount - 1
                        cmd.CommandText = "Update tbATKPRDetails set CekPo='0' where TransID=@TransID "
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", Me.Dgv2.Item("ID_PR", i).Value))
                        cmd.ExecuteNonQuery()
                    Next
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End Using
        End Using


    End Sub

    Private Sub btnMintaApproval_Click(sender As System.Object, e As System.EventArgs) Handles btnMintaApproval.Click
        If Me.txtPONo.Text = "" Then
            MsgBox("Nomor PO masih kosong" & vbCrLf & "Pastikan data di-Save terlebih dahulu")
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
        strHeader1 = "<tr>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Barang</th>" & _
                    "<th bgcolor=#00BFFF align=center>Storerkey</th>" & _
                    "<th bgcolor=#00BFFF align=center>Satuan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>LastPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>EstTotPrice</th>" & _
                         "</tr>"
        Dim ds As New DataSet
        Dim ds1 As New DataSet
        ds = ShowDataHarga_PO(Me.txtPONo.Text)
        ds1 = Show_Details_PO(Me.txtPONo.Text)


        For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1

            detail = detail & "<tr>"

            detail = detail & "<td>" & ds1.Tables(0).Rows(i)("Description")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds1.Tables(0).Rows(i)("Storerkey")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds1.Tables(0).Rows(i)("UOM")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds1.Tables(0).Rows(i)("Qty")
            detail = detail & "</td>"

            detail = detail & "<td>" & Format(ds1.Tables(0).Rows(i)("LastPrice"), "##,##0")
            detail = detail & "</td>"

            detail = detail & "<td>" & Format(ds1.Tables(0).Rows(i)("EstTotPrice"), "##,##0")
            detail = detail & "</td>"

            detail = detail & "</tr>"


            strFooter = "<tr>" & _
                          "<th bgcolor=#CCCCCC align=center>Total Price : Rp. " & IIf(IsDBNull(Format(ds.Tables(0).Rows(0)("EstTotPrice"), "##,##0")), "0", Format(ds.Tables(0).Rows(0)("EstTotPrice"), "##,##0")) & "</th></tr>"
            'summary = summary & "<td>" &
            'summary = summary & "</td>"



            hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
            hasil = hasil & "Dear Pak Bayu,<br /><br />Mohon Approvalnya untuk PO No : " & Me.txtPONo.Text & " dengan detail sebagai berikut : <br />"
            hasil = hasil & "<table border='0' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>"
            hasil = hasil & "<tr><td align='right'>Supplier              : </td><td>" & Me.cbCompany.Text.Trim & "</td></tr></table></p>"
            'hasil = hasil & "<tr><td align='right'>End User Name        : </td><td>" & Me.cbCustomer.Text & "</td></tr>"
            'hasil = hasil & "<tr><td align='right'>End User Location    : </td><td>" & Me.cbLocation.Text & "</td></tr></table>
            hasil = hasil & "<br />"
            hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail & strFooter
            hasil = hasil & "</table> <br /><br /></p>"
            hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Requested By : " & strUserName & "</b><br /></p>"
            hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"
            hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Do Not Reply</b><br /></p>"

        Next
        Dim ht As New Hashtable
        ht = G_PRProfile_PO(Me.txtPONo.Text)

        dsTO = Me.G_EmailAddressTo(ht("prapproval"))
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC("atk")

        If SendEmail("[ATK] PO Approval Request", hasil, "", dsTO, dsCC, dsBCC) = False Then
            MsgBox("Kesalahan bukan pada komputer anda")
        Else
            UpdateStatus(Me.txtTransID.Text, 1)
            MsgBox("Send ''Minta Approval PO'' Sukses")
            Me.lblStatus.Text = "Waiting for Approval"
        End If

    End Sub
    Private Function SendEmail(ByVal strSubject As String, ByVal strMsg As String, ByVal strAttach As String, ByVal dsTo As Data.DataSet, ByVal dsCC As Data.DataSet, ByVal dsBCC As Data.DataSet) As Boolean
        Dim ws As New WebReference.WebService
        Dim hasil As Boolean = True

        Try
            ws.Timeout = 6000
            ws.SendEmailNew(strSubject, strMsg, strAttach, "PO_Noreply@agility.com", dsTo, dsCC, dsBCC)
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

                strSQL = "Update tbATKPOMain set Status=@Status Where TransID=@TransID"

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

                'strSQL = "Select '" & strTO & "' as EmailAddress"

                'If RequestType = "PRApproval" Then
                '    strSQL = "Select '" & GetSetting("ATKCL", "Config", "PRApproval") & "' as EmailAddress"
                'ElseIf RequestType = "PRApproved" Then
                '    strSQL = "Select '" & GetSetting("ATKCL", "Config", "AdminATK") & "' as EmailAddress"
                'End If

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

    Private Function G_EmailAddressCC(ByVal ht As Hashtable) As DataSet
        Dim ds As DataSet = New DataSet
        Dim emails As String = ""
        Dim strCC As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal
                cmd.Connection = cn
                cn.Open()

                'If Microsoft.VisualBasic.Right(ht("copypr"), 1) <> ";" Then
                '    emails = ht("copypr") & ";"
                'Else
                '    emails = ht("copypr")
                'End If
                'While InStr(emails, ";") > 0
                '    strCC = strCC & "union select '" & Microsoft.VisualBasic.Left(emails, InStr(emails, ";") - 1) & "' as EmailAddress "
                '    emails = Mid(emails, InStr(emails, ";") + 1)
                'End While

                'strSQL = "Select '" & ht("emailaddress") & "' as  EmailAddress " & strCC

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
    Private Sub BtnPrint_Click(sender As System.Object, e As System.EventArgs) Handles BtnPrint.Click
        Dim frm As New frmPrintPO
        frm.strPONo = Me.txtPONo.Text.Trim
        'frm.strNamaSite = Me.cbSite.SelectedValue
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub ckAddress1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckAddress1.CheckedChanged
        If Me.ckAddress1.Checked = True Then
            Me.txtAddress1.Enabled = True
        Else
            Me.txtAddress1.Enabled = False
        End If
    End Sub

    Private Sub ckAddress2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckAddress2.CheckedChanged
        If Me.ckAddress2.Checked = True Then
            Me.txtAddress2.Enabled = True
        Else
            Me.txtAddress2.Enabled = False
        End If
    End Sub

    Private Sub ckAddress3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckAddress3.CheckedChanged
        If Me.ckAddress3.Checked = True Then
            Me.txtAddress3.Enabled = True
        Else
            Me.txtAddress3.Enabled = False
        End If
    End Sub

    Private Sub ckTelp_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckTelp.CheckedChanged
        If Me.ckTelp.Checked = True Then
            Me.txtTlp.Enabled = True
        Else
            Me.txtTlp.Enabled = False
        End If
    End Sub

    Private Sub ckAttn_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckAttn.CheckedChanged
        If Me.ckAttn.Checked = True Then
            Me.TxtAttnTo.Enabled = True
        Else
            Me.TxtAttnTo.Enabled = False
        End If
    End Sub


    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        Dim strPONo As String = ""
        Dim strTransID As Integer
        strPONo = InputBox("No. PO : ", "Input No PO yang dicari", "")
        If strPONo.Trim = "" Then
            Exit Sub
        Else
            strTransID = G_PONo(strPONo)
            If strTransID <> -1 Then
                Me.txtPONo.Text = strPONo
                Me.txtTransID.Text = strTransID
                IsiDataPO()
            End If
        End If

        Rules()

    End Sub
    Public Sub IsiDataPO()
        'Dim ht As New Hashtable
        'ht = G_DatasplMain(Me.txtTransID.Text)

        'If ht.Count > 0 Then

        '    Me.txtTransID.Text = ht("TransID")
        '    Me.txtPRNo.Text = ht("PRNo")
        '    Me.cbSite.SelectedValue = G_KodeWH(ht("NamaSite"))
        '    Me.cbCustomer.Text = KodeCustomer(ht("Storerkey"))
        '    Me.cbNama.Text = ht("Name")
        '    Me.cbJabatan.Text = ht("Designation")
        '    Me.dtTglTrans.Value = ht("TglTransaksi")
        '    Me.dtpDateReq.Value = ht("DateRequired")
        '    Me.cbLocation.Text = ht("EndUserLocation")
        '    Me.TxtInputBy.Text = ht("InputBy")

        '    Select Case ht("Status")
        '        Case "Created"
        '            Me.txtStatus.Text = "Created"
        '            Me.dtTglTrans.Enabled = True
        '        Case "Waiting for Approval"
        '            Me.txtStatus.Text = "Waiting for Approval"
        '            Me.dtTglTrans.Enabled = False
        '        Case "Approved"
        '            Me.txtStatus.Text = "Approved"
        '            Me.dtTglTrans.Enabled = False
        '        Case "Closed"
        '            Me.txtStatus.Text = "Closed"
        '            Me.dtTglTrans.Enabled = False
        '        Case "Revisi"
        '            Me.txtStatus.Text = "Revisi"
        '            Me.dtTglTrans.Enabled = False
        '        Case "Waiting 2nd Approval"
        '            Me.txtStatus.Text = "Waiting 2nd Approval"
        '            Me.dtTglTrans.Enabled = False
        '        Case "Cancelled"
        '            Me.txtStatus.Text = "Cancelled"
        '            Me.dtTglTrans.Enabled = False
        '    End Select

        'End If
        G_DataDetail(Me.txtPONo.Text, Me.Dgv2)

        Application.DoEvents()

    End Sub
End Class