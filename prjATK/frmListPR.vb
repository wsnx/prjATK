Imports System.Net.Dns
Public Class frmListPR

    Dim dv As New DataView

    Private Sub frmListPR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = WindowState.Maximized

        Me.Text = "List PR " & htUser("site") 'htUser("site")
        IsiNamaSite(Me.cbSite)
        Me.cbSite.SelectedValue = G_KodeWH(htUser("site"))

        If strUserType.ToLower = "adminpr" Then
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

    Private Sub ShowDataMaster(ByVal strStatus As String)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()

                Select Case strStatus
                    Case "1"
                        cmd.CommandText =
                        "Select a.TransID,PRNo,NamaSite,isnull(c.NickName,a.StorerKey)StorerKey,TglTransaksi,case Status when 1 then 'Created' when 2 then 'Waiting for Approval'  " &
                        "when 3 then 'Approved' when 4 then 'Close' when 5 then 'Revisi' when 6 then 'Waiting for Approval' when 9 then 'Ditolak' end as Status,case Status when 2 then PRAppName when 6 then PRAppName1 else PRAppName end ApprovedBy  " &
                        ",a.InputBy,b.Department from tbATKPRMain a inner join tbATKUserConfig b on a.InputBy= b.UserID left join tbDORStorer c on a.StorerKey=c.StorerKey 
                         where a.inputby=@userID " &
                        "order by a.TransID desc "
                    Case "3"
                        cmd.CommandText =
                     "Select a.TransID,PRNo,NamaSite,isnull(c.NickName,a.StorerKey)StorerKey,TglTransaksi,case Status when 1 then 'Created' when 2 then 'Waiting for Approval'  " &
                     "when 3 then 'Approved' when 4 then 'Waiting for Approval' when 9 then 'Ditolak' end as Status,case Status when 2 then PRAppName when 4 then PRAppName1 else PRAppName end ApprovedBy  " &
                     ",a.InputBy,b.Department from tbATKPRMain a inner join tbATKUserConfig b on a.InputBy= b.UserID left join tbDORStorer c on a.StorerKey=c.StorerKey " &
                     "where  " &
                     "a.inputby=@UserID and NamaSite=@NamaSite  " &
                     "order by a.TransID desc "
                    Case "6"
                        cmd.CommandText =
                     "Select a.TransID,PRNo,NamaSite,isnull(c.NickName,a.StorerKey)StorerKey,TglTransaksi,case Status when 1 then 'Created' when 2 then 'Waiting for Approval'  " &
                     "when 3 then 'Approved' when 4 then 'Close' when 5 then 'Revisi' when 6 then 'Waiting for Approval' when 9 then 'Ditolak' end as Status,a.InputBy,b.Department  " &
                     "from tbATKPRMain a inner join tbATKUserConfig b on a.InputBy= b.UserID left join tbDORStorer c on a.StorerKey=c.StorerKey " &
                     "where  " &
                     " a.inputby=@UserID  and NamaSite=@NamaSite order by a.TransID desc "
                        '--left(PRApproval1, (case when ((charindex('@',PRApproval1) - 1) < 0) then 0 else (charindex('@',PRApproval1) - 1) end))=@UserID


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

    Private Sub ShowDataDetails()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "Select a.TransID,PRNo,a.KodeBarang, b.NamaBarang, a.UOM, a.Qty, isnull(a.LastPrice,0) LastPrice,isnull(a.EstTotPrice,0) EstTotPrice,a.Keterangan,a.PurchasedByGA,KodeVendor from tbATKPRDetails a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where PRNo=@PRNo order by b.NamaBarang desc"
                cmd.Parameters.Clear()

                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value))

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "hasil")
                    Me.DataGridView2.DataSource = ds.Tables(0)
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
                cmd.CommandText =
                    "Select a.TransID,a.KodeBarang, b.NamaBarang, a.UOM, a.Qty, a.LastPrice,a.EstTotPrice,a.Keterangan from tbATKPRDetails a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where 1>2 order by a.TransID desc"
                'cmd.Parameters.Clear()

                'cmd.Parameters.Add(New SqlClient.SqlParameter("ReqNo", Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value))

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "hasil")
                    Me.DataGridView2.DataSource = ds.Tables(0)
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbClose.CheckedChanged
        dv.RowFilter = "status='Close'"
        ShowDataDetailsBlank()
        SetButton()
        Me.btnFollowUp.Enabled = False
        Me.btnApprove.Enabled = False
        'Me.DataGridView1.DataSource = dv

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCreated.CheckedChanged
        dv.RowFilter = "status='Created'"
        ShowDataDetailsBlank()
        SetButton()
        btnApprove.Enabled = False
        Me.btnFollowUp.Enabled = False
        'Me.DataGridView1.DataSource = dv
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ShowDataDetails()
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub rbWait_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWait.CheckedChanged
        dv.RowFilter = "status='Waiting for Approval'"
        ShowDataDetailsBlank()
        SetButton()
        Me.btnFollowUp.Enabled = False
        'Me.DataGridView1.DataSource = dv
    End Sub
    Private Sub rdWait2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdWait2.CheckedChanged
        dv.RowFilter = "status='Waiting for 2nd Approval'"
        ShowDataDetailsBlank()
        SetButton()
        Me.btnFollowUp.Enabled = False
    End Sub

    Private Sub rbApproved_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbApproved.CheckedChanged
        dv.RowFilter = "status='Approved'"
        ShowDataDetailsBlank()
        mnuApprove.Enabled = False
        mnuRevisi.Enabled = False
        mnuNotApprove.Enabled = False
        Me.btnApprove.Enabled = False
        'Me.DataGridView1.DataSource = dv
    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

        If Me.DataGridView2.RowCount = 0 Then
            MsgBox("Silahkan di-Click dulu datanya sampai data detailnya terlihat")
            Exit Sub
        End If

        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Approved" Then
            MsgBox("PR sudah di-approve")
            Exit Sub
        End If
        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Closed" Then
            MsgBox("PR sudah di-Close")
            Exit Sub
        End If

        Dim ws As New WebReference.WebService
        Dim dsTO As New DataSet
        Dim dsCC As New DataSet
        Dim dsBCC As New DataSet
        Dim hasil As String = ""
        Dim detail As String = ""
        Dim strHeader1 As String = ""
        Dim strHeader As String = ""
        Dim strFooter As String = ""
        strHeader1 = "<tr>" &
                    "<th bgcolor=#00BFFF align=center>Description</th>" &
                    "<th bgcolor=#00BFFF align=center>UOM</th>" &
                    "<th bgcolor=#00BFFF align=center>Qty</th>" &
                    "<th bgcolor=#00BFFF align=center>LastPrice</th>" &
                    "<th bgcolor=#00BFFF align=center>EstTotPrice</th>" &
                    "<th bgcolor=#00BFFF align=center>Remarks</th>" &
                    "<th bgcolor=#00BFFF align=center>Bill to Customer</th>" &
                   "</tr>"


        For i As Integer = 0 To Me.DataGridView2.RowCount - 1
            detail = detail & "<tr>"
            For j As Integer = 0 To Me.DataGridView2.ColumnCount - 1
                If Me.DataGridView2.Columns(j).Name = "NamaBarang" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "Satuan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "Qty" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "LastPrice" Then
                    detail = detail & "<td>" & Format(Me.DataGridView2.Item(j, i).Value, "##,##0")
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "EstTotPrice" Then
                    detail = detail & "<td>" & Format(Me.DataGridView2.Item(j, i).Value, "##,##0")
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "Keterangan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name.ToLower = "dibeliolehga" Then
                    detail = detail & "<td>" & IIf(Me.DataGridView2.Item(j, i).Value = 1, "YES", "NO")
                    detail = detail & "</td>"
                End If
            Next

            detail = detail & "</tr>"
        Next

        Dim ds As New DataSet
        ds = ShowDataHarga(Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value)
        Dim ht As New Hashtable
        ht = G_PRProfile(Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value)

        strFooter = "<tr>" &
                     "<th bgcolor=#CCCCCC align=center>Total Price : Rp. " & IIf(IsDBNull(Format(ds.Tables(0).Rows(0)("EstTotPrice"), "##,##0")), "0", Format(ds.Tables(0).Rows(0)("EstTotPrice"), "##,##0")) & "</th></tr>"

        If ds.Tables(0).Rows(0)("EstTotPrice") <= "5000000" And ht("status") = "2" Then
            hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
            hasil = hasil & "Dear Admin,<br /><br />Silahkan di-follow up untuk Request PR No : " & Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value & " dengan detail sebagai berikut : <br /><br /></p>"
        ElseIf ds.Tables(0).Rows(0)("EstTotPrice") > "5000000" And ht("status") = "2" Then
            hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
            hasil = hasil & "Dear " & ht("apptittle1") & " " & ht("prappname1") & ",<br /><br />Mohon Approvalnya yang ke-2 untuk Request PR No : " & Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value & " dengan detail sebagai berikut : <br />"
            hasil = hasil & "<table border='0' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>"
            hasil = hasil & "<tr><td align='right'>Transaction Date     : </td><td>" & Format(Me.DataGridView1.Item("TglTransaksi", Me.DataGridView1.CurrentRow.Index).Value, "dd-MM-yyyy") & "</td></tr>"
            hasil = hasil & "<tr><td align='right'>Approved by          : </td><td>" & Me.DataGridView1.Item("ApprovedBy", Me.DataGridView1.CurrentRow.Index).Value & "</td></tr>"
            hasil = hasil & "<tr><td align='right'>End User Location    : </td><td>" & Me.DataGridView1.Item("NamaSite", Me.DataGridView1.CurrentRow.Index).Value & "</td></tr>"
            If ht("department") = "Kaizen" Then
                hasil = hasil & "<tr><td align='right'>Type PR          : </td><td>PROJECT</td></tr></table></p>"
            Else
                hasil = hasil & "<tr><td align='right'>Type PR          : </td><td>Non Project</td></tr></table></p>"
            End If

        ElseIf ht("status") = "4" Then
            hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
            hasil = hasil & "Dear Admin,<br /><br />Silahkan di-follow up untuk Request PR No : " & Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value & " dengan detail sebagai berikut : <br /><br /></p>"
        End If
        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail & strFooter
        hasil = hasil & "</table> <br /><br />"

        If ds.Tables(0).Rows(0)("EstTotPrice") > "5000000" And ht("status") = "2" Then
            hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Silahkan klik <a href='http://10.130.12.190/eproc/prapproval.aspx?n=" & Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value & "&apr=2'>disini</a> untuk proses approval.<br /></p>"
            hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"
            hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Do not reply</b><br /></p>"
        Else
            hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"
            hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Do not reply</b><br /></p>"
        End If

        If ds.Tables(0).Rows(0)("EstTotPrice") <= "5000000" And ht("status") = "2" Then
            If ht("prapp1") <> strUserName Then
                MsgBox("tidak punya otorisasi untuk approved PR ini")
                Exit Sub
            End If
            strHeader = "[Purchase Request] PR No. " & Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value & " has been approved"
            dsTO = Me.G_EmailAddressTo(3, ht)
            dsCC = Me.G_EmailAddressCC(ht)
            dsBCC = Me.G_EmailAddressBCC("pr")

        ElseIf ds.Tables(0).Rows(0)("EstTotPrice") > "5000000" And ht("status") = "2" Then
            If ht("prapp1") <> strUserName Then
                MsgBox("tidak punya otorisasi untuk approved PR ini")
                Exit Sub
            End If
            strHeader = "[Purchase Request] 2nd Approval Request For PR No. " & Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value
            dsTO = Me.G_EmailAddressTo(4, ht)
            dsCC = Me.G_EmailAddressCC(ht)
            dsBCC = Me.G_EmailAddressBCC("pr")

        ElseIf ht("status") = "4" Then
            If ht("prapp2") <> strUserName Then
                MsgBox("tidak punya otorisasi untuk approved PR ini")
                Exit Sub
            End If
            strHeader = "[Purchase Request] PR No. " & Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value & " has been approved"
            dsTO = Me.G_EmailAddressTo(5, ht)
            dsCC = Me.G_EmailAddressCC(ht)
            dsBCC = Me.G_EmailAddressBCC("pr")
        End If


        'If SendEmail(strHeader, hasil, "", dsTO, dsCC, dsBCC) = False Then
        '    MsgBox("Kesalahan bukan pada komputer anda")
        'Else
        'Kalau status masih created dan PR lebih kecil dari 5Jt status Approved dan Created PO
        If ds.Tables(0).Rows(0)("EstTotPrice") <= "5000000" And ht("status") = "2" Then
            UpdateStatus(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 3)
            'Create PO
            INSERTDATA(Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value)
            'UpdateStatus_PR(Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value)

            'Kalau status masih created dan PR lebih kecil dari 5Jt status Approved dan Created PO
        ElseIf ds.Tables(0).Rows(0)("EstTotPrice") > "5000000" And ht("status") = "2" Then
            UpdateStatus(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 4)

            'Waiting 2nd Approval untuk menjadi approved dan Created PO
        ElseIf ht("status") = "4" Then
            UpdateStatus_1(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 5)

            'Create PO
            INSERTDATA(Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value)

        End If

        If SendEmail(strHeader, hasil, "", dsTO, dsCC, dsBCC) = False Then
            MsgBox("[Purchase Request] Approval Request is succesfully but unsend email")
        Else
            MsgBox("Send ''PR Approval'' Successfully")
        End If

        If strUserName.ToLower = "vero_pr" Then
            ShowDataMaster("1")
        Else
            ShowDataMaster("3")
        End If

        Me.ShowDataDetailsBlank()

    End Sub

    Private Sub UpdateStatus(ByVal TransID As Integer, ByVal intStatus As Integer)
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal


                cmd.Connection = cn
                cn.Open()


                strSQL = "Update tbATKPRMain set Status=@Status,ApprovedBy=@ApproveBy,ApprovedDate=@ApproveDate,ApprovedHost=@HostName Where TransID=@TransID"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", TransID))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Status", intStatus))
                cmd.Parameters.Add(New SqlClient.SqlParameter("ApproveBy", strUserName))
                cmd.Parameters.Add(New SqlClient.SqlParameter("ApproveDate", Now.Date))
                cmd.Parameters.Add(New SqlClient.SqlParameter("HostName", System.Net.Dns.GetHostName))
                Try

                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub
    Private Sub UpdateStatus_1(ByVal TransID As Integer, ByVal intStatus As Integer)
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal


                cmd.Connection = cn
                cn.Open()


                strSQL = "Update tbATKPRMain set Status=@Status,ApprovedBy1=@ApproveBy,ApprovedDate1=@ApproveDate,ApprovedHost1=@HostName Where TransID=@TransID"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", TransID))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Status", intStatus))
                cmd.Parameters.Add(New SqlClient.SqlParameter("ApproveBy", strUserName))
                cmd.Parameters.Add(New SqlClient.SqlParameter("ApproveDate", Now.Date))
                cmd.Parameters.Add(New SqlClient.SqlParameter("HostName", System.Net.Dns.GetHostName))
                Try

                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub

    Private Sub UpdateStatus1(ByVal TransID As Integer, ByVal intStatus As Integer)
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal


                cmd.Connection = cn
                cn.Open()

                strSQL = "Update tbATKPRMain set Status=@Status,FollowUpBy=@FollowUpBy,FollowUpDate=@FollowUpDate,HostName=@HostName Where TransID=@TransID"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", TransID))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Status", intStatus))
                cmd.Parameters.Add(New SqlClient.SqlParameter("FollowUpBy", strUserName))
                cmd.Parameters.Add(New SqlClient.SqlParameter("FollowUpDate", Now.Date))
                cmd.Parameters.Add(New SqlClient.SqlParameter("HostName", System.Net.Dns.GetHostName))
                Try

                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub
    Private Function G_EmailAddressTo(ByVal intStatus As Integer, ByVal ht As Hashtable) As DataSet
        Dim ds As DataSet = New DataSet
        'Dim ht As Hashtable = G_RequesterProfile(Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value)

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal


                cmd.Connection = cn
                cn.Open()
                Select Case intStatus
                    Case 3 'Single Approved
                        strSQL = "Select '" & ht("emailaddress") & "' as EmailAddress"
                    Case 4 'Waiting 2nd Approval
                        strSQL = "Select '" & ht("prapproval1") & "' as EmailAddress"
                        'strSQL = "Select 'farimbayu@agility.com' as EmailAddress"
                    Case 5 '2nd Approved
                        strSQL = "Select '" & ht("emailaddress") & "' as EmailAddress"
                    Case 9 'Not approve
                        strSQL = "Select '" & ht("emailaddress") & "' as EmailAddress"
                End Select

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

                strSQL = "select '" & ht("adminga") & "' as EmailAddress " & strCC
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

    Private Function SendEmail(ByVal strSubject As String, ByVal strMsg As String, ByVal strAttach As String, ByVal dsTo As Data.DataSet, ByVal dsCC As Data.DataSet, ByVal dsBCC As Data.DataSet) As Boolean
        Dim ws As New WebReference.WebService
        Dim hasil As Boolean = True
        strAttach = ""

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

    Private Sub btnFollowUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFollowUp.Click

        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value <> "Approved" Then
            If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Closed" Then
                MsgBox("PR sudah di-Close")
                Exit Sub
            Else
                MsgBox("PR belum di-approve")
                Exit Sub
            End If
        End If
        If AddDetailToLedger() = True Then
            UpdateStatus1(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 4)

            If strUserName.ToLower = "vero" Then
                ShowDataMaster("1")
            Else
                ShowDataMaster("3")
            End If
            Me.ShowDataDetailsBlank()

        End If
    End Sub

    Private Function AddDetailToLedger() As Boolean
        Dim hasil As Boolean = False
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal


                cmd.Connection = cn
                cn.Open()

                strSQL = "INSERT INTO tbATKmain (NamaSite, TglTransaksi, NamaKaryawan, StorerKey, KodeBarang, UOM, JenisTrans, Qty, Keterangan,ReqNo) " &
                    "Select a.NamaSite, a.TglTransaksi,Name , a.StorerKey, b.KodeBarang, b.UOM, 'D' JenisTrans, b.Qty, b.Keterangan,b.PRNo " &
                    "from tbATKPRMain a inner join tbATKPRDetails b on a.PRNo  = b.PRNo where b.PRNo=" & Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value

                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                hasil = True

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    hasil = False
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Private Sub DataGridView2_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub frmListPR_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub

    Private Sub btnNotApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotApprove.Click
        Dim strReason As String = ""
        strReason = InputBox("Alasan Ditolak : ", "Alasan PR Ditolak")

        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Approved" Then
            MsgBox("PR sudah di-approve")
            Exit Sub
        End If
        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Closed" Then
            MsgBox("PR sudah di-Close")
            Exit Sub
        End If

        Dim ws As New WebReference.WebService
        Dim dsTO As New DataSet
        Dim dsCC As New DataSet
        Dim dsBCC As New DataSet
        Dim hasil As String = ""
        Dim detail As String = ""
        Dim strHeader1 As String = ""
        strHeader1 = "<tr>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Barang</th>" & _
                    "<th bgcolor=#00BFFF align=center>Satuan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>LastPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>EstTotPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>Keterangan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Dibeli Oleh GA</th>" & _
                   "</tr>"

        For i As Integer = 0 To Me.DataGridView2.RowCount - 1
            detail = detail & "<tr>"
            For j As Integer = 0 To Me.DataGridView2.ColumnCount - 1
                If Me.DataGridView2.Columns(j).Name = "NamaBarang" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "Satuan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "Qty" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "LastPrice" Then
                    detail = detail & "<td>" & Format(Me.DataGridView2.Item(j, i).Value, "##,##0")
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "EstTotPrice" Then
                    detail = detail & "<td>" & Format(Me.DataGridView2.Item(j, i).Value, "##,##0")
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "Keterangan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name.ToLower = "dibeliolehga" Then
                    detail = detail & "<td>" & IIf(Me.DataGridView2.Item(j, i).Value = 1, "Ya", "Tidak")
                    detail = detail & "</td>"
                End If
            Next

            detail = detail & "</tr>"
        Next

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear Admin,<br /><br />Mohon Maaf, untuk PRNo : " & Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value & " dengan detail sebagai berikut : <br /><br /></p>"
        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Ditolak dengan alasan : " & strReason & ".<br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"
        Dim ht As New Hashtable
        ht = G_PRProfile(Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value)

        dsTO = Me.G_EmailAddressTo(9, ht)
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC("pr")
        If SendEmail("[ATK] PR Request Not Approved", hasil, "", dsTO, dsCC, dsBCC) = False Then
            MsgBox("Kesalahan bukan pada komputer anda")
        Else
            UpdateStatus(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 9)
            MsgBox("Send ''ATK Not Approve'' Sukses")
            Me.ShowDataDetailsBlank()
            If strUserName.ToLower = "vero" Then
                ShowDataMaster("1")
            Else
                ShowDataMaster("3")
            End If
        End If
    End Sub

    Private Sub mnuApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuApprove.Click
        Me.btnApprove_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuRevisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRevisi.Click
        Me.btnRevisi_Click(Nothing, Nothing)
    End Sub

    Private Sub btnRevisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevisi.Click
        Dim strReason As String = ""
        strReason = InputBox("Yang harus direvisi : ", "Alasan PR Direvisi")

        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Approved" Then
            MsgBox("Permintaan ATK sudah di-approve")
            Exit Sub
        End If
        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Closed" Then
            MsgBox("Permintaan ATK sudah di-Close")
            Exit Sub
        End If
        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Ditolak" Then
            MsgBox("Permintaan ATK sudah di-Tolak")
            Exit Sub
        End If
        Dim ws As New WebReference.WebService
        Dim dsTO As New DataSet
        Dim dsCC As New DataSet
        Dim dsBCC As New DataSet
        Dim hasil As String = ""
        Dim detail As String = ""
        Dim strHeader1 As String = ""
        strHeader1 = "<tr>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Barang</th>" & _
                    "<th bgcolor=#00BFFF align=center>Satuan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>LastPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>EstTotPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>Keterangan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Dibeli Oleh GA</th>" & _
                   "</tr>"

        For i As Integer = 0 To Me.DataGridView2.RowCount - 1
            detail = detail & "<tr>"
            For j As Integer = 0 To Me.DataGridView2.ColumnCount - 1
                If Me.DataGridView2.Columns(j).Name = "NamaBarang" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "Satuan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "Qty" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "LastPrice" Then
                    detail = detail & "<td>" & Format(Me.DataGridView2.Item(j, i).Value, "##,##0")
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "EstTotPrice" Then
                    detail = detail & "<td>" & Format(Me.DataGridView2.Item(j, i).Value, "##,##0")
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name = "Keterangan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
                If Me.DataGridView2.Columns(j).Name.ToLower = "dibeliolehga" Then
                    detail = detail & "<td>" & IIf(Me.DataGridView2.Item(j, i).Value = 1, "Ya", "Tidak")
                    detail = detail & "</td>"
                End If
            Next

            detail = detail & "</tr>"
        Next

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear Admin,<br /><br />PR ATK No : " & Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value & " dengan detail sebagai berikut : <br /><br /></p>"
        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana>'Perlu direvisi dengan catatan : " & strReason & "<br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"

        'Dim htRequester As Hashtable = G_RequesterProfile(Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value)
        Dim ht As New Hashtable
        ht = G_PRProfile(Me.DataGridView1.Item("PRNo", Me.DataGridView1.CurrentRow.Index).Value)

        dsTO = Me.G_EmailAddressTo(5, ht)
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC("pr")
        If SendEmail("[ATK] PR Perlu Direvisi", hasil, "", dsTO, dsCC, dsBCC) = False Then
            MsgBox("Kesalahan bukan pada komputer anda")
        Else
            UpdateStatus(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 5) '1=create 2. waiting for approval 3. approve 4.Follow up 5. Revisi 9. Close
            MsgBox("Send ''ATK Approval'' Sukses")
            If strUserName.ToLower = "vero" Then
                ShowDataMaster("1")
            Else
                ShowDataMaster("3")
            End If
            Me.ShowDataDetailsBlank()
        End If
    End Sub

    Private Sub mnuNotApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNotApprove.Click
        Me.btnNotApprove_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuFollowUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFollowUp.Click
        Me.btnFollowUp_Click(Nothing, Nothing)
    End Sub

    Private Sub cbSite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSite.SelectedIndexChanged
        Me.ShowDataMaster("3")
    End Sub
    Private Function cekData(ByVal strPONo As String) As Boolean

        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                "Select TransID from tbATKPODetails  WHERE PONo='" & strPONo & "' "

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
    Private Sub INSERTDATA(ByVal strPRNo As String)
        Dim ds As New DataSet
        Dim dataprdetails As New DataSet
        Dim Min As New DataSet
        Dim Max As New DataSet
        Min = MinRow(strPRNo)
        Max = MaxRow(strPRNo)
        Dim strVendor As String = ""
        Dim strPO As String = ""

        'strPO = G_PO(ds.Tables(0).Rows(0)("KodeVendor"))


        For i As Integer = Min.Tables(0).Rows(0)("MinRow") To Max.Tables(0).Rows(0)("MaxRow")
            ds = G_DataPR(i, strPRNo)
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                strPO = G_PO(G_KodeWH(ds.Tables(0).Rows(j)("NamaSite")))

                'Insert data PO MAIN
                Using cn As New SqlClient.SqlConnection(strCOnnLocal)
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cn.Open()

                        cmd.CommandText =
                        "INSERT INTO tbATKPOMain (WHAsal,PONo,PRNo,KodeVendor,VendorName,StartDate,Status,InputBy) VALUES (@WHAsal,@PONo,@PRNo,@KodeVendor,@VendorName,@StartDate,0,@InputBy)"
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlClient.SqlParameter("WHAsal", ds.Tables(0).Rows(j)("NamaSite")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", strPO))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", ds.Tables(0).Rows(j)("PRNo")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("KodeVendor", ds.Tables(0).Rows(j)("KodeVendor")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("VendorName", ds.Tables(0).Rows(j)("VendorName")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("StartDate", Format(Now.Date, "yyyy/MM/dd")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("InputBy", ds.Tables(0).Rows(j)("InputBy")))

                        Try
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception

                            MsgBox(ex.Message)
                        End Try

                    End Using
                End Using

                dataprdetails = G_DataPRDetails(i, strPRNo)
                'Insert data PO Details
                Using cn As New SqlClient.SqlConnection(strCOnnLocal)
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cn.Open()
                        For k As Integer = 0 To dataprdetails.Tables(0).Rows.Count - 1
                            cmd.CommandText =
                        "INSERT INTO tbATKPODetails (PONo,PRNo,KodeBarang, KodeVendor,UOM, Qty, Keterangan,LastPrice,EstTotPrice,EndUserName,EndUserLocation,PurchasedbyGA) VALUES (@PONo,@PRNo,@KodeBarang, @KodeVendor,@UOM, @Qty, @Keterangan,@LastPrice,@EstTotPrice,@EndUserName,@EndUserLocation,@PurchasedbyGA)"
                            cmd.Parameters.Clear()
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", strPO))
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", dataprdetails.Tables(0).Rows(k)("PRNo")))
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("KodeVendor", dataprdetails.Tables(0).Rows(k)("KodeVendor")))
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", dataprdetails.Tables(0).Rows(k)("KodeBarang")))
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", dataprdetails.Tables(0).Rows(k)("UOM")))
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", dataprdetails.Tables(0).Rows(k)("Qty")))
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", dataprdetails.Tables(0).Rows(k)("NamaBarang")))
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("LastPrice", dataprdetails.Tables(0).Rows(k)("LastPrice")))
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("EstTotPrice", dataprdetails.Tables(0).Rows(k)("EstTotPrice")))
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserName", Me.DataGridView1.Item("Storerkey", Me.DataGridView1.CurrentRow.Index).Value))
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("EndUserLocation", Me.DataGridView1.Item("Department", Me.DataGridView1.CurrentRow.Index).Value))
                                    cmd.Parameters.Add(New SqlClient.SqlParameter("PurchasedbyGA", dataprdetails.Tables(0).Rows(k)("PurchasedbyGA")))
                                    Try
                                        cmd.ExecuteNonQuery()

                            Catch ex As Exception

                                        MsgBox(ex.Message)
                                    End Try

                        Next
                    End Using
                End Using
            Next
        Next

    End Sub
    Private Function G_DataPR(ByVal Row As Integer, ByVal strPRNo As String) As DataSet
        Dim strSQL As String = ""
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText = "select * from (select ROW_NUMBER() OVER (ORDER BY KodeVendor) AS Row,* from (select distinct a.PRNO,isnull(KodeVendor,'Agility')KodeVendor,cm.CompanyName,NamaSite,c.InputBy from tbATKPRDetails a left join tbATKmstbrg  b on a.KodeBarang = b.KodeBarang inner join tbATKPRMain c on a.PRNo=c.PRNo left join tbATKmstCompany cm on isnull(KodeVendor,'Agility')=cm.SupplierID where a.PRNo='" & strPRNo & "')a)b  where Row='" & Row & "' "
                '"select * from (select ROW_NUMBER() OVER (ORDER BY KodeVendor) AS Row,* from (select distinct a.PRNO,isnull(KodeVendor,'Agility')KodeVendor,NamaSite,c.InputBy from tbATKPRDetails a left join tbATKmstbrg  b on a.KodeBarang = b.KodeBarang inner join tbATKPRMain c on a.PRNo=c.PRNo where a.PRNo='" & strPRNo & "')a)b where Row='" & Row & "' "

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
    Private Function G_DataPRDetails(ByVal Row As Integer, ByVal strPRNo As String) As DataSet
        Dim strSQL As String = ""
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                "Select Row,a.PRNo,a.KodeBarang, b.NamaBarang, a.UOM, a.Qty, isnull(a.LastPrice,0) LastPrice,isnull(a.EstTotPrice,0) EstTotPrice,a.Keterangan,a.PurchasedByGA,case when b.KodeVendor='' then 'Agility' else isnull(b.KodeVendor,'Agility') end KodeVendor " &
                "From tbATKPRDetails a inner Join tbATKmstbrg b on a.KodeBarang=b.KodeBarang " &
                "inner join (select * from (select ROW_NUMBER() OVER (ORDER BY KodeVendor) AS Row,* from (select distinct a.PRNO,isnull(KodeVendor,'Agility')KodeVendor,NamaSite " &
                "from tbATKPRDetails a left join tbATKmstbrg  b on a.KodeBarang = b.KodeBarang inner join tbATKPRMain c on a.PRNo=c.PRNo where a.PRNo='" & strPRNo & "')a)b) c on ISNULL(b.KodeVendor,'Agility')=c.KodeVendor " &
                "where a.PRNo='" & strPRNo & "' and Row='" & Row & "' order by Row asc "

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
    Private Function MinRow(ByVal strPRNo As String) As DataSet
        Dim strSQL As String = ""
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                "select Min(Row)as MinRow from(select ROW_NUMBER() OVER (ORDER BY KodeVendor) AS Row,* from (select distinct PRNO,isnull(KodeVendor,'Agility')KodeVendor from tbATKPRDetails a left join tbATKmstbrg  b on a.KodeBarang = b.KodeBarang where a.PRNo='" & strPRNo & "')a)b "

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
    Private Function MaxRow(ByVal strPRNo As String) As DataSet
        Dim strSQL As String = ""
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                "select Max(Row)as MaxRow from(select ROW_NUMBER() OVER (ORDER BY KodeVendor) AS Row,* from (select distinct PRNO,isnull(KodeVendor,'Agility')KodeVendor from tbATKPRDetails a left join tbATKmstbrg  b on a.KodeBarang = b.KodeBarang where a.PRNo='" & strPRNo & "')a)b "

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
    Private Sub UpdateStatus_PR(ByVal strPRNo As String)
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal


                cmd.Connection = cn
                cn.Open()

                strSQL = "Update tbATKPRMain set Status='8' Where PRNo=@PRNo"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", strPRNo))
                'cmd.Parameters.Add(New SqlClient.SqlParameter("StatusPO", StatusPO))
                'cmd.Parameters.Add(New SqlClient.SqlParameter("Status", StatusPR))
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub
End Class