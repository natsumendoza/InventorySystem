Public Class UserList

    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EditUser.ShowDialog()

    End Sub
End Class