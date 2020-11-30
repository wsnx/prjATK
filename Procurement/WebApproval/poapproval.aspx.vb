Imports System
Imports System.Data
Imports clsFunction

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim strConnLocal As String = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString
    Dim strSQL As String = ""

    Protected Sub btnApprove_Click(sender As Object, e As System.EventArgs) Handles btnApprove.Click
        If Me.GridView2.Rows.Count = 0 Then
            Response.Write("<script>alert('Silahkan Klik SELECT No PR');</script>")
            Exit Sub
        End If
        Dim computer_name() As String
        computer_name = Split(System.Net.Dns.Resolve(Request.ServerVariables("remote_addr")).HostName, ".")
        'Dim hostname As String
        'hostname = System.Net.Dns.GetHostName

        Dim ht As New Hashtable

        ht = clsFunction.G_POProfile(Me.GridView1.SelectedValue)
        Dim POAmount As Integer = G_POAmount(Me.GridView1.SelectedValue)
        Dim lblStatus As Label
        Dim lbTransID As Label
        lblStatus = CType(Me.GridView1.SelectedRow.FindControl("lblStatus"), Label)
        lbTransID = CType(Me.GridView1.SelectedRow.FindControl("lblTransID"), Label)

        Dim strhasil As String = ""

        If lblStatus.Text = "Waiting for NSO Approval" Then
            'minta approval kedua
            If POAmount <= 5000000 Then
                strhasil = clsFunction.UpdateStatusByTransID("PO", lbTransID.Text, 3, Session("UserName"), computer_name(0).ToUpper, "NS", lbTransID.Text)
                'clsFunction.CREATE_PO(Me.GridView1.SelectedValue)
                ApprovalKe1(ht)

            Else
                strhasil = clsFunction.UpdateStatusByTransID("PO", lbTransID.Text, 4, Session("UserName"), computer_name(0).ToUpper, "NS", lbTransID.Text)
                ReqApproval2(ht)
            End If
        ElseIf lblStatus.Text = "Waiting for GM Approval" Then
            'ApproveKe2()
            strhasil = clsFunction.UpdateStatusByTransID("PO", lbTransID.Text, 6, Session("UserName"), computer_name(0).ToUpper, "GM", lbTransID.Text)
            'clsFunction.CREATE_PO(Me.GridView1.SelectedValue)
            ReqApproval3(ht)
        ElseIf lblStatus.Text = "Waiting for CFO Approval" Then
            'ApproveKe2()
            strhasil = clsFunction.UpdateStatusByTransID("PO", lbTransID.Text, 8, Session("UserName"), computer_name(0).ToUpper, "CF", lbTransID.Text)
            'clsFunction.CREATE_PO(Me.GridView1.SelectedValue)
            ApprovalKe1(ht)
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
        Dim strSQL As String
        Session.Add("pono", Request.QueryString("n"))
        Session.Add("approvalKe", Request.QueryString("apr"))
        Session.Add("alamat", "poapproval.aspx?n=" & Session("pono") & "&apr=" & Session("approvalKe"))

        Try
            strUserName = Session("UserName")

            If strUserName.Trim = "" Then
                Response.Redirect("Login.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("Login.aspx")
        End Try

        If Is1stApproval(Session("UserName")) = True Then
            strSQL = "select a.TransID, PONo, PRNo, WHAsal NamaSite, StartDate as TglTransaksi, KodeVendor, case status when 1 then 'Created' when 2 then 'Waiting for NSO Approval' when 4 then 'Waiting for GM Approval' when 6 then 'Waiting for CFO Approval' when 8 then 'Approved' when 9 then 'Cancel' end as Status, substring(PRAppName,5,len(PRAppName)-4) as Manager,substring(NSOAppName,5,len(NSOAppName)-4) as NSO  " & _
                       "From tbATKPOMain a inner Join tbATKUserConfig b on a.InputBy=b.UserID " & _
                      "Where (case when charindex('@',NSOApproval) > 0 then lower(left(NSOApproval,charindex('@',NSOApproval)-1)) end =@UserName) " & _
                    "And status=2 order by a.TransID desc"
            Me.SqlDataSource1.SelectCommand = strSQL
            Me.SqlDataSource1.SelectParameters.Clear()
            Me.SqlDataSource1.SelectParameters.Add("UserName", strUserName)
            'Me.GridView1.DataSource = Me.SqlDataSource1
            Me.GridView1.DataBind()

        ElseIf Is2ndApproval(Session("UserName")) = True Then
            strSQL = "select a.TransID, PONo, PRNo, WHAsal NamaSite, StartDate as TglTransaksi, KodeVendor, case status when 1 then 'Created' when 2 then 'Waiting for NSO Approval' when 4 then 'Waiting for GM Approval' when 6 then 'Waiting for CFO Approval' when 8 then 'Approved' when 9 then 'Cancel' end as Status, substring(PRAppName,5,len(PRAppName)-4) as Manager,substring(NSOAppName,5,len(NSOAppName)-4) as NSO  " & _
                           "From tbATKPOMain a inner Join tbATKUserConfig b on a.InputBy=b.UserID " & _
                          "Where (case when charindex('@',GMApproval) > 0 then lower(left(GMApproval,charindex('@',GMApproval)-1)) end =@UserName) " & _
                        "And status = 4 order by a.TransID desc"
            Me.SqlDataSource1.SelectCommand = strSQL
            Me.SqlDataSource1.SelectParameters.Clear()
            Me.SqlDataSource1.SelectParameters.Add("UserName", strUserName)
            'Me.GridView1.DataSource = Me.SqlDataSource1
            Me.GridView1.DataBind()
        ElseIf Is3rdApproval(Session("UserName")) = True Then
            strSQL = "select a.TransID, PONo, PRNo, WHAsal NamaSite,StartDate as TglTransaksi, KodeVendor, case status when 1 then 'Created' when 2 then 'Waiting for NSO Approval' when 4 then 'Waiting for GM Approval' when 6 then 'Waiting for CFO Approval' when 8 then 'Approved' when 9 then 'Cancel' end as Status, substring(PRAppName,5,len(PRAppName)-4) as Manager,substring(NSOAppName,5,len(NSOAppName)-4) as NSO  " & _
                       "From tbATKPOMain a inner Join tbATKUserConfig b on a.InputBy=b.UserID " & _
                      "Where (case when charindex('@',CFOApproval) > 0 then lower(left(CFOApproval,charindex('@',CFOApproval)-1)) end =@UserName) " & _
                    "And status=6 order by a.TransID desc"
            Me.SqlDataSource1.SelectCommand = strSQL
            Me.SqlDataSource1.SelectParameters.Clear()
            Me.SqlDataSource1.SelectParameters.Add("UserName", strUserName)
            'Me.GridView1.DataSource = Me.SqlDataSource1
            Me.GridView1.DataBind()
        End If

        'Me.SqlDataSource1.DataBind()
        'Me.SqlDataSource2.DataBind()
        Me.Panel1.Visible = False
        Me.Label5.Text = Session("username")
    End Sub

    Private Sub ReqApproval2(ByVal ht As Hashtable)
        Dim ws As New WebReference.Service
        Dim dsTO As New DataSet
        Dim dsCC As New DataSet
        Dim dsBCC As New DataSet
        Dim hasil As String = ""
        Dim detail As String = ""
        Dim strHeader1 As String = ""

        strHeader1 = "<tr>" & _
                    "<th bgcolor=#00BFFF align=center>Description</th>" & _
                    "<th bgcolor=#00BFFF align=center>UOM</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>LastPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>EstTotPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>User</th>" & _
                    "<th bgcolor=#00BFFF align=center>Manager</th>" & _
                    "<th bgcolor=#00BFFF align=center>NSO</th>" & _
                    "<th bgcolor=#00BFFF align=center>Bill To Customer</th>" & _
                   "</tr>"
        Dim ds As New DataSet
        ds = clsFunction.G_PODetails(GridView1.SelectedValue)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            detail = detail & "<tr>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("Keterangan")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("UOM")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("Qty")
            detail = detail & "</td>"

            detail = detail & "<td align=right>" & Format(ds.Tables(0).Rows(i)("LastPrice"), "###,##0")
            detail = detail & "</td>"

            detail = detail & "<td align=right>" & Format(ds.Tables(0).Rows(i)("EstTotPrice"), "###,##0")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("EndUserName")
            detail = detail & "</td>"

            detail = detail & "<td>" & Mid(ht("PRAppName").ToString, 5)
            detail = detail & "</td>"

            detail = detail & "<td>" & Mid(ht("NSOAppName").ToString, 5)
            detail = detail & "</td>"

            If ds.Tables(0).Rows(i)("PurchasedbyGA") = "1" Then
                detail = detail & "<td>" & "YES"
                detail = detail & "</td>"
            Else
                detail = detail & "<td>" & "NO"
                detail = detail & "</td>"
            End If

            detail = detail & "</tr>"
        Next

        Dim POAmount As Decimal
        POAmount = clsFunction.G_POAmount(Me.GridView1.SelectedValue)

        detail = detail & "<tr><td bgcolor=#00BFFF align=center colspan=4>Total</td>"
        detail = detail & "<td bgcolor=#00BFFF align=right>" & Format(POAmount, "###,##0") & "</td>"
        detail = detail & "<td bgcolor=#00BFFF align=right colspan=3></td></tr>"

        ds = New DataSet
        ds = clsFunction.G_PRMain(Me.GridView1.SelectedValue)
        'TransID, , , , , StorerKey, , TglTransaksi, , ApproveBy, ApproveDate, FollowUpBy, FollowUpDate, Status, InputDate, InputBy, hostname, ApproveBy1, ApproveDate1
        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear Pak " & ht("GMAppName") & ",<br /><br />Mohon Approvalnya untuk PO No : " & Me.GridView1.SelectedValue & " dengan detail sebagai berikut : <br /><br /></p>"

        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br />"

        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Silahkan klik <a href='http://10.130.37.5/prpo/poapproval.aspx?n=" & Me.GridView1.SelectedValue & "&apr=2'>disini</a> untuk proses approval.<br /></p>"

        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Requested By : " & Session("UserName") & "</b><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"


        dsTO = Me.G_EmailAddressTo(ht, "POApproval2")
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC("PR")

        'clsFunction.UpdateStatus(Me.txtTransID.Text, 9)

        If SendEmail("[Purchase Order] 2nd Approval Request for PO No. " & Me.GridView1.SelectedValue, hasil, "", dsTO, dsCC, dsBCC) = False Then
            lblErr.Text = "'2nd PO Approval Request' Sukses Tapi Email Tidak Terkirim"
        Else

            lblErr.Text = "Send ''2nd PO Approval Request'' Sukses"

        End If

    End Sub

    Private Sub ReqApproval3(ByVal ht As Hashtable)
        Dim ws As New WebReference.Service
        Dim dsTO As New DataSet
        Dim dsCC As New DataSet
        Dim dsBCC As New DataSet
        Dim hasil As String = ""
        Dim detail As String = ""
        Dim strHeader1 As String = ""

        strHeader1 = "<tr>" & _
                    "<th bgcolor=#00BFFF align=center>Description</th>" & _
                    "<th bgcolor=#00BFFF align=center>UOM</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>LastPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>EstTotPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>User</th>" & _
                    "<th bgcolor=#00BFFF align=center>Manager</th>" & _
                    "<th bgcolor=#00BFFF align=center>NSO</th>" & _
                    "<th bgcolor=#00BFFF align=center>Bill To Customer</th>" & _
                   "</tr>"
        Dim ds As New DataSet
        ds = clsFunction.G_PODetails(GridView1.SelectedValue)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            detail = detail & "<tr>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("Keterangan")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("UOM")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("Qty")
            detail = detail & "</td>"

            detail = detail & "<td align=right>" & Format(ds.Tables(0).Rows(i)("LastPrice"), "###,##0")
            detail = detail & "</td>"

            detail = detail & "<td align=right>" & Format(ds.Tables(0).Rows(i)("EstTotPrice"), "###,##0")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("EndUserName")
            detail = detail & "</td>"

            detail = detail & "<td>" & Mid(ht("PRAppName").ToString, 5)
            detail = detail & "</td>"

            detail = detail & "<td>" & Mid(ht("NSOAppName").ToString, 5)
            detail = detail & "</td>"

            If ds.Tables(0).Rows(i)("PurchasedbyGA") = "1" Then
                detail = detail & "<td>" & "YES"
                detail = detail & "</td>"
            Else
                detail = detail & "<td>" & "NO"
                detail = detail & "</td>"
            End If

            detail = detail & "</tr>"
        Next
        Dim POAmount As Decimal
        POAmount = clsFunction.G_POAmount(Me.GridView1.SelectedValue)

        detail = detail & "<tr><td bgcolor=#00BFFF align=center colspan=4>Total</td>"
        detail = detail & "<td bgcolor=#00BFFF align=right>" & Format(POAmount, "###,##0") & "</td>"
        detail = detail & "<td bgcolor=#00BFFF align=right colspan=3></td></tr>"

        ds = New DataSet
        ds = clsFunction.G_PRMain(Me.GridView1.SelectedValue)
        'TransID, , , , , StorerKey, , TglTransaksi, , ApproveBy, ApproveDate, FollowUpBy, FollowUpDate, Status, InputDate, InputBy, hostname, ApproveBy1, ApproveDate1
        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear Bu " & ht("CFOAppName") & ",<br /><br />Mohon Approvalnya untuk PO No : " & Me.GridView1.SelectedValue & " dengan detail sebagai berikut : <br /><br /></p>"

        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br />"

        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Silahkan klik <a href='http://10.130.37.5/prpo/poapproval.aspx?n=" & Me.GridView1.SelectedValue & "&apr=3'>disini</a> untuk proses approval.<br /></p>"

        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Requested By : " & Session("UserName") & "</b><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"


        dsTO = Me.G_EmailAddressTo(ht, "POApproval3")
        dsCC = Me.G_EmailAddressCC_PO(ht)
        dsBCC = Me.G_EmailAddressBCC("PR")

        'clsFunction.UpdateStatus(Me.txtTransID.Text, 9)
        'MsgBox(SendEmail("[Purchase Request] PO No. " & Me.GridView1.SelectedValue & " has been approved", hasil, "", dsTO, dsCC, dsBCC))
        If SendEmail("[Purchase Order] 3rd Approval Request for PO No. " & Me.GridView1.SelectedValue, hasil, "", dsTO, dsCC, dsBCC) = False Then
            lblErr.Text = "'3rd PO Approval Request' Sukses Tapi Email Tidak Terkirim"
        Else

            lblErr.Text = "Send ''3rd PO Approval Request'' Sukses"

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
                    "<th bgcolor=#00BFFF align=center>Description</th>" & _
                    "<th bgcolor=#00BFFF align=center>UOM</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>LastPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>EstTotPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>Bill To Customer</th>" & _
                   "</tr>"
        Dim ds As New DataSet
        ds = clsFunction.G_PODetails(GridView1.SelectedValue)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            detail = detail & "<tr>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("Keterangan")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("UOM")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("Qty")
            detail = detail & "</td>"

            detail = detail & "<td>" & Format(ds.Tables(0).Rows(i)("LastPrice"), "###,##0")
            detail = detail & "</td>"

            detail = detail & "<td>" & Format(ds.Tables(0).Rows(i)("EstTotPrice"), "###,##0")
            detail = detail & "</td>"

            If ds.Tables(0).Rows(i)("PurchasedbyGA") = "1" Then
                detail = detail & "<td>" & "YES"
                detail = detail & "</td>"
            Else
                detail = detail & "<td>" & "NO"
                detail = detail & "</td>"
            End If

            detail = detail & "</tr>"
        Next

        ds = New DataSet
        ds = clsFunction.G_PRMain(Me.GridView1.SelectedValue)

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear Team,<br /><br />Saya sudah approve No PO : " & Me.GridView1.SelectedValue & " dengan detail sebagai berikut : <br />"

        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br /><br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Approved By : " & Session("UserName") & "</b><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"


        dsTO = Me.G_EmailAddressTo(ht, "POApproved")
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC("PR")

        'UpdateStatus(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 3)
        'MsgBox(SendEmail("[Purchase Request] PO No. " & Me.GridView1.SelectedValue & " has been approved", hasil, "", dsTO, dsCC, dsBCC))
        If SendEmail("[Purchase Request] PO No. " & Me.GridView1.SelectedValue & " has been approved", hasil, "", dsTO, dsCC, dsBCC) = False Then
            lblErr.Text = "PO Approved tapi Email tidak terkirim"
        Else
            lblErr.Text = "Send ''PO Approved'' Sukses"
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
                    "<th bgcolor=#00BFFF align=center>Description</th>" & _
                    "<th bgcolor=#00BFFF align=center>UOM</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>LastPrice</th>" & _
                    "<th bgcolor=#00BFFF align=center>EstTotPrice</th>" & _
                   "</tr>"
        Dim ds As New DataSet
        ds = clsFunction.G_PRDetails(GridView1.SelectedValue)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            detail = detail & "<tr>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("Keterangan")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("OUM")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("Qty")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("LastPrice")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds.Tables(0).Rows(i)("EstTotPrice")
            detail = detail & "</td>"

            detail = detail & "</tr>"
        Next
        ds = New DataSet
        ds = clsFunction.G_PRMain(Me.GridView1.SelectedValue)
        'TransID, , , , , StorerKey, , TglTransaksi, , ApproveBy, ApproveDate, FollowUpBy, FollowUpDate, Status, InputDate, InputBy, hostname, ApproveBy1, ApproveDate1
        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear Team,<br /><br />Mohon maaf, saya tidak approve No PR : " & GridView1.SelectedValue & " dengan detail sebagai berikut : <br />"
        hasil = hasil & "<table border='0' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>"
        hasil = hasil & "<tr><td align='right'>No PR         : </td><td>" & ds.Tables(0).Rows(0)("PRNo") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>NamaSite      : </td><td>" & ds.Tables(0).Rows(0)("NamaSite") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Diminta Oleh  : </td><td>" & ds.Tables(0).Rows(0)("Name") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Ditujukan     : </td><td>" & IIf(ds.Tables(0).Rows(0)("Designation") = "1", "Request(Customer)", IIf(ds.Tables(0).Rows(0)("Kategori") = "2", "Request Sales / CS Agility", "Request(Internal)")) & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Lokasi User   : </td><td>" & ds.Tables(0).Rows(0)("EndUserLocation") & "</td></tr>"
        hasil = hasil & "<tr><td align='right'>Date Required : </td><td>" & Format(ds.Tables(0).Rows(0)("DateRequired"), "dd MM yyyy") & "</td></tr></table></p>"

        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Dengan alasan : " & Me.txtReason.Text & "<br /><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Not Approved By : " & Session("UserName") & "</b><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"


        dsTO = Me.G_EmailAddressTo(ht, "PRNotApproved")
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC("PR")

        'clsFunction.UpdateStatus(Me.txtTransID.Text, 9)

        If SendEmail("[Purchase Request] PR No. " & Me.GridView1.SelectedValue & " is not approved,", hasil, "", dsTO, dsCC, dsBCC) = False Then
            lblErr.Text = "'PR Not Approve' Sukses Tapi Email Tidak Terkirim"
        Else

            lblErr.Text = "Send ''PR Not Approve'' Sukses"

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

                If RequestType = "POApproval" Then
                    strSQL = "Select '" & ht("NSOApproval") & "' as EmailAddress"
                ElseIf RequestType = "POApproval2" Then
                    strSQL = "Select '" & ht("GMApproval") & "' as EmailAddress"
                ElseIf RequestType = "POApproval3" Then
                    strSQL = "Select '" & ht("CFOApproval") & "' as EmailAddress"
                ElseIf RequestType = "POApproved" Then
                    strSQL = "Select '" & ht("AdminGA") & "' as EmailAddress"
                ElseIf RequestType = "PONotApproved" Then
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

                If Microsoft.VisualBasic.Right(ht("CopyPR"), 1) <> ";" Then
                    emails = ht("CopyPR") & ";"
                Else
                    emails = ht("CopyPR")
                End If
                While InStr(emails, ";") > 0
                    strCC = strCC & " union select '" & Microsoft.VisualBasic.Left(emails, InStr(emails, ";") - 1) & "' as EmailAddress "
                    emails = Mid(emails, InStr(emails, ";") + 1)
                End While

                strSQL = "Select '" & ht("AdminGA") & "' as EmailAddress " & strCC

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
    Private Function G_EmailAddressCC_PO(ByVal ht As Hashtable) As DataSet
        Dim ds As DataSet = New DataSet
        Dim emails As String = ""
        Dim strCC As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strConnLocal
                cmd.Connection = cn
                cn.Open()

                If Microsoft.VisualBasic.Right(ht("CopyPR"), 1) <> ";" Then
                    emails = ht("CopyPR") & ";"
                Else
                    emails = ht("CopyPR")
                End If
                While InStr(emails, ";") > 0
                    strCC = strCC & " union select '" & Microsoft.VisualBasic.Left(emails, InStr(emails, ";") - 1) & "' as EmailAddress "
                    emails = Mid(emails, InStr(emails, ";") + 1)
                End While

                strSQL = "Select '" & ht("AdminPO") & "' as EmailAddress " & strCC

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
        'Dim ws As New WebReference.WebService
        Dim hasil As Boolean = True

        Try
            ws.Timeout = 30000
            ws.SendEmailNew(strSubject, strMsg, strAttach, "noreply@agility.com", dsTo, dsCC, dsBCC)
            'sr.SendErrorEmail(strSubject, strMsg, dsTo)

            hasil = True
        Catch ex As Exception
            hasil = False
        End Try

        Return hasil

    End Function

    Protected Sub btnNotApprove_Click(sender As Object, e As System.EventArgs) Handles btnNotApprove.Click
        If Me.GridView2.Rows.Count = 0 Then
            Response.Write("<script>alert('Silahkan Klik SELECT No PR');</script>")
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
        strHasil = clsFunction.UpdateStatusByTransID("PO", lbTransID.Text, 9, Session("UserName"), computer_name(0).ToUpper, "NS", lbTransID.Text)
        If strHasil <> "" Then
            lblErr.Text = strHasil
        End If

        TampilkanData()
    End Sub

    Private Function Is3rdApproval(ByVal strUserID As String) As Boolean
        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strConnLocal

                cmd.Connection = cn
                cn.Open()
                strSQL = "Select PRApproval1 from tbATKUserConfig where case when charindex('@',CFOApproval) > 0 then lower(left(CFOApproval,charindex('@',CFOApproval)-1)) end='" & strUserID & "'"
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

    Private Function Is2ndApproval(ByVal strUserID As String) As Boolean
        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strConnLocal

                cmd.Connection = cn
                cn.Open()
                strSQL = "Select PRApproval1 from tbATKUserConfig where case when charindex('@',GMApproval) > 0 then lower(left(GMApproval,charindex('@',GMApproval)-1)) end='" & strUserID & "'"
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

    Private Function Is1stApproval(ByVal strUserID As String) As Boolean
        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strConnLocal

                cmd.Connection = cn
                cn.Open()
                strSQL = "Select NSOApproval from tbATKUserConfig where case when charindex('@',NSOApproval) > 0 then lower(left(NSOApproval,charindex('@',NSOApproval)-1)) end='" & strUserID & "'"
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
