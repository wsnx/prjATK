Public Class frmConfig

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        SaveSetting("ATKCL", "Config", "srv", Me.txtServer.Text.Trim)
        SaveSetting("ATKCL", "Config", "dB", Me.txtdB.Text.Trim)
        SaveSetting("ATKCL", "Config", "usr", Me.txtUserID.Text.Trim)
        SaveSetting("ATKCL", "Config", "pwd", Me.txtPwd.Text.Trim)

        strCOnnLocal = "Integrated Security = False;Data Source=" & Me.txtServer.Text.Trim & ";Initial Catalog=" & Me.txtdB.Text.Trim & ";User ID=" & Me.txtUserID.Text.Trim & ";Password=" & Me.txtPwd.Text.Trim & ";"
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Try
                cn.Open()
            Catch ex As Exception
                MsgBox("Setting Connection masih salah")
                Exit Sub
            End Try
        End Using

        MsgBox("Data Saved Succesfully")
        Me.Close()
    End Sub

    Private Sub frmConfig_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.txtServer.Text = GetSetting("ATKCL", "Config", "srv")
        Me.txtdB.Text = GetSetting("ATKCL", "Config", "dB")
        Me.txtUserID.Text = GetSetting("ATKCL", "Config", "usr")
        Me.txtPwd.Text = GetSetting("ATKCL", "Config", "pwd")

    End Sub

End Class