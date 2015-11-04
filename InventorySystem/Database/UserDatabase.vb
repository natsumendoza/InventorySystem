Imports MySql.Data.MySqlClient

Public Class UserDatabase
    Private cmd As MySqlCommand
    Private reader As MySqlDataReader
    Private conn = New MySqlConnection
    Private name As String
    Private id As String

    Sub New()
        name = ""
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
                name = getInfoNameById(id)
            End If

            reader.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try

        closeConnection()

        Return loginBool
    End Function

    Public Function getInfoNameById(id As Integer) As String
        Dim name As String = ""
        Dim query As String
        query = "select first_name as first from user_info where user_id=@id "

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
                name = reader.GetString("first")
            End If

            reader.Close()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try

        closeConnection()

        Return name
    End Function

    Public Function getFirstName() As String
        Return name
    End Function

    Public Function getUserId() As String
        Return id
    End Function

End Class
