
Partial Class Logout1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Session.Remove("UserName")
        Response.Redirect("Login1.aspx")
    End Sub
End Class
