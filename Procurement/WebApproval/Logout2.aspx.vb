
Partial Class Logout2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Session.Remove("UserName")
        Response.Redirect("Login2.aspx")
    End Sub
End Class
