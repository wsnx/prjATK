Imports System
Imports System.Data
Imports clsFunction

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim strConnLocal As String = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString
    Dim strSQL As String = ""

    Protected Sub btnApprove_Click(sender As Object, e As System.EventArgs) Handles btnApprove.Click
        If Me.GridView2.Rows.Count = 0 Then
            Response.Write("<script>alert('Silahkan Klik SELECT No SPL');</script>")
            Exit Sub
        End If
        'Dim computer_name() As String
        'computer_name = Split(System.Net.Dns.Resolve(Request.ServerVariables("remote_addr")).HostName, ".")
        'Dim hostname As String
        'hostname = System.Net.Dns.GetHostName

        Dim ht As New Hashtable

        ht = clsFunction.G_PRProfile(Me.GridView1.SelectedValue)
        Dim lblStatus As Label
        Dim lbTransID As Label
        lblStatus = CType(Me.GridView1.SelectedRow.FindControl("lblStatus"), Label)
        lbTransID = CType(Me.GridView1.SelectedRow.FindControl("lblTransID"), Label)

        Dim strhasil As String = ""
        If ht("jenisapproval") = "and" Then
            If lblStatus.Text = "Waiting for Approval" Then
                'minta approval kedua
                ReqApproval2(ht)
                strhasil = clsFunction.UpdateStatusByTransID("PR", lbTransID.Text, 4, Session("UserName"), "By Mobile Dev")
            ElseIf lblStatus.Text = "Waiting for 2nd Approval" Then
                'ApproveKe2()
                ApprovalKe1(ht)
                strhasil = clsFunction.UpdateStatusByTransID("PR", lbTransID.Text, 5, Session("UserName"), "By Mobile Dev")
            End If
        Else
            ApprovalKe1(ht)
            strhasil = clsFunction.UpdateStatusByTransID("PR", lbTransID.Text, 3, Session("UserName"), "By Mobile Dev")
        End If

        If strhasil <> "" Then
            lblErr.Text = strhasil
        End If
        TampilkanData()

        
    End Sub

    Private Sub TampilkanData()
        Me.GridView1.DataBind()
        Me.GridView2.DataBind()
        Me.SqlDataSource1.DataBind()
        Me.SqlDataSource2.DataBind()

        Me.Panel1.Visible = False
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim strUserName As String = ""
        Me.lblErr.Text = ""
        Dim strSPLNo As String = ""

        Session.Add("splno", Request.QueryString("n"))
        Try
            strUserName = Session("UserName")

            If strUserName.Trim = "" Then
                Response.Redirect("Login1.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("Login1.aspx")
        End Try

        If Is2ndApproval(Session("UserName")) = True Then
            Me.SqlDataSource1.SelectCommand = "select a.TransID as MainTransID, NamaSite, NoSPL, NamaBagian, c.CustomerName as Customer, TglLembur, Weekday as HariKerja, DiperintahOleh, case Kategori when '1' then 'Request(Customer)' when '2' then 'Request Sales / CS Agility' when '3' then 'Request(Internal)' end as Kategori , TargetPekerjaan, PencapaianTarget, InputBy, case status when 1 then 'Created' when 2 then 'Waiting for Approval' when 3 then 'Approved' when 8 then 'Realisasi Confirm' when 4 then 'Waiting for 2nd Approval' when 5 then 'Approved' when 9 then 'Cancel' end as Status from tbsplmain a inner join tbspluserconfig b on a.InputBy=b.UserID left join tbDORStorer c on a.Customer=c.StorerKey where  case when charindex('@',splappemail1) > 0 then lower(left(splappemail1,charindex('@',splappemail1)-1)) end =@UserName and status=4 order by a.TransID desc"
            Me.SqlDataSource1.SelectParameters.Clear()
            Me.SqlDataSource1.SelectParameters.Add("UserName", strUserName)
            'Me.GridView1.DataSource = Me.SqlDataSource1
            Me.GridView1.DataBind()
        Else
            Me.SqlDataSource1.SelectCommand = "select a.TransID as MainTransID, NamaSite, NoSPL, NamaBagian, c.CustomerName as Customer, TglLembur, Weekday as HariKerja, DiperintahOleh, case Kategori when '1' then 'Request(Customer)' when '2' then 'Request Sales / CS Agility' when '3' then 'Request(Internal)' end as Kategori , TargetPekerjaan, PencapaianTarget, InputBy, case status when 1 then 'Created' when 2 then 'Waiting for Approval' when 3 then 'Approved' when 8 then 'Realisasi Confirm' when 4 then 'Waiting for 2nd Approval' when 5 then 'Approved' when 9 then 'Cancel' end as Status from tbsplmain a inner join tbspluserconfig b on a.InputBy=b.UserID left join tbDORStorer c on a.Customer=c.StorerKey where  case when charindex('@',splappemail) > 0 then lower(left(splappemail,charindex('@',splappemail)-1)) end =@UserName and status=2 order by a.TransID desc"
            Me.SqlDataSource1.SelectParameters.Clear()
            Me.SqlDataSource1.SelectParameters.Add("UserName", strUserName)
            'Me.GridView1.DataSource = Me.SqlDataSource1
            Me.GridView1.DataBind()
        End If
        'Me.SqlDataSource1.DataBind()
        Me.SqlDataSource2.DataBind()
        Me.Panel1.Visible = False

    End Sub

    Private Sub ReqApproval2(ByVal ht As Hashtable)
        Dim ws As New WebReference.Service
        Dim dsTO As New DataSet
        Dim dsCC As New DataSet
        Dim dsBCC As New DataSet
        Dim hasil As String = ""
        Dim detail As String = ""
        Dim strHeader1 As String = ""

        'Dim ht As New Hashtable

        'ht = G_SPLProfile(Me.txtNoSPL.Text)

        strHeader1 = "<tr>" & _
                    "<th bgcolor=#00BFFF align=center>NIK</th>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Karyawan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Rencana Mulai</th>" & _
                    "<th bgcolor=#00BFFF align=center>Rencana Selesai</th>" & _
                    "<th bgcolor=#00BFFF align=center>Keterangan</th>" & _
                   "</tr>"
        Dim ds As New DataSet
        ds = clsFunction.G_PRDetails(GridView1.SelectedValue)
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            detail = detail & "<tr>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("NIK")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("NamaKaryawan")
            detail = detail & "</td>"

            detail = detail & "<td>" & Format(ds.Tables(0).Rows(i)("PlanStart"), "hh:mm")
            detail = detail & "</td>"

            detail = detail & "<td>" & Format(ds.Tables(0).Rows(i)("PlanEnd"), "hh:mm")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("Remark")
            detail = detail & "</td>"

            detail = detail & "</tr>"
        Next

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear " & ht("apptitle1") & " " & ht("splappname1") & ",<br /><br />Mohon approvalnya untuk rencana lembur dengan No SPL : " & Me.GridView1.SelectedValue & " dengan detail sebagai berikut : <br />"
        'hasil = hasil & "Tgl Lembur : " & Format(Me.DataGridView1.Item("TglLembur", Me.DataGridView1.CurrentRow.Index).Value, "dd-MMM-yyyy") & " <br />"
        'hasil = hasil & "Jenis Hari : " & IIf(Me.DataGridView1.Item("Weekday", Me.DataGridView1.CurrentRow.Index).Value = True, "Hari Kerja", "Hari Libur") & " <br />"
        'hasil = hasil & "Diperintahkan Oleh : " & Me.DataGridView1.Item("DiperintahOleh", Me.DataGridView1.CurrentRow.Index).Value & " <br />"
        'hasil = hasil & "Kategori : " & Me.DataGridView1.Item("Kategori", Me.DataGridView1.CurrentRow.Index).Value & " <br />"
        'hasil = hasil & "Departemen : " & Me.DataGridView1.Item("Departemen", Me.DataGridView1.CurrentRow.Index).Value & " <br />"
        'hasil = hasil & "Target : " & Me.DataGridView1.Item("TargetPekerjaan", Me.DataGridView1.CurrentRow.Index).Value & " <br /></p>"

        ds = New DataSet
        ds = clsFunction.G_PRMain(Me.GridView1.SelectedValue)
        'case Kategori when '1' then 'Request(Customer)' when '2' then 'Request Sales / CS Agility' when '3' then 'Request(Internal)'
        hasil = hasil & "<table border='0' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>"
        hasil = hasil & "<tr><td align='right'>Site               : </td><td>" & ds.Tables(0).Rows(0)("NamaSite") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Customer           : </td><td>" & ds.Tables(0).Rows(0)("Customer") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Tgl Lembur         : </td><td>" & Format(ds.Tables(0).Rows(0)("TglLembur"), "dd-MMM-yyyy") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Jenis Hari         : </td><td>" & IIf(ds.Tables(0).Rows(0)("Weekday") = True, "Hari Kerja", "Hari Libur") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Diperintahkan Oleh : </td><td>" & ds.Tables(0).Rows(0)("DiperintahOleh") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Kategori           : </td><td>" & IIf(ds.Tables(0).Rows(0)("Kategori") = "1", "Request(Customer)", IIf(ds.Tables(0).Rows(0)("Kategori") = "2", "Request Sales / CS Agility", "Request(Internal)")) & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Departemen         : </td><td>" & ds.Tables(0).Rows(0)("NamaBagian") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Target             : </td><td>" & ds.Tables(0).Rows(0)("TargetPekerjaan") & "</td></tr></table></p>"

        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br /><br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Jika SPL ini di-approve silahkan klik <a href=" & """" & "http://10.130.12.190/splapproval/approval.aspx?n=" & Me.GridView1.SelectedValue & "&s=4" & """" & ">di sini</a> atau jika tidak di-approve silahkan klik silahkan klik <a href=" & """" & "http://10.130.12.190/splapproval/notapprove.aspx?n=" & Me.GridView1.SelectedValue & """" & ">di sini.</a><br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Requested By : " & Session("UserName") & "</b><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"


        dsTO = Me.G_EmailAddressTo(ht, "SPLApproval2")
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC("spl")

        'UpdateStatus(Me.txtTransID.Text, 4) 'Request for Approval Ke-2
        If SendEmail("[SPL] 2nd Approval Request, SPL No." & Me.GridView1.SelectedValue, hasil, "", dsTO, dsCC, dsBCC) = False Then
            lblErr.Text = "SPL Approval Request ke-2 Sukses tapi Email tidak terkirim"
        Else

            lblErr.Text = "Send ''Minta Approval SPL ke-2'' Sukses"

        End If
    End Sub

    Private Sub ApprovalKe1(ByVal ht As Hashtable)
        Dim ws As New WebReference.Service
        Dim dsTO As New DataSet
        Dim dsCC As New DataSet
        Dim dsBCC As New DataSet
        Dim hasil As String = ""
        Dim detail As String = ""
        Dim strHeader1 As String = ""

        strHeader1 = "<tr>" & _
                    "<th bgcolor=#00BFFF align=center>NIK</th>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Karyawan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Rencana Mulai</th>" & _
                    "<th bgcolor=#00BFFF align=center>Rencana Selesai</th>" & _
                    "<th bgcolor=#00BFFF align=center>Keterangan</th>" & _
                   "</tr>"
        Dim ds As New DataSet
        ds = clsFunction.G_PRDetails(GridView1.SelectedValue)
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            detail = detail & "<tr>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("NIK")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("NamaKaryawan")
            detail = detail & "</td>"

            detail = detail & "<td>" & Format(ds.Tables(0).Rows(i)("PlanStart"), "hh:mm")
            detail = detail & "</td>"

            detail = detail & "<td>" & Format(ds.Tables(0).Rows(i)("PlanEnd"), "hh:mm")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("Remark")
            detail = detail & "</td>"

            detail = detail & "</tr>"
        Next

        ds = New DataSet
        ds = clsFunction.G_PRMain(Me.GridView1.SelectedValue)

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear Team,<br /><br />Silahkan dilanjutkan, saya sudah approve No SPL : " & Me.GridView1.SelectedValue & " dengan detail sebagai berikut : <br />"
        hasil = hasil & "<table border='0' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>"
        hasil = hasil & "<tr><td align='right'>Tgl Lembur         : </td><td>" & Format(ds.Tables(0).Rows(0)("TglLembur"), "dd-MMM-yyyy") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Jenis Hari         : </td><td>" & IIf(ds.Tables(0).Rows(0)("Weekday") = True, "Hari Kerja", "Hari Libur") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Diperintahkan Oleh : </td><td>" & ds.Tables(0).Rows(0)("DiperintahOleh") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Kategori           : </td><td>" & IIf(ds.Tables(0).Rows(0)("Kategori") = "1", "Request(Customer)", IIf(ds.Tables(0).Rows(0)("Kategori") = "2", "Request Sales / CS Agility", "Request(Internal)")) & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Departemen         : </td><td>" & ds.Tables(0).Rows(0)("NamaBagian") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Target             : </td><td>" & ds.Tables(0).Rows(0)("TargetPekerjaan") & "</td></tr></table></p>"

        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br /><br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Approved By : " & Session("UserName") & "</b><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"


        dsTO = Me.G_EmailAddressTo(ht, "SPLApproved")
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC("spl")

        'UpdateStatus(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 3)
        If SendEmail("[SPL] SPL No. " & Me.GridView1.SelectedValue & " has been approved", hasil, "", dsTO, dsCC, dsBCC) = False Then
            lblErr.Text = "SPL Approved tapi Email tidak terkirim"
        Else
            lblErr.Text = "Send ''SPL Approved'' Sukses"
        End If
    End Sub

    Private Sub NotApprove(ByVal ht As Hashtable)
        Dim strReason As String = ""
        'strReason = InputBox("Alasan Ditolak : ", "Alasan SPL Ditolak")

        Dim ws As New WebReference.Service
        Dim dsTO As New DataSet
        Dim dsCC As New DataSet
        Dim dsBCC As New DataSet
        Dim hasil As String = ""
        Dim detail As String = ""
        Dim strHeader1 As String = ""
        strHeader1 = "<tr>" & _
                    "<th bgcolor=#00BFFF align=center>NIK</th>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Karyawan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Rencana Mulai</th>" & _
                    "<th bgcolor=#00BFFF align=center>Rencana Selesai</th>" & _
                    "<th bgcolor=#00BFFF align=center>Keterangan</th>" & _
                   "</tr>"
        Dim ds As New DataSet
        ds = clsFunction.G_PRDetails(GridView1.SelectedValue)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            detail = detail & "<tr>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("NIK")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("NamaKaryawan")
            detail = detail & "</td>"

            detail = detail & "<td>" & Format(ds.Tables(0).Rows(i)("PlanStart"), "hh:mm")
            detail = detail & "</td>"

            detail = detail & "<td>" & Format(ds.Tables(0).Rows(i)("PlanEnd"), "hh:mm")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("Remark")
            detail = detail & "</td>"

            detail = detail & "</tr>"
        Next
        ds = New DataSet
        ds = clsFunction.G_PRMain(Me.GridView1.SelectedValue)

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear Team,<br /><br />Mohon maaf, saya tidak approve No SPL : " & GridView1.SelectedValue & " dengan detail sebagai berikut : <br />"
        hasil = hasil & "<table border='0' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>"
        hasil = hasil & "<tr><td align='right'>Tgl Lembur         : </td><td>" & Format(ds.Tables(0).Rows(0)("TglLembur"), "dd-MMM-yyyy") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Jenis Hari         : </td><td>" & IIf(ds.Tables(0).Rows(0)("Weekday") = True, "Hari Kerja", "Hari Libur") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Diperintahkan Oleh : </td><td>" & ds.Tables(0).Rows(0)("DiperintahOleh") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Kategori           : </td><td>" & IIf(ds.Tables(0).Rows(0)("Kategori") = "1", "Request(Customer)", IIf(ds.Tables(0).Rows(0)("Kategori") = "2", "Request Sales / CS Agility", "Request(Internal)")) & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Departemen         : </td><td>" & ds.Tables(0).Rows(0)("NamaBagian") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Target             : </td><td>" & ds.Tables(0).Rows(0)("TargetPekerjaan") & "</td></tr></table></p>"

        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Dengan alasan : " & Me.txtReason.Text & "<br /><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Not Approved By : " & Session("UserName") & "</b><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"
         

        dsTO = Me.G_EmailAddressTo(ht, "SPLNotApproved")
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC("spl")

        'clsFunction.UpdateStatus(Me.txtTransID.Text, 9)

        If SendEmail("[SPL] SPL No. " & Me.GridView1.SelectedValue & " is not approved", hasil, "", dsTO, dsCC, dsBCC) = False Then
            lblErr.Text = "'SPL Not Approve' Sukses Tapi Email Tidak Terkirim"
        Else

            lblErr.Text = "Send ''SPL Not Approve'' Sukses"

        End If
    End Sub

    Private Function G_EmailAddressTo(ByVal ht As Hashtable, ByVal RequestType As String) As DataSet
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strConnLocal


                cmd.Connection = cn
                cn.Open()

                'strSQL = "Select EmailAddress from tbEmailReceiver where ReportType='" & strReportType & "' and isto=1"

                If RequestType = "SPLApproval" Then
                    strSQL = "Select '" & ht("splappemail") & "' as EmailAddress"
                ElseIf RequestType = "SPLApproval2" Then
                    strSQL = "Select '" & ht("splappemail1") & "' as EmailAddress"
                ElseIf RequestType = "SPLApproved" Then
                    strSQL = "Select '" & ht("emailaddress") & "' as EmailAddress"
                ElseIf RequestType = "SPLNotApproved" Then
                    strSQL = "Select '" & ht("emailaddress") & "' as EmailAddress"
                End If

                'strSQL = "Select 'rfaisal@agility.com' as EmailAddress"

                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL

                Try

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception

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

                cn.ConnectionString = strConnLocal
                cmd.Connection = cn
                cn.Open()

                If Microsoft.VisualBasic.Right(ht("copyemail"), 1) <> ";" Then
                    emails = ht("copyemail") & ";"
                Else
                    emails = ht("copyemail")
                End If
                While InStr(emails, ";") > 0
                    strCC = strCC & "union select '" & Microsoft.VisualBasic.Left(emails, InStr(emails, ";") - 1) & "' as EmailAddress "
                    emails = Mid(emails, InStr(emails, ";") + 1)
                End While

                'emails = Mid(emails, 6)
                strSQL = "Select '" & ht("adminspl") & "' as EmailAddress " & strCC
                'strSQL = emails

                'strSQL = "Select 'rfaisal@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL

                Try

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception

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

                cn.ConnectionString = strConnLocal

                cmd.Connection = cn
                cn.Open()
                strSQL = "Select EmailAddress from tbEmailReceiver where ReportType='" & strReportType & "' and isbcc=1"
                'strSQL = "Select 'rfaisal@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL

                Try

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception

                    ds = New DataSet
                End Try
            End Using
        End Using
        Return ds
    End Function

    Private Function SendEmail(ByVal strSubject As String, ByVal strMsg As String, ByVal strAttach As String, ByVal dsTo As Data.DataSet, ByVal dsCC As Data.DataSet, ByVal dsBCC As Data.DataSet) As Boolean
        Dim ws As New WebReference.Service
        Dim hasil As Boolean = True

        Try
            ws.Timeout = 6000
            ws.SendEmailNew(strSubject, strMsg, strAttach, "spl_noreply@agility.com", dsTo, dsCC, dsBCC)
            'sr.SendErrorEmail(strSubject, strMsg, dsTo)

            hasil = True
        Catch ex As Exception
            hasil = False
        End Try

        Return hasil

    End Function

    Protected Sub btnNotApprove_Click(sender As Object, e As System.EventArgs) Handles btnNotApprove.Click
        If Me.GridView2.Rows.Count = 0 Then
            Response.Write("<script>alert('Silahkan Klik SELECT No SPL');</script>")
            Exit Sub
        End If
        Me.Panel1.Visible = True
        If Me.txtReason.Text = "" Then Exit Sub
        Dim computer_name() As String
        computer_name = Split(System.Net.Dns.Resolve(Request.ServerVariables("remote_addr")).HostName, ".")

        Dim ht As New Hashtable

        ht = clsFunction.G_PRProfile(Me.GridView1.SelectedValue)
        Dim lblStatus As Label
        Dim lbTransID As Label
        lblStatus = CType(Me.GridView1.SelectedRow.FindControl("lblStatus"), Label)
        lbTransID = CType(Me.GridView1.SelectedRow.FindControl("lblTransID"), Label)
        Me.NotApprove(ht)


        Dim strHasil As String = ""
        strHasil = clsFunction.UpdateStatusBySPLno(Session("splno"), 9, Session("UserName"), computer_name(0).ToUpper)
        If strHasil <> "" Then
            lblErr.Text = strHasil
        End If

        TampilkanData()
    End Sub

    Private Function Is2ndApproval(ByVal strUserID As String) As Boolean
        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strConnLocal

                cmd.Connection = cn
                cn.Open()
                strSQL = "Select splappemail1 from tbspluserconfig where case when charindex('@',splappemail1) > 0 then lower(left(splappemail1,charindex('@',splappemail1)-1)) end='" & strUserID & "'"
                'strSQL = "Select 'rfaisal@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL

                Try
                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = True
                    Else
                        hasil = False
                    End If
                    
                Catch ex As Exception

                End Try
            End Using
        End Using

        Return hasil
    End Function
    
End Class
