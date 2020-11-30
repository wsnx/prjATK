Public Class frmMaster

    Private Sub frmMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand("select distinct UOM from tbATKmstbrg union select '' UOM Order By UOM asc", cn)
                cn.Open()
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Dim ds As New DataSet
                Try
                    da.Fill(ds, "hasil")
                    Me.cbUOM.DataSource = ds.Tables(0)
                    Me.cbUOM.ValueMember = ds.Tables(0).Columns("UOM").ColumnName
                    Me.cbUOM.DisplayMember = ds.Tables(0).Columns("UOM").ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand("select distinct GrpBarang from tbATKmstbrg where GrpBarang is not null union select '' GrpBarang Order By GrpBarang asc", cn)
                cn.Open()
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Dim ds As New DataSet
                Try
                    da.Fill(ds, "hasil")
                    Me.cbGroupBarang.DataSource = ds.Tables(0)
                    Me.cbGroupBarang.ValueMember = ds.Tables(0).Columns("GrpBarang").ColumnName
                    Me.cbGroupBarang.DisplayMember = ds.Tables(0).Columns("GrpBarang").ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                '1502030001'
                cmd.CommandText = _
                    "INSERT INTO tbATKmstbrg (NamaBarang,UOM,GrpBarang ,Status) VALUES (@NamaBarang,@UOM,@GrpBarang ,1)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("NamaBarang", Me.txtNamaBarang.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UOM", Me.cbUOM.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("GrpBarang", Me.cbGroupBarang.Text))

                Try
                    cmd.ExecuteNonQuery()

                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using

        IsiMasterBarang(frmPR.cbNamaBarang, cbGroupBarang.Text)

        Close()

    End Sub
End Class