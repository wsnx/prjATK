Public Class FrmGeneratePO
    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub FrmGeneratePO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsiPRNo(Me.ComboBox1)
        ShowData()
    End Sub
    Private Sub ShowData()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText = "Select PONo,PRNo,KodeVendor,TglTransaksi,Status from tbATKPOmain where Status='0' Order By PONo asc "
                    Dim ds As New DataSet
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    da.Fill(ds, "hasil")
                    Me.DataGridView1.DataSource = ds.Tables(0)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub UpdateStatus_PR(ByVal strPRNo As String)
        Dim ds As DataSet = New DataSet
        Using cn As New SqlClient.SqlConnection()
            Using cmd As New SqlClient.SqlCommand

                cn.ConnectionString = strCOnnLocal


                cmd.Connection = cn
                cn.Open()

                strSQL = "Update tbATKPRMain set Status_PO='1',Status='8' Where PRNo=@PRNo"

                'strSQL = "Select 'TWahyuningsih@agility.com' as EmailAddress"
                cmd.CommandTimeout = 3000
                cmd.CommandText = strSQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", strPRNo))
                'cmd.Parameters.Add(New SqlClient.SqlParameter("StatusPO", StatusPO))
                'cmd.Parameters.Add(New SqlClient.SqlParameter("Status", StatusPR))
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

    End Sub
    Private Function G_DataPR(ByVal Row As Integer) As DataSet
        Dim strSQL As String = ""
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                "select * from (select ROW_NUMBER() OVER (ORDER BY KodeVendor) AS Row,* from (select distinct a.PRNO,isnull(KodeVendor,'Agility')KodeVendor,NamaSite from tbATKPRDetails a left join tbATKmstbrg  b on a.KodeBarang = b.KodeBarang inner join tbATKPRMain c on a.PRNo=c.PRNo where a.PRNo='" & Me.ComboBox1.Text.Trim & "')a)b where Row='" & Row & "' "

                Dim da As New SqlClient.SqlDataAdapter(cmd)

                Try
                    da.Fill(ds, "hasil")

                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = ""
                End Try
            End Using
        End Using
        Return ds
    End Function
    Private Function MinRow() As DataSet
        Dim strSQL As String = ""
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                "select Min(Row)as MinRow from(select ROW_NUMBER() OVER (ORDER BY KodeVendor) AS Row,* from (select distinct PRNO,isnull(KodeVendor,'Agility')KodeVendor from tbATKPRDetails a left join tbATKmstbrg  b on a.KodeBarang = b.KodeBarang where a.PRNo='" & Me.ComboBox1.Text.Trim & "')a)b "

                Dim da As New SqlClient.SqlDataAdapter(cmd)

                Try
                    da.Fill(ds, "hasil")

                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = ""
                End Try
            End Using
        End Using
        Return ds
    End Function
    Private Function MaxRow() As DataSet
        Dim strSQL As String = ""
        Dim ds As New DataSet
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                "select Max(Row)as MaxRow from(select ROW_NUMBER() OVER (ORDER BY KodeVendor) AS Row,* from (select distinct PRNO,isnull(KodeVendor,'Agility')KodeVendor from tbATKPRDetails a left join tbATKmstbrg  b on a.KodeBarang = b.KodeBarang where a.PRNo='" & Me.ComboBox1.Text.Trim & "')a)b "

                Dim da As New SqlClient.SqlDataAdapter(cmd)

                Try
                    da.Fill(ds, "hasil")

                Catch ex As Exception
                    MsgBox(ex.Message)
                    hasil = ""
                End Try
            End Using
        End Using
        Return ds
    End Function
    Public Function ColumnLetterToColumnIndex(baris As Integer, columnLetter As String) As Integer
        columnLetter = columnLetter.ToUpper()
        Dim sum As Integer = 0

        'For i As Integer = 0 To columnLetter.Length - 1
        'sum *= 26
        'Dim charA As Integer = Char.GetNumericValue("A")
        'Dim charColLetter As Integer = Char.GetNumericValue(columnLetter(i))
        'sum += (charColLetter - charA) + 1
        'Next

        For i As Integer = 0 To columnLetter.Length - 1
            sum *= 26
            Dim charA As Integer = Asc(columnLetter(i)) - 64
            sum += charA
        Next
        Return sum
    End Function
    Private Sub INSERTDATA()
        Dim ds As New DataSet
        Dim Min As New DataSet
        Dim Max As New DataSet
        Min = MinRow()
        Max = MaxRow()
        Dim strVendor As String = ""
        Dim strPO As String = ""

        'strPO = G_PO(ds.Tables(0).Rows(0)("KodeVendor"))


        For i As Integer = Min.Tables(0).Rows(0)("MinRow") To Max.Tables(0).Rows(0)("MaxRow")
            ds = G_DataPR(i)
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                strPO = G_PO(G_KodeWH(ds.Tables(0).Rows(j)("NamaSite")))

                'Insert data PO MAIN
                Using cn As New SqlClient.SqlConnection(strCOnnLocal)
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cn.Open()

                        cmd.CommandText =
                        "INSERT INTO tbATKPOMain (WHAsal,PONo,PRNo,KodeVendor,TglTransaksi,Status,InputBy) VALUES (@WHAsal,@PONo,@PRNo,@KodeVendor,@TglTransaksi,0,@InputBy)"
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add(New SqlClient.SqlParameter("WHAsal", ds.Tables(0).Rows(j)("NamaSite")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", strPO))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("PRNo", ds.Tables(0).Rows(j)("PRNo")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("KodeVendor", ds.Tables(0).Rows(j)("KodeVendor")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("TglTransaksi", Format(Now.Date, "yyyy/MM/dd")))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("InputBy", strUserName))

                        Try
                            cmd.ExecuteNonQuery()

                            'Dim dr As SqlClient.SqlDataReader
                            'cmd.CommandText = "Select max(TransID) as TransID from tbATKPOMain"

                            'dr = cmd.ExecuteReader
                            'If dr.Read() Then
                            '    Me.txtTransID.Text = dr(0)
                            'End If
                        Catch ex As Exception

                            MsgBox(ex.Message)
                        End Try

                    End Using
                End Using
            Next
        Next

    End Sub
    Private Sub ShowDataDetails()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText =
                    "Select a.KodeBarang, b.NamaBarang, a.UOM, a.Qty, isnull(a.LastPrice,0) LastPrice,isnull(a.EstTotPrice,0) EstTotPrice from tbATKPOMain PO " &
                    "inner join tbATKPRDetails a On PO.PRNo=a.PRNo inner join (select KodeBarang,isnull(KodeVendor,'Agility')KodeVendor,NamaBarang from tbATKmstbrg )b on a.KodeBarang=b.KodeBarang and PO.KodeVendor=b.KodeVendor  " &
                    "where PO.PONo=@PONo order by b.NamaBarang desc"
                cmd.Parameters.Clear()

                cmd.Parameters.Add(New SqlClient.SqlParameter("PONo", Me.DataGridView1.Item("PONo", Me.DataGridView1.CurrentRow.Index).Value))

                Try
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "hasil")
                    Me.DataGridView2.DataSource = ds.Tables(0)
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub btnGeneratePO_Click(sender As Object, e As EventArgs) Handles btnGeneratePO.Click
        INSERTDATA()
        UpdateStatus_PR(Me.ComboBox1.Text.Trim)
        FrmGeneratePO_Load(Nothing, Nothing)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ShowDataDetails()
    End Sub
End Class