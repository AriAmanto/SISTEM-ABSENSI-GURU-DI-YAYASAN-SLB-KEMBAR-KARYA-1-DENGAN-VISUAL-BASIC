Imports MySql.Data.MySqlClient
Public Class Form1
    Sub terbuka()
        FormMenuUtama.LOGINToolStripMenuItem.Visible = False
        FormMenuUtama.LOGOUTToolStripMenuItem.Visible = True
        FormMenuUtama.MASTERDATAToolStripMenuItem.Visible = True
        FormMenuUtama.LAPORANToolStripMenuItem.Visible = True

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.PasswordChar = "x"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Harap isi username & password terlebih dahulu sebelum LOGIN!!")
        Else
            Call koneksi()
            cmd = New MySqlCommand("Select * From tbl_login where userid='" & TextBox1.Text & "' and pwdadmin='" & TextBox2.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                MsgBox("Login Berhasil")
                'If TextBox1.Text = "AA" And TextBox2.Text = "BB" Then
                Me.Close()

                Call terbuka()
                FormMenuUtama.Show()
                FormMenuUtama.SLabel2.Text = rd!userid
                FormMenuUtama.SLabel4.Text = rd!status

                If FormMenuUtama.SLabel4.Text = "User" Then
                    FormMenuUtama.DATAPENGURUSToolStripMenuItem.Enabled = False
                    FormMenuUtama.DATAGURUToolStripMenuItem.Enabled = False
                    FormMenuUtama.ABSENSIToolStripMenuItem.Enabled = False
                End If
            Else
                MsgBox("Username & Password SALAH!!!")
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then

            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "x"
        End If
    End Sub
End Class
