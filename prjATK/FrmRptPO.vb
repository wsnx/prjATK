Imports System.Data.SqlClient
Public Class FrmRptPO
    Private Sub FrmInvoiceVendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub UploadData()
        Application.DoEvents()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                Try
                    cmd.Connection = cn
                    cn.Open()
                    cmd.CommandText =
                        "select PRNo,a.PONo,NamaBarang,CompanyName,QtyToReceive,Qty as ActualGR,QtyToReceive-qty as Diff,a.GRNo,TypePO,TglTransaksi,GRDate, " &
                        "case TypePO when 'ONE TIME' then TglTransaksi else x.DeadLine end TglAkhir from tbATKMain a inner join tbReceivingMain b on a.GRNo=b.GRNo inner join ( " &
                        "select PRNo,PONo,NamaBarang,CompanyName,TypePO,DeadLine from ( " &
                        "Select InputBy,PO.PRNo,PO.PONo,a.KodeBarang, b.NamaBarang, a.UOM, a.Qty,TypePO, " &
                        "isnull(a.LastPrice,0) LastPrice,isnull(a.EstTotPrice,0) EstTotPrice,PO.KodeVendor,TglTransaksi,WHAsal,Keterangan,UserPR,DateRequired,PO.InputDate,DeadLine from tbATKPOMain PO " &
                        "inner join tbATKPODetails a on PO.PRNo=a.PRNo " &
                        "inner join (select PRNo,isnull(NickName,a.StorerKey)UserPR,DateRequired,substring(NSOAppName,5,20)NSOAppName,substring(GMAppName,5,20)GMAppName,substring(CFOAppName,5,20)CFOAppName from tbATKPRMain a left join tbDORStorer b on a.StorerKey=b.StorerKey " &
                        "inner join tbATKUserConfig c on a.InputBy=c.UserID " &
                        ") PR on a.PRNo=PR.PRNo " &
                        "inner join (select KodeBarang,isnull(KodeVendor,'Agility')KodeVendor,NamaBarang from tbATKmstbrg )b " &
                        "on a.KodeBarang=b.KodeBarang and PO.KodeVendor=b.KodeVendor)a " &
                        "left join (select SupplierID,CompanyName,Address1,Address2,Address3,Code,Phone,Email,[Top] from tbATKmstCompany)b on a.KodeVendor=b.SupplierID )x on a.PONo=x.PONo " &
                        "where TglTransaksi between '" & Format(Me.dtpTglDari.Value, "yyyy/MM/dd") & "' and '" & Format(Me.dtpTglSampai.Value, "yyyy/MM/dd") & "'  "

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "hasil")

                    InsertKeLocal(ds)

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Function cekData(ByVal strGRNo As String, ByVal strSKU As String) As Boolean

        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                "Select TransID from tbATKPOReports  WHERE GRNo='" & strGRNo & "' and Namabarang='" & strSKU & "'"

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
    Private Sub InsertKeLocal(ByVal ds As DataSet)
        Dim SOada As Boolean = False
        Using cn As New SqlConnection(strCOnnLocal)
            Using cmd As New SqlCommand
                cmd.Connection = cn
                cn.Open()

                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                    Application.DoEvents()
                    If cekData(ds.Tables(0).Rows(i)("GRNo"), ds.Tables(0).Rows(i)("NamaBarang")) = False Then

                        cmd.CommandText = "INSERT INTO tbATKPOReports (PRNo,PONo,NamaBarang,CompanyName,QtyToReceive,ActualGR,Diff,GRNo,TypePO,GRDate,TglAkhir) VALUES (@PRNo,@PONo,@NamaBarang,@CompanyName,@QtyToReceive,@ActualGR,@Diff,@GRNo,@TypePO,@GRDate,@TglAkhir)"

                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlParameter("PRNo", ds.Tables(0).Rows(i)("PRNo")))
                        cmd.Parameters.Add(New SqlParameter("PONo", ds.Tables(0).Rows(i)("PONo")))
                        cmd.Parameters.Add(New SqlParameter("NamaBarang", ds.Tables(0).Rows(i)("NamaBarang")))
                        cmd.Parameters.Add(New SqlParameter("CompanyName", ds.Tables(0).Rows(i)("CompanyName")))
                        cmd.Parameters.Add(New SqlParameter("QtyToReceive", ds.Tables(0).Rows(i)("QtyToReceive")))
                        cmd.Parameters.Add(New SqlParameter("ActualGR", ds.Tables(0).Rows(i)("ActualGR")))
                        cmd.Parameters.Add(New SqlParameter("Diff", ds.Tables(0).Rows(i)("Diff")))
                        cmd.Parameters.Add(New SqlParameter("GRNo", ds.Tables(0).Rows(i)("GRNo")))
                        cmd.Parameters.Add(New SqlParameter("TypePO", ds.Tables(0).Rows(i)("TypePO")))
                        cmd.Parameters.Add(New SqlParameter("GRDate", ds.Tables(0).Rows(i)("GRDate")))
                        cmd.Parameters.Add(New SqlParameter("TglAkhir", ds.Tables(0).Rows(i)("TglAkhir")))

                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                Next
            End Using
        End Using
        '  Me.ProgressBar1.Value = Me.ProgressBar1.Maximum
    End Sub
    Public dsPublic As DataSet
    Public Sub ShowData()
        Cursor.Current = Cursors.WaitCursor
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Try
                If Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 1) = "5" Then
                    Dim strSQL As String = "DOR.dbo.RPT_EPROC_ReportPO"

                    Using cmd As New SqlClient.SqlCommand(strSQL, cn)

                        cmd.Connection = cn
                        cn.Open()
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add(New SqlClient.SqlParameter("StartDate", Format(Me.dtpTglDari.Value, "yyyy-MM-dd")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("EndDate", Format(Me.dtpTglSampai.Value, "yyyy-MM-dd")))
                        Try
                            Dim ds As New DataSet
                            Dim da As New SqlDataAdapter(cmd)
                            da.Fill(ds, "hasil")
                            dsPublic = ds
                            Me.DataGridView1.DataSource = ds.Tables(0)
                            cn.Close()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End Using
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = Me.DataGridView1.Columns("TglTerimaInvoice").Index Then
            frmTgl.StartPosition = FormStartPosition.CenterParent
            frmTgl.ShowDialog()
            Me.DataGridView1.Item("TglTerimaInvoice", e.RowIndex).Value = frmTgl.tgl.Date
        ElseIf e.ColumnIndex = Me.DataGridView1.Columns("PaymentDate").Index Then
            frmTgl.StartPosition = FormStartPosition.CenterParent
            frmTgl.ShowDialog()
            Me.DataGridView1.Item("PaymentDate", e.RowIndex).Value = frmTgl.tgl.Date
        End If
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        'UploadData()
        ShowData()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        UpdateData()
        ShowData()
    End Sub
    Private Sub UpdateData()
        Application.DoEvents()

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                    Try
                        cmd.CommandText = "UPDATE tbATKPOReports set InvoiceNo=@InvoiceNo,TglInvoice=@TglInvoice,TglBayar=@TglBayar,InternalReff=@InternalReff where Transid=@TransID"
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", Me.DataGridView1.Item("TransID", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("InvoiceNo", Me.DataGridView1.Item("InvoiceNo", i).Value.ToString))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("TglInvoice", Me.DataGridView1.Item("TglTerimaInvoice", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("TglBayar", Me.DataGridView1.Item("PaymentDate", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("InternalReff", Me.DataGridView1.Item("InternalReff", i).Value))

                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
            End Using
        End Using
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        Dim strfilename = "C:\DORCLDD\PR\ATKPOReports" & Format(Now, "ddMMyymm") & ".csv"
        G_CSV_File(dsPublic, strfilename)
        MsgBox("Done")
        Process.Start(strfilename)
    End Sub
    Private Function G_Data() As DataSet
        Dim ds As New DataSet


        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()
                If Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 1) = "1" Then
                    cmd.CommandText =
                    "select case isnull(Status,0) when 0 then 'Created' when 2 then 'Waiting NSO Approval' " &
                    "when 3 then 'Approved by NSO' when 4 then 'Waiting GM Approval' when 5 then 'Approved by GM' when 6 then 'Waiting CFO Approval' when 7 then 'Follow up To Vendor' when 8 then 'Approved by CFO' when 9 then 'Cancelled' else '' end StatusPO,a.PRNo,isnull(RequiredDate,getdate())RequiredDate,a.PONo,isnull(CustomerName,EndUserName)CustomerName,TypePO,Keterangan as Item,c.CompanyName as VendorName,isnull(QtyToReceive,Qty)QtyToReceive,QtyGR,QtyToReceive-QtyGR as Diff," &
                    "a.Status,GRNo,GRDate,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff,DueDate,DayLeft,cast(floor(cast(a.inputdate as float))as datetime)PODate, " &
                    "StartDate,EndDate into #Reports from tbATKPOMain a " &
                    "inner join tbATKPODetails b on a.PONo=b.PONo and a.PRNo=b.PRNo " &
                    "inner join tbATKmstCompany c on a.KodeVendor=c.SupplierID left join tbDORStorer st on b.EndUserName = st.StorerKey " &
                    "left join (select a.PONo,a.GRNo,GRDate,KodeBarang,QtyToReceive,Qty as QTyGR,TglTerima,SuratJalan,[TOP] as DayLeft,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff, " &
                    "case when TglTerimaInv is null then '' else TglTerimaInv + convert(int,[TOP]) end DueDate " &
                    "from tbATKMain a inner join tbReceivingMain b on a.PONo = b.PONo and a.GRNo=b.GRNo)d on a.PONo=d.PONo and b.KodeBarang=d.KodeBarang " &
                    "where a.Status = '0' " &
                    " " &
                    "select case when QtyToReceive-isnull(QTyGR,0)= '0' then 'CLOSE' else StatusPO end StatusPO,PRNo,RequiredDate,a.PONo,CustomerName,TypePO,Item,VendorName,QtyToReceive,QTyGR,QtyToReceive-isnull(QTyGR,0)Diff,GRNo,GRDate," &
                    "case when isnull(GRDate,cast(floor(cast(getdate() as float))as datetime)) > cast(floor(cast(RequiredDate as float))as datetime) then 'EXPIRED' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)< cast(floor(cast(getdate()as float))as datetime) then 'EXPIRED RENTAL' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)> cast(floor(cast(getdate()as float))as datetime) then 'VALID RENTAL' " &
                    "when GRDate is not null then b.Status " &
                    "when a.Status >='2' then 'OPEN' " &
                    "else '' end StatusPODoc,InvoiceNo,TglTerimaInv,DueDate,DayLeft,PaymentPlan,PaymentAct,InternalReff " &
                    "into #Report2 from #Reports a " &
                    "Left Join(Select PONo,case when min(Diff) ='0' then 'CLOSE' else 'OPEN' end Status from #Reports group by PONo) b on a.PONo=b.PONo " &
                    "where PODate between '" & Format(Me.dtpTglDari.Value, "yyyy/MM/dd") & "' and '" & Format(Me.dtpTglSampai.Value, "yyyy/MM/dd") & "' " &
                    "select StatusPO,PRNo,RequiredDate,PONo,CustomerName,TypePo,Item,VendorName,QtyToReceive,QtyGR,Diff,GRNo,GRDate,StatusPODoc,InvoiceNo, " &
                    "TglTerimaInv, DueDate, DayLeft, PaymentPlan, PaymentAct, InternalReff  from #Report2 " &
                    "where StatusPODoc ='' " &
                    "order by PONo, PRNo " &
                    "drop table #Reports,#Report2 "
                ElseIf Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 1) = "2" Then
                    cmd.CommandText =
                    "select case isnull(Status,0) when 0 then 'Created' when 2 then 'Waiting NSO Approval' " &
                    "when 3 then 'Approved by NSO' when 4 then 'Waiting GM Approval' when 5 then 'Approved by GM' when 6 then 'Waiting CFO Approval' when 7 then 'Follow up To Vendor' when 8 then 'Approved by CFO' when 9 then 'Cancelled' else '' end StatusPO,a.PRNo,isnull(RequiredDate,getdate())RequiredDate,a.PONo,TypePO,Keterangan as Item,c.CompanyName as VendorName,isnull(QtyToReceive,Qty)QtyToReceive,QtyGR,QtyToReceive-QtyGR as Diff," &
                    "a.Status,GRNo,isnull(CustomerName,EndUserName)CustomerName,GRDate,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff,DueDate,DayLeft,cast(floor(cast(a.inputdate as float))as datetime)PODate, " &
                    "StartDate,EndDate into #Reports from tbATKPOMain a " &
                    "inner join tbATKPODetails b on a.PONo=b.PONo and a.PRNo=b.PRNo " &
                    "inner join tbATKmstCompany c on a.KodeVendor=c.SupplierID left join tbDORStorer st on b.EndUserName = st.StorerKey " &
                    "left join (select a.PONo,a.GRNo,GRDate,KodeBarang,QtyToReceive,Qty as QTyGR,TglTerima,SuratJalan,[TOP] as DayLeft,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff, " &
                    "case when TglTerimaInv is null then '' else TglTerimaInv + convert(int,[TOP]) end DueDate " &
                    "from tbATKMain a inner join tbReceivingMain b on a.PONo = b.PONo and a.GRNo=b.GRNo)d on a.PONo=d.PONo and b.KodeBarang=d.KodeBarang " &
                    "where a.Status > '2' " &
                    " " &
                    "select case when QtyToReceive-isnull(QTyGR,0)= '0' then 'CLOSE' else StatusPO end StatusPO,PRNo,RequiredDate,a.PONo,CustomerName,TypePO,Item,VendorName,QtyToReceive,QTyGR,QtyToReceive-isnull(QTyGR,0)Diff,GRNo,GRDate," &
                    "case when isnull(GRDate,cast(floor(cast(getdate() as float))as datetime)) > cast(floor(cast(RequiredDate as float))as datetime) then 'EXPIRED' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)< cast(floor(cast(getdate()as float))as datetime) then 'EXPIRED RENTAL' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)> cast(floor(cast(getdate()as float))as datetime) then 'VALID RENTAL' " &
                    "when GRDate is not null then b.Status " &
                    "when a.Status >='2' then 'OPEN' " &
                    "else '' end StatusPODoc,InvoiceNo,TglTerimaInv,DueDate,DayLeft,PaymentPlan,PaymentAct,InternalReff " &
                    "into #Report2 from #Reports a " &
                    "Left Join(Select PONo,case when min(Diff) ='0' then 'CLOSE' else 'OPEN' end Status from #Reports group by PONo) b on a.PONo=b.PONo " &
                    "where PODate between '" & Format(Me.dtpTglDari.Value, "yyyy/MM/dd") & "' and '" & Format(Me.dtpTglSampai.Value, "yyyy/MM/dd") & "' " &
                    "select StatusPO,PRNo,RequiredDate,PONo,CustomerName,TypePo,Item,VendorName,QtyToReceive,QtyGR,Diff,GRNo,GRDate,StatusPODoc,InvoiceNo, " &
                    "TglTerimaInv, DueDate, DayLeft, PaymentPlan, PaymentAct, InternalReff  from #Report2 " &
                    "where GRNo is not null " &
                    "order by PONo, PRNo " &
                    "drop table #Reports,#Report2 "
                ElseIf Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 1) = "3" Then
                    cmd.CommandText =
                    "select case isnull(Status,0) when 0 then 'Created' when 2 then 'Waiting NSO Approval' " &
                    "when 3 then 'Approved by NSO' when 4 then 'Waiting GM Approval' when 5 then 'Approved by GM' when 6 then 'Waiting CFO Approval' when 7 then 'Follow up To Vendor' when 8 then 'Approved by CFO' when 9 then 'Cancelled' else '' end StatusPO,a.PRNo,isnull(RequiredDate,getdate())RequiredDate,a.PONo,TypePO,Keterangan as Item,c.CompanyName as VendorName,isnull(QtyToReceive,Qty)QtyToReceive,QtyGR,QtyToReceive-QtyGR as Diff," &
                    "a.Status,isnull(CustomerName,EndUserName)CustomerName,GRNo,GRDate,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff,DueDate,DayLeft,cast(floor(cast(a.inputdate as float))as datetime)PODate, " &
                    "StartDate,EndDate into #Reports from tbATKPOMain a " &
                    "inner join tbATKPODetails b on a.PONo=b.PONo and a.PRNo=b.PRNo " &
                    "inner join tbATKmstCompany c on a.KodeVendor=c.SupplierID left join tbDORStorer st on b.EndUserName = st.StorerKey " &
                    "left join (select a.PONo,a.GRNo,GRDate,KodeBarang,QtyToReceive,Qty as QTyGR,TglTerima,SuratJalan,[TOP] as DayLeft,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff, " &
                    "case when TglTerimaInv is null then '' else TglTerimaInv + convert(int,[TOP]) end DueDate " &
                    "from tbATKMain a inner join tbReceivingMain b on a.PONo = b.PONo and a.GRNo=b.GRNo)d on a.PONo=d.PONo and b.KodeBarang=d.KodeBarang " &
                    "where a.Status >= '2' " &
                    " " &
                    "select case when QtyToReceive-isnull(QTyGR,0)= '0' then 'CLOSE' else StatusPO end StatusPO,PRNo,RequiredDate,a.PONo,CustomerName,TypePO,Item,VendorName,QtyToReceive,QTyGR,QtyToReceive-isnull(QTyGR,0)Diff,GRNo,GRDate," &
                    "case when isnull(GRDate,cast(floor(cast(getdate() as float))as datetime)) > cast(floor(cast(RequiredDate as float))as datetime) then 'EXPIRED' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)< cast(floor(cast(getdate()as float))as datetime) then 'EXPIRED RENTAL' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)> cast(floor(cast(getdate()as float))as datetime) then 'VALID RENTAL' " &
                    "when GRDate is not null then b.Status " &
                    "when a.Status >='2' then 'OPEN' " &
                    "else '' end StatusPODoc,InvoiceNo,TglTerimaInv,DueDate,DayLeft,PaymentPlan,PaymentAct,InternalReff " &
                    "into #Report2 from #Reports a " &
                    "Left Join(Select PONo,case when min(Diff) ='0' then 'CLOSE' else 'OPEN' end Status from #Reports group by PONo) b on a.PONo=b.PONo " &
                    "where PODate between '" & Format(Me.dtpTglDari.Value, "yyyy/MM/dd") & "' and '" & Format(Me.dtpTglSampai.Value, "yyyy/MM/dd") & "' " &
                    "select StatusPO,PRNo,RequiredDate,PONo,CustomerName,TypePo,Item,VendorName,QtyToReceive,QtyGR,Diff,GRNo,GRDate,StatusPODoc,InvoiceNo, " &
                    "TglTerimaInv, DueDate, DayLeft, PaymentPlan, PaymentAct, InternalReff  from #Report2 " &
                    "where StatusPODoc='OPEN' " &
                    "order by PONo, PRNo " &
                    "drop table #Reports,#Report2 "
                ElseIf Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 1) = "4" Then
                    cmd.CommandText =
                    "select case isnull(Status,0) when 0 then 'Created' when 2 then 'Waiting NSO Approval' " &
                    "when 3 then 'Approved by NSO' when 4 then 'Waiting GM Approval' when 5 then 'Approved by GM' when 6 then 'Waiting CFO Approval' when 7 then 'Follow up To Vendor' when 8 then 'Approved by CFO' when 9 then 'Cancelled' else '' end StatusPO,a.PRNo,isnull(RequiredDate,getdate())RequiredDate,a.PONo,TypePO,Keterangan as Item,c.CompanyName as VendorName,isnull(QtyToReceive,Qty)QtyToReceive,QtyGR,QtyToReceive-QtyGR as Diff," &
                    "a.Status,isnull(CustomerName,EndUserName)CustomerName,GRNo,GRDate,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff,DueDate,DayLeft,cast(floor(cast(a.inputdate as float))as datetime)PODate, " &
                    "StartDate,EndDate into #Reports from tbATKPOMain a " &
                    "inner join tbATKPODetails b on a.PONo=b.PONo and a.PRNo=b.PRNo " &
                    "inner join tbATKmstCompany c on a.KodeVendor=c.SupplierID left join tbDORStorer st on b.EndUserName = st.StorerKey " &
                    "left join (select a.PONo,a.GRNo,GRDate,KodeBarang,QtyToReceive,Qty as QTyGR,TglTerima,SuratJalan,[TOP] as DayLeft,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff, " &
                    "case when TglTerimaInv is null then '' else TglTerimaInv + convert(int,[TOP]) end DueDate " &
                    "from tbATKMain a inner join tbReceivingMain b on a.PONo = b.PONo and a.GRNo=b.GRNo)d on a.PONo=d.PONo and b.KodeBarang=d.KodeBarang " &
                    "where a.Status >= '3' " &
                    " " &
                    "select case when QtyToReceive-isnull(QTyGR,0)= '0' then 'CLOSE' else StatusPO end StatusPO,PRNo,RequiredDate,a.PONo,CustomerName,TypePO,Item,VendorName,QtyToReceive,QTyGR,QtyToReceive-isnull(QTyGR,0)Diff,GRNo,GRDate," &
                    "case when isnull(GRDate,cast(floor(cast(getdate() as float))as datetime)) > cast(floor(cast(RequiredDate as float))as datetime) then 'EXPIRED' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)< cast(floor(cast(getdate()as float))as datetime) then 'EXPIRED RENTAL' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)> cast(floor(cast(getdate()as float))as datetime) then 'VALID RENTAL' " &
                    "when GRDate is not null then b.Status " &
                    "when a.Status >='2' then 'OPEN' " &
                    "else '' end StatusPODoc,InvoiceNo,TglTerimaInv,DueDate,DayLeft,PaymentPlan,PaymentAct,InternalReff " &
                    "into #Report2 from #Reports a " &
                    "Left Join(Select PONo,case when min(Diff) ='0' then 'CLOSE' else 'OPEN' end Status from #Reports group by PONo) b on a.PONo=b.PONo " &
                    "where PODate between '" & Format(Me.dtpTglDari.Value, "yyyy/MM/dd") & "' and '" & Format(Me.dtpTglSampai.Value, "yyyy/MM/dd") & "' " &
                    "select StatusPO,PRNo,RequiredDate,PONo,CustomerName,TypePo,Item,VendorName,QtyToReceive,QtyGR,Diff,GRNo,GRDate,StatusPODoc,InvoiceNo, " &
                    "TglTerimaInv, DueDate, DayLeft, PaymentPlan, PaymentAct, InternalReff  from #Report2 " &
                    "where StatusPODoc='CLOSE' " &
                    "order by PONo, PRNo " &
                    "drop table #Reports,#Report2 "
                ElseIf Microsoft.VisualBasic.Left(Me.ComboBox1.Text, 1) = "5" Then
                    cmd.CommandText =
                     "select case isnull(Status,0) when 0 then 'Created' when 2 then 'Waiting NSO Approval' " &
                    "when 3 then 'Approved by NSO' when 4 then 'Waiting GM Approval' when 5 then 'Approved by GM' when 6 then 'Waiting CFO Approval' when 7 then 'Follow up To Vendor' when 8 then 'Approved by CFO' when 9 then 'Cancelled' else '' end StatusPO,a.PRNo,isnull(RequiredDate,getdate())RequiredDate,a.PONo,TypePO,Keterangan as Item,c.CompanyName as VendorName,isnull(QtyToReceive,Qty)QtyToReceive,QtyGR,QtyToReceive-QtyGR as Diff," &
                    "a.Status,isnull(CustomerName,EndUserName)CustomerName,GRNo,GRDate,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff,DueDate,DayLeft,cast(floor(cast(a.inputdate as float))as datetime)PODate, " &
                    "StartDate,EndDate into #Reports from tbATKPOMain a " &
                    "inner join tbATKPODetails b on a.PONo=b.PONo and a.PRNo=b.PRNo " &
                    "inner join tbATKmstCompany c on a.KodeVendor=c.SupplierID left join tbDORStorer st on b.EndUserName = st.StorerKey " &
                    "left join (select a.PONo,a.GRNo,GRDate,KodeBarang,QtyToReceive,Qty as QTyGR,TglTerima,SuratJalan,[TOP] as DayLeft,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff, " &
                    "case when TglTerimaInv is null then '' else TglTerimaInv + convert(int,[TOP]) end DueDate " &
                    "from tbATKMain a inner join tbReceivingMain b on a.PONo = b.PONo and a.GRNo=b.GRNo)d on a.PONo=d.PONo and b.KodeBarang=d.KodeBarang " &
                    "where a.Status >= '0' " &
                    " " &
                    "select case when QtyToReceive-isnull(QTyGR,0)= '0' then 'CLOSE' else StatusPO end StatusPO,PRNo,RequiredDate,a.PONo,CustomerName,TypePO,Item,VendorName,QtyToReceive,QTyGR,QtyToReceive-isnull(QTyGR,0)Diff,GRNo,GRDate," &
                    "case when isnull(GRDate,cast(floor(cast(getdate() as float))as datetime)) > cast(floor(cast(RequiredDate as float))as datetime) then 'EXPIRED' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)< cast(floor(cast(getdate()as float))as datetime) then 'EXPIRED RENTAL' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)> cast(floor(cast(getdate()as float))as datetime) then 'VALID RENTAL' " &
                    "when GRDate is not null then b.Status " &
                    "when a.Status >='2' then 'OPEN' " &
                    "else '' end StatusPODoc,InvoiceNo,TglTerimaInv,DueDate,DayLeft,PaymentPlan,PaymentAct,InternalReff " &
                    "from #Reports a " &
                    "Left Join(Select PONo,case when min(Diff) ='0' then 'CLOSE' else 'OPEN' end Status from #Reports group by PONo) b on a.PONo=b.PONo " &
                    "where PODate between '" & Format(Me.dtpTglDari.Value, "yyyy/MM/dd") & "' and '" & Format(Me.dtpTglSampai.Value, "yyyy/MM/dd") & "' " &
                    "order by PONo,PRNo " &
                    "drop table #Reports"
                End If


                Dim da As New SqlClient.SqlDataAdapter(cmd)

                Try
                    da.Fill(ds, "hasil")

                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = ""
                End Try
            End Using
        End Using
        Return ds
    End Function
    Shared Function G_CSV_File(ByVal ds As Data.DataSet, ByVal filename As String) As String
        Dim writer As New IO.StreamWriter(filename)

        Dim dt As Data.DataTable = ds.Tables(0)
        Dim colCount As Integer = dt.Columns.Count
        For i As Integer = 0 To colCount - 1
            writer.Write("""" & dt.Columns(i).ToString & """")
            If (i < colCount - 1) Then
                writer.Write(",")
            End If
        Next
        writer.Write(writer.NewLine)
        For Each dr As Data.DataRow In dt.Rows
            For i As Integer = 0 To colCount - 1
                ''If dt.Columns(i).ColumnName = "TglLembur" Then
                ''    MsgBox("yes")
                ''End If
                If Not Convert.IsDBNull(dr(i)) Then
                    'MsgBox(dr(i).GetType.ToString)
                    If dr(i).GetType.ToString.ToLower = "system.double" Or dr(i).GetType.ToString.ToLower = "system.decimal" Then
                        'MsgBox(dr(i).ToString())
                        writer.Write("""" & Replace(dr(i).ToString, ",", ".") & """")
                    ElseIf dr(i).GetType.ToString.ToLower = "system.datetime" Then

                        If dt.Columns(i).ColumnName = "GRDate" Then
                            writer.Write("""" & Format(dr(i), "yyyy/MM/dd HH:mm") & """")
                        Else
                            writer.Write("""" & Format(dr(i), "yyyy/MM/dd") & """")
                        End If
                    Else
                        If Mid(dr(i).ToString, 1, 1) = "-" Then
                            writer.Write("""" & " " & Replace(dr(i).ToString, vbCrLf, "  ") & """")
                        Else
                            writer.Write("""" & Replace(dr(i).ToString, vbCrLf, "  ") & """")
                        End If

                    End If
                End If

                If (i < colCount - 1) Then
                    writer.Write(",")
                End If
            Next
            writer.Write(writer.NewLine)
        Next
        writer.Close()
        Return "T"
    End Function

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Control Then
            Select Case e.KeyCode
                'Case Keys.C
                '    Clipboard.SetText = Me.DataGridView1.Item(DataGridView1.
                Case Keys.V
                    Dim a, ori, b As String
                    a = Clipboard.GetText
                    ori = a
                    If IsNothing(a) Then Exit Sub

                    If a.Trim <> "" Then
                        While a.Trim <> ""
                            If InStr(a, vbCrLf) > 0 Then ' multi line
                                Dim col As Integer = 0
                                Dim row As Integer = 0
                                For i As Integer = 0 To Me.DataGridView1.SelectedCells.Count - 1
                                    a = ori
                                    col = 0
                                    row = 0
                                    While InStr(a, vbCrLf) > 0
                                        b = Microsoft.VisualBasic.Left(a, InStr(a, vbCrLf))
                                        While InStr(b, vbTab) > 0
                                            Me.DataGridView1.Item(Me.DataGridView1.SelectedCells(i).ColumnIndex + col, Me.DataGridView1.SelectedCells(i).RowIndex + row).Value = Microsoft.VisualBasic.Left(b, InStr(b, vbTab) - 1)
                                            b = Mid(b, InStr(b, vbTab) + 1)
                                            col = col + 1
                                        End While
                                        Me.DataGridView1.Item(Me.DataGridView1.SelectedCells(i).ColumnIndex + col, Me.DataGridView1.SelectedCells(i).RowIndex + row).Value = b
                                        a = Microsoft.VisualBasic.Mid(a, InStr(a, vbCrLf) + 1)
                                        row = row + 1
                                    End While
                                    col = 0
                                    'row = row + 1
                                    If a.Trim <> "" Then
                                        b = a
                                        While InStr(b, vbTab) > 0
                                            Me.DataGridView1.Item(Me.DataGridView1.SelectedCells(i).ColumnIndex + col, Me.DataGridView1.SelectedCells(i).RowIndex + row).Value = Microsoft.VisualBasic.Left(b, InStr(b, vbTab) - 1)
                                            b = Mid(b, InStr(b, vbTab) + 1)
                                            col = col + 1
                                        End While
                                        Me.DataGridView1.Item(Me.DataGridView1.SelectedCells(i).ColumnIndex + col, Me.DataGridView1.SelectedCells(i).RowIndex + row).Value = b

                                    End If

                                    b = ""
                                Next

                                'While InStr(b, vbTab) > 0
                                '    MsgBox("Hai vbtab ada")
                                'End While

                            Else 'cuma 1 baris
                                Dim col As Integer = 0
                                For i As Integer = 0 To Me.DataGridView1.SelectedCells.Count - 1
                                    a = ori
                                    col = 0
                                    While InStr(a, vbTab) > 0
                                        Me.DataGridView1.Item(Me.DataGridView1.SelectedCells(i).ColumnIndex + col, Me.DataGridView1.SelectedCells(i).RowIndex).Value = Microsoft.VisualBasic.Left(a, InStr(a, vbTab) - 1)
                                        a = Mid(a, InStr(a, vbTab) + 1)
                                        col = col + 1
                                    End While
                                    Me.DataGridView1.Item(Me.DataGridView1.SelectedCells(i).ColumnIndex + col, Me.DataGridView1.SelectedCells(i).RowIndex).Value = a
                                    a = ""
                                Next

                            End If
                            a = ""
                        End While
                    End If

                    'Me.DataGridView1.CurrentCell.Value = Clipboard.GetText
                    'Case Keys.X
                    '    MessageBox.Show("CTRL + X")
            End Select
        Else
            If e.KeyCode = Keys.Delete Then
                For i As Integer = 0 To Me.DataGridView1.SelectedCells.Count - 1

                    Me.DataGridView1.SelectedCells(i).Value = ""

                Next
            End If
        End If
    End Sub

    Private Sub UpdateInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateInvoiceToolStripMenuItem.Click
        Dim i As Integer
        i = Me.DataGridView1.CurrentRow.Index
        With DataGridView1.Rows.Item(i)
            frmCari.txtGRNo.Text = IIf(IsDBNull(Me.DataGridView1.Item("GRNo", i).Value), "", Me.DataGridView1.Item("GRNo", i).Value)
            frmCari.txtInvNo.Text = IIf(IsDBNull(Me.DataGridView1.Item("InvoiceNo", i).Value), "", Me.DataGridView1.Item("InvoiceNo", i).Value)
            frmCari.txtInternalReff.Text = IIf(IsDBNull(Me.DataGridView1.Item("InternalReff", i).Value), "", Me.DataGridView1.Item("InternalReff", i).Value)
        End With
        frmCari.ShowDialog()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class