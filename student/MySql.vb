Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Public Class MySql


    Public conn As New MySqlConnection("server=127.0.0.1;uid=root;port=3306;database=student;password=123456")


    Public Function SelectQuery(Query As String, mtable As DataGridView)
        Try

            conn.Open()



            Dim adp As MySqlDataAdapter = New MySqlDataAdapter(Query, conn)

            Dim ds As DataSet = New DataSet()
            adp.Fill(ds)

            mtable.DataSource = ds

            conn.Close()
            Return ds
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Function

    Public Sub InsertQuery(q As String)
        Try
            conn.Open()

            Dim cmd As MySqlCommand = New MySqlCommand(q, conn)
            cmd.ExecuteScalar()
            MsgBox("Table altered successfully successfully")
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
        conn.Close()
    End Sub

    Public Function Login(q As String) As String
        Try
            conn.Open()

            Dim myAdapter As New MySqlDataAdapter

            Dim myCommand As New MySqlCommand(q, conn)


            Dim myData As MySqlDataReader

            myData = myCommand.ExecuteReader()
            If myData.HasRows Then
                myData.Read()
                Dim count As Integer = myData(0)
                conn.Close()
                Return count
            End If
            conn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
        conn.Close()
        Return 0
    End Function

    Public Sub deleteQuery(Query As String)
        Try
            conn.Open()
            Dim myCommand As New MySqlCommand(Query, conn)
            myCommand.ExecuteNonQuery()
            conn.Close()
            MsgBox("Deleted  successfully")
        Catch ex As Exception

            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

End Class
