Public Class FrmGR
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        ShowData(Me.txtPONo.Text)
    End Sub
    Private Sub ShowData(ByVal strPONo As String)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                Try
                    cmd.CommandText =
                    "select ROW_NUMBER() OVER (ORDER BY NamaBarang) AS NoUrut,Storerkey,KodeBarang,NamaBarang,UOM,Qty-isnull(QtyGR,0)SisaPO,'0'QtyGR,[TOP],WHAsal,RequiredDate from ( " &
                    "Select a.KodeBarang, Keterangan as NamaBarang, a.UOM+'_'+convert(varchar,Conversi) as UOM, a.Qty, " &
                    "isnull(a.LastPrice,0) LastPrice,isnull(a.EstTotPrice,0) EstTotPrice,PO.KodeVendor,StartDate,WHAsal,Keterangan,UserPR,PR.Storerkey,PO.InputDate,RequiredDate from tbATKPOMain PO " &
                    "inner join tbATKPODetails a on PO.PONo=a.PONo " &
                    "inner join (select PRNo,isnull(NickName,a.StorerKey)UserPR,a.Storerkey from tbATKPRMain a left join tbDORStorer b on a.StorerKey=b.StorerKey " &
                    "inner join tbATKUserConfig c on a.InputBy=c.UserID ) PR on a.PRNo=PR.PRNo " &
                    "left join tbATKuombrg u on a.KodeBarang=u.KodeBarang and a.UOM=u.UOM " &
                    "where PO.PONo=@PONo )a " &
                    "left join (select SupplierID as ID,CompanyName as Name,Address1 as Add1,Address2 as Add2,Address3 as Add3,[Top] from tbATKmstCompany)b on a.KodeVendor=b.ID " &
                    "left join (select SupplierID,CompanyName,Address1,Address2,Address3,Code,Phone,Email,PIC from tbATKmstCompany where [Grouping]='SITE')c on a.WHAsal=c.SupplierID " &
                    "left join ( " &
                    "select PONo,KodeBarang as SKUGR,sum(Qty)QtyGR from tbATKmain where JenisTrans='D' " &
                    "group by PONo,KodeBarang ) GR on @PONo=GR.PONo and a.KodeBarang=GR.SKUGR"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", strPONo))

                    Dim ds As New DataSet
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    Me.dgv1.DataSource = ds.Tables(0)

                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        Dim top1 As Integer
                        top1 = dr!TOP
                        Me.txtTOP.Text = top1
                        Me.dtpDueDate.Value = dr!RequiredDate
                        Me.txtSite.Text = dr!WHAsal
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub
    Private Sub dtpTglTerima_ValueChanged(sender As Object, e As EventArgs) Handles dtpTglTerima.ValueChanged
        'Dim top As Integer
        'top = Me.txtTOP.Text
        'Me.dtpDueDate.Value = DateAdd(DateInterval.Day, top, Me.dtpTglTerima.Value)
    End Sub

    Private Sub txtPONo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPONo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnShow_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim frm As New frmPrintITS
        frm.strPONo = Me.txtPONo.Text.Trim
        'frm.strNamaSite = Me.cbSite.SelectedValue
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        If Me.txtGRNo.Text.Trim = "" Then
            'INSERTDATA
            INSERTDATAMASTER()
            INSERTDATADETAILS()
            MsgBox("GR Done")
        Else
            UpdateDataMaster()
            MsgBox("GR Done")
        End If
    End Sub
    Private Sub INSERTDATAMASTER()
        Me.txtGRNo.Text = G_MaxGRNo(G_KodeWH(Me.txtSite.Text.Trim))

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "INSERT INTO tbReceivingMain (GRNo,PONo,SuratJalan,TglTerima,[TOP],DueDate,AddBy,Jumlah,NilaiJumlah,Kondisi,NilaiKondisi,Surat,NilaiSurat,Lampiran,NilaiLampiran,Deadline,NilaiDeadLine,Pengantaran,NilaiPengantaran) VALUES (@GRNo,@PONo,@SuratJalan,@TglTerima,@TOP,@DueDate,@AddBy,@Jumlah,@NilaiJumlah,@Kondisi,@NilaiKondisi,@Surat,@NilaiSurat,@Lampiran,@NilaiLampiran,@Deadline,@NilaiDeadLine,@Pengantaran,@NilaiPengantaran)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("GRNo", Me.txtGRNo.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", Me.txtPONo.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("SuratJalan", Me.txtSuratJalan.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("TglTerima", Format(Me.dtpTglTerima.Value, "yyyy/MM/dd HH:mm")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("TOP", Me.txtTOP.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("DueDate", Format(Me.dtpDueDate.Value, "yyyy/MM/dd")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("AddBy", strUserName))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Jumlah", Me.cbJumlah.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiJumlah", Microsoft.VisualBasic.Left(Me.NilaiJml.Text, 1)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Kondisi", Me.cbKondisi.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiKondisi", Microsoft.VisualBasic.Left(Me.NilaiKondisi.Text, 1)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Surat", Me.cbSurat.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiSurat", Microsoft.VisualBasic.Left(Me.NilaiSurat.Text, 1)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Lampiran", Me.cbLampiran.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiLampiran", Microsoft.VisualBasic.Left(Me.NilaiLampiran.Text, 1)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Deadline", Me.cbDeadLine.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiDeadLine", Microsoft.VisualBasic.Left(Me.NilaiDeadline.Text, 1)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Pengantaran", Me.cbPengataran.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiPengantaran", Microsoft.VisualBasic.Left(Me.NilaiPengantaran.Text, 1)))
                Try
                    cmd.ExecuteNonQuery()

                    'Dim dr As SqlClient.SqlDataReader
                    'cmd.CommandText = "Select max(TransID) as TransID from tbATKPRMain"
                    'dr = cmd.ExecuteReader
                    'If dr.Read() Then
                    '    Me.txtTransID.Text = dr(0)
                    'End If
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
                cmd.CommandText =
                    "Update tbReceivingMain set SuratJalan=@SuratJalan,TglTerima=@TglTerima,[TOP]=@TOP,DueDate=@DueDate,Jumlah=@Jumlah,NilaiJumlah=@NilaiJumlah,Kondisi=@Kondisi,NilaiKondisi=@NilaiKondisi,Surat=@Surat,NilaiSurat=@NilaiSurat,Lampiran=@Lampiran,NilaiLampiran=@NilaiLampiran,Deadline=@Deadline,NilaiDeadLine=@NilaiDeadLine,Pengantaran=@Pengantaran,NilaiPengantaran=@NilaiPengantaran where GRNo=@GRNo "
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("GRNo", Me.txtGRNo.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("SuratJalan", Me.txtSuratJalan.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("TglTerima", Format(Me.dtpTglTerima.Value, "yyyy/MM/dd HH:mm")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("TOP", Me.txtTOP.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("DueDate", Format(Me.dtpDueDate.Value, "yyyy/MM/dd")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Jumlah", Me.cbJumlah.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiJumlah", Microsoft.VisualBasic.Left(Me.NilaiJml.Text, 1)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Kondisi", Me.cbKondisi.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiKondisi", Microsoft.VisualBasic.Left(Me.NilaiKondisi.Text, 1)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Surat", Me.cbSurat.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiSurat", Microsoft.VisualBasic.Left(Me.NilaiSurat.Text, 1)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Lampiran", Me.cbLampiran.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiLampiran", Microsoft.VisualBasic.Left(Me.NilaiLampiran.Text, 1)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Deadline", Me.cbDeadLine.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiDeadLine", Microsoft.VisualBasic.Left(Me.NilaiDeadline.Text, 1)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Pengantaran", Me.cbPengataran.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NilaiPengantaran", Microsoft.VisualBasic.Left(Me.NilaiPengantaran.Text, 1)))

                Try
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
                '1502030001'
                For i As Integer = 0 To Me.dgv1.RowCount - 1
                    With Me.dgv1
                        cmd.CommandText =
                            "Update tbATKMain set Qty=@Qty where GRNo=@GRNo and KodeBarang=@KodeBarang"
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", .Item("KodeBarang", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", .Item("QtyGR", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("GRNo", Me.txtGRNo.Text.Trim))

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
    Private Sub INSERTDATADETAILS()
        'Dim ht As New Hashtable

        'ht = G_ItemDetails()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                For i As Integer = 0 To Me.dgv1.RowCount - 1
                    With Me.dgv1

                        cmd.CommandText =
                            "INSERT INTO tbATKMain (NamaSite,TglTransaksi,KodeBarang,UOM,JenisTrans,QtyToReceive,Qty,PONo,GRNo,Storerkey) VALUES (@NamaSite,@TglTransaksi,@KodeBarang,@UOM,@JenisTrans,@QtyToReceive,@Qty,@PONo,@GRNo,@Storerkey)"
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", .Item("WHAsal", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Me.dtpTglTerima.Value, "yyyy/MM/dd")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", .Item("KodeBarang", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", .Item("UOM", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("JenisTrans", "D"))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("QtyToReceive", .Item("SisaPO", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", .Item("QtyGR", i).Value * CInt(Mid(.Item("UOM", i).Value, InStr(1, .Item("UOM", i).Value, "_") + 1))))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", Me.txtPONo.Text.Trim))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("GRNo", Me.txtGRNo.Text.Trim))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("Storerkey", .Item("Storerkey", i).Value))

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

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Me.txtGRNo.Text = ""
        Me.txtPONo.Text = ""
        Me.txtSuratJalan.Text = ""
        Me.dtpTglTerima.Value = Now.Date
        Me.txtTOP.Text = "0"
        Me.dtpDueDate.Value = Now.Date
        Me.cbJumlah.SelectedIndex = -1
        Me.cbKondisi.SelectedIndex = -1
        Me.cbLampiran.SelectedIndex = -1
        Me.cbSurat.SelectedIndex = -1
        Me.cbDeadLine.SelectedIndex = -1
        Me.cbPengataran.SelectedIndex = -1

        Me.NilaiJml.SelectedIndex = -1
        Me.NilaiKondisi.SelectedIndex = -1
        Me.NilaiLampiran.SelectedIndex = -1
        Me.NilaiSurat.SelectedIndex = -1
        Me.NilaiDeadline.SelectedIndex = -1
        Me.NilaiPengantaran.SelectedIndex = -1
        GridKosong()
    End Sub
    Private Sub GridKosong()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText =
                    "select ROW_NUMBER() OVER (ORDER BY NamaBarang) AS NoUrut,Storerkey,KodeBarang,NamaBarang,UOM,Qty-isnull(QtyGR,0)SisaPO,'0'QtyGR,[TOP],WHAsal,RequiredDate from ( " &
                    "Select a.KodeBarang, Keterangan as NamaBarang, a.UOM, a.Qty, " &
                    "isnull(a.LastPrice,0) LastPrice,isnull(a.EstTotPrice,0) EstTotPrice,PO.KodeVendor,StartDate,WHAsal,Keterangan,UserPR,PR.Storerkey,PO.InputDate,RequiredDate from tbATKPOMain PO " &
                    "inner join tbATKPODetails a on PO.PONo=a.PONo " &
                    "inner join (select PRNo,isnull(NickName,a.StorerKey)UserPR,a.Storerkey from tbATKPRMain a left join tbDORStorer b on a.StorerKey=b.StorerKey " &
                    "inner join tbATKUserConfig c on a.InputBy=c.UserID ) PR on a.PRNo=PR.PRNo " &
                    "where PO.PONo='0' )a " &
                    "left join (select SupplierID as ID,CompanyName as Name,Address1 as Add1,Address2 as Add2,Address3 as Add3,[Top] from tbATKmstCompany)b on a.KodeVendor=b.ID " &
                    "left join (select SupplierID,CompanyName,Address1,Address2,Address3,Code,Phone,Email,PIC from tbATKmstCompany where [Grouping]='SITE')c on a.WHAsal=c.SupplierID " &
                    "left join ( " &
                    "select PONo,KodeBarang as SKUGR,sum(Qty)QtyGR from tbATKmain where JenisTrans='D' " &
                    "group by PONo,KodeBarang ) GR on '0'=GR.PONo and a.KodeBarang=GR.SKUGR"
                    Dim ds As New DataSet
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    Me.dgv1.DataSource = ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End Using
        End Using
    End Sub

    Private Sub txtPONo_TextChanged(sender As Object, e As EventArgs) Handles txtPONo.TextChanged

    End Sub

    Private Function G_FirstRec() As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select min(TransID) from tbReceivingMain "
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", G_KodeWH(Me.txtSite.Text.Trim)))

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
                cmd.CommandText = "select isnull(max(TransID),-1) from tbReceivingMain Where TransID < " & CurrRec & " "
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", G_KodeWH(Me.txtSite.Text.Trim)))


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
                cmd.CommandText = "select isnull(min(TransID),-1) from tbReceivingMain Where TransID > " & CurrRec & " "
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", G_KodeWH(Me.txtSite.Text.Trim)))


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
                cmd.CommandText = "select max(TransID) from tbReceivingMain "
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", G_KodeWH(Me.txtSite.Text.Trim)))

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
                    cmd.CommandText =
                    "select TransID,GRNo,PONo,isnull(SuratJalan,'')SuratJalan,TglTerima,[Top],DueDate,isnull(Jumlah,'')Jumlah,isnull(Kondisi,'')Kondisi,isnull(Surat,'')Surat,isnull(Lampiran,'')Lampiran,isnull(DeadLine,'')DeadLine,isnull(Pengantaran,'')Pengantaran,isnull(Jumlah,'')Jumlah,isnull(Kondisi,'')Kondisi,isnull(Surat,'')Surat,isnull(Lampiran,'')Lampiran,isnull(DeadLine,'')DeadLine,isnull(Pengantaran,'')Pengantaran,isnull(NilaiJumlah,'0')NilaiJumlah,isnull(NilaiKondisi,'0')NilaiKondisi,isnull(NilaiSurat,'0')NilaiSurat,isnull(NilaiLampiran,'0')NilaiLampiran,isnull(NilaiDeadLine,'0')NilaiDeadLine,isnull(NilaiPengantaran,'0')NilaiPengantaran from tbReceivingMain Where TransID=@TransID "
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", G_KodeWH(Me.txtSite.Text.Trim)))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", TransID))


                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        Me.txtTransID.Text = dr!TransID
                        Me.txtGRNo.Text = dr!GRNo
                        Me.txtPONo.Text = dr!PONo
                        Me.txtSuratJalan.Text = dr!SuratJalan
                        Me.dtpTglTerima.Value = dr!TglTerima
                        Me.txtTOP.Text = dr!Top
                        Me.dtpDueDate.Value = dr!DueDate
                        Me.cbJumlah.Text = dr!Jumlah
                        Me.cbKondisi.Text = dr!Kondisi
                        Me.cbSurat.Text = dr!Surat
                        Me.cbLampiran.Text = dr!Lampiran
                        Me.cbDeadLine.Text = dr!DeadLine
                        Me.cbPengataran.Text = dr!Pengantaran

                        If dr!NilaiJumlah = "1" Then
                            Me.NilaiJml.SelectedIndex = 0
                        ElseIf dr!NilaiJumlah = "2" Then
                            Me.NilaiJml.SelectedIndex = 1
                        ElseIf dr!NilaiJumlah = "3" Then
                            Me.NilaiJml.SelectedIndex = 2
                        ElseIf dr!NilaiJumlah = "4" Then
                            Me.NilaiJml.SelectedIndex = 3
                        ElseIf dr!NilaiJumlah = "5" Then
                            Me.NilaiJml.SelectedIndex = 4
                        End If

                        If dr!NilaiKondisi = "1" Then
                            Me.NilaiKondisi.SelectedIndex = 0
                        ElseIf dr!NilaiKondisi = "2" Then
                            Me.NilaiKondisi.SelectedIndex = 1
                        ElseIf dr!NilaiKondisi = "3" Then
                            Me.NilaiKondisi.SelectedIndex = 2
                        ElseIf dr!NilaiKondisi = "4" Then
                            Me.NilaiKondisi.SelectedIndex = 3
                        ElseIf dr!NilaiKondisi = "5" Then
                            Me.NilaiKondisi.SelectedIndex = 4
                        End If

                        If dr!NilaiSurat = "1" Then
                            Me.NilaiSurat.SelectedIndex = 0
                        ElseIf dr!NilaiSurat = "2" Then
                            Me.NilaiSurat.SelectedIndex = 1
                        ElseIf dr!NilaiSurat = "3" Then
                            Me.NilaiSurat.SelectedIndex = 2
                        ElseIf dr!NilaiSurat = "4" Then
                            Me.NilaiSurat.SelectedIndex = 3
                        ElseIf dr!NilaiSurat = "5" Then
                            Me.NilaiSurat.SelectedIndex = 4
                        End If

                        If dr!NilaiLampiran = "1" Then
                            Me.NilaiLampiran.SelectedIndex = 0
                        ElseIf dr!NilaiLampiran = "2" Then
                            Me.NilaiLampiran.SelectedIndex = 1
                        ElseIf dr!NilaiLampiran = "3" Then
                            Me.NilaiLampiran.SelectedIndex = 2
                        ElseIf dr!NilaiLampiran = "4" Then
                            Me.NilaiLampiran.SelectedIndex = 3
                        ElseIf dr!NilaiLampiran = "5" Then
                            Me.NilaiLampiran.SelectedIndex = 4
                        End If

                        If dr!NilaiDeadline = "1" Then
                            Me.NilaiDeadline.SelectedIndex = 0
                        ElseIf dr!NilaiDeadline = "2" Then
                            Me.NilaiDeadline.SelectedIndex = 1
                        ElseIf dr!NilaiDeadline = "3" Then
                            Me.NilaiDeadline.SelectedIndex = 2
                        ElseIf dr!NilaiDeadline = "4" Then
                            Me.NilaiDeadline.SelectedIndex = 3
                        ElseIf dr!NilaiDeadline = "5" Then
                            Me.NilaiDeadline.SelectedIndex = 4
                        End If

                        If dr!NilaiPengantaran = "1" Then
                            Me.NilaiPengantaran.SelectedIndex = 0
                        ElseIf dr!NilaiPengantaran = "2" Then
                            Me.NilaiPengantaran.SelectedIndex = 1
                        ElseIf dr!NilaiPengantaran = "3" Then
                            Me.NilaiPengantaran.SelectedIndex = 2
                        ElseIf dr!NilaiPengantaran = "4" Then
                            Me.NilaiPengantaran.SelectedIndex = 3
                        ElseIf dr!NilaiPengantaran = "5" Then
                            Me.NilaiPengantaran.SelectedIndex = 4
                        End If

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Dim intRec As Integer
        intRec = G_LastRec()
        ShowDataMaster(intRec)
        G_DataGRDetail(Me.txtGRNo.Text.Trim, Me.dgv1)
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim intRec As Integer
        If Me.txtTransID.Text.Trim = "" Then
            btnLast_Click(Nothing, Nothing)
        Else
            intRec = G_NextRec(Me.txtTransID.Text)
            ShowDataMaster(intRec)
            G_DataGRDetail(Me.txtGRNo.Text.Trim, Me.dgv1)
        End If
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Dim intRec As Integer
        If Me.txtTransID.Text.Trim = "" Then
            btnLast_Click(Nothing, Nothing)
        Else
            intRec = G_PrevRec(Me.txtTransID.Text)
            ShowDataMaster(intRec)
            G_DataGRDetail(Me.txtGRNo.Text.Trim, Me.dgv1)
        End If
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Dim intRec As Integer
        intRec = G_FirstRec()
        ShowDataMaster(intRec)
        G_DataGRDetail(Me.txtGRNo.Text.Trim, Me.dgv1)
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim strNoGR As String = ""
        Dim strTransID As Integer
        strNoGR = InputBox("No. GR : ", "Input No GR yang dicari", "")
        If strNoGR.Trim = "" Then
            Exit Sub
        Else
            strTransID = G_NoGR(strNoGR)
            If strTransID <> -1 Then
                Me.txtGRNo.Text = strNoGR
                Me.txtTransID.Text = strTransID
                ShowDataMaster(Me.txtTransID.Text)
                G_DataGRDetail(Me.txtGRNo.Text.Trim, Me.dgv1)
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim frm As New frmPrint
        frm.strGRNo = Me.txtGRNo.Text.Trim
        'frm.strNamaSite = Me.cbSite.SelectedValue
        frm.ShowDialog()
        frm.Dispose()
    End Sub
End Class