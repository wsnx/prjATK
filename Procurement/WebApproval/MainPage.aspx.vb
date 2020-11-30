
Partial Class MainPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim strUserAgent As String = Request.UserAgent.ToString().ToLower()
        Me.Label1.Text = strUserAgent
        If Not (IsDBNull(strUserAgent)) Then
            If strUserAgent.Contains("android") Or strUserAgent.Contains("mobile") Then
                '                Me.Label2.Text = "Dibuka lewat HP"
                Response.Redirect("prapproval1.aspx")
            Else
                Response.Redirect("prapproval.aspx")
            End If
        End If
        'if (strUserAgent != null)
        '{
        '	if (Request.Browser.IsMobileDevice == true || strUserAgent.Contains("iphone") ||
        '             strUserAgent.Contains("blackberry") || strUserAgent.Contains("mobile") ||
        '             strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
        '             strUserAgent.Contains("palm"))
        '	{
        '		//Request from Mobile Device
        '	}
        '        else{
        '                //Request from Computer
        '        }
        '}
    End Sub
End Class
