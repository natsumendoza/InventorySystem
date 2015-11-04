Imports MySql.Data.MySqlClient

Public Class Database

    Private cmd As MySqlCommand
    Private reader As MySqlDataReader

    Public Function checkConnection() As Boolean
        Dim connection As New MySqlConnection
        connection = New MySqlConnection
        connection.ConnectionString = "server=localhost;userid=root;password=;database=inventory_db"

        Try

            connection.Open()

            Return True

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        Finally
            connection.Close()
        End Try

        Return False

    End Function

    Public Sub openConnection(conn As MySqlConnection)

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

    Public Sub closeConnection(conn As MySqlConnection)

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

    Public Sub addProduct(productCode As String, productName As String, productDescription As String, productPrice As Integer)
        Dim connection As New MySqlConnection
        Dim query As String
        query = "insert into inventory (product_code, product_name, product_description, product_price) values (@productCode, @productName, @productDescription, @productPrice)"


        Try
            cmd = New MySqlCommand(query, connection)

            cmd.Parameters.Add(New MySqlParameter("@productCode", productName))
            cmd.Parameters.Add(New MySqlParameter("@productName", productCode))
            cmd.Parameters.Add(New MySqlParameter("@productDescription", productDescription))
            cmd.Parameters.Add(New MySqlParameter("@productPrice", productPrice))

            reader = cmd.ExecuteReader

            Console.WriteLine("Product Inserted!")

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message)
        End Try


    End Sub

    Public Sub addInventory(inventoryName As String, locationName As String, quantity As Integer, expiryDate As Date, obsolescenceDate As Date)

        Dim query As String
        query = "insert into inventory (inventory_name, location_name, quantity, expiry_date, obsolescence_date) values (@inventoryName, @locationName, @quantity, @expiryDate, @obsolescenceDate)"


        Try


            cmd.Parameters.Add(New MySqlParameter("@inventoryName", inventoryName))
            cmd.Parameters.Add(New MySqlParameter("@locationName", locationName))
            cmd.Parameters.Add(New MySqlParameter("@quantity", quantity))
            cmd.Parameters.Add(New MySqlParameter("@expiryDate", expiryDate))
            cmd.Parameters.Add(New MySqlParameter("@obsolescenceDate", obsolescenceDate))

            reader = cmd.ExecuteReader

            Console.WriteLine("Inventory Inserted!")

        Catch ex As Exception
            MsgBox(ex.Message)
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Public Function getInfoNameById(user_id As Integer) As String
        Dim name As String
        Dim query As String
        name = ""
        query = "select first_name from user_info where user_id = @user_id"


        Try

            cmd.Parameters.Add(New MySqlParameter("user_id", user_id))

            reader = cmd.ExecuteReader

            If (reader.Read) Then
                name = reader.GetString("first_name")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Console.WriteLine(ex.Message)
        End Try

        Return name
    End Function

End Class
