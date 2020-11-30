Imports System.Deployment.Application
Public Class frmMain

    Private Sub TransaksiToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuTransaksi.Click

    End Sub

    Private Sub ReportsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuReports.Click

    End Sub

    Private Sub frmMain_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Me.mnuLogout_Click(Nothing, Nothing)
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            frmConfig.ShowDialog()
        End If
    End Sub

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                ctl.BackColor = Me.BackColor
            End If
        Next ctl
        '        labelVersion.Text = "eProcurement version" + System.Windows.Forms.Application.ProductVersion + " @2020"
        labelVersion.Text = "eProcuremen version" + My.Application.Info.Version.ToString()

        MenuStrip1.MdiWindowListItem = WindowsToolStripMenuItem

        DS = "10.130.0.16\sql2k8"
        IC = "DOR"
        UI = "kadmin"
        PW = "s3c4dm1n"
        strCOnnLocal = "Integrated Security = False;Data Source=" & DS & ";Initial Catalog=" & IC & ";User ID=" & UI & ";Password=" & PW & ";"
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Dim frm As New frmLogin
        frm.ShowDialog()
        If frm.Logged = True Then
            Me.lblStatus.Text = strUserName & " logged in"
            SetLogin()
        End If
        frm.Dispose()

        Dim frm1 As New frmPO_New
        If frm1.IsDisposed = True Then
            MsgBox("Form PO has Closed")
        End If
    End Sub

    Private Sub SetLogin()
        htUser = G_UserProfile(strUserName)
        mnuLogin.Enabled = False
        mnuLogout.Enabled = True
        mnuExit.Enabled = False
        mnuTransaksi.Enabled = True
        mnuReports.Enabled = True
        ReportPOToolStripMenuItem.Enabled = False
        DataMasterToolStripMenuItem.Enabled = False

        strUserType = G_UserType(strUserName).ToLower
        If strUserType = "adminpo" Then

            mnuPR.Enabled = True
            mnuPRApproval.Enabled = True
            CreatePOToolStripMenuItem.Enabled = True
            GRPOToolStripMenuItem.Enabled = True
            mnuPRApproval_Click(Nothing, Nothing)
            ReportPOToolStripMenuItem.Enabled = True
            DataMasterToolStripMenuItem.Enabled = True

        ElseIf strUserType = "adminpr" Then
            mnuPR.Enabled = True
            mnuPRApproval.Enabled = True
            CreatePOToolStripMenuItem.Enabled = False
            GRPOToolStripMenuItem.Enabled = True
        Else
            mnuPR.Enabled = False
            mnuPRApproval.Enabled = False
            CreatePOToolStripMenuItem.Enabled = False
            GRPOToolStripMenuItem.Enabled = False

        End If
    End Sub

    Private Sub SetLogout()
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next
        mnuLogin.Enabled = True
        mnuLogout.Enabled = False
        mnuExit.Enabled = True
        mnuTransaksi.Enabled = False
        mnuReports.Enabled = False
        'mnuConfig.Enabled = False
        'mnuDOR.Enabled = False
        lblStatus.Text = strUserName & " Logged Out"
    End Sub

    Private Sub ClearForm(ByRef frm As Form)
        For Each a As Form In Me.MdiChildren
            If a.Name = frm.Name Then
                a.Close()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub mnuLogout_Click(sender As System.Object, e As System.EventArgs) Handles mnuLogout.Click
        SetLogout()
        InsertToLog(strUserName, 0)
        frmMain_Shown(Nothing, Nothing)
    End Sub

    Private Sub DataMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DataMasterToolStripMenuItem.Click

    End Sub

    Private Sub ItemLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmReports.MdiParent = Me
        'frmReports.Show()
    End Sub

    Private Sub SOHToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ConfigToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConfigToolStripMenuItem.Click

    End Sub

    Private Sub ATKLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmTransaksiATK.MdiParent = Me
        frmTransaksiATK.Show()
    End Sub

    Private Sub ATKRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmRequestATK.MdiParent = Me
        frmRequestATK.Show()
    End Sub

    Private Sub mnuATKApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmListReqATK.MdiParent = Me
        frmListReqATK.Show()
    End Sub

    Private Sub mnuLogin_Click(sender As System.Object, e As System.EventArgs) Handles mnuLogin.Click
        frmMain_Shown(Nothing, Nothing)
    End Sub

    Private Sub mnuPRApproval_Click(sender As System.Object, e As System.EventArgs) Handles mnuPRApproval.Click
        frmListPR.MdiParent = Me
        frmListPR.Show()

    End Sub

    Private Sub mnuPR_Click(sender As System.Object, e As System.EventArgs) Handles mnuPR.Click
        frmPR.MdiParent = Me
        frmPR.Show()
    End Sub

    Private Sub mnuListReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmListReqATK.MdiParent = Me
        frmListReqATK.Show()
    End Sub

    Private Sub mnuListPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmListPR.MdiParent = Me
        frmListPR.Show()
    End Sub

    Private Sub DbConfigToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DbConfigToolStripMenuItem.Click
        frmConfig.MdiParent = Me
        frmConfig.Show()
    End Sub

    Private Sub UserConfigToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UserConfigToolStripMenuItem.Click
        frmUserConfig.MdiParent = Me
        frmUserConfig.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmListReqATK4Mgr
        frmListReqATK4Mgr.MdiParent = Me
        frmListReqATK4Mgr.Show()
    End Sub

    Private Sub SKUMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SKUMasterToolStripMenuItem.Click
        frmMasterData.MdiParent = Me
        frmMasterData.Show()
    End Sub

    Private Sub CreatePOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CreatePOToolStripMenuItem.Click
        'FrmGeneratePO.MdiParent = Me
        'FrmGeneratePO.Show()
        'Upload by PR


        'Manual PO
        'frmPO.MdiParent = Me
        'frmPO.Show()
    End Sub

    Private Sub AddressMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddressMasterToolStripMenuItem.Click
        frmCompany.MdiParent = Me
        frmCompany.Show()
    End Sub

    Private Sub PrintPRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        frmPrintPR.MdiParent = Me
        frmPrintPR.Show()
    End Sub

    Private Sub ListPOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        frmListPO.MdiParent = Me
        frmListPO.Show()
    End Sub

    Private Sub ReportPRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportPRToolStripMenuItem.Click
        FormReportPR.MdiParent = Me
        FormReportPR.Show()
    End Sub

    Private Sub GRPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GRPOToolStripMenuItem.Click
        FrmGR.MdiParent = Me
        FrmGR.Show()
    End Sub

    Private Sub ReportPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportPOToolStripMenuItem.Click
        FrmRptPO.MdiParent = Me
        FrmRptPO.Show()
    End Sub

    Private Sub PrintGRPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintGRPOToolStripMenuItem.Click
        frmPrintITS.MdiParent = Me
        frmPrintITS.Show()
    End Sub

    Private Sub PrintGRResultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintGRResultToolStripMenuItem.Click
        frmPrint.MdiParent = Me
        frmPrint.Show()
    End Sub

    Private Sub MainPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MainPOToolStripMenuItem.Click
        frmPO_New.MdiParent = Me
        frmPO_New.Show()
    End Sub

    Private Sub EditPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPOToolStripMenuItem.Click
        frmPO.MdiParent = Me
        frmPO.Show()
    End Sub

    Private Sub WindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowsToolStripMenuItem.Click

    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://10.130.12.190//eproc/login.aspx")
    End Sub
End Class