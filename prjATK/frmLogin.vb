Public Class frmLogin
    Public Logged As Boolean = False

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim hasil As Boolean
        If Me.txtUser.Text.Trim = "" Then
            MsgBox("Please input your User ID")
            Me.txtUser.Focus()
            hasil = False
            Exit Sub
        End If
        If Me.txtPwd.Text.Trim = "" Then
            MsgBox("Please input your Password")
            Me.txtPwd.Focus()
            hasil = False
            Exit Sub
        End If

        'strConn = "Integrated Security=False;Initial Catalog=Trucking;Data Source=10.130.0.7\sql2005;User ID=sa;Password=cmaker;"
        'Using cn As New SqlClient.SqlConnection(strConn)
        'Try
        'cn.Open()
        If Cek_Login(Me.txtUser.Text.Trim, Me.txtPwd.Text.Trim) = True Then
            If IsUserRegistered(Me.txtUser.Text.Trim) Then
                If IsUserInUsed(Me.txtUser.Text) = True Then
                    MsgBox("User Anda sedang dipakai di komputer lain")
                    'Logged = False
                    'Exit Sub
                End If
                Logged = True
                strUserName = Me.txtUser.Text.Trim.ToLower
                InsertToLog(Me.txtUser.Text.Trim, 1)

                Me.Hide()
            Else
                Logged = False
                MsgBox("Your UserID is not registered for DOR application" & vbCrLf & "Please contact your supervisor/manager.")
            End If
        Else
            Logged = False
            MsgBox("Your UserID or Password is invalid" & vbCrLf & "Please try again.")
        End If

        'Catch ex As Exception
        '    Logged = False
        '    MsgBox(ex.Message)
        'End Try
        'End Using

    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtPwd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPwd.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.btnLogin_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtPwd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPwd.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Closed_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub
End Class