Imports MySql.Data.MySqlClient

Public Class Database

    Private connection As MySqlConnection
    Private cmd As MySqlCommand
    Private reader As MySqlDataReader

    Public Function checkConnection() As Boolean

        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=;database=chat_test"

        Try

            connection.Open()

            Return True

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try

        Return False

    End Function

    Private Sub openConnection()

        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=;database=chat_test"

        Try
            connection.Open()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub closeConnection()

        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=;database=chat_test"

        Try
            connection.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try

    End Sub

End Class
