Public Class frmUserConfig

    Private Sub frmUserConfig_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmUserConfig_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        IsiCustomer(Me.cbCustomer)

        IsiNamaSite(Me.cbSite)
        Me.cbSite.SelectedValue = G_KodeWH(htUser("site"))

        Me.ShowAllData()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs)


        If Me.txtTransID.Text.Trim = "" Then
            INSERT_DATA()
        Else
            UPDATE_DATA()
        End If

        Me.ShowAllData()
        ClearData()
    End Sub

    Private Sub ClearData()
        Me.txtTransID.Text = ""
        Me.txtUserID.Text = ""
        Me.txtEmailAddress.Text = ""
        Me.cbSite.SelectedIndex = -1
        Me.cbCustomer.SelectedIndex = -1
        Me.txtAdminATK.Text = ""
        Me.txtReqApproval.Text = ""
        Me.txtPRApproval.Text = ""
        Me.txtCopyReq.Text = ""
        Me.txtCopyPR.Text = ""
        Me.txtLastUpdate.Text = ""
        Me.txtUpdatedBy.Text = ""
    End Sub

    Private Sub ShowAllData()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "Select TransID, userID, EmailAddress, Site, StorerKey, AdminATK, ReqApproval, PRApproval, CopyReq, CopyPR, LastUpdate, UpdatedBy from tbATKUserConfig order by UserID"

                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Try
                    Dim ds As New DataSet
                    da.Fill(ds, "hasil")
                    Me.DataGridView1.DataSource = ds.Tables(0)
                Catch ex As Exception

                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub INSERT_DATA()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "INSERT INTO tbATKUserConfig (userID, EmailAddress, Site, StorerKey, AdminATK, ReqApproval, PRApproval, CopyReq, CopyPR, LastUpdate, UpdatedBy) " &
                                "values (@userID, @EmailAddress, @Site, @StorerKey, @AdminATK, @ReqApproval, @PRApproval, @CopyReq, @CopyPR, getdate(), @UpdatedBy)"

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("userID", Me.txtUserID.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("EmailAddress", Me.txtEmailAddress.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Site", cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("StorerKey", Me.cbCustomer.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("AdminATK", Me.txtAdminATK.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("ReqApproval", Me.txtReqApproval.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRApproval", Me.txtPRApproval.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("CopyReq", Me.txtCopyReq.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("CopyPR", Me.txtCopyPR.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UpdatedBy", strUserName))

                Try
                    cmd.ExecuteNonQuery()
                    MsgBox("Tambah Data Sukses")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub UPDATE_DATA()
        Using cn As New SqlClient.SqlConnection(strCOnnLocal)
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = cn
                cn.Open()
                cmd.CommandText = "UPDATE tbATKUserConfig SET userID=@userID, EmailAddress=@EmailAddress, Site=@Site, StorerKey=@StorerKey, AdminATK=@AdminATK, ReqApproval=@ReqApproval, PRApproval=@PRApproval, CopyReq=@CopyReq, CopyPR=@CopyPR, LastUpdate=getdate(), UpdatedBy=@UpdatedBy WHERE TransID=@TransID"

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlClient.SqlParameter("TransID", Me.txtTransID.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("userID", Me.txtUserID.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("EmailAddress", Me.txtEmailAddress.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("Site", cbSite.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("StorerKey", Me.cbCustomer.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("AdminATK", Me.txtAdminATK.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("ReqApproval", Me.txtReqApproval.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("PRApproval", Me.txtPRApproval.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("CopyReq", Me.txtCopyReq.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("CopyPR", Me.txtCopyPR.Text.Trim))
                cmd.Parameters.Add(New SqlClient.SqlParameter("UpdatedBy", strUserName))

                Try
                    cmd.ExecuteNonQuery()
                    MsgBox("Update Data Sukses")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        Me.txtTransID.Text = Me.DataGridView1.Item("TransID", Me.DataGridView1.CurrentRow.Index).Value
        Me.txtUserID.Text = Me.DataGridView1.Item("userID", Me.DataGridView1.CurrentRow.Index).Value
        Me.txtEmailAddress.Text = Me.DataGridView1.Item("EmailAddress", Me.DataGridView1.CurrentRow.Index).Value
        'Me.cbSite.SelectedText = Me.DataGridView1.Item("Site", Me.DataGridView1.CurrentRow.Index).Value
        Me.cbSite.SelectedValue = G_KodeWH(Me.DataGridView1.Item("Site", Me.DataGridView1.CurrentRow.Index).Value)
        Me.cbCustomer.SelectedValue = Me.DataGridView1.Item("StorerKey", Me.DataGridView1.CurrentRow.Index).Value
        Me.txtAdminATK.Text = Me.DataGridView1.Item("AdminATK", Me.DataGridView1.CurrentRow.Index).Value
        Me.txtReqApproval.Text = Me.DataGridView1.Item("ReqApproval", Me.DataGridView1.CurrentRow.Index).Value
        Me.txtPRApproval.Text = Me.DataGridView1.Item("PRApproval", Me.DataGridView1.CurrentRow.Index).Value
        Me.txtCopyReq.Text = Me.DataGridView1.Item("CopyReq", Me.DataGridView1.CurrentRow.Index).Value
        Me.txtCopyPR.Text = Me.DataGridView1.Item("CopyPR", Me.DataGridView1.CurrentRow.Index).Value
        Me.txtLastUpdate.Text = Me.DataGridView1.Item("LastUpdate", Me.DataGridView1.CurrentRow.Index).Value
        Me.txtUpdatedBy.Text = Me.DataGridView1.Item("UpdatedBy", Me.DataGridView1.CurrentRow.Index).Value()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class