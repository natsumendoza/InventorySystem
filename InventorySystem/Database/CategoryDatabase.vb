Imports MySql.Data.MySqlClient

Public Class CategoryDatabase

    Private connection As MySqlConnection
    Private cmd As MySqlCommand
    Private reader As MySqlDataReader

    Public Sub openConnection()

        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=;database=inventory_db"

        Try
            connection.Open()
            Console.WriteLine("connection opened.")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Sub closeConnection()

        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=;database=inventory_db"

        Try
            connection.Close()
            Console.WriteLine("connection closed.")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub addCategory(categoryName As String)

        Dim query As String
        query = "insert into categories (category_name) values (@categoryName)"

        openConnection()

        Try
            cmd = New MySqlCommand(query, connection)

            cmd.Parameters.Add(New MySqlParameter("categoryName", categoryName))

            reader = cmd.ExecuteReader

            Console.WriteLine("Category Successfully Inserted!")
        Catch ex As Exception
            MsgBox(ex.Message)
            Console.WriteLine(ex.Message)
        Finally
            reader.Close()
        End Try

        closeConnection()

    End Sub

End Class
