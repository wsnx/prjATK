Public Class frmUOM
    Public strIDBarang As String
    Public strDefUOM As String

    Private Sub frmUOM_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Validasi() = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub frmUOM_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.TampilkanData()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim ht As New Hashtable
        If Validasi() = False Then Exit Sub
        For i As Integer = 0 To Me.DataGridView1.RowCount - 2
            If IsDBNull(Me.DataGridView1.Item("TransID", i).Value) Or Me.DataGridView1.Item("TransID", i).Value = Nothing Then
                ht.Clear()
                ht.Add("KodeBarang", Me.txtIDBarang.Text)
                ht.Add("UOM", Me.DataGridView1.Item("UOM", i).Value)
                ht.Add("Conversi", Me.DataGridView1.Item("Conversi", i).Value)

                INSERTDataUOM(ht)

            Else
                ht.Clear()
                ht.Add("TransID", Me.DataGridView1.Item("TransID", i).Value)
                ht.Add("UOM", Me.DataGridView1.Item("UOM", i).Value)
                ht.Add("Conversi", Me.DataGridView1.Item("Conversi", i).Value)

                UPDATEDataUOM(ht)
            End If
        Next
        MsgBox("Data Saved")
        TampilkanData()
    End Sub

    Private Function Validasi() As Boolean
        Dim hasil As Boolean = False
        Dim ada As Integer = 0
        For i As Integer = 0 To Me.DataGridView1.RowCount - 2
            If Me.DataGridView1.Item("Conversi", i).Value = 1 Then
                ada = ada + 1
                strDefUOM = Me.DataGridView1.Item("UOM", i).Value
            End If
        Next

        If ada = 1 Then
            hasil = True
        ElseIf ada > 1 Then
            hasil = False
            MsgBox("Conversi = 1, harus ada 1 tidak boleh lebih")
        Else
            MsgBox("Belum ada UOM dengan Conversi = 1, Silahkan diperbaharui")
            hasil = False
        End If

        Return hasil
    End Function


    Private Sub TampilkanData()
        Using cn As New SqlClient.SqlConnection(strConnLocal)
            Using cmd As New SqlClient.SqlCommand("Select TransID,UOM,Conversi from [tbATKuombrg] Where KodeBarang=@KodeBarang", cn)
                cn.Open()
                cmd.Parameters.Add(New SqlClient.SqlParameter("KodeBarang", Me.txtIDBarang.Text))

                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Dim ds As New DataSet
                Try
                    da.Fill(ds, "hasil")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Me.DataGridView1.RowCount = 1
                        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                            Me.DataGridView1.RowCount = Me.DataGridView1.RowCount + 1
                            Me.DataGridView1.Item("TransID", Me.DataGridView1.RowCount - 2).Value = ds.Tables(0).Rows(i)("TransID")
                            Me.DataGridView1.Item("UOM", Me.DataGridView1.RowCount - 2).Value = ds.Tables(0).Rows(i)("UOM")
                            Me.DataGridView1.Item("Conversi", Me.DataGridView1.RowCount - 2).Value = ds.Tables(0).Rows(i)("Conversi")
                        Next
                    End If
                Catch ex As Exception
                    hasil = -1
                    MsgBox(ex.Message)
                    hasil = False
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        'If Validasi() = True Then
        '    Me.Hide()
        'End If
        Me.Close()

    End Sub

End Class