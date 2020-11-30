Public Class frmMasterData

    Private Sub frmMasterData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet

        ds = G_DataMasterBarang()
        Me.DataGridView1.DataSource = ds.Tables(0)

        ShowVendor()

    End Sub
    Private Sub ShowVendor()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand("select SupplierID,CompanyName from tbATKmstcompany where SupplierID is not null order by SupplierID asc ", cn)
                cn.Open()
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Dim ds As New DataSet
                Try
                    da.Fill(ds, "hasil")
                    Me.cbVendor.DataSource = ds.Tables(0)
                    Me.cbVendor.DisplayMember = ds.Tables(0).Columns("CompanyName").ColumnName
                    Me.cbVendor.ValueMember = ds.Tables(0).Columns("SupplierID").ColumnName
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmUOM

        frm.txtIDBarang.Text = Me.txtIDBarang.Text
        frm.txtNamaBarang.Text = Me.txtNamaBarang.Text
        frm.ShowDialog()
        If frm.strDefUOM.Trim <> "" Or frm.strDefUOM = Nothing Then
            Me.txtUOM.Text = frm.strDefUOM.Trim
        End If
        frm.Dispose()

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Me.txtIDBarang.Text = IIf(IsDBNull(Me.DataGridView1.Item("IDBarang", e.RowIndex).Value), "", Me.DataGridView1.Item("IDBarang", e.RowIndex).Value)
        Me.txtNamaBarang.Text = Me.DataGridView1.Item("NamaBarang", e.RowIndex).Value
        Me.txtUOM.Text = Me.DataGridView1.Item("UOM", e.RowIndex).Value
        Me.txtLastPrice.Text = Me.DataGridView1.Item("LastPrice", e.RowIndex).Value
        Me.cbGrpBarang.Text = Me.DataGridView1.Item("GrpBarang", e.RowIndex).Value
        Me.cbVendor.Text = Me.DataGridView1.Item("VendorCode", e.RowIndex).Value
        'Me.txtMinStock.Text = IIf(IsDBNull(Me.DataGridView1.Item("MinStock", e.RowIndex).Value), "", Me.DataGridView1.Item("MinStock", e.RowIndex).Value)
        'Me.txtReorderQty.Text = IIf(IsDBNull(Me.DataGridView1.Item("ReOrderQty", e.RowIndex).Value), "", Me.DataGridView1.Item("ReOrderQty", e.RowIndex).Value)
        If Me.DataGridView1.Item("Status", e.RowIndex).Value = 1 Then
            Me.ckStatus.Checked = True
        Else
            Me.ckStatus.Checked = False
        End If

    End Sub


    Private Sub BtnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCari.Click
        CariMaster()
    End Sub
    Private Sub CariMaster()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand("Select KodeBarang,NamaBarang,UOM,LastPrice,isnull(KodeVendor,'')KodeVendor,isnull(GrpBarang,'')GrpBarang,InputDate,Status from tbATKmstbrg where NamaBarang like '%" & Me.txtNamaBarang.Text.Trim & "%' Order by grpbarang,namabarang ")
                Try
                    cmd.Connection = cn
                    cn.Open()
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

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim ht As New Hashtable
        If Me.txtIDBarang.Text.Trim = "" Then
            ht.Clear()
            ht.Add("NamaBarang", Me.txtNamaBarang.Text.Trim)
            ht.Add("UOM", Me.txtUOM.Text.Trim)
            ht.Add("LastPrice", Me.txtLastPrice.Text)
            ht.Add("VendorCode", Me.cbVendor.SelectedValue)
            ht.Add("GrpBarang", Me.cbGrpBarang.Text)
            If Me.ckStatus.Checked = True Then
                ht.Add("Status", 1)
            Else
                ht.Add("Status", 0)
            End If
            INSERTDataBrg(ht)
        Else
            ht.Clear()
            ht.Add("KodeBarang", Me.txtIDBarang.Text)
            ht.Add("NamaBarang", Me.txtNamaBarang.Text.Trim)
            ht.Add("UOM", Me.txtUOM.Text.Trim)
            ht.Add("LastPrice", Me.txtLastPrice.Text)
            ht.Add("VendorCode", Me.cbVendor.SelectedValue)
            ht.Add("GrpBarang", Me.cbGrpBarang.Text)
            If Me.ckStatus.Checked = True Then
                ht.Add("Status", 1)
            Else
                ht.Add("Status", 0)
            End If

            UPDATEDataBrg(ht)
        End If
        BtnCari_Click(Nothing, Nothing)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Me.txtIDBarang.Text = ""
        Me.txtNamaBarang.Text = ""
        Me.txtUOM.Text = ""
        Me.txtLastPrice.Text = ""
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteItem()
        BtnCari_Click(Nothing, Nothing)
    End Sub
    Private Sub DeleteItem()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Delete tbATKmstbrg where KodeBarang=@KodeBarang "
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.txtIDBarang.Text))
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
    End Sub
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        btnNew_Click(Nothing, Nothing)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        btnSave_Click_1(Nothing, Nothing)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        btnDelete_Click(Nothing, Nothing)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
