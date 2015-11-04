Imports MySql.Data.MySqlClient

Public Class UserDatabase
    Private cmd As MySqlCommand
    Private reader As MySqlDataReader
    Private conn = New MySqlConnection
    Private name As String

    Sub New()
        name = ""
    End Sub

    Public Sub openConnection()

        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password=;database=inventory_db"

        Try
            conn.Open()
            Console.WriteLine("connection opened.")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub closeConnection()

        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password=;database=inventory_db"

        Try
            conn.Close()
            Console.WriteLine("connection closed.")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Function login(username As String, password As String) As Boolean
        Dim loginBool As Boolean = False
        Dim query As String
        query = "select user_id as id from user where username=@username and password=@password"

        openConnection()

        Try
            cmd = New MySqlCommand(query, conn)

            cmd.Parameters.Add(New MySqlParameter("username", username))
            cmd.Parameters.Add(New MySqlParameter("password", password))

            reader = cmd.ExecuteReader

            Dim count As Integer = 0

            While reader.Read
                count += 1
            End While

            If count <> 0 Then
                loginBool = True
            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try

        closeConnection()

        Return loginBool
    End Function

End Class
