Public Class Marks
    Dim SQL As MySql = New MySql()
    Dim conn As MySqlConnection = SQL.conn
    Private Sub Marks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim query As String = "Select sd.subject_code,sd.subject_name,m.marks FROM student.subjects As sd
inner Join student.marks as m on sd.subject_code=m.subject_code
where m.username ='" & TextBox1.Text & "';"
        conn.Open()
            Dim myAdapter2 As New MySqlDataAdapter
        Dim myCommand2 As New MySqlCommand(query, conn)
        myAdapter2.SelectCommand = myCommand2
            Dim myData2 As MySqlDataReader
            myData2 = myCommand2.ExecuteReader()
        DataGridView1.ColumnCount = 0
        DataGridView1.ColumnCount = 3
        DataGridView1.Columns(0).Name = "Subject Code"

        DataGridView1.Columns(1).Name = "Subject Name"
        DataGridView1.Columns(2).Name = "Marks"
        DataGridView1.Rows.Clear()
        If myData2.HasRows Then
            While myData2.Read()
                Dim row As String() = New String() {myData2(0).ToString, myData2(1).ToString, myData2(2).ToString}
                DataGridView1.Rows.Add(row)
            End While
            End If
            conn.Close()
    End Sub
End Class