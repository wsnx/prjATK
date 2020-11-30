Module modFunction
    'Public strConnWMS As String = "Integrated Security=False;initial catalog=geo;Data Source=10.201.80.55;User ID=geo45; Password=geo45;"
    'Public strConnLocal As String = "Integrated Security=False;initial catalog=PickTicket;Data Source=10.130.12.2;User ID=sa; Password=cmaker;"

   
    Public Sub DataPRDetails(ByVal strTransID As String)
        'Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                "select a.TransID,a.KodeBarang,NamaBarang,Qty,a.LastPrice,EstTotPrice,Keterangan,a.PRNo from tbatkprdetails a inner join [dbo].[tbATKmstbrg] b on a.KodeBarang=b.KodeBarang  " & _
                "inner join tbATKPRMain c on a.PrNo=c.PRNo where c.status='3' and a.TransID='" & strTransID & "' " & _
                "order by NamaBarang,a.PRNo "
                cmd.Parameters.Clear()

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")

                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        'dgv.RowCount = 0

        'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
        '    dgv.RowCount = dgv.RowCount + 1
        '    dgv.Item("SKU_PO", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("KodeBarang")
        '    dgv.Item("Description_PO", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("NamaBarang")
        '    dgv.Item("PRNo_PO", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("PRNo")
        '    dgv.Item("Qty_PO", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("Qty")
        '    dgv.Item("Price_PO", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("LastPrice")
        '    dgv.Item("Total_PO", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("EstTotPrice")

        '    Try
        '        dgv.Item("PRNo_PO", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("PRNo")
        '    Catch ex As Exception

        '    End Try
        'Next

    End Sub
    Public Sub G_DataDetail(ByVal strPONo As String, ByRef dgv2 As DataGridView)
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "Select a.TransID, a.PRNo,a.KodeBarang, Keterangan as NamaBarang, a.UOM, a.Qty,isnull(a.LastPrice,0) LastPrice,isnull(a.EstTotPrice,0) EstTotPrice,isnull(a.PurchasedByGA,0)PurchasedByGA,b.TransID as IDPR from tbATKPODetails a inner join tbATKPRMain b on a.PRNo=b.PRNo where PONo='" & strPONo & "' order by a.TransID desc"

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    dgv2.RowCount = 0
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        dgv2.RowCount = dgv2.RowCount + 1
                        dgv2.Item("ID_PO", dgv2.RowCount - 1).Value = ds.Tables(0).Rows(i)("TransID")
                        dgv2.Item("ID_PR", dgv2.RowCount - 1).Value = ds.Tables(0).Rows(i)("IDPR")
                        dgv2.Item("PRNo_PO", dgv2.RowCount - 1).Value = ds.Tables(0).Rows(i)("PRNo")
                        dgv2.Item("SKU_PO", dgv2.RowCount - 1).Value = ds.Tables(0).Rows(i)("KodeBarang")
                        dgv2.Item("Description_PO", dgv2.RowCount - 1).Value = ds.Tables(0).Rows(i)("NamaBarang")
                        dgv2.Item("UOM", dgv2.RowCount - 1).Value = ds.Tables(0).Rows(i)("UOM")
                        dgv2.Item("Qty_PO", dgv2.RowCount - 1).Value = ds.Tables(0).Rows(i)("Qty")
                        dgv2.Item("Price_PO", dgv2.RowCount - 1).Value = ds.Tables(0).Rows(i)("LastPrice")
                        dgv2.Item("Total_PO", dgv2.RowCount - 1).Value = ds.Tables(0).Rows(i)("EstTotPrice")
                        ' dgv2.Item("PurchasedByGA", dgv2.RowCount - 1).Value = ds.Tables(0).Rows(i)("PurchasedByGA")

                    Next
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub
    Public Sub GridKosong_Dgv(ByRef dgv2 As DataGridView)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                Try
                    cmd.Connection = cn
                    cn.Open()
                    cmd.CommandText = _
                    "select a.TransID,a.KodeBarang,NamaBarang,Qty,a.LastPrice,EstTotPrice,Keterangan,a.PRNo,isnull(CekPO,0)Cek,'Add'BtnAdd from tbatkprdetails a inner join [dbo].[tbATKmstbrg] b on a.KodeBarang=b.KodeBarang  " & _
                    "inner join tbATKPRMain c on a.PrNo=c.PRNo where isnull(CekPO,0)='2' " & _
                    "order by NamaBarang,a.PRNo "
                    Dim ds As New DataSet
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    dgv2.DataSource = ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Public Function G_MaxPONo() As String
        Dim hasil As String = ""
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(max(left(PONo,3)),100)+1 as MaxRefNo from tbATKPOMain where substring(PONo,11,6)='" & Format(Now.Date, "MM/yy") & "' and substring(PONo,5,5)='AI-GA' "

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = Microsoft.VisualBasic.Left("000" + dr(0), 3) & "/AI-GA/" & Format(Now.Date, "MM/yy")
                    End If
                Catch ex As Exception
                    hasil = ""
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function
    Public Function G_MinRecord() As String
        Dim hasil As String = ""
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Select isnull(min(NoSPL),0) as NoSPL From tbsplmain"
                cmd.Parameters.Clear()
                'cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", strNamaSite))

                Try
                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    hasil = ""
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Function G_PrevRecord(ByVal intNoSPL As Integer) As Integer
        Dim hasil As Integer
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Select max(NoSPL) as NoSPL From tbsplmain Where NoSPL < " & intNoSPL
                cmd.Parameters.Clear()

                Try
                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = IIf(IsDBNull(dr(0)), 0, dr(0))
                    End If
                Catch ex As Exception
                    hasil = 0
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function


    Public Function G_NextRecord(ByVal intNoSPL As Integer) As Integer
        Dim hasil As Integer
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Select min(NoSPL) as NoSPL From tbsplmain Where NoSPL > " & intNoSPL
                cmd.Parameters.Clear()

                Try
                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = IIf(IsDBNull(dr(0)), 0, dr(0))
                    End If
                Catch ex As Exception
                    hasil = 0
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Function G_DatasplMain(ByVal intNoPR As Integer) As Hashtable
        Dim ht As New Hashtable
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "Select a.TransID,isnull(a.PRNo,'') as PRNo,NamaSite, StorerKey,isnull(Name,'')Name,NamaSite,isnull(Designation,'')Designation, " &
                    "isnull(DateRequired,TglTransaksi)DateRequired,TglTransaksi,case isnull(Status,1) when 1 then 'Created' when 2 then 'Waiting for Approval' " &
                    "when 3 then 'Approved' when 4 then 'Waiting 2nd Approval'when 5 then 'Approved' when 9 then 'Cancelled' end as Status,isnull(a.EndUserLocation,b.EndUserLocation)EndUserLocation,a.Storerkey EndUserName " &
                    ",a.InputBy from tbATKPRMain a inner join tbatkprdetails b on a.PRNo=b.PRNo where a.TransID = " & intNoPR
                cmd.Parameters.Clear()

                Try
                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        ht.Clear()
                        ht.Add("TransID", dr!TransID)
                        ht.Add("PRNo", dr!PRNo)
                        ht.Add("NamaSite", dr!NamaSite)
                        ht.Add("Storerkey", dr!Storerkey)
                        ht.Add("Name", dr!Name)
                        ht.Add("Designation", dr!Designation)
                        ht.Add("DateRequired", dr!DateRequired)
                        ht.Add("TglTransaksi", dr!TglTransaksi)
                        ht.Add("Status", dr!Status)
                        ht.Add("EndUserLocation", dr!EndUserLocation)
                        ht.Add("EndUserName", dr!EndUserName)
                    End If
                Catch ex As Exception
                    ht.Clear()
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ht
    End Function
    Public Function G_DataGRMain(ByVal intNoPR As Integer) As Hashtable
        Dim ht As New Hashtable
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "select TransID,GRNo,PONo,isnull(SuratJalan,'')SuratJalan,TglTerima,[Top],DueDate,isnull(Jumlah,'')Jumlah,isnull(Kondisi,'')Kondisi,isnull(Surat,'')Surat,isnull(Lampiran,'')Lampiran,isnull(DeadLine,'')DeadLine,isnull(Pengantaran,'')Pengantaran,isnull(Jumlah,'')Jumlah,isnull(Kondisi,'')Kondisi,isnull(Surat,'')Surat,isnull(Lampiran,'')Lampiran,isnull(DeadLine,'')DeadLine,isnull(Pengantaran,'')Pengantaran,isnull(NilaiJumlah,'0')NilaiJumlah,isnull(NilaiKondisi,'0')NilaiKondisi,isnull(NilaiSurat,'0')NilaiSurat,isnull(NilaiLampiran,'0')NilaiLampiran,isnull(NilaiDeadLine,'0')NilaiDeadLine,isnull(NilaiPengantaran,'0')NilaiPengantaran from tbReceivingMain Where TransID=" & intNoPR
                cmd.Parameters.Clear()

                Try
                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        ht.Clear()
                        ht.Add("TransID", dr!TransID)
                        ht.Add("GRNo", dr!PRNo)

                    End If
                Catch ex As Exception
                    ht.Clear()
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ht
    End Function

    Public Function G_DatasplDetail(ByVal intNoSPL As Integer) As DataSet
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "Select * From tbspldetail Where NoSPL = " & intNoSPL
                cmd.Parameters.Clear()

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")

                Catch ex As Exception
                    ds = New DataSet
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ds
    End Function


    Public Function G_DataMasterBarang() As DataSet
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "Select KodeBarang,NamaBarang,UOM,LastPrice,isnull(KodeVendor,'')KodeVendor,isnull(GrpBarang,'')GrpBarang,InputDate,Status From tbATKmstbrg order by GrpBarang,NamaBarang"
                cmd.Parameters.Clear()

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")

                Catch ex As Exception
                    ds = New DataSet
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ds
    End Function

    Public Function Cek_Login(ByVal user As String, ByVal pwd As String) As Boolean
        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand("select * from [User] where UserID=@UserID and Password=@Password", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("UserID", user))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Password", pwd))
                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = True
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function
    Public Function Cek_Master(ByVal StrNamaBarang As String) As Boolean
        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand("Select KodeBarang,NamaBarang from tbATKmstbrg where NamaBarang=@NamaBarang ", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaBarang", StrNamaBarang.ToLower))
                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = True
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function
    Public Function IsUserRegistered(ByVal user As String) As Boolean
        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand("select * from [User] where UserID=@UserID and ATK=1", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("UserID", user))

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = True
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Function InsertToLog(ByVal user As String, ByVal intStatus As Integer) As Boolean
        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand("INSERT INTO tbUserLog (userid,login,lastlogin,computername) VALUES (@UserID,@login,getdate(),host_name())", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("UserID", user))
                cmd.Parameters.Add(New SqlClient.SqlParameter("login", intStatus))

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Function IsUserInUsed(ByVal user As String) As Boolean
        Dim hasil As Boolean = True

        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand("Select top 1 login from tbUserLog Where UserID=@UserID order by LastLogin desc", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("UserID", user))

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        If dr(0) = 0 Then
                            hasil = False
                        Else
                            hasil = True
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = True
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Function IsUserExist(ByVal user As String) As Integer
        Dim hasil As Integer = -1

        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand("Select top 1 [ID] from [User] Where UserID=@UserID", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("UserID", user))

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    Else
                        hasil = -1
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Function IsKaryawanExist(ByVal strSite As String, ByVal strEmployeeName As String) As Integer
        Dim hasil As Integer = -1

        Using cn As New SqlClient.SqlConnection(strConnPusat)
            Using cmd As New SqlClient.SqlCommand("Select EmployeeName from [tbabsmst] Where lower(EmployeeName)=@EmployeeName and lower(Location)=@Location", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("EmployeeName", strEmployeeName.ToLower))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Location", strSite.ToLower))

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = 1
                    Else
                        hasil = -1
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Function INSERTDataUOM(ByVal ht As Hashtable) As Integer
        Dim hasil As Integer = -1

        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand("INSERT INTO tbATKuombrg (KodeBarang,UOM,Conversi) VALUES (@KodeBarang,@UOM,@Conversi)", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", ht("KodeBarang")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", ht("UOM")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Conversi", ht("Conversi")))


                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Function UPDATEDataUOM(ByVal ht As Hashtable) As Integer
        Dim hasil As Integer = -1

        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand("UPDATE tbATKuombrg SET UOM=@UOM,Conversi=@Conversi WHERE TransID=@TransID", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", ht("TransID")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", ht("UOM")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Conversi", ht("Conversi")))


                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Function UPDATEDataBrg(ByVal ht As Hashtable) As Integer
        Dim hasil As Integer = -1

        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand("UPDATE tbATKmstbrg SET NamaBarang=@NamaBarang,UOM=@UOM,LastPrice=@LastPrice,GrpBarang=@GrpBarang,Status=@Status,KodeVendor=@KodeVendor,Inputdate=getdate() WHERE KodeBarang=@KodeBarang", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", ht("KodeBarang")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaBarang", ht("NamaBarang")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", ht("UOM")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("LastPrice", ht("LastPrice")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("GrpBarang", ht("GrpBarang")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Status", ht("Status")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeVendor", ht("VendorCode")))

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Function INSERTDataBrg(ByVal ht As Hashtable) As Integer
        Dim hasil As Integer = -1

        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand("INSERT INTO tbATKmstbrg (NamaBarang,UOM,KodeVendor,GrpBarang,LastPrice) VALUES (@NamaBarang, @UOM, @KodeVendor, @GrpBarang,@LastPrice)", cn)
                cn.Open()

                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaBarang", ht("NamaBarang")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", ht("UOM")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeVendor", IIf(IsDBNull(ht("VendorCode")), "", ht("VendorCode"))))
                cmd.Parameters.Add(New SqlClient.SqlParameter("GrpBarang", ht("GrpBarang")))
                cmd.Parameters.Add(New SqlClient.SqlParameter("LastPrice", ht("LastPrice")))


                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Function G_UserType(ByVal user As String) As String
        Dim hasil As String = ""

        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand("select UserType from [User] where UserID=@UserID", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("UserID", user))

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = ""
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Sub IsiCustomer(ByRef combo As ComboBox)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select StorerKey,CustomerName from tbDORStorer union select 'All' as StorerKey,'All Customer' as CustomerName order by CustomerName"


                Dim ds As New DataSet
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    da.Fill(ds, "hasil")
                    combo.DataSource = ds.Tables(0)
                    combo.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                    combo.ValueMember = ds.Tables(0).Columns(0).ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Sub IsiNamaSite(ByRef combo As ComboBox)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select KodeSite,NamaSite from tbDORSite order by NamaSite"
                Dim ds As New DataSet
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    da.Fill(ds, "hasil")
                    combo.DataSource = ds.Tables(0)
                    combo.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                    combo.ValueMember = ds.Tables(0).Columns(0).ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Public Sub IsiDept(ByRef combo As ComboBox)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand("select distinct Department from tbATKUserConfig order by Department ", cn)
                cn.Open()
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Dim ds As New DataSet
                Try
                    da.Fill(ds, "hasil")
                    combo.DataSource = ds.Tables(0)
                    combo.DisplayMember = ds.Tables(0).Columns("Department").ColumnName
                    combo.ValueMember = ds.Tables(0).Columns("Department").ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Public Sub IsiPRNo(ByRef combo As ComboBox)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select PRNo from tbATKPRmain where isnull(Status_PO,0)='0' order by PRNo asc"
                Dim ds As New DataSet
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    da.Fill(ds, "hasil")
                    combo.DataSource = ds.Tables(0)
                    combo.DisplayMember = ds.Tables(0).Columns(0).ColumnName
                    combo.ValueMember = ds.Tables(0).Columns(0).ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Function G_MaxPRNo(ByVal strNamaSite As String) As String
        Dim hasil As String = ""
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(max(right(PRNo,5)),0)+1 as MaxRefNo from tbATKPRMain where substring(PRNo,7,4)='" & Format(Now.Date, "yyyy") & "' "

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = "PR" & strNamaSite & "." & Format(Now.Date, "yyyy") & "." & Microsoft.VisualBasic.Right(100000 + dr(0), 5)
                    End If
                Catch ex As Exception
                    hasil = ""
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function
    Public Function G_MaxGRNo(ByVal strNamaSite As String) As String
        Dim hasil As String = ""
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(max(right(GRNo,5)),0)+1 as MaxRefNo from tbATKMain where substring(GRNo,7,4)='" & Format(Now.Date, "yyyy") & "' "

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = "GR" & strNamaSite & "." & Format(Now.Date, "yyyy") & "." & Microsoft.VisualBasic.Right(100000 + dr(0), 5)
                    End If
                Catch ex As Exception
                    hasil = ""
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function
    Public Function G_PO(ByVal strNamaSite As String) As String
        Dim hasil As String = ""
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()

                'PO Counter by Site
                'cmd.CommandText = "select isnull(max(right(PONo,3)),0)+1 as MaxRefNo from tbATKPOMain where substring(PONo,7,6)='" & Format(Now.Date, "yyyyMM") & "' and left(PONo,5)='PO" & strNamaSite & "' "

                'PO tidak Counter by Site
                cmd.CommandText = "select isnull(max(right(PONo,5)),0)+1 as MaxRefNo from tbATKPOMain where substring(PONo,7,4)='" & Format(Now.Date, "yyyy") & "' "

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = "PO" & strNamaSite & "." & Format(Now.Date, "yyyyMM") & "." & Microsoft.VisualBasic.Right(100000 + dr(0), 5)
                    End If
                Catch ex As Exception
                    hasil = ""
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function


    Public Function G_MaxReqNo(ByVal strNamaSite As String) As String
        Dim hasil As String = ""
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "select isnull(max(right(ReqNo,4)),0)+1 as MaxRefNo from tbATKReqMain where substring(ReqNo,6,6)='" & Format(Now.Date, "yyyyMM") & "' and left(ReqNo,3)='" & strNamaSite & "' and left(ReqNo,5)='" & strNamaSite & "RQ'"

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = strNamaSite & "RQ" & Format(Now.Date, "yyyyMM") & Microsoft.VisualBasic.Right(10000 + dr(0), 4)
                    End If
                Catch ex As Exception
                    hasil = ""
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function

    Public Sub IsiMasterBarang(ByRef cmb As ComboBox, ByVal strGroup As String)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText = "Select KodeBarang,NamaBarang from tbATKmstbrg where status=1 and GrpBarang='" & strGroup & "' and KodeVendor <>'' and KodeVendor is not null union select 0 as KodeBarang,'' as NamaBarang order by NamaBarang"


                Dim ds As New DataSet
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    da.Fill(ds, "hasil")
                    cmb.DataSource = ds.Tables(0)
                    cmb.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                    cmb.ValueMember = ds.Tables(0).Columns(0).ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Public Sub IsiMasterBarang_ALL(ByRef cmb As ComboBox)
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText = "Select KodeBarang,NamaBarang from tbATKmstbrg where status=1 and KodeVendor <>'' and KodeVendor is not null union select 0 as KodeBarang,'' as NamaBarang order by NamaBarang"


                Dim ds As New DataSet
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    da.Fill(ds, "hasil")
                    cmb.DataSource = ds.Tables(0)
                    cmb.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                    cmb.ValueMember = ds.Tables(0).Columns(0).ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Function G_KodeWH(ByVal strNamaSite As String) As String
        Dim hasil As String = ""

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand("select KodeSite from [tbDORSite] where NamaSite=@NamaSite", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaSite", strNamaSite))

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = ""
                End Try
            End Using
        End Using
        Return hasil
    End Function
    Public Function KodeCustomer(ByVal strCustomer As String) As String
        Dim hasil As String = ""

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand("select CustomerName from tbDORStorer where Storerkey=@Storerkey", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("Storerkey", strCustomer))

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = ""
                End Try
            End Using
        End Using
        Return hasil
    End Function


    Public Function G_ReqProfile(ByVal strNoReq As String) As Hashtable
        Dim ht As New Hashtable
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select b.* from tbATKReqMain a inner join tbATKUserConfig b on a.InputBy= b.UserID where a.ReqNo='" & strNoReq.Trim & "'"

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        ', , , , , , , , , , LastUpdate, UpdatedBy
                        ht.Add("userid", dr!userID)
                        ht.Add("emailaddress", dr!EmailAddress)
                        ht.Add("site", dr!Site)
                        ht.Add("storerkey", dr!StorerKey)
                        ht.Add("adminatk", dr!AdminATK)
                        ht.Add("reqapproval", dr!ReqApproval)
                        ht.Add("prapproval", dr!PRApproval)
                        ht.Add("copyreq", dr!CopyReq)
                        ht.Add("copypr", dr!CopyPR)
                    End If
                Catch ex As Exception
                    ht.Clear()
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ht
    End Function

    Public Function G_PRProfile(ByVal strNoPR As String) As Hashtable
        Dim ht As New Hashtable
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = _
                "Select a.Status,lower(left(PRApproval, (case when ((charindex('@',PRApproval) - 1) < 0) then 0 else (charindex('@',PRApproval) - 1) end)))PRApp1, " & _
                "lower(left(PRApproval1, (case when ((charindex('@',PRApproval1) - 1) < 0) then 0 else (charindex('@',PRApproval1) - 1) end)))PRApp2 " & _
                ",b.* from tbATKPRMain a inner join tbATKUserConfig b on a.InputBy= b.UserID where a.PRNo='" & strNoPR.Trim & "' "

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        ', , , , , , , , , , LastUpdate, UpdatedBy
                        ht.Add("status", dr!Status)
                        ht.Add("userid", dr!userID)
                        ht.Add("emailaddress", dr!EmailAddress)
                        ht.Add("site", dr!Site)
                        ht.Add("storerkey", dr!StorerKey)
                        ht.Add("adminatk", dr!AdminATK)
                        ht.Add("adminga", dr!AdminGA)
                        ht.Add("reqapproval", dr!ReqApproval)
                        ht.Add("prappname", dr!PRAppName)
                        ht.Add("prapproval", dr!PRApproval)
                        ht.Add("prappname1", dr!PRAppName1)
                        ht.Add("prapproval1", dr!PRApproval1)
                        ht.Add("copyreq", dr!CopyReq)
                        ht.Add("copypr", dr!CopyPR)
                        ht.Add("jenisapproval", dr!JenisApproval)
                        ht.Add("prapp1", dr!PRApp1)
                        ht.Add("prapp2", dr!PRApp2)
                        ht.Add("apptittle", dr!AppTittle)
                        ht.Add("apptittle1", dr!AppTittle1)
                        ht.Add("department", dr!Department)

                    End If
                Catch ex As Exception
                    ht.Clear()
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ht
    End Function
    Public Function G_PRProfile_PO(ByVal strNoPO As String) As Hashtable
        Dim ht As New Hashtable
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText =
                "Select a.Status,lower(left(NSOApproval, (case when ((charindex('@',NSOApproval) - 1) < 0) then 0 else (charindex('@',NSOApproval) - 1) end)))POApp1, " &
                "lower(left(GMApproval, (case when ((charindex('@',GMApproval) - 1) < 0) then 0 else (charindex('@',GMApproval) - 1) end)))POApp2, " &
                "lower(left(CFOApproval, (case when ((charindex('@',CFOApproval) - 1) < 0) then 0 else (charindex('@',CFOApproval) - 1) end)))POApp3 " &
                ",AppName,NSOtittle,NSOAppName,NSOApproval,GMApproval,CFOApproval,CopyPR,EmailAddress from tbATKPOMain a inner join  " &
                "(select case when ApprovedBy1 is null then PRAppName else PRAppName1 end AppName,PRNo,b.* from tbATKPRMain a inner join " &
                "tbATKUserConfig b on a.InputBy=b.userID) b on a.PRNo= b.PRNo  where a.PONo='" & strNoPO & "' "

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        ', , , , , , , , , , LastUpdate, UpdatedBy
                        ht.Add("status", dr!Status)
                        ht.Add("nsotittle", dr!NSOTittle)
                        ht.Add("nsoappname", dr!NSOAppName)
                        ht.Add("nsoapproval", dr!NSOApproval)
                        ht.Add("gmapproval", dr!GMApproval)
                        ht.Add("cfoapproval", dr!CFOApproval)
                        ht.Add("poapp1", dr!POApp1)
                        ht.Add("poapp2", dr!POApp2)
                        ht.Add("poapp3", dr!POApp3)
                        ht.Add("appname", dr!AppName)
                        ht.Add("copypr", dr!CopyPR)
                        ht.Add("emailaddress", dr!EmailAddress)
                    End If
                Catch ex As Exception
                    ht.Clear()
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ht
    End Function

    Public Function G_UserProfile(ByVal strUserID As String) As Hashtable
        Dim ht As New Hashtable
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select * from tbATKUserConfig where UserID='" & strUserID.Trim & "'"

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        ', , , , , , , , , , LastUpdate, UpdatedBy
                        ht.Add("userid", dr!userID)
                        ht.Add("emailaddress", dr!EmailAddress)
                        ht.Add("site", dr!Site)
                        ht.Add("storerkey", dr!StorerKey)
                        ht.Add("adminatk", dr!AdminATK)
                        ht.Add("reqapproval", dr!ReqApproval)
                        ht.Add("prapproval", dr!PRApproval)
                        ht.Add("copyreq", dr!CopyReq)
                        ht.Add("copypr", dr!CopyPR)
                        ht.Add("department", dr!Department)
                    End If
                Catch ex As Exception
                    ht.Clear()
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ht
    End Function

    Public Sub IsiKaryawan(ByVal strLoc As String, ByRef combo As ComboBox)
        Using cn As New SqlClient.SqlConnection(strConnPusat)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select NIK,EmployeeName from tbabsmst WHERE lower(location)='" & strLoc & "' order by EmployeeName"


                Dim ds As New DataSet
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    da.Fill(ds, "hasil")
                    combo.DataSource = ds.Tables(0)
                    combo.DisplayMember = ds.Tables(0).Columns(1).ColumnName
                    combo.ValueMember = ds.Tables(0).Columns(0).ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Public Function IsMasterExist(ByVal KodeBarang As String) As Integer
        Dim hasil As Integer = -1

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand("Select KodeBarang,NamaBarang from tbATKmstbrg where NamaBarang=@NamaBarang ", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaBarang", KodeBarang.ToLower))

                Dim dr As SqlClient.SqlDataReader
                Try
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = 1
                    Else
                        hasil = -1
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
        Return hasil
    End Function
    Public Sub G_DataPRDetail(ByVal strPRNo As String, ByRef dgv As DataGridView)
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                    "Select a.TransID, a.KodeBarang, b.NamaBarang, a.UOM, a.Qty, a.Keterangan,isnull(a.LastPrice,0) LastPrice,isnull(a.EstTotPrice,0) EstTotPrice,isnull(a.PurchasedByGA,0)PurchasedByGA from tbATKPRDetails a left join tbATKmstbrg b on a.KodeBarang=b.KodeBarang where PRNo='" & strPRNo & "' order by a.TransID desc "
                cmd.Parameters.Clear()

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    dgv.RowCount = 0
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        dgv.RowCount = dgv.RowCount + 1
                        dgv.Item("TransID", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("TransID")
                        dgv.Item("KodeBarang", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("KodeBarang")
                        dgv.Item("NamaBarang", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("NamaBarang")
                        dgv.Item("UOM", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("UOM")
                        dgv.Item("Qty", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("Qty")
                        dgv.Item("Keterangan", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("Keterangan")
                        dgv.Item("LastPrice", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("LastPrice")
                        dgv.Item("EstTotPrice", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("EstTotPrice")
                        dgv.Item("PurchasedbyGA", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("PurchasedbyGA")
                    Next
                Catch ex As Exception
                    dgv.RowCount = 0
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        dgv.RowCount = dgv.RowCount + 1
                        dgv.Item("TransID", dgv.RowCount - 1).Value = ""
                        dgv.Item("KodeBarang", dgv.RowCount - 1).Value = ""
                        dgv.Item("NamaBarang", dgv.RowCount - 1).Value = ""
                        dgv.Item("UOM", dgv.RowCount - 1).Value = ""
                        dgv.Item("Qty", dgv.RowCount - 1).Value = ""
                        dgv.Item("Keterangan", dgv.RowCount - 1).Value = ""
                        dgv.Item("LastPrice", dgv.RowCount - 1).Value = ""
                        dgv.Item("EstTotPrice", dgv.RowCount - 1).Value = ""
                        dgv.Item("PurchasedbyGA", dgv.RowCount - 1).Value = ""
                    Next

                End Try
            End Using
        End Using

    End Sub
    Public Sub G_DataGRDetail(ByVal strGRNo As String, ByRef dgv As DataGridView)
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "select ROW_NUMBER() OVER (PARTITION BY GRNo ORDER BY a.KodeBarang) as ROW,Storerkey,a.KodeBarang,b.Keterangan as NamaBarang,a.UOM,isnull(QtyToReceive,0)QtyToReceive,a.Qty,NamaSite from tbATKmain a inner join tbATKPODetails b on a.KodeBarang=b.KodeBarang and a.POno=b.PONo  where GRNo='" & strGRNo & "'"
                cmd.Parameters.Clear()

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    dgv.RowCount = 0
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        dgv.RowCount = dgv.RowCount + 1
                        dgv.Item("NoUrut", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("Row")
                        dgv.Item("Storerkey", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("Storerkey")
                        dgv.Item("KodeBarang", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("KodeBarang")
                        dgv.Item("NamaBarang", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("NamaBarang")
                        dgv.Item("UOM", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("UOM")
                        dgv.Item("SisaPO", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("QtyToReceive")
                        dgv.Item("QtyGR", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("Qty")
                        dgv.Item("WHAsal", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("NamaSite")

                    Next
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub
    Public Sub G_DataPODetail(ByVal strPONo As String, ByRef dgv As DataGridView)
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "Select a.TransID, a.PRNo,a.KodeBarang, Keterangan as NamaBarang, a.UOM, a.Qty,isnull(a.LastPrice,0) LastPrice,isnull(a.EstTotPrice,0) EstTotPrice,isnull(a.PurchasedByGA,0)PurchasedByGA from tbATKPODetails a  where PONo='" & strPONo & "' order by a.TransID desc "
                cmd.Parameters.Clear()

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    dgv.RowCount = 0
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        dgv.RowCount = dgv.RowCount + 1
                        dgv.Item("TransID", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("TransID")
                        dgv.Item("PRNo", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("PRNo")
                        dgv.Item("KodeBarang", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("KodeBarang")
                        dgv.Item("NamaBarang", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("NamaBarang")
                        dgv.Item("UOM", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("UOM")
                        dgv.Item("Qty", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("Qty")
                        'dgv.Item("Keterangan", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("Keterangan")
                        dgv.Item("HargaSatuan", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("LastPrice")
                        dgv.Item("Jumlah", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("EstTotPrice")
                        dgv.Item("PurchasedbyGA", dgv.RowCount - 1).Value = ds.Tables(0).Rows(i)("PurchasedbyGA")
                    Next
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub
    Public Function ShowDataHarga(ByVal strPRNo As String) As DataSet
        Dim ds As New DataSet

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                Try
                    cn.Open()
                    cmd.Connection = cn
                    cmd.CommandText = _
                    "Select sum(EstTotPrice)EstTotPrice from tbATKPRDetails where PRNo='" & strPRNo & "' "
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception
                    ds = New DataSet
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ds
    End Function
    Public Function ShowDataHarga_PO(ByVal strPONo As String) As DataSet
        Dim ds As New DataSet

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                Try
                    cn.Open()
                    cmd.Connection = cn
                    cmd.CommandText =
                    "Select sum(isnull(a.LastPrice,0)) LastPrice,sum(isnull(a.EstTotPrice,0)) EstTotPrice,PO.KodeVendor,Po.PONo from tbATKPOMain PO " &
                    "inner join tbATKPODetails a On PO.PONo=a.PONo " &
                    "left join (select KodeBarang,isnull(KodeVendor,'Agility')KodeVendor,NamaBarang from tbATKmstbrg )b " &
                    "On a.KodeBarang=b.KodeBarang And PO.KodeVendor=b.KodeVendor " &
                    "where PO.PONo='" & strPONo & "' " &
                    "group by PO.KodeVendor,Po.PONo "

                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception
                    ds = New DataSet
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ds
    End Function
    Public Function Show_Details_PO(ByVal strPONo As String) As DataSet
        Dim ds As New DataSet

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                Try
                    cn.Open()
                    cmd.Connection = cn
                    cmd.CommandText =
                    "Select PONo,a.KodeBarang,Keterangan,EndUserName As Storerkey,UOM,Qty,LastPrice,EstTotPrice,isnull(a.PurchasedbyGA,0)PurchasedbyGA,AppName  " &
                    "from tbatkpodetails a inner join  (select case when ApprovedBy1 is null then PRAppName else PRAppName1 end AppName,PRNo,b.* " &
                    "from tbATKPRMain a inner join tbATKUserConfig b on a.InputBy=b.userID) b on a.PRNo= b.PRNo " &
                    "where a.PONo='" & strPONo & "' "
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                Catch ex As Exception
                    ds = New DataSet
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return ds
    End Function
    Public Function G_NoPR(ByVal strNoPR As String) As Integer
        Dim hasil As New Integer
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "Select TransID From tbATKPRMain Where PRNo = @PRNo"

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", strNoPR))

                Try
                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function
    Public Function G_NoGR(ByVal strNoGR As String) As Integer
        Dim hasil As New Integer
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "Select TransID From tbReceivingMain Where GRNo = @GRNo"

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("GRNo", strNoGR))

                Try
                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function
    Public Function G_PONo(ByVal strPONo As String) As Integer
        Dim hasil As New Integer
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "Select TransID From tbATKPOMain Where PONo = @PONo"

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", strPONo))

                Try
                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = dr(0)
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return hasil
    End Function

End Module
