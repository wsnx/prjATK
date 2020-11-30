Public Class frmTgl
    Public tgl As Date

    Private Sub MonthCalendar1_DateChanged(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        'tgl = e.End
        ''MsgBox(tgl.Date)
        'Me.Hide()
    End Sub

    Private Sub frmTgl_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        MonthCalendar1.ShowToday = True
        tgl = Now.Date
    End Sub

    Private Sub MonthCalendar1_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        tgl = e.End
        'MonthCalendar1.SelectionRange = New SelectionRange(Date.Today, Date.Today.AddDays("7"))

        'MsgBox(tgl.Date)
        Me.Hide()
    End Sub

    Private Sub MonthCalendar1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MonthCalendar1.KeyPress

    End Sub

    Private Sub frmTgl_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class