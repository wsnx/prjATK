
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub ImageButton1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Session.Remove("UserName")
        If clsFunction.Cek_Login(Me.txtUserID.Text.Trim, Me.txtPassword.Text.Trim) = False Then
            Me.lblError.Visible = True
        Else
            Session.Add("UserName", Me.txtUserID.Text.Trim)

            Me.lblError.Visible = False
            Dim strAddr As String
            If IsNothing(Session("alamat")) Then
                strAddr = ""
            Else
                strAddr = Session("alamat").ToString()
            End If

            Try
                If strAddr <> "" Then
                    Response.Redirect(strAddr)
                Else
                    If Mid(strAddr, 1, 2) = "pr" Then
                        Response.Redirect("prapproval.aspx")
                    Else
                        Response.Redirect("poapproval.aspx")
                    End If
                End If
                'If Session("splno").ToString <> "" And Session("approve") = "yes" Then
                'Response.Redirect("approval.aspx?n=" & Session("splno") & "&s=" & Session("status"))
                'ElseIf Session("splno").ToString <> "" And Session("approve") = "no" Then
                'Response.Redirect("notapprove.aspx?n=" & Session("splno"))
                'Else
                'Response.Redirect("prapproval.aspx")
                ' End If
            Catch ex As Exception
                If Mid(strAddr, 1, 2) = "pr" Then
                    Response.Redirect("prapproval.aspx")
                Else
                    Response.Redirect("poapproval.aspx")
                End If
            End Try



        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub
End Class
