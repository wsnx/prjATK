Public Class FormReportPR

    Private Sub FormReportPR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub ShowData()
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                If Me.cbCustomer.Text = "All Customer" Then
                    'cmd.CommandText = _
                    '"Select a.KodeBarang, b.NamaBarang, a.UOM, case a.JenisTrans when 'D' then 'Deposit' when 'W' then 'Withdrawl' end as JenisTrans, sum(a.Qty) as Qty from tbATKmain a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where NamaSite=@NamaSite " & _
                    '"Group by a.KodeBarang, b.NamaBarang, a.UOM, case a.JenisTrans when 'D' then 'Deposit' when 'W' then 'Withdrawl' end " & _
                    '"order by b.NamaBarang"
                    'cmd.Parameters.Clear()
                    'cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))

                    cmd.CommandText =
                    "select a.PRNo,NamaSite,Name,Designation,StorerKey,ISNULL(a.EndUserLocation,b.EndUserLocation)EndUserLocation,TglTransaksi,DateRequired, " &
                    "c.NamaBarang,b.UOM,Qty,Keterangan,b.LastPrice,b.EstTotPrice,case isnull(a.Status,1) when 1 then 'Created' when 2 then 'Waiting for Approval' " &
                    "when 3 then 'Approved' when 4 then 'Waiting 2nd Approval' when 5 then 'Approved' when 9 then 'Cancelled' end as Status  from tbATKPRMain a " &
                    "inner join tbATKPRDetails b inner join tbATKmstbrg c on b.KodeBarang=c.KodeBarang  on a.PRNo=b.PRNo  " &
                    "where a.NamaSite=@NamaSite and a.Status not in ('9','1') and cast(floor(cast(TglTransaksi as float)) as datetime) between '" & Format(dtTglTrans1.Value, "yyyy/MM/dd") & "' and '" & Format(dtTglTrans2.Value, "yyyy/MM/dd") & "' Order by TglTransaksi "

                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))

                Else
                    'cmd.CommandText = _
                    '"Select a.KodeBarang, b.NamaBarang, a.UOM, case a.JenisTrans when 'D' then 'Deposit' when 'W' then 'Withdrawl' end as JenisTrans, sum(a.Qty) as Qty from tbATKmain a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where NamaSite=@NamaSite and StorerKey=@StorerKey " & _
                    '"Group by a.KodeBarang, b.NamaBarang, a.UOM, case a.JenisTrans when 'D' then 'Deposit' when 'W' then 'Withdrawl' end " & _
                    '"order by b.NamaBarang"
                    cmd.CommandText =
                   "select a.PRNo,NamaSite,Name,Designation,StorerKey,ISNULL(a.EndUserLocation,b.EndUserLocation)EndUserLocation,TglTransaksi,DateRequired, " &
                    "c.NamaBarang,b.UOM,Qty,Keterangan,b.LastPrice,b.EstTotPrice,case isnull(a.Status,1) when 1 then 'Created' when 2 then 'Waiting for Approval' " &
                    "when 3 then 'Approved' when 4 then 'Closed' when 5 then 'Revisi' when 9 then 'Cancelled' end as Status  from tbATKPRMain a " &
                    "inner join tbATKPRDetails b inner join tbATKmstbrg c on b.KodeBarang=c.KodeBarang  on a.PRNo=b.PRNo  " &
                    "where a.NamaSite=@NamaSite and a.Status not in ('9','1') and a.Storerkey=@Storerkey  and cast(floor(cast(TglTransaksi as float)) as datetime) between '" & Format(dtTglTrans1.Value, "yyyy/MM/dd") & "' and '" & Format(dtTglTrans2.Value, "yyyy/MM/dd") & "' Order by TglTransaksi "

                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("StorerKey", Me.cbCustomer.SelectedValue))
                End If

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


    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Me.ShowData()
    End Sub

    Private Sub FormReportPR_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized

        IsiCustomer(Me.cbCustomer)
        Me.cbCustomer.SelectedValue = htUser("storerkey")

        IsiNamaSite(Me.cbSite)
        Me.cbSite.SelectedValue = G_KodeWH(htUser("site"))
    End Sub
End Class