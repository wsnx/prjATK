Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmPrintPO
    Public strPONo As String
    Public strNamaSite As String
    Private Sub frmPrintPO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ReportATK()
    End Sub
    Private Sub ReportATK()
        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim mySubRepDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        mySubRepDoc.Load("C:\DORCLDD\PR\rptPO.rpt")

        ConInfo.ConnectionInfo.UserID = UI
        ConInfo.ConnectionInfo.Password = PW
        ConInfo.ConnectionInfo.ServerName = DS
        ConInfo.ConnectionInfo.DatabaseName = IC

        On Error Resume Next
        For intCounter As Integer = 0 To mySubRepDoc.Database.Tables.Count - 1
            mySubRepDoc.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
        Next


        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues

        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        crParameterDiscreteValue.Value = strPONo
        crParameterFieldDefinitions = mySubRepDoc.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("PONo")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = mySubRepDoc
        CrystalReportViewer1.Refresh()
    End Sub
End Class