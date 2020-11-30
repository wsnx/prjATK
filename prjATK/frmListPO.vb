Public Class frmListPO
    Dim dv As New DataView
    Private Sub frmListPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "List PO " & htUser("site") 'htUser("site")

        IsiNamaSite(Me.cbSite)
        Me.cbSite.SelectedValue = G_KodeWH(htUser("site"))

        If strUserName.ToLower = "vero" Then
            ShowDataMaster("1")
        Else
            ShowDataMaster("3")
        End If
        SetButton()
        Me.rbWait_CheckedChanged(Nothing, Nothing)

        If strUserType.ToLower = "manager" Or strUserType.ToLower = "deputy manager" Or strUserType.ToLower = "adminatk" Then
            Me.cbSite.Enabled = True
        Else
            Me.cbSite.Enabled = False
        End If
    End Sub
    Private Sub SetButton()
        If strUserType.ToLower = "adminatk" Then
            mnuApprove.Enabled = False
            mnuFollowUp.Enabled = True
            mnuNotApprove.Enabled = False
            mnuRevisi.Enabled = False
        ElseIf strUserType.ToLower = "manager" Or strUserType.ToLower = "area" Or strUserType.ToLower = "nso" Or strUserType.ToLower = "gm" Or strUserType.ToLower = "ceo" Then
            mnuApprove.Enabled = True
            mnuFollowUp.Enabled = False
            mnuNotApprove.Enabled = True
            mnuRevisi.Enabled = True
        Else
            mnuApprove.Enabled = False
            mnuFollowUp.Enabled = False
            mnuNotApprove.Enabled = False
            mnuRevisi.Enabled = False
        End If
    End Sub

    Private Sub rbWait_CheckedChanged(sender As Object, e As EventArgs) Handles rbWait.CheckedChanged
        dv.RowFilter = "status='Waiting for Approval'"
        'ShowDataDetailsBlank()
        SetButton()
        Me.btnFollowUp.Enabled = False
    End Sub
    Private Sub ShowDataMaster(ByVal strStatus As String)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                Select Case strStatus
                    Case "1"
                        cmd.CommandText =
                        "Select a.TransID,PRNo,NamaSite,a.StorerKey,TglTransaksi,case Status when 0 then 'Created' when 1 then 'Waiting for NSO Approval'  " &
                        "when 3 then 'Approved' when 4 then 'Close'  when 2 then 'Waiting for GM Approval' when 9 then 'Ditolak' end as Status,case Status when 2 then PRAppName when 6 then PRAppName1 else PRAppName end ApprovedBy  " &
                        ",a.InputBy from tbATKPRMain a inner join tbATKUserConfig b on a.InputBy= b.UserID " &
                        "order by a.TransID desc "
                    Case "2"
                        cmd.CommandText =
                     "Select a.TransID,PRNo,NamaSite,a.StorerKey,TglTransaksi,case Status when 1 then 'Created' when 2 then 'Waiting for Approval'  " &
                     "when 3 then 'Approved' when 4 then 'Close' when 5 then 'Revisi' when 6 then 'Waiting for Approval' when 9 then 'Ditolak' end as Status,case Status when 2 then PRAppName when 6 then PRAppName1 else PRAppName end ApprovedBy  " &
                     ",a.InputBy from tbATKPRMain a inner join tbATKUserConfig b on a.InputBy= b.UserID " &
                     "where (left(PRApproval1, (case when ((charindex('@',PRApproval1) - 1) < 0) then 0 else (charindex('@',PRApproval1) - 1) end))=@UserID) or (left(PRApproval, (case when ((charindex('@',PRApproval) - 1) < 0) then 0 else (charindex('@',PRApproval) - 1) end))=@UserID) " &
                     "and NamaSite=@NamaSite " &
                     "order by a.TransID desc "
                    Case "3"
                        cmd.CommandText =
                     "Select a.TransID,PRNo,NamaSite,a.StorerKey,TglTransaksi,case Status when 1 then 'Created' when 2 then 'Waiting for Approval'  " &
                     "when 3 then 'Approved' when 4 then 'Close' when 5 then 'Revisi' when 6 then 'Waiting for Approval' when 9 then 'Ditolak' end as Status  " &
                     "from tbATKPRMain a inner join tbATKUserConfig b on a.InputBy= b.UserID " &
                     "where left(PRApproval1, (case when ((charindex('@',PRApproval1) - 1) < 0) then 0 else (charindex('@',PRApproval1) - 1) end))=@UserID " &
                     "and NamaSite=@NamaSite " &
                     "order by a.TransID desc "
                    Case "4"
                        cmd.CommandText =
                     "Select a.TransID,PRNo,NamaSite,a.StorerKey,TglTransaksi,case Status when 1 then 'Created' when 2 then 'Waiting for Approval'  " &
                     "when 3 then 'Approved' when 4 then 'Close' when 5 then 'Revisi' when 6 then 'Waiting for Approval' when 9 then 'Ditolak' end as Status  " &
                     "from tbATKPRMain a inner join tbATKUserConfig b on a.InputBy= b.UserID " &
                     "where left(PRApproval1, (case when ((charindex('@',PRApproval1) - 1) < 0) then 0 else (charindex('@',PRApproval1) - 1) end))=@UserID " &
                     "and NamaSite=@NamaSite " &
                     "order by a.TransID desc "

                End Select

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UserID", strUserName))

                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Dim ds As New DataSet
                Try
                    da.Fill(ds, "hasil")

                    dv.Table = ds.Tables("hasil")

                    Me.DataGridView1.DataSource = dv
                    dv.RowFilter = "status = 'Waiting for Approval'"
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click

    End Sub
End Class