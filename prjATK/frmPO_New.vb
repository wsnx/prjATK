Public Class frmPO_New



    Private Function G_ItemDetails(ByVal strSKU As String) As Hashtable
        Dim ht As New Hashtable

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
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

    Private Sub frmPO_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        btnLast_Click(Nothing, Nothing)
        Me.WindowState = FormWindowState.Maximized

        If Me.lblStatus.Text.ToLower = "created" Then
            Me.btnMintaApproval.Enabled = True
            Me.btnDOne.Enabled = False
        ElseIf Me.lblStatus.Text.ToLower = "approved by nso" Then
            Me.btnDOne.Enabled = True
        ElseIf Me.lblStatus.Text.ToLower = "approved by cfo" Then
            Me.btnDOne.Enabled = True
        ElseIf Me.lblStatus.Text.ToLower = "waiting cfo approval" Then
            Me.btnDOne.Enabled = True
        Else
            Me.btnDOne.Enabled = False
            Me.btnMintaApproval.Enabled = False
        End If
    End Sub
    Private Sub ShowMasterCompany()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand("select SupplierID,CompanyName from [dbo].[tbATKmstCompany] union Select ''SupplierID,''CompanyName order by CompanyName ", cn)
                cn.Open()
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Dim ds As New DataSet
                Try
                    da.Fill(ds, "hasil")
                    Me.cbCompany.DataSource = ds.Tables(0)
                    Me.cbCompany.DisplayMember = ds.Tables(0).Columns("CompanyName").ColumnName
                    Me.cbCompany.ValueMember = ds.Tables(0).Columns("SupplierID").ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            Dim ds As New DataSet
            ds = Company(Me.cbCompany.Text)
            Me.txtAddress1.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("Address1")), "", ds.Tables(0).Rows(0)("Address1"))
            Me.txtAddress2.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("Address2")), "", ds.Tables(0).Rows(0)("Address2"))
            Me.txtAddress3.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("Address3")), "", ds.Tables(0).Rows(0)("Address3"))
            Me.txtTlp.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("Phone")), "", ds.Tables(0).Rows(0)("Phone"))
            Me.TxtAttnTo.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("Email")), "", ds.Tables(0).Rows(0)("Email"))

        End If
    End Sub
    Private Function Company(ByVal strCompany As String) As DataSet
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                Try
                    cn.Open()
                    cmd.Connection = cn
                    cmd.CommandText =
                    "select isnull(Address1,'')Address1,isnull(Address2,'')Address2,isnull(Address3,'')Address3,isnull(Phone,'')Phone,isnull(Email,'')Email,isnull(PIC,'')PIC from tbATKmstCompany where CompanyName ='" & strCompany & "'"
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Dim ds As New DataSet
        ds = Company(Me.cbCompany.Text)
        If Me.cbCompany.SelectedIndex <> 0 Then
            Me.txtAddress1.Text = ds.Tables(0).Rows(0)("Address1")
            Me.txtAddress2.Text = ds.Tables(0).Rows(0)("Address2")
            Me.txtAddress3.Text = ds.Tables(0).Rows(0)("Address3")
            Me.txtTlp.Text = ds.Tables(0).Rows(0)("Phone")
            Me.TxtAttnTo.Text = ds.Tables(0).Rows(0)("Email")
        Else
            Me.txtAddress1.Text = ""
            Me.txtAddress2.Text = ""
            Me.txtAddress3.Text = ""
            Me.txtTlp.Text = ""
            Me.TxtAttnTo.Text = ""

        End If
    End Sub

    Private Sub BtnAddNew_Click(sender As System.Object, e As System.EventArgs)
        FrmGeneratePO.ShowDialog()
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        frmMain.AddressMasterToolStripMenuItem.PerformClick()
    End Sub

    Private Sub INSERTDATAMASTER()

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                        "Update tbATKPOMain set KodeVendor=@KodeVendor,VendorName=@VendorName,StartDate=@StartDate,EndDate=@EndDate,RequiredDate=@RequiredDate,TypePO=@TypePO,Notes=@Notes,editwho=@editwho,JobType=@JobType where PONo=@PONo "
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", Me.txtPONo.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeVendor", Me.cbCompany.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("VendorName", Me.cbCompany.Text))
                'add Jobtype --> Wisnu 27-11-2020
                cmd.Parameters.Add(New SqlClient.SqlParameter("JobType", Me.txt_JobType.Text))

                cmd.Parameters.Add(New SqlClient.SqlParameter("StartDate", Me.dtpStartDate.Value))

                If Me.cbTypePO.Text.ToLower = "investment" Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("EndDate", Me.dtpEndDate.Value))
                ElseIf Me.cbTypePO.Text.ToLower = "rental" Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("EndDate", Me.dtpEndDate.Value))
                Else
                    cmd.Parameters.Add(New SqlClient.SqlParameter("EndDate", Format(Now.Date, "yyyy/MM/dd")))
                End If
                'Required Date allow to edit --> by Wisnu 27/11/2020
                cmd.Parameters.Add(New SqlClient.SqlParameter("RequiredDate", Me.dtpRequired.Value))

                cmd.Parameters.Add(New SqlClient.SqlParameter("TypePO", Me.cbTypePO.Text))

                cmd.Parameters.Add(New SqlClient.SqlParameter("Notes", Me.txtNotes.Text))
                If strUserName = "dsari" Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("EditWho", "Dhita"))
                ElseIf strUserName = "zariska" Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("EditWho", "Zanuar"))
                Else
                    cmd.Parameters.Add(New SqlClient.SqlParameter("EditWho", strUserName))
                End If



                'End If
                Try
                    cmd.ExecuteNonQuery()

                    'Dim dr As SqlClient.SqlDataReader
                    'cmd.CommandText = "Select max(TransID) as TransID from tbATKPOMain"

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
    Private Sub INSERTDATADETAILS()
        'Dim ht As New Hashtable

        'ht = G_ItemDetails()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                For i As Integer = 0 To Me.dgv2.RowCount - 1


                    Try

                        cmd.CommandText =
                    "Update tbATKPODetails set KodeBarang=@KodeBarang,UOM=@UOM,Qty=@Qty,Keterangan=@Keterangan,LastPrice=@LastPrice,EstTotPrice=@EstTotPrice where TransID=@TransID"
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", dgv2.Item("TransID", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", dgv2.Item("KodeBarang", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", dgv2.Item("UOM", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("Qty", dgv2.Item("Qty", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("Keterangan", dgv2.Item("NamaBarang", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("LastPrice", dgv2.Item("HargaSatuan", i).Value))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("EstTotPrice", dgv2.Item("Jumlah", i).Value))
                        cmd.ExecuteNonQuery()
                        'End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Next
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
                    cmd.CommandText =
                    "Select isnull(a.TransID,'0')TransID,a.PONo,a.JobType,WHAsal,a.KodeVendor,CompanyName,isnull(Address1,'')Address1,isnull(Address2,'')Address2,isnull(Address3,'')Address3,case isnull(Status,0) when 0 then 'Created' when 2 then 'Waiting NSO Approval' " &
                    "when 3 then 'Approved by NSO' when 4 then 'Waiting GM Approval' when 5 then 'Approved by GM' when 6 then 'Waiting CFO Approval' when 7 then 'Follow up To Vendor' when 8 then 'Approved by CFO' when 9 then 'Cancelled' else '' end Status,InputBy, " &
                    "isnull(Notes,'')Notes,isnull(StartDate,getdate())StartDate,isnull(EndDate,getdate())EndDate,isnull(RequiredDate,DateRequired)DateRequired,isnull(TypePO,'')TypePO  from tbATkPOMain a " &
                    "inner join tbATKmstCompany b On a.KodeVendor = b.SupplierID and a.VendorName=b.CompanyName inner join (Select PRNo, DateRequired from tbATKPRMain) c On a.PRNo= c.PRNo where  a.TransID=@TransID "
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", TransID))


                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        Me.txtTransID.Text = dr!TransID
                        ' Add Jobtype --> Wisnu 27-11-2020
                        Me.txt_JobType.Text = dr!JobType
                        Me.txtPONo.Text = dr!PONo
                        Me.cbCompany.SelectedValue = dr!KodeVendor
                        Me.cbCompany.Text = dr!CompanyName
                        Me.txtAddress1.Text = dr!Address1
                        Me.txtAddress2.Text = dr!Address2
                        Me.txtAddress3.Text = dr!Address3
                        Me.lblStatus.Text = dr!Status
                        Me.cbTypePO.Text = dr!Notes
                        Me.dtpStartDate.Value = dr!StartDate
                        Me.dtpEndDate.Value = dr!EndDate
                        Me.dtpRequired.Value = dr!DateRequired
                        Me.cbTypePO.Text = dr!TypePO
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Rules()

    End Sub
    Private Sub Rules()
        If Me.lblStatus.Text.ToLower = "created" Then
            Me.btnMintaApproval.Enabled = True
            Me.btnPrint.Enabled = False
            Me.btnDOne.Enabled = False
        ElseIf Me.lblStatus.Text.ToLower = "approved by nso" Then
            Me.btnDOne.Enabled = True
            Me.btnPrint.Enabled = True
        ElseIf Me.lblStatus.Text.ToLower = "approved by cfo" Then
            Me.btnDOne.Enabled = True
            Me.btnPrint.Enabled = True
        ElseIf Me.lblStatus.Text.ToLower = "waiting cfo approval" Then
            Me.btnDOne.Enabled = True
            Me.btnPrint.Enabled = True
        ElseIf Me.lblStatus.Text.ToLower = "waiting nso approval" Then
            Me.btnDOne.Enabled = False
            Me.btnPrint.Enabled = True
        ElseIf Me.lblStatus.Text.ToLower = "waiting gm approval" Then
            Me.btnDOne.Enabled = False
            Me.btnPrint.Enabled = True
        ElseIf Me.lblStatus.Text.ToLower = "follow up to vendor" Then
            Me.btnDOne.Enabled = False
            Me.btnPrint.Enabled = True
        Else
            Me.btnPrint.Enabled = True
            Me.btnMintaApproval.Enabled = False
        End If
    End Sub


    Private Function G_FirstRec() As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select min(TransID) from tbATKPOMain "
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

    Private Function G_PrevRec(ByVal CurrRec As Integer) As Integer
        Dim hasil As Integer = -1
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select isnull(max(TransID),-1) from tbATKPOMain Where TransID < " & CurrRec & " "


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


    End Sub


    Private Function SendEmail(ByVal strSubject As String, ByVal strMsg As String, ByVal strAttach As String, ByVal dsTo As Data.DataSet, ByVal dsCC As Data.DataSet, ByVal dsBCC As Data.DataSet) As Boolean
        Dim ws As New WebReference.WebService
        Dim hasil As Boolean = True

        Try
            ws.Timeout = 30000
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
                cmd.CommandTimeout = 30000
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

                strSQL = "Select '" & strTO & "' as EmailAddress"

                'If RequestType = "PRApproval" Then
                '    strSQL = "Select '" & GetSetting("ATKCL", "Config", "PRApproval") & "' as EmailAddress"
                'ElseIf RequestType = "PRApproved" Then
                '    strSQL = "Select '" & GetSetting("ATKCL", "Config", "AdminATK") & "' as EmailAddress"
                'End If

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

                strSQL = "Select '" & ht("emailaddress") & "' as  EmailAddress " & strCC

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
    Private Sub BtnPrint_Click(sender As System.Object, e As System.EventArgs)
        Dim frm As New frmPrintPO
        frm.strPONo = Me.txtPONo.Text.Trim
        'frm.strNamaSite = Me.cbSite.SelectedValue
        frm.ShowDialog()
        frm.Dispose()
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
        ShowDataMaster(Me.txtTransID.Text)
        G_DataPODetail(Me.txtPONo.Text, Me.dgv2)

        Application.DoEvents()

    End Sub

    Private Sub Dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Dgv2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub frmPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowMasterCompany()
    End Sub

    Private Sub cbTypePO_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Me.cbTypePO.Text = "RENTAL" Then
            Me.dtpEndDate.Enabled = True
        Else
            Me.dtpEndDate.Enabled = False
        End If
    End Sub

    Private Sub cbTypePO_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbTypePO.SelectedIndexChanged
        If Me.cbTypePO.Text.ToLower = "capex" Then
            Me.dtpStartDate.Enabled = False
            Me.dtpEndDate.Enabled = False
            Me.txtMonth.Enabled = False
            Me.lbl1.Text = "Start Date :"
            Me.lbl2.Text = "End Date :"
        ElseIf Me.cbTypePO.Text.ToLower = "investment" Then
            Me.dtpEndDate.Enabled = False
            Me.dtpStartDate.Enabled = True
            Me.txtMonth.Enabled = True
            Me.lbl1.Text = "Start Date :"
            Me.lbl2.Text = "Depreciation (Month) :"
        ElseIf Me.cbTypePO.Text.ToLower = "rental" Then
            Me.dtpEndDate.Enabled = True
            Me.dtpStartDate.Enabled = True
            Me.txtMonth.Enabled = True
            Me.lbl1.Text = "Start Rental :"
            Me.lbl2.Text = "End Rental :"
        ElseIf Me.cbTypePO.Text.ToLower = "consumable" Then
            Me.dtpStartDate.Enabled = False
            Me.dtpEndDate.Enabled = False
            Me.txtMonth.Enabled = False
            Me.lbl1.Text = "Start Date :"
            Me.lbl2.Text = "End Date :"
        End If
    End Sub

    Private Sub txtMonth_TextChanged(sender As Object, e As EventArgs) Handles txtMonth.TextChanged
        Dim month As Int32 = Me.txtMonth.Text

        Me.dtpEndDate.Value = DateAdd(DateInterval.Month, month, Me.dtpStartDate.Value)
    End Sub

    Private Sub btnMintaApproval_Click(sender As Object, e As EventArgs) Handles btnMintaApproval.Click

        If Me.txtPONo.Text = "" Then
            MsgBox("Nomor PO masih kosong" & vbCrLf & "Pastikan data di-Save terlebih dahulu")
            Exit Sub
        ElseIf Me.cbTypePO.Text = "" Then
            MsgBox("Type PO masih kosong" & vbCrLf & "Pastikan data di-Save terlebih dahulu")
            Exit Sub
        ElseIf Format(dtpRequired.Value, "yyyy/MM/dd") < Format(Now.Date, "yyyy/MM/dd") Then
            MsgBox("PO telah expired" & vbCrLf & "Hubungi GA agar di-buatkan PR baru")
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
        strHeader1 = "<tr>" &
                    "<th bgcolor=#00BFFF align=center>Description</th>" &
                    "<th bgcolor=#00BFFF align=center>UOM</th>" &
                    "<th bgcolor=#00BFFF align=center>Qty</th>" &
                    "<th bgcolor=#00BFFF align=center>LastPrice</th>" &
                    "<th bgcolor=#00BFFF align=center>EstTotPrice</th>" &
                    "<th bgcolor=#00BFFF align=center>User</th>" &
                    "<th bgcolor=#00BFFF align=center>Approved By</th>" &
                    "<th bgcolor=#00BFFF align=center>Bill to Customer</th>" &
                         "</tr>"
        Dim ds As New DataSet
        Dim ds1 As New DataSet
        ds = ShowDataHarga_PO(Me.txtPONo.Text)
        ds1 = Show_Details_PO(Me.txtPONo.Text)


        'For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
        For i As Integer = 0 To Me.dgv2.Rows.Count - 1

            detail = detail & "<tr>"

            'detail = detail & "<td>" & ds1.Tables(0).Rows(i)("Storerkey")
            detail = detail & "<td>" & Me.dgv2.Item("NamaBarang", i).Value
            detail = detail & "</td>"

            'detail = detail & "<td>" & ds1.Tables(0).Rows(i)("UOM")
            detail = detail & "<td>" & Me.dgv2.Item("UOM", i).Value
            detail = detail & "</td>"

            'detail = detail & "<td>" & ds1.Tables(0).Rows(i)("Qty")
            detail = detail & "<td>" & Me.dgv2.Item("Qty", i).Value
            detail = detail & "</td>"

            'detail = detail & "<td>" & Format(ds1.Tables(0).Rows(i)("LastPrice"), "##,##0")
            detail = detail & "<td>" & Format(Me.dgv2.Item("HargaSatuan", i).Value, "##,##0")
            detail = detail & "</td>"

            'detail = detail & "<td>" & Format(ds1.Tables(0).Rows(i)("EstTotPrice"), "##,##0")
            detail = detail & "<td>" & Format(Me.dgv2.Item("Jumlah", i).Value, "##,##0")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds1.Tables(0).Rows(i)("Storerkey")
            detail = detail & "</td>"

            detail = detail & "<td>" & ds1.Tables(0).Rows(i)("AppName")
            detail = detail & "</td>"

            detail = detail & "<td>" & IIf(Me.dgv2.Item("PurchasedbyGA", i).Value = 1, "YES", "NO")
            detail = detail & "</td>"

            detail = detail & "</tr>"

        Next
        'strFooter = "<tr>" &
        '                  "<th bgcolor=#CCCCCC align=center>Total Price : Rp. " & IIf(IsDBNull(Format(ds.Tables(0).Rows(0)("EstTotPrice"), "##,##0")), "0", Format(ds.Tables(0).Rows(0)("EstTotPrice"), "##,##0")) & "</th></tr>"
        'summary = summary & "<td>" &
        'summary = summary & "</td>"
        detail = detail & "<tr><td bgcolor=#00BFFF align=center colspan=4>Total</td>"
        detail = detail & "<td bgcolor=#00BFFF align=right>" & IIf(IsDBNull(Format(ds.Tables(0).Rows(0)("EstTotPrice"), "##,##0")), "0", Format(ds.Tables(0).Rows(0)("EstTotPrice"), "##,##0")) & "</td>"
        detail = detail & "<td bgcolor=#00BFFF align=right colspan=3></td></tr>"

        Dim ht As New Hashtable
        ht = G_PRProfile_PO(Me.txtPONo.Text)

        hasil = "<p style='font-size: 8pt; font-family: Verdana'>"
        hasil = hasil & "Dear " & ht("nsotittle") & " " & ht("nsoappname") & ",<br /><br />Mohon Approvalnya untuk PO No : " & Me.txtPONo.Text & " dengan detail sebagai berikut : <br /><br /></p>"
        hasil = hasil & "<table border='0' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>"


        hasil = hasil & "<table border='1' cellspacing='0' cellpadding='1' style='font-family: Verdana; font-size: 8pt;'>" & strHeader1 & detail
        hasil = hasil & "</table> <br />"

        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'>Silahkan klik <a href='http://10.130.12.190/eproc/poapproval.aspx?n=" & Me.txtPONo.Text & "&apr=1'>disini</a> untuk proses approval.<br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Requested By : " & strUserName & "</b><br /></p>"
        hasil = hasil & "<p style='font-size: 8pt; font-family: Verdana'><b>Generated By System</b><br /></p>"


        dsTO = Me.G_EmailAddressTo(ht("nsoapproval"))
        dsCC = Me.G_EmailAddressCC(ht)
        dsBCC = Me.G_EmailAddressBCC("atk")

        UpdateStatus(Me.txtTransID.Text, 2)
        Me.lblStatus.Text = "Waiting NSO Approval"

        If cekStatus(Me.txtPONo.Text) = False Then
            MsgBox("Data koneksi terputus" & vbNewLine & "Silakan di-coba kembali")
            Exit Sub
        Else
            If SendEmail("[Purchase Order] Approval Request for PO No." & Me.txtPONo.Text, hasil, "", dsTO, dsCC, dsBCC) = False Then
                MsgBox("[Purchase Order] Approval Request is succesfully but unsend email")
            Else
                MsgBox("Send '[Purchase Order] Approval Request' Successfully")
            End If
        End If

    End Sub



    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click

        Dim intRec As Integer
        intRec = G_LastRec()
        ShowDataMaster(intRec)

        'If cekData(Me.txtPONo.Text) = False Then
        '    G_DataDetail(Me.txtPONo.Text.Trim, Me.dgv2)
        'Else
        G_DataPODetail(Me.txtPONo.Text, Me.dgv2)
        'End If

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        Dim intRec As Integer
        If Me.txtTransID.Text.Trim = "" Then
            btnLast_Click(Nothing, Nothing)
        Else
            intRec = G_NextRec(Me.txtTransID.Text)
            ShowDataMaster(intRec)

            If cekData(Me.txtPONo.Text) = False Then
                G_DataDetail(Me.txtPONo.Text.Trim, Me.dgv2)
            Else
                G_DataPODetail(Me.txtPONo.Text, Me.dgv2)
            End If

        End If

    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click

        Dim intRec As Integer
        If Me.txtTransID.Text.Trim = "" Then
            btnLast_Click(Nothing, Nothing)
        Else
            intRec = G_PrevRec(Me.txtTransID.Text)
            ShowDataMaster(intRec)
            If cekData(Me.txtPONo.Text) = False Then
                G_DataDetail(Me.txtPONo.Text.Trim, Me.dgv2)
            Else
                G_DataPODetail(Me.txtPONo.Text, Me.dgv2)
            End If
        End If

    End Sub

    Private Sub btnFirst_Click_1(sender As Object, e As EventArgs) Handles btnFirst.Click

        Dim intRec As Integer
        intRec = G_FirstRec()
        ShowDataMaster(intRec)
        If cekData(Me.txtPONo.Text) = False Then
            G_DataDetail(Me.txtPONo.Text.Trim, Me.dgv2)
        Else
            G_DataPODetail(Me.txtPONo.Text, Me.dgv2)
        End If


    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click


        If Me.txtPONo.Text = "" Then
            MsgBox("PO No tidak boleh kosong")
            Exit Sub
        Else
            INSERTDATAMASTER()
            INSERTDATADETAILS()
            G_DataPODetail(Me.txtPONo.Text, Me.dgv2)
            MsgBox("Saved")
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        CancelData()
        btnLast_Click(Nothing, Nothing)
    End Sub

    Private Sub cbCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCompany.SelectedIndexChanged
        Dim ds As New DataSet
        ds = Company(Me.cbCompany.Text)
        If Me.cbCompany.SelectedIndex <> 0 Then
            Me.txtAddress1.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("Address1")), "", ds.Tables(0).Rows(0)("Address1"))
            Me.txtAddress2.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("Address2")), "", ds.Tables(0).Rows(0)("Address2"))
            Me.txtAddress3.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("Address3")), "", ds.Tables(0).Rows(0)("Address3"))
            Me.txtTlp.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("Phone")), "", ds.Tables(0).Rows(0)("Phone"))
            Me.TxtAttnTo.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("PIC")), "", ds.Tables(0).Rows(0)("PIC"))
        Else
            Me.txtAddress1.Text = ""
            Me.txtAddress2.Text = ""
            Me.txtAddress3.Text = ""
            Me.txtTlp.Text = ""
            Me.TxtAttnTo.Text = ""
        End If
    End Sub


    Private Sub cbCompany_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbCompany.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim ds As New DataSet
            ds = Company(Me.cbCompany.Text)
            Me.txtAddress1.Text = ds.Tables(0).Rows(0)("Address1")
            Me.txtAddress2.Text = ds.Tables(0).Rows(0)("Address2")
            Me.txtAddress3.Text = ds.Tables(0).Rows(0)("Address3")
            Me.txtTlp.Text = ds.Tables(0).Rows(0)("Phone")
            Me.TxtAttnTo.Text = ds.Tables(0).Rows(0)("Email")

        End If
    End Sub

    Private Sub btnPrint_Click_1(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim frm As New frmPrintPO
        frm.strPONo = Me.txtPONo.Text.Trim
        'frm.strNamaSite = Me.cbSite.SelectedValue
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btnDOne_Click(sender As Object, e As EventArgs) Handles btnDOne.Click
        UpdateStatus(Me.txtTransID.Text, 7)
        ' Dim strPONo As String = ""
        Dim strTransID As Integer

        strTransID = G_PONo(Me.txtPONo.Text)
        If strTransID <> -1 Then
            'Me.txtPONo.Text = strPONo
            Me.txtTransID.Text = strTransID
                IsiDataPO()
            End If
        'End If
    End Sub
    Private Function cekStatus(ByVal strPONo As String) As Boolean

        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                "Select TransID from tbATKPOMain  WHERE PONo='" & strPONo & "' and Status='2' "

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

    Private Sub dgv2_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgv2.CellContentClick

    End Sub

    Private Sub dgv2_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv2.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Me.dgv2.Item("TransID", Me.dgv2.CurrentRow.Index).Value = Nothing Then
                Me.dgv2.Rows.RemoveAt(Me.dgv2.CurrentRow.Index)
            ElseIf MsgBox("Anda yakin akan menghapus Transaksi ini", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Using cn As New SqlClient.SqlConnection(strCOnnLocal)
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cn.Open()
                        cmd.CommandText = "Delete from tbATKPODetails where TransID=@TransID"
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", Me.dgv2.Item("TransID", Me.dgv2.CurrentRow.Index).Value))
                        Try
                            cmd.ExecuteNonQuery()
                            Me.dgv2.Rows.RemoveAt(Me.dgv2.CurrentRow.Index)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End Using
                End Using
            End If
        End If
    End Sub
End Class