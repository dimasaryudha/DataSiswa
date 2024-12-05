Imports MySql.Data.MySqlClient

Public Class FormLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Membuka koneksi ke database
            Using conn As New MySqlConnection("server=localhost;user id=root;password=;database=your_database_name")
                conn.Open()

                ' Query untuk memeriksa email dan password
                Dim query As String = "SELECT * FROM users WHERE email = @Email AND password = @Password"
                Using cmd As New MySqlCommand(query, conn)
                    ' Menambahkan parameter ke query
                    cmd.Parameters.AddWithValue("@Email", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@Password", TextBox2.Text)

                    ' Membaca hasil query
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            ' Jika login berhasil
                            Dim dashboardForm As New Dashboard()
                            dashboardForm.Show()
                            Me.Hide()
                        Else
                            ' Jika login gagal
                            MessageBox.Show("Username atau Password Salah", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Menangani error saat login
            MessageBox.Show($"Gagal login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
