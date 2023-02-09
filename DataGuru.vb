Imports MySql.Data.MySqlClient
Public Class DataGuru
    Sub kosongkandata()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
    End Sub

    Sub kondisiawal()
        Call koneksi()
        da = New MySqlDataAdapter("Select * from tbl_guru", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_guru")
        DataGridView1.DataSource = ds.Tables("tbl_guru")
        ComboBox1.Text = ""

        Call kosongkandata()
        Button1.Text = "Input"
        Button2.Text = "Edit"
        Button3.Text = "Delete"
        Button4.Text = "Tutup"
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        ComboBox1.Enabled = False
    End Sub

    Sub callsiapisi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        ComboBox1.Enabled = True
    End Sub

    Private Sub DataGuru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("LAKI-LAKI")
        ComboBox1.Items.Add("PEREMPUAN")
        Call kondisiawal()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Input" Then
            Button1.Text = "Simpan"
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            callsiapisi()

        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = " " Then
                MsgBox("Data belum lengkap,silahkan isi semua field")
            Else
                Call koneksi()
                cmd = New MySqlCommand("Select * from tbl_guru where nip = '" & TextBox1.Text & "'", conn)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    MsgBox("KODE ANGGOTA SUDAH DI INPUT, Silahkan edit atau buat yang berbeda!!!")
                    Call kondisiawal()

                Else
                    Call koneksi()
                    Dim inputdata As String = "insert into tbl_guru values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "')"
                    cmd = New MySqlCommand(inputdata, conn)
                    cmd.ExecuteNonQuery()
                    MsgBox("Data Berhasil Diinput")
                    Call kondisiawal()
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Edit" Then
            Button2.Text = "Simpan"
            Button1.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            callsiapisi()
        Else

            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = " " Then
                MsgBox("Data belum lengkap,silahkan isi semua field")
            Else
                Call koneksi()
                Dim Editdata As String = "update tbl_guru Set namaguru= '" & TextBox2.Text & "',alamat='" & TextBox3.Text & "',namasekolah='" & TextBox4.Text & "',gender='" & ComboBox1.Text & "' where nip= '" & TextBox1.Text & "'"
                cmd = New MySqlCommand(Editdata, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil di Edit")
                Call kondisiawal()
            End If
        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            cmd = New MySqlCommand("Select * from tbl_guru where nip ='" & TextBox1.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                TextBox2.Text = rd.Item("namaguru")
                TextBox3.Text = rd.Item("alamat")
                TextBox4.Text = rd.Item("namasekolah")

            Else
                MsgBox("Data Tidak Ada")
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "Delete" Then
            Button3.Text = "Hapus"
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Text = "Batal"
            callsiapisi()
        Else

            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = " " Then
                MsgBox("Pastikan Data yang akan di hapus terisi")
            Else
                Call koneksi()
                Dim hapusdata As String = "delete from tbl_guru where nip= '" & TextBox1.Text & "'"
                cmd = New MySqlCommand(hapusdata, conn)
                cmd.ExecuteNonQuery()
                If MessageBox.Show("Apakah Anda Ingin Menghapus Data nya?", "APAKAH ANDA YAKIN???", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Call kondisiawal()
                End If

            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "Tutup" Then
            Me.Hide()
        Else
            Call kondisiawal()
            FormMenuUtama.Show()



        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        On Error Resume Next
        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(1, i).Value
        TextBox3.Text = DataGridView1.Item(2, i).Value
        TextBox4.Text = DataGridView1.Item(3, i).Value
        ComboBox1.Text = DataGridView1.Item(4, i).Value

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class