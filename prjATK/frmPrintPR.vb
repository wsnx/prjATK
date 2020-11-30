Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPrintPR
    Public strPRNo As String
    Public strNamaSite As String
    Private Sub ReportPR()
        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim mySubRepDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        'OpenConfig()
        mySubRepDoc.Load("C:\DORCLDD\PR\rptPR.rpt")

        ConInfo.ConnectionInfo.UserID = UI
        ConInfo.ConnectionInfo.Password = PW
        ConInfo.ConnectionInfo.ServerName = DS
        ConInfo.ConnectionInfo.DatabaseName = IC

        On Error Resume Next
        For intCounter As Integer = 0 To mySubRepDoc.Database.Tables.Count - 1
            mySubRepDoc.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
        Next
        'mySubRepDoc.DataDefinition.RecordSelectionFormula = strSelectionFormula

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues

        Dim crParameterDiscreteValue As New ParameterDiscreteValue



        crParameterDiscreteValue.Value = strPRNo
        crParameterFieldDefinitions = mySubRepDoc.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("PRNo")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = mySubRepDoc
        CrystalReportViewer1.Refresh()

        'mySubRepDoc.PrintOptions.PrinterName = Me.PrintDocument1.PrinterSettings.PrinterName
        'mySubRepDoc.PrintToPrinter(1, True, 0, 0)
    End Sub
    Private Sub ReportATK()
        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim mySubRepDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        'OpenConfig()
        mySubRepDoc.Load("C:\DORCLDD\PR\rptPRATK.rpt")

        ConInfo.ConnectionInfo.UserID = UI
        ConInfo.ConnectionInfo.Password = PW
        ConInfo.ConnectionInfo.ServerName = DS
        ConInfo.ConnectionInfo.DatabaseName = IC

        On Error Resume Next
        For intCounter As Integer = 0 To mySubRepDoc.Database.Tables.Count - 1
            mySubRepDoc.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
        Next
        'mySubRepDoc.DataDefinition.RecordSelectionFormula = strSelectionFormula

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues

        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        crParameterDiscreteValue.Value = strPRNo
        crParameterFieldDefinitions = mySubRepDoc.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("PRNo")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = mySubRepDoc
        CrystalReportViewer1.Refresh()
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub RbPR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbPR.CheckedChanged
        ReportPR()
    End Sub

    Private Sub RbATK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbATK.CheckedChanged
        ReportATK()
    End Sub
End Class
