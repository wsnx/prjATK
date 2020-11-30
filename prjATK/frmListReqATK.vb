Public Class frmListReqATK

    Dim dv As New DataView

    Private Sub frmListReqATK_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        IsiNamaSite(Me.cbSite)
        Me.cbSite.SelectedValue = G_KodeWH(htUser("site"))

        ShowDataMaster()
        SetButton()
        Me.rbWait_CheckedChanged(Nothing, Nothing)

        If strUserType.ToLower = "manager" Or strUserType.ToLower = "deputy manager" Then
            Me.cbSite.Enabled = True
        Else
            Me.cbSite.Enabled = False
        End If
    End Sub

    Private Sub SetButton()
        If strUserType.ToLower = "adminatk" Then
            'btnApprove.Enabled = False
            'btnFollowUp.Enabled = True
            'Me.btnNotApprove.Enabled = False

            mnuApprove.Enabled = False
            mnuFollowUp.Enabled = True
            mnuNotApprove.Enabled = False
            mnuRevisi.Enabled = False
        ElseIf strUserType.ToLower = "manager" Then
            'btnApprove.Enabled = True
            'btnFollowUp.Enabled = False
            'Me.btnNotApprove.Enabled = True
            If Mid(htUser("reqapproval"), 1, InStr(htUser("reqapproval"), "@") - 1).ToLower = strUserName.ToLower Then
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
            
        Else
            'btnApprove.Enabled = False
            'btnFollowUp.Enabled = False
            'Me.btnNotApprove.Enabled = False

            mnuApprove.Enabled = False
            mnuFollowUp.Enabled = False
            mnuNotApprove.Enabled = False
            mnuRevisi.Enabled = False
        End If
    End Sub

    Private Sub ShowDataMaster()
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Select a.TransID,a.ReqNo,a.NamaSite,a.StorerKey,a.TglTransaksi,case a.Status when 1 then 'Created' when 2 then 'Waiting for Approval' when 3 then 'Approved' when 4 then 'Close' when 5 then 'Revisi' when 9 then 'Ditolak' end as Status,a.InputBy,left(reqapproval,charindex('@',reqapproval)-1) ApprovalBy from tbATKReqMain a inner join tbATKUserConfig b on a.InputBy=b.UserID where a.NamaSite=@NamaSite and charindex('@',reqapproval) > 1 order by ReqNo"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", Me.cbSite.Text.Trim))

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    Dim ds As New DataSet
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


    Private Sub ShowDataDetails(ByVal baris As Integer)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Select a.TransID,a.ReqNo,a.NamaKaryawan, a.KodeBarang, b.NamaBarang, a.UOM, a.Qty, a.Keterangan from tbATKReqDetails a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where a.ReqNo=@ReqNo order by a.TransID desc"
                cmd.Parameters.Clear()

                cmd.Parameters.Add(New SqlClient.SqlParameter("ReqNo", Me.DataGridView1.Item("ReqNo", baris).Value))

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
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Select a.TransID,a.ReqNo,a.NamaKaryawan, a.KodeBarang, b.NamaBarang, a.UOM, a.Qty, a.Keterangan from tbATKReqDetails a inner join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where 1 > 2 order by a.TransID desc"
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

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbClose.CheckedChanged
        dv.RowFilter = "status='Close'"
        ShowDataDetailsBlank()
        SetButton()
        'Me.btnFollowUp.Enabled = False
        'Me.btnApprove.Enabled = False
        'Me.DataGridView1.DataSource = dv
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbCreated.CheckedChanged
        dv.RowFilter = "status='Created'"
        ShowDataDetailsBlank()
        SetButton()
        'btnApprove.Enabled = False
        'Me.btnFollowUp.Enabled = False
        'Me.DataGridView1.DataSource = dv
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ShowDataDetails(e.RowIndex)
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub rbWait_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbWait.CheckedChanged
        dv.RowFilter = "status='Waiting for Approval'"
        ShowDataDetailsBlank()
        SetButton()
        'Me.btnFollowUp.Enabled = False
        'Me.DataGridView1.DataSource = dv
    End Sub

    Private Sub rbApproved_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbApproved.CheckedChanged
        dv.RowFilter = "status='Approved'"
        ShowDataDetailsBlank()
        SetButton()
        'Me.btnApprove.Enabled = False
        'Me.DataGridView1.DataSource = dv
    End Sub

    Private Sub btnApprove_Click(sender As System.Object, e As System.EventArgs) Handles btnApprove.Click
        If Me.DataGridView1.Item("ApprovalBy", Me.DataGridView1.CurrentRow.Index).Value.ToString.ToLower <> strUserName.ToLower Then
            MsgBox("Anda tidak berhak mem-follow-up request ini")
            Exit Sub
        End If

        If Me.DataGridView2.RowCount = 0 Then
            MsgBox("Silahkan di-Click dulu datanya sampai data detailnya terlihat")
            Exit Sub
        Else
            If Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value.ToString.ToLower <> Me.DataGridView2.Item("ReqNoDet", Me.DataGridView2.CurrentRow.Index).Value.ToString.ToLower Then
                MsgBox("Silahkan di-Click dulu datanya sampai data detailnya terlihat" & vbCrLf & "Pastikan No Permintaan di Header dan Detailnya sama")
                Exit Sub
            End If
        End If

        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Approved" Then
            MsgBox("Permintaan ATK sudah di-approve")
            Exit Sub
        End If
        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Revisi" Then
            MsgBox("Permintaan ATK perlu direvisi")
            Exit Sub
        End If
        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Closed" Then
            MsgBox("Permintaan ATK sudah di-Close")
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
                    "<th bgcolor=#00BFFF align=center>Nama Karyawan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Barang</th>" & _
                    "<th bgcolor=#00BFFF align=center>Satuan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>Keterangan</th>" & _
                   "</tr>"

        For i As Integer = 0 To Me.DataGridView2.RowCount - 1
            detail = detail & "<tr>"
            For j As Integer = 0 To Me.DataGridView2.ColumnCount - 1
                If Me.DataGridView2.Columns(j).Name = "NamaKaryawan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
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
                If Me.DataGridView2.Columns(j).Name = "Keterangan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
            Next

            detail = detail & "</tr>"
        Next

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear Admin,<br /><br />Silahkan di-follow up untuk Request ATK No : " & Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value & " dengan detail sebagai berikut : <br /><br /></p>"
        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br /><br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"

        Dim ht As New Hashtable
        ht = G_ReqProfile(Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value)

        dsTO = Me.G_EmailAddressTo(3, ht)
        dsCC = Me.G_EmailAddressCC(3, ht)
        dsBCC = Me.G_EmailAddressBCC()
        If SendEmail("[ATK] Approval Request Approved", hasil, "", dsTO, dsCC, dsBCC) = False Then
            MsgBox("Kesalahan bukan pada komputer anda")
        Else
            UpdateStatus(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 3)
            MsgBox("Send ''ATK Approval'' Sukses")
            Me.ShowDataMaster()
            Me.ShowDataDetailsBlank()
        End If


    End Sub

    Private Sub UpdateStatus(ByVal TransID As Integer, ByVal intStatus As Integer)
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal


                cmd.Connection = cn
                cn.Open()

                strSQL = "Update tbATKReqMain set Status=@Status Where TransID=@TransID"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", TransID))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Status", intStatus))
                Try

                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub


    Private Function G_EmailAddressTo(ByVal strStatus As Integer, ByVal ht As Hashtable) As DataSet
        Dim ds As DataSet = New DataSet

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal

                cmd.Connection = cn
                cn.Open()

                Select Case strStatus
                    Case 3 'Approve
                        strSQL = "Select '" & ht("adminatk") & "' as EmailAddress"
                    Case 4 'Followup
                        strSQL = "Select '" & ht("adminatk") & "' as EmailAddress"
                    Case 5 'Revisi
                        strSQL = "Select '" & ht("emailaddress") & "' as EmailAddress"
                    Case 9 'Not approve
                        strSQL = "Select '" & ht("emailaddress") & "' as EmailAddress"
                End Select

                'strSQL = "Select '" & GetSetting("ATKCL", "Config", "ReqApproval") & "' as EmailAddress"
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

    Private Function G_EmailAddressCC(ByVal intStatus As Integer, ByVal ht As Hashtable) As DataSet
        Dim ds As DataSet = New DataSet
        Dim emails As String = ""
        Dim strCC As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal
                cmd.Connection = cn
                cn.Open()

                If Microsoft.VisualBasic.Right(ht("copyreq"), 1) <> ";" Then
                    emails = ht("copyreq") & ";"
                Else
                    emails = ht("copyreq")
                End If
                While InStr(emails, ";") > 0
                    strCC = strCC & "union select '" & Microsoft.VisualBasic.Left(emails, InStr(emails, ";") - 1) & "' as EmailAddress "
                    emails = Mid(emails, InStr(emails, ";") + 1)
                End While

                Select Case intStatus
                    Case 3 'Approve
                        strSQL = "Select '" & ht("emailaddress") & "' as EmailAddress " & strCC
                    Case 4 'Followup
                        strSQL = "Select '" & ht("emailaddress") & "' as EmailAddress " & strCC
                    Case 5 'Revisi
                        strSQL = "Select '" & ht("adminatk") & "' as EmailAddress " & strCC
                    Case 9 'Not approve
                        strSQL = "Select '" & ht("adminatk") & "' as EmailAddress " & strCC
                End Select

                'strSQL = "Select '" & GetSetting("ATKCL", "Config", "ReqApproval") & "' as EmailAddress"
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
        Return ds
    End Function

    Private Function G_EmailAddressBCC() As DataSet
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal

                cmd.Connection = cn
                cn.Open()
                'strSQL = "Select EmailAddress from tbEmailReceiver where ReportType='" & strReportType & "' and isbcc=1"
                strSQL = "Select 'rfaisal@agility.com' as EmailAddress"
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

        Try
            ws.Timeout = 6000
            ws.SendEmailNew(strSubject, strMsg, strAttach, "atk_noreply@agility.com", dsTo, dsCC, dsBCC)
            'sr.SendErrorEmail(strSubject, strMsg, dsTo)

            hasil = True
        Catch ex As Exception
            hasil = False
        End Try

        Return hasil

    End Function

    Private Sub btnFollowUp_Click(sender As System.Object, e As System.EventArgs) Handles btnFollowUp.Click

        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value <> "Approved" Then
            If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Closed" Then
                MsgBox("Permintaan ATK sudah di-Close")
                Exit Sub
            Else
                MsgBox("Permintaan ATK belum di-approve")
                Exit Sub
            End If
        End If
        Dim ws As New WebReference.WebService
        Dim dsTO As New DataSet
        Dim dsCC As New DataSet
        Dim dsBCC As New DataSet
        Dim hasil As String = ""
        Dim detail As String = ""
        Dim strHeader1 As String = ""
        strHeader1 = "<tr>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Karyawan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Barang</th>" & _
                    "<th bgcolor=#00BFFF align=center>Satuan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>Keterangan</th>" & _
                   "</tr>"

        For i As Integer = 0 To Me.DataGridView2.RowCount - 1
            detail = detail & "<tr>"
            For j As Integer = 0 To Me.DataGridView2.ColumnCount - 1
                If Me.DataGridView2.Columns(j).Name = "NamaKaryawan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
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
                If Me.DataGridView2.Columns(j).Name = "Keterangan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
            Next

            detail = detail & "</tr>"
        Next

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear Admin ATK,<br /><br />Request ATK No : " & Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value & " dengan detail sebagai berikut : <br /><br /></p>"
        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Silahkan diambil pada hari yang sudah dijadwalkan.<br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"

        Dim ht As New Hashtable
        ht = G_ReqProfile(Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value)

        dsTO = Me.G_EmailAddressTo(4, ht)
        dsCC = Me.G_EmailAddressCC(4, ht)
        dsBCC = Me.G_EmailAddressBCC()
        If SendEmail("[ATK] ATK Sedang Disiapkan", hasil, "", dsTO, dsCC, dsBCC) = False Then
            MsgBox("Kesalahan bukan pada komputer anda")
        Else
            'UpdateStatus(Me.DataGridView1.Item("TransID", Me.DataGridView1.CurrentRow.Index).Value, 3)
            If AddDetailToLedger() = True Then
                UpdateStatus(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 4)

                Me.ShowDataMaster()
                Me.ShowDataDetailsBlank()
                MsgBox("Send ''Persiapan ATK'' Sukses")
            End If
        End If
    End Sub

    Private Function AddDetailToLedger() As Boolean
        Dim hasil As Boolean = False
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strConnLocal


                cmd.Connection = cn
                cn.Open()

                strSQL = "INSERT INTO tbATKmain (NamaSite, TglTransaksi, NamaKaryawan, StorerKey, KodeBarang, UOM, JenisTrans, Qty, Keterangan,ReqNo) " & _
                    "Select a.NamaSite, a.TglTransaksi, b.NamaKaryawan, a.StorerKey, b.KodeBarang, b.UOM, 'W' JenisTrans, b.Qty, b.Keterangan,b.ReqNo " & _
                    "from tbATKReqMain a inner join tbATKReqDetails b on a.ReqNo = b.ReqNo Where a.TransID=" & Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value

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

    Private Sub DataGridView2_CellContentClick_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub btnNotApprove_Click(sender As System.Object, e As System.EventArgs) Handles btnNotApprove.Click
        If Me.DataGridView1.Item("ApprovalBy", Me.DataGridView1.CurrentRow.Index).Value.ToString.ToLower <> strUserName.ToLower Then
            MsgBox("Anda tidak berhak mem-follow-up request ini")
            Exit Sub
        End If

        If Me.DataGridView2.RowCount = 0 Then
            MsgBox("Silahkan di-Click dulu datanya sampai data detailnya terlihat")
            Exit Sub
        Else
            If Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value.ToString.ToLower <> Me.DataGridView2.Item("ReqNoDet", Me.DataGridView2.CurrentRow.Index).Value.ToString.ToLower Then
                MsgBox("Silahkan di-Click dulu datanya sampai data detailnya terlihat" & vbCrLf & "Pastikan No Permintaan di Header dan Detailnya sama")
                Exit Sub
            End If
        End If

        Dim strReason As String = ""
        strReason = InputBox("Alasan Ditolak : ", "Alasan Request Ditolak")

        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Approved" Then
            MsgBox("Permintaan ATK sudah di-approve")
            Exit Sub
        End If
        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Revisi" Then
            MsgBox("Permintaan ATK perlu direvisi")
            Exit Sub
        End If
        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Closed" Then
            MsgBox("Permintaan ATK sudah di-Close")
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
                    "<th bgcolor=#00BFFF align=center>Nama Karyawan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Barang</th>" & _
                    "<th bgcolor=#00BFFF align=center>Satuan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>Keterangan</th>" & _
                   "</tr>"

        For i As Integer = 0 To Me.DataGridView2.RowCount - 1
            detail = detail & "<tr>"
            For j As Integer = 0 To Me.DataGridView2.ColumnCount - 1
                If Me.DataGridView2.Columns(j).Name = "NamaKaryawan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
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
                If Me.DataGridView2.Columns(j).Name = "Keterangan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
            Next

            detail = detail & "</tr>"
        Next

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear PIC,<br /><br />Untuk Request ATK No : " & Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value & " dengan detail sebagai berikut : <br /><br /></p>"
        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Ditolak dengan alasan : " & strReason & ".<br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"

        Dim ht As Hashtable = G_ReqProfile(Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value)

        dsTO = Me.G_EmailAddressTo(9, ht)
        dsCC = Me.G_EmailAddressCC(9, ht)
        dsBCC = Me.G_EmailAddressBCC()
        If SendEmail("[ATK] Approval Request Ditolak", hasil, "", dsTO, dsCC, dsBCC) = False Then
            MsgBox("Kesalahan bukan pada komputer anda")
        Else
            UpdateStatus(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 9)
            MsgBox("Send ''ATK Approval'' Sukses")
            Me.ShowDataMaster()
            Me.ShowDataDetailsBlank()
        End If
    End Sub

    Private Sub mnuApprove_Click(sender As System.Object, e As System.EventArgs) Handles mnuApprove.Click
        btnApprove_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuNotApprove_Click(sender As System.Object, e As System.EventArgs) Handles mnuNotApprove.Click
        btnNotApprove_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuFollowUp_Click(sender As System.Object, e As System.EventArgs) Handles mnuFollowUp.Click
        btnFollowUp_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuRevisi_Click(sender As System.Object, e As System.EventArgs) Handles mnuRevisi.Click
        btnRevisi_Click(Nothing, Nothing)
    End Sub

    Private Sub btnRevisi_Click(sender As System.Object, e As System.EventArgs) Handles btnRevisi.Click
        If Me.DataGridView1.Item("ApprovalBy", Me.DataGridView1.CurrentRow.Index).Value.ToString.ToLower <> strUserName.ToLower Then
            MsgBox("Anda tidak berhak mem-follow-up request ini")
            Exit Sub
        End If

        If Me.DataGridView2.RowCount = 0 Then
            MsgBox("Silahkan di-Click dulu datanya sampai data detailnya terlihat")
            Exit Sub
        Else
            If Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value.ToString.ToLower <> Me.DataGridView2.Item("ReqNoDet", Me.DataGridView2.CurrentRow.Index).Value.ToString.ToLower Then
                MsgBox("Silahkan di-Click dulu datanya sampai data detailnya terlihat" & vbCrLf & "Pastikan No Permintaan di Header dan Detailnya sama")
                Exit Sub
            End If
        End If

        Dim strReason As String = ""
        strReason = InputBox("Yang harus direvisi : ", "Alasan Request Direvisi")

        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Approved" Then
            MsgBox("Permintaan ATK sudah di-approve")
            Exit Sub
        End If
        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Closed" Then
            MsgBox("Permintaan ATK sudah di-Close")
            Exit Sub
        End If
        If Me.DataGridView1.Item("Status", Me.DataGridView1.CurrentRow.Index).Value = "Ditolak" Then
            MsgBox("Permintaan ATK Ditolak")
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
                    "<th bgcolor=#00BFFF align=center>Nama Karyawan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Nama Barang</th>" & _
                    "<th bgcolor=#00BFFF align=center>Satuan</th>" & _
                    "<th bgcolor=#00BFFF align=center>Qty</th>" & _
                    "<th bgcolor=#00BFFF align=center>Keterangan</th>" & _
                   "</tr>"

        For i As Integer = 0 To Me.DataGridView2.RowCount - 1
            detail = detail & "<tr>"
            For j As Integer = 0 To Me.DataGridView2.ColumnCount - 1
                If Me.DataGridView2.Columns(j).Name = "NamaKaryawan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
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
                If Me.DataGridView2.Columns(j).Name = "Keterangan" Then
                    detail = detail & "<td>" & Me.DataGridView2.Item(j, i).Value
                    detail = detail & "</td>"
                End If
            Next

            detail = detail & "</tr>"
        Next

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear PIC,<br /><br />Request ATK No : " & Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value & " dengan detail sebagai berikut : <br /><br /></p>"
        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br />"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Perlu direvisi dengan catatan : " & strReason & "<br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"

        Dim ht As Hashtable = G_ReqProfile(Me.DataGridView1.Item("ReqNo", Me.DataGridView1.CurrentRow.Index).Value)

        dsTO = Me.G_EmailAddressTo(5, ht)
        dsCC = Me.G_EmailAddressCC(5, ht)
        dsBCC = Me.G_EmailAddressBCC()
        If SendEmail("[ATK] Approval Request Perlu Direvisi", hasil, "", dsTO, dsCC, dsBCC) = False Then
            MsgBox("Kesalahan bukan pada komputer anda")
        Else
            UpdateStatus(Me.DataGridView1.Item("MainTransID", Me.DataGridView1.CurrentRow.Index).Value, 5) '1=create 2. waiting for approval 3. approve 4.Follow up 5. Revisi 9. Close
            MsgBox("Send ''ATK Approval'' Sukses")
            Me.ShowDataMaster()
            Me.ShowDataDetailsBlank()
        End If
    End Sub

    Private Sub DataGridView1_MouseHover(sender As System.Object, e As System.EventArgs) Handles DataGridView1.MouseHover
        On Error Resume Next
        Me.Label1.Visible = True
        Application.DoEvents()
    End Sub

    Private Sub DataGridView1_MouseLeave(sender As Object, e As System.EventArgs) Handles DataGridView1.MouseLeave
        On Error Resume Next
        Me.Label1.Visible = False
        Application.DoEvents()
    End Sub

    'Private Sub DataGridView1_CellMouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
    'MsgBox("baris " & e.RowIndex.ToString & "Kolom ke " & e.ColumnIndex.ToString)

    '    Me.DataGridView1.Rows(e.RowIndex).Selected = True
    '    ShowDataDetails(e.RowIndex)
    'End Sub

    Private Sub frmListReqATK_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Me.DataGridView1.Item("ApprovalBy", Me.DataGridView1.CurrentRow.Index).Value = strUserName Then
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
        End If
    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub cbSite_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbSite.SelectedIndexChanged
        Me.ShowDataMaster()
    End Sub
End Class