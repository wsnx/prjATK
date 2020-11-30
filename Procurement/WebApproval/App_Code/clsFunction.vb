Imports Microsoft.VisualBasic
Imports System
Imports System.Data

Public Class clsFunction
    Shared Function Cek_Login(ByVal user As String, ByVal pwd As String) As Boolean
        Dim hasil As Boolean = False

        Using cn As New Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString)
            Using cmd As New Data.SqlClient.SqlCommand("select * from [User] where UserID=@UserID and Password=@Password", cn)
                cn.Open()
                cmd.Parameters.Add(New Data.SqlClient.SqlParameter("UserID", user))
                cmd.Parameters.Add(New Data.SqlClient.SqlParameter("Password", pwd))
                Dim dr As Data.SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = True
                    End If
                Catch ex As Exception

                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Shared Function G_PRProfile(ByVal strNoPR As String) As Hashtable
        Dim ht As New Hashtable
        Using cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select b.* from tbATKPRMain a inner join tbatkuserconfig b on a.InputBy= b.UserID where a.PRNo='" & strNoPR.Trim & "'"

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        ', , , , , 
                        ht.Add("userid", dr!userID)
                        ht.Add("emailaddress", dr!EmailAddress)
                        ht.Add("site", dr!Site)
                        ht.Add("storerkey", dr!StorerKey)
                        ht.Add("AdminATK", dr!AdminATK)
                        ht.Add("AdminGA", dr!AdminGA)

                        ht.Add("ReqApproval", dr!ReqApproval)
                        ht.Add("PRAppName", dr!PRAppName)
                        ht.Add("PRApproval", dr!PRApproval)
                        ht.Add("PRAppName1", dr!PRAppName1)
                        ht.Add("PRApproval1", dr!PRApproval1)
                        ht.Add("CopyReq", dr!CopyReq)
                        ht.Add("CopyPR", dr!CopyPR)
                        ht.Add("NSOAppName", dr!NSOAppName)
                        ht.Add("NSOApproval", dr!NSOApproval)
                        ht.Add("GMAppName", dr!GMAppName)
                        ht.Add("GMApproval", dr!GMApproval)
                        ht.Add("CFOAppName", dr!CFOAppName)
                        ht.Add("CFOApproval", dr!CFOApproval)
                        ht.Add("NSOTittle", dr!NSOTittle)
                    End If
                Catch ex As Exception
                    ht.Clear()

                End Try
            End Using
        End Using
        Return ht
    End Function

    Shared Function G_POProfile(ByVal strNoPO As String) As Hashtable
        Dim ht As New Hashtable
        Using cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select b.* from tbATKPOMain a inner join tbatkuserconfig b on a.InputBy= b.UserID where a.PONo='" & strNoPO.Trim & "'"

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        ', , , , , 
                        ht.Add("userid", dr!userID)
                        ht.Add("emailaddress", dr!EmailAddress)
                        ht.Add("site", dr!Site)
                        ht.Add("storerkey", dr!StorerKey)
                        ht.Add("AdminATK", dr!AdminATK)
                        ht.Add("AdminGA", dr!AdminGA)
                        ht.Add("AdminPO", dr!AdminPO)
                        ht.Add("ReqApproval", dr!ReqApproval)
                        ht.Add("PRAppName", dr!PRAppName)
                        ht.Add("PRApproval", dr!PRApproval)
                        ht.Add("PRAppName1", dr!PRAppName1)
                        ht.Add("PRApproval1", dr!PRApproval1)
                        ht.Add("CopyReq", dr!CopyReq)
                        ht.Add("CopyPR", dr!CopyPR)
                        ht.Add("NSOAppName", dr!NSOAppName)
                        ht.Add("NSOApproval", dr!NSOApproval)
                        ht.Add("GMAppName", dr!GMAppName)
                        ht.Add("GMApproval", dr!GMApproval)
                        ht.Add("CFOAppName", dr!CFOAppName)
                        ht.Add("CFOApproval", dr!CFOApproval)
                    End If
                Catch ex As Exception
                    ht.Clear()

                End Try
            End Using
        End Using
        Return ht
    End Function

    Shared Function UpdateStatusByTransID(ByVal JenisTransaksi As String, ByVal TransID As Integer, ByVal intStatus As Integer, ByVal strUserName As String, ByVal ComputerName As String) As String
        Dim ds As DataSet = New DataSet
        Dim strSQL As String = ""
        Dim hostname As String
        Dim strHasil As String = ""
        hostname = System.Net.Dns.GetHostName

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString


                cmd.Connection = cn
                cn.Open()

                If JenisTransaksi = "PR" Then
                    Select Case intStatus
                        Case 2 'Waiting For Manager Approval
                            strSQL = "Update tbATKPRMain set Status=@Status,ApprovedBy=@ApprovedBy,SubmittedDate=getdate(),SubmittedHost=@HostName Where TransID=@TransID"
                        Case 3 'Approved By Manager
                            strSQL = "Update tbATKPRMain set Status=@Status,ApprovedBy=@ApprovedBy,ApprovedDate=getdate(),ApprovedHost=@HostName Where TransID=@TransID"
                        Case 4 'Waiting For Nat Manager Approval
                            strSQL = "Update tbATKPRMain set Status=@Status,ApprovedBy=@ApprovedBy,ApprovedDate=getdate(),ApprovedHost=@HostName Where TransID=@TransID"
                        Case 5 'Approved By Nat. Manager
                            strSQL = "Update tbATKPRMain set Status=@Status,ApprovedBy1=@ApprovedBy,ApprovedDate1=getdate(),ApprovedHost1=@HostName Where TransID=@TransID"
                        Case 8 'Realisasi Confirm
                            strSQL = "Update tbATKPRMain set Status=@Status,RealisasiBy=@ApprovedBy,RealisasiDate=getdate(),RealisasiHost=@HostName Where TransID=@TransID"
                        Case 9 'Cancel
                            strSQL = "Update tbATKPRMain set Status=@Status,ApprovedBy=@ApprovedBy,CancelledDate=getdate() Where TransID=@TransID"
                    End Select
                ElseIf JenisTransaksi = "PO" Then
                    Select Case intStatus
                        Case 2 'Waiting For Manager Approval
                            strSQL = "Update tbATKPOMain set Status=@Status,ApprovedBy=@ApprovedBy,SubmittedDate=getdate(),SubmittedHost=@HostName Where TransID=@TransID"
                        Case 3 'Approved By Manager
                            strSQL = "Update tbATKPOMain set Status=@Status,ApprovedBy=@ApprovedBy,ApprovedDate=getdate(),ApprovedHost=@HostName Where TransID=@TransID"
                        Case 4 'Waiting For Nat Manager Approval
                            strSQL = "Update tbATKPOMain set Status=@Status,ApprovedBy=@ApprovedBy,ApprovedDate=getdate(),ApprovedHost=@HostName Where TransID=@TransID"
                        Case 5 'Approved By GM
                            strSQL = "Update tbATKPOMain set Status=@Status,ApprovedByGM=@ApprovedBy,ApprovedDateGM=getdate(),ApprovedHost1=@HostName Where TransID=@TransID"
                        Case 6 'Waiting For CFO Approval
                            strSQL = "Update tbATKPOMain set Status=@Status,ApprovedByGM=@ApprovedBy,ApprovedDateGM=getdate(),ApprovedHost1=@HostName Where TransID=@TransID"
                        Case 8 'Approved By CFO
                            strSQL = "Update tbATKPOMain set Status=@Status,ApprovedByCFO=@ApprovedBy,ApprovedDateCFO=getdate(),ApprovedHost2=@HostName Where TransID=@TransID"
                        Case 9 'Cancel
                            strSQL = "Update tbATKPOMain set Status=@Status,ApprovedBy=@ApprovedBy,CancelledDate=getdate() Where TransID=@TransID"
                    End Select
                End If


                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", TransID))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Status", intStatus))
                cmd.Parameters.Add(New SqlClient.SqlParameter("ApprovedBy", strUserName))
                cmd.Parameters.Add(New SqlClient.SqlParameter("HostName", ComputerName))

                Try

                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    strHasil = ex.Message
                End Try
            End Using
        End Using
        Return strHasil
    End Function

    Shared Function UpdateStatusBySPLno(ByVal strPRNo As String, ByVal intStatus As Integer, ByVal strUserName As String, ByVal NamaComputer As String) As String
        Dim ds As DataSet = New DataSet
        Dim strSQL As String = ""
        Dim hostname As String
        Dim strHasil As String = ""
        hostname = System.Net.Dns.GetHostName



        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString


                cmd.Connection = cn
                cn.Open()

                Select Case intStatus
                    Case 2 'Waiting For Manager Approval
                        strSQL = "Update tbsplmain set Status=@Status,ApprovedBy=@ApprovedBy,SubmittedDate=getdate(),SubmittedHost=@HostName Where PRNo=@PRNo"
                    Case 3 'Approved By Manager
                        strSQL = "Update tbsplmain set Status=@Status,ApprovedBy=@ApprovedBy,ApprovedDate=getdate(),ApprovedHost=@HostName Where PRNo=@PRNo"
                    Case 4 'Waiting For Nat Manager Approval
                        strSQL = "Update tbsplmain set Status=@Status,ApprovedBy=@ApprovedBy,ApprovedDate=getdate(),ApprovedHost=@HostName Where PRNo=@PRNo"
                    Case 5 'Approved By Nat. Manager
                        strSQL = "Update tbsplmain set Status=@Status,ApprovedBy1=@ApprovedBy,ApprovedDate1=getdate(),ApprovedHost1=@HostName Where PRNo=@PRNo"
                    Case 8 'Realisasi Confirm
                        strSQL = "Update tbsplmain set Status=@Status,RealisasiBy=@ApprovedBy,RealisasiDate=getdate(),RealisasiHost=@HostName Where PRNo=@PRNo"
                    Case 9 'Cancel
                        strSQL = "Update tbsplmain set Status=@Status,ApprovedBy=@ApprovedBy,CancelledDate=getdate() Where PRNo=@PRNo"
                End Select

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", strPRNo))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Status", intStatus))
                cmd.Parameters.Add(New SqlClient.SqlParameter("ApprovedBy", strUserName))
                cmd.Parameters.Add(New SqlClient.SqlParameter("HostName", NamaComputer))

                Try

                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    strHasil = ex.Message
                End Try
            End Using
        End Using
        Return strHasil
    End Function

    Shared Function G_PRMain(ByVal strPRNo As String) As DataSet
        Dim ds As DataSet = New DataSet
        Dim strSQL As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString


                cmd.Connection = cn
                cn.Open()

                strSQL = "select * from tbATKPRMain Where PRNo=@PRNo"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", strPRNo))

                Try

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception

                End Try
            End Using
        End Using

        Return ds
    End Function

    Shared Function CREATE_PO(ByVal strPRNo As String) As Boolean
        Dim ds As DataSet = New DataSet
        Dim strSQL As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString


                cmd.Connection = cn
                cn.Open()

                strSQL = "select a.NamaSite,a.PRNo,c.KodeVendor from tbATKPRMain a inner join tbATKPRDetails b on a.PRNo=b.PRNo inner join [tbATKmstbrg] c on b.KodeBarang=c.KodeBarang Where a.PRNo=@PRNo order by c.KodeVendor"

                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", strPRNo))

                Try

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception

                End Try
            End Using
        End Using

        Dim strKodeVendor As String
        Dim strPONo As String = ""

        strKodeVendor = ""
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            If strKodeVendor <> ds.Tables(0).Rows(i)("KodeVendor") Then
                strPONo = G_NoPOMax(strPRNo, ds.Tables(0).Rows(i)("NamaSite"))
                Add_POHeader(strPRNo, strPONo, ds.Tables(0).Rows(i)("KodeVendor"))
            End If
            'addDetailPO
            Add_PODetails(strPRNo, strPONo, ds.Tables(0).Rows(i)("KodeVendor"))
            strKodeVendor = ds.Tables(0).Rows(i)("KodeVendor")
        Next

    End Function


    Shared Function Add_POHeader(ByVal strPRNo As String, ByVal strPONo As String, ByVal strKodeVendor As String) As String
        Dim strSQL As String = ""
        Dim hasil As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString

                'POPDU.201905.001.01
                cmd.Connection = cn
                cn.Open()

                strSQL = "INSERT INTO tbATKPOMain (WHAsal, PONo, PRNo, KodeVendor, TglTransaksi, Status, InputDate, InputBy, hostname ) select NamaSite,@NoPO,PRNo,@KodeVendor,getdate(),0,getdate(),@UserName,host_name() from tbATKPRMain Where PRNo=@PRNo"

                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", strPRNo))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NoPO", strPONo))
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeVendor", strKodeVendor))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UserName", "System"))

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                End Try
            End Using
        End Using

        Return hasil
    End Function

    Shared Function Add_PODetails(ByVal strPRNo As String, ByVal strPONo As String, ByVal strKodeVendor As String) As String
        Dim strSQL As String = ""
        Dim hasil As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString

                'POPDU.201905.001.01
                cmd.Connection = cn
                cn.Open()

                strSQL = "INSERT INTO tbATKPODetails (PONo, PRNo, EndUserName, EndUserLocation, KodeBarang, UOM, Qty, KodeVendor,Keterangan, LastPrice, EstTotPrice, PurchasedbyGA, InputDate) select @PONo, PRNo, EndUserName, EndUserLocation, KodeBarang, UOM, Qty, @KodeVendor, Keterangan, LastPrice, EstTotPrice, PurchasedbyGA, getdate() from tbATKPRDetails Where PRNo=@PRNo"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", strPRNo))
                cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", strPONo))
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeVendor", strKodeVendor))

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                End Try
            End Using
        End Using

        Return hasil
    End Function

    Shared Function G_NoPOMax(ByVal strPRNo As String, ByVal strWHSite As String) As String
        Dim ds As DataSet = New DataSet
        Dim strSQL As String = ""
        Dim hasil As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString

                'POPDU.201905.001.01
                cmd.Connection = cn
                cn.Open()

                'strSQL = "select isnull(max(cast(right(PONo,2) as int)),0) as NoMax from tbATKPOMain Where PRNo=@PRNo"
                strSQL = "select isnull(max(cast(right(PONo,5) as int)),0) as NoMax from tbATKPOMain Where substring(PONo,7,6)='" & Format(Now.Date, "yyyyMM") & "'"

                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", strPRNo))

                Try

                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        'hasil = "PO" & strWHSite & "." & Format(Now.Date, "yyyyMM") & "." & Microsoft.VisualBasic.Right(strPRNo, 4) & "." & Mid(dr(0) + 101, 2, 2)
                        hasil = "PO" & G_KodeWH(strWHSite.Trim) & "." & Format(Now.Date, "yyyyMM") & "." & Mid(dr(0) + 100001, 2, 5)
                    End If
                Catch ex As Exception

                End Try
            End Using
        End Using

        Return hasil
    End Function

    Shared Function G_PRDetails(ByVal strPRNo As String) As DataSet
        Dim ds As DataSet = New DataSet
        Dim strSQL As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString


                cmd.Connection = cn
                cn.Open()

                strSQL = "select * from tbATKPRDetails Where PRNo=@PRNo"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", strPRNo))

                Try

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception

                End Try
            End Using
        End Using

        Return ds
    End Function

    Shared Function G_PODetails(ByVal strPONo As String) As DataSet
        Dim ds As DataSet = New DataSet
        Dim strSQL As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString


                cmd.Connection = cn
                cn.Open()

                strSQL = "select * from tbATKPODetails Where PONo=@PONo"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", strPONo))

                Try

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception

                End Try
            End Using
        End Using

        Return ds
    End Function

    Shared Function G_PRAmount(ByVal strPRNo As String) As Integer
        Dim hasil As Integer = 0
        Dim strSQL As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString


                cmd.Connection = cn
                cn.Open()

                strSQL = "select isnull(sum(EstTotPrice),0) as TotHarga from tbATKPRDetails Where PRNo=@PRNo"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", strPRNo))

                Try

                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception

                End Try
            End Using
        End Using

        Return hasil
    End Function

    Shared Function G_POAmount(ByVal strPONo As String) As Integer
        Dim hasil As Integer = 0
        Dim strSQL As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString


                cmd.Connection = cn
                cn.Open()

                strSQL = "select isnull(sum(EstTotPrice),0) as TotHarga from tbATKPODetails Where PONo=@PONo"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", strPONo))

                Try

                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception

                End Try
            End Using
        End Using

        Return hasil
    End Function

    Shared Function G_KodeWH(ByVal strNamaSite As String) As String
        Dim hasil As String
        Dim strSQL As String = ""

        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = ConfigurationManager.ConnectionStrings("DORConnectionString").ConnectionString


                cmd.Connection = cn
                cn.Open()

                strSQL = "select KodeSite from [tbDORSite] Where NamaSite=@NamaSite"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", strNamaSite))

                Try

                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception

                End Try
            End Using
        End Using

        Return hasil
    End Function
End Class
