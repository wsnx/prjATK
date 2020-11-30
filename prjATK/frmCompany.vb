Public Class frmCompany

    Private Sub frmCompany_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowData()
    End Sub

    Sub ShowData()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText = "Select * from tbATKmstCompany Order By CompanyName"
                    Dim da As New SqlClient.SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "hasil")
                    Me.DataGridView1.DataSource = ds.Tables(0)

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmCompany_Load(Nothing, Nothing)
        If cekData(Me.txtCompany.Text) = True Then
            UpdateData()
            MsgBox("Saved")
        Else
            Simpan()
            MsgBox("Saved")
        End If

    End Sub
    Private Function cekData(ByVal strCompany As String) As Boolean

        Dim hasil As Boolean = False

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()

                cmd.CommandText =
                "Select TransID from tbATKmstCompany WHERE CompanyName='" & strCompany & "' "

                Try

                    Dim dr As SqlClient.SqlDataReader
                    dr = cmd.ExecuteReader
                    If dr.Read() Then
                        hasil = True
                    End If

                Catch ex As Exception
                    hasil = False
                    MsgBox(ex.Message)
                End Try

            End Using
        End Using
        Return hasil
    End Function
    Private Sub Simpan()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText = "Insert into [dbo].[tbATKmstCompany] (CompanyName,Address1,Address2,Address3,Phone,PIC,SupplierID,[TOP],Email)values(@Company,@Address1,@Address2,@Address3,@Tlp,@Attn,@SupplierID,@TOP,@Email) "
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Company", Me.txtCompany.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address1", Me.txtAddress1.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address2", Me.txtAddress2.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address3", Me.txtAddress3.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Tlp", Me.txtTlp.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Attn", Me.TxtAttnTo.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("SupplierID", Me.txtSupplierID.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("TOP", Me.txtTOP.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Email", Me.txtEmail.Text))
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End Using
        End Using
    End Sub
    Private Sub UpdateData()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                Try
                    cmd.CommandText = "Update [dbo].[tbATKmstCompany] Set SupplierID=@SupplierID,Address1=@Address1,Address2=@Address2,Address3=@Address3,Phone=@Phone,PIC=@PIC,Email=@Email,[Top]=@Top where CompanyName=@Company "
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Company", Me.txtCompany.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address1", Me.txtAddress1.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address2", Me.txtAddress2.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Address3", Me.txtAddress3.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Phone", Me.txtTlp.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("PIC", Me.TxtAttnTo.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("SupplierID", Me.txtSupplierID.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("TOP", Me.txtTOP.Text))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("Email", Me.txtEmail.Text))
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Me.txtSupplierID.Text = IIf(IsDBNull(Me.DataGridView1.Item("SupplierID", e.RowIndex).Value), "", Me.DataGridView1.Item("SupplierID", e.RowIndex).Value)
        Me.txtCompany.Text = Me.DataGridView1.Item("CompanyName", e.RowIndex).Value
        Me.txtAddress1.Text = IIf(IsDBNull(Me.DataGridView1.Item("Address1", e.RowIndex).Value), "", Me.DataGridView1.Item("Address1", e.RowIndex).Value)
        Me.txtAddress2.Text = IIf(IsDBNull(Me.DataGridView1.Item("Address2", e.RowIndex).Value), "", Me.DataGridView1.Item("Address2", e.RowIndex).Value)
        Me.txtAddress3.Text = IIf(IsDBNull(Me.DataGridView1.Item("Address3", e.RowIndex).Value), "", Me.DataGridView1.Item("Address3", e.RowIndex).Value)
        Me.txtTlp.Text = IIf(IsDBNull(Me.DataGridView1.Item("Phone", e.RowIndex).Value), "", Me.DataGridView1.Item("Phone", e.RowIndex).Value)
        Me.txtEmail.Text = IIf(IsDBNull(Me.DataGridView1.Item("Email", e.RowIndex).Value), "", Me.DataGridView1.Item("Email", e.RowIndex).Value)
        Me.TxtAttnTo.Text = IIf(IsDBNull(Me.DataGridView1.Item("PIC", e.RowIndex).Value), "", Me.DataGridView1.Item("PIC", e.RowIndex).Value)
        Me.txtTOP.Text = Me.DataGridView1.Item("TOP", e.RowIndex).Value

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "delete tbATKMstCompany where CompanyName=@CompanyName"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("CompanyName", Me.txtCompany.Text.Trim))

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        ShowData()
    End Sub
End Class