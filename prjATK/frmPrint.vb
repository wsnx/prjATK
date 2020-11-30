Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPrint
    Public strGRNo As String


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim mySubRepDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        'OpenConfig()
        mySubRepDoc.Load("C:\DORCLDD\PR\rptPOGR_Result.rpt")

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



        crParameterDiscreteValue.Value = strGRNo
        crParameterFieldDefinitions = mySubRepDoc.DataDefinition.ParameterFields()
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("GRNo")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = mySubRepDoc
        CrystalReportViewer1.Refresh()

        'mySubRepDoc.PrintOptions.PrinterName = Me.PrintDocument1.PrinterSettings.PrinterName
        'mySubRepDoc.PrintToPrinter(1, True, 0, 0)
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub
End Class
