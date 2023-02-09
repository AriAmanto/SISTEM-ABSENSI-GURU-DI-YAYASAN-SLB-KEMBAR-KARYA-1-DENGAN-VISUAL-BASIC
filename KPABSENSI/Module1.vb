Imports MySql.Data.MySqlClient
Module Module1

    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public db As String

    Sub koneksi()
        Try
            db = "Server=localhost;user id=root;password=; database=db_absenguru"
            conn = New MySqlConnection(db)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

        Catch ex As Exception

        End Try
    End Sub

End Module
