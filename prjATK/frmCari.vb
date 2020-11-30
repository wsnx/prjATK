Public Class frmCari
    Private Sub frmCari_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.txtGRNo.Text = "" Then
            MsgBox("Data belum di GR")
            Exit Sub
        End If

        UpdateData()
        Close()
        ShowData()
    End Sub
    Sub UpdateData()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText =
                            "Update tbReceivingMain set InvoiceNo=@InvoiceNo,TglTerimaInv=@TglTerimaInv,PaymentPlan=@PaymentPlan,Paymentact=@Paymentact,InternalReff=@InternalReff where GRNo=@GRNo"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("InvoiceNo", Me.txtInvNo.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("TglTerimaInv", Format(Me.dtpTglTerima.Value, "yyyy/MM/dd")))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("PaymentPlan", Format(Me.dtpPlan.Value, "yyyy/MM/dd")))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Paymentact", Format(Me.dtpActual.Value, "yyyy/MM/dd")))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("InternalReff", Me.txtInternalReff.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("GRNo", Me.txtGRNo.Text))

                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub ShowData()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText =
                    "select a.PRNo,isnull(RequiredDate,getdate())RequiredDate,a.PONo,TypePO,Keterangan as Item,c.CompanyName as VendorName,isnull(QtyToReceive,Qty)QtyToReceive,QtyGR,QtyToReceive-QtyGR as Diff," &
                    "a.Status,GRNo,GRDate,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff,DueDate,DayLeft,cast(floor(cast(a.inputdate as float))as datetime)PODate, " &
                    "StartDate,EndDate into #Reports from tbATKPOMain a " &
                    "inner join tbATKPODetails b on a.PONo=b.PONo " &
                    "inner join tbATKmstCompany c on a.KodeVendor=c.SupplierID " &
                    "left join (select a.PONo,a.GRNo,GRDate,KodeBarang,QtyToReceive,Qty as QTyGR,TglTerima,SuratJalan,[TOP] as DayLeft,InvoiceNo,TglTerimaInv,PaymentPlan,PaymentAct,InternalReff, " &
                    "case when TglTerimaInv is null then '' else TglTerimaInv + convert(int,[TOP]) end DueDate " &
                    "from tbATKMain a inner join tbReceivingMain b on a.PONo = b.PONo and a.GRNo=b.GRNo)d on a.PONo=d.PONo and b.KodeBarang=d.KodeBarang " &
                    "where a.Status >= '0' " &
                    " " &
                    "select PRNo,RequiredDate,a.PONo,TypePO,Item,VendorName,QtyToReceive,QTyGR,GRNo,GRDate," &
                    "case when isnull(GRDate,cast(floor(cast(getdate() as float))as datetime)) > cast(floor(cast(RequiredDate as float))as datetime) then 'EXPIRED' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)< cast(floor(cast(getdate()as float))as datetime) then 'EXPIRED RENTAL' " &
                    "when TypePO='Rental' and cast(floor(cast(EndDate as float))as datetime)> cast(floor(cast(getdate()as float))as datetime) then 'VALID RENTAL' " &
                    "when GRDate is not null then b.Status " &
                    "when a.Status >='2' then 'OPEN' " &
                    "else '' end StatusPODoc,InvoiceNo,TglTerimaInv,DueDate,DayLeft,PaymentPlan,PaymentAct,InternalReff " &
                    "from #Reports a " &
                    "Left Join(Select PONo,case when min(Diff) ='0' then 'CLOSE' else 'OPEN' end Status from #Reports group by PONo) b on a.PONo=b.PONo " &
                    "where PODate between '" & Format(FrmRptPO.dtpTglDari.Value, "yyyy/MM/dd") & "' and '" & Format(FrmRptPO.dtpTglSampai.Value, "yyyy/MM/dd") & "' " &
                    "order by PONo,PRNo " &
                    "drop table #Reports"
                    Dim ds As New DataSet
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    FrmRptPO.DataGridView1.DataSource = ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
End Class