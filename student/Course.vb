Imports MySql.Data
Public Class Course


    Dim SQL As MySql = New MySql()
    Private Sub Course_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer = 1
        For i = 1 To 8
            ComboBox1.Items.Add(i)
            ComboBox2.Items.Add(i)



        Next


    End Sub

    Private Sub MyTabControl_SelectedIndexChanged(ByVal sender As Object,
                                              ByVal e As System.EventArgs) _
            Handles TabControl1.SelectedIndexChanged

        Dim indexOfSelectedTab As Integer = TabControl1.SelectedIndex
        Dim selectedTab As System.Windows.Forms.TabPage = TabControl1.SelectedTab
        If selectedTab.Name = "TabPage3" Then
            DataGridView1.Rows.Clear()
            Dim conn As MySqlConnection = SQL.conn
            Dim myAdapter2 As New MySqlDataAdapter
            conn.Open()
            Dim myCommand2 As New MySqlCommand("select * from courses", SQL.conn)
            myAdapter2.SelectCommand = myCommand2
            Dim myData2 As MySqlDataReader
            myData2 = myCommand2.ExecuteReader()
            DataGridView1.DataSource = Nothing
            DataGridView1.ColumnCount = 3

            DataGridView1.Columns(0).Name = "Course Name"
            DataGridView1.Columns(1).Name = "No. of Semesters"
            DataGridView1.Columns(2).Name = "No. of Subjects/Sem"

            If myData2.HasRows Then
                While myData2.Read()
                    Dim row As String() = New String() {myData2(0).ToString, myData2(1).ToString, myData2(2).ToString}
                    DataGridView1.Rows.Add(row)
                End While
            End If
            conn.Close()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        SQL.InsertQuery("INSERT INTO COURSES VALUES('" + TextBox4.Text + "','" + ComboBox1.SelectedItem.ToString() + "','" + ComboBox2.SelectedItem.ToString() + "');")

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        SQL.deleteQuery("delete from courses where name='" + TextBox1.Text + "'")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        SQL.deleteQuery("delete from courses where name='" + TextBox1.Text + "'")
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        SQL.InsertQuery("INSERT INTO COURSES VALUES('" + TextBox4.Text + "','" + ComboBox1.SelectedItem.ToString() + "','" + ComboBox2.SelectedItem.ToString() + "');")
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub
End Class