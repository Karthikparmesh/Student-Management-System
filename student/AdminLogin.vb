Public Class AdminLogin


    Dim Sql As MySql = New MySql()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            If Sql.Login("SELECT count(*) As UserCount
  FROM admin where username='" + userName.Text + "'and password ='" + Password.Text + "'") = 1 Then

                MsgBox("Logged In")
                Me.Close()
                Adminform.Show()
            Else
                MsgBox("Wrong Username or password")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try



    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged

    End Sub

    Private Sub userName_TextChanged(sender As Object, e As EventArgs) Handles userName.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class