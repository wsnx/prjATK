Module modVariable
    Public strConnPusat As String = "Integrated Security=False;Data Source=10.130.0.16\sql2k8;Initial Catalog=MAP;User ID=kadmin;Password=s3c4dm1n"
    'Public strConnWMSgeo45 As String = "Integrated Security=False;Data Source=10.64.0.152;Initial Catalog=geo;User ID=geo45;Password=geo45"
    Public strConnWMSgeo45 As String = "Integrated Security=False;Data Source=10.201.80.55;Initial Catalog=geo;User ID=geo45;Password=geo45"
    Public strConnPDU As String = "Integrated Security=False;Data Source=10.130.12.2;Initial Catalog=PickTicket;User ID=sa;Password=cmaker"
    Public strCOnnLocal As String = "Integrated Security=False;Data Source=10.130.0.16\sql2k8;Initial Catalog=DOR;User ID=kadmin;Password=s3c4dm1n"
    Public strUserName As String
    Public hasil As Boolean
    Public DS As String
    Public IC As String
    Public UI As String
    Public PW As String
    Public strNamaSite As String

    Public strSQL As String
    Public strUserType As String
    Public htUser As New Hashtable
End Module
