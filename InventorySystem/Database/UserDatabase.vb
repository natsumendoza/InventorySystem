Imports MySql.Data.MySqlClient

Public Class UserDatabase
    Private cmd As MySqlCommand
    Private reader As MySqlDataReader
    Private conn = New MySqlConnection

    Private id As String

    Sub New()
        id = ""
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
                id = reader.GetString("id")
            End If

            reader.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try

        closeConnection()

        Return loginBool
    End Function

    Public Function getAllUserInfo() As List(Of String)

        Dim list As List(Of String) = Nothing
        Dim query As String = ""
        query = "select user.username, user_info.first_name, user_info.last_name, user_info.middle_name, user_info.date_of_birth from user inner join user_info on user.user_id=@id "

        openConnection()

        Try
            cmd = New MySqlCommand(query, conn)

            cmd.Parameters.Add(New MySqlParameter("id", id))

            reader = cmd.ExecuteReader

            Dim count As Integer = 0

            While reader.Read
                count += 1
            End While

            If count <> 0 Then
                list.Add(reader.GetString("username"))
                list.Add(reader.GetString("first_name"))
                list.Add(reader.GetString("last_name"))
                list.Add(reader.GetString("middle_name"))
                list.Add(reader.GetString("date_of_birth"))
            End If

            reader.Close()

        Catch ex As Exception

        End Try

        closeConnection()

        Return list
    End Function

End Class
