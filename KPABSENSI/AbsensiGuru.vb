Imports MySql.Data.MySqlClient
Public Class AbsensiGuru
    Sub kondisiawal()
        Call koneksi()
        da = New MySqlDataAdapter("Select * from tbl_absen", conn)
        ds = New DataSet
        da.Fill(ds, "tbl_absen")
        DataGridView1.DataSource = ds.Tables("tbl_absen")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox2.Text = ""
        ComboBox1.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub AbsensiGuru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call munculnamapengurus()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        ComboBox2.Items.Add("")
        ComboBox1.Items.Add("HADIR")
        ComboBox1.Items.Add("IZIN")
        ComboBox1.Items.Add("ALPA")
        Call kondisiawal()
        Call tampildata()
    End Sub

    Sub tampildata()
        Call koneksi()
        da = New MySqlDataAdapter("Select * From tbl_absen", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_absen")
        Me.DataGridView1.DataSource = (ds.Tables("tbl_absen"))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text =  " " Then
            MsgBox("Data belum lengkap,silahkan isi semua field")

        Else

            Call koneksi()
            cmd = New MySqlCommand("Select * from tbl_absen where Nipguru = '" & TextBox1.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                MsgBox("KODE ANGGOTA SUDAH DI INPUT, Silahkan Edit atau buat yang berbeda!!!")
                Call kondisiawal()

            Else
                Dim tglsaya As String
                tglsaya = Format(DateTimePicker1.Value, "yyyy-MM-dd")
                Call koneksi()
                Dim inputdata As String = "insert into tbl_absen values ('" & TextBox1.Text & "','" & tglsaya & "','" & ComboBox2.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.Text & "','" & TextBox7.Text & "')"
                cmd = New MySqlCommand(inputdata, conn)
                cmd.ExecuteNonQuery()
                rd.Read()
                MsgBox("Data Berhasil Di INPUT")
                Call kondisiawal()

            End If
        End If
    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            cmd = New MySqlCommand("Select * from tbl_guru where nip='" & TextBox1.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                TextBox2.Text = rd.Item("namaguru")
                TextBox3.Text = rd.Item("alamat")
                TextBox4.Text = rd.Item("namasekolah")
                TextBox5.Text = rd.Item("gender")
            Else
                MsgBox("Data Tidak Ada")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = " " Then
            MsgBox("Data belum di EDIT,silahkan Edit data nya terlebih dahulu")
        Else
            Call koneksi()
            Dim editdata As String = "Update tbl_absen set namapengurus = '" & ComboBox2.Text & "',namaguru='" & TextBox2.Text & "',alamat='" & TextBox3.Text & "',namasekolah='" & TextBox4.Text & "',gender='" & TextBox5.Text & "',keterangan='" & ComboBox1.Text & "'where Nipguru='" & TextBox1.Text & "'"
            cmd = New MySqlCommand(editdata, conn)
            cmd.ExecuteNonQuery()
            rd.Read()
            MsgBox("Data Berhasil Di EDIT")
            Call kondisiawal()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = " " Then
            MsgBox("Data belum di Hapus,silahkan pilih data nya terlebih dahulu")
        Else
            Call koneksi()
            Dim hapusdata As String = "delete from tbl_absen where Nipguru= '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(hapusdata, conn)
            cmd.ExecuteNonQuery()
            If MessageBox.Show("Apakah Anda Ingin Menghapus Data nya?", "APAKAH ANDA YAKIN???", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        On Error Resume Next
        TextBox1.Text = DataGridView1.Item(0, i).Value
        DateTimePicker1 = DataGridView1.Item(1, i).Value
        ComboBox2.Text = DataGridView1.Item(2, i).Value
        TextBox2.Text = DataGridView1.Item(3, i).Value
        TextBox3.Text = DataGridView1.Item(4, i).Value
        TextBox4.Text = DataGridView1.Item(5, i).Value
        TextBox5.Text = DataGridView1.Item(6, i).Value
        ComboBox1.Text = DataGridView1.Item(7, i).Value
    End Sub
    Sub munculnamapengurus()
        Call koneksi()
        ComboBox2.Items.Clear()
        cmd = New MySqlCommand("Select * from tbl_pengurus", conn)
        rd = cmd.ExecuteReader
        Do While rd.Read
            ComboBox2.Items.Add(rd.Item(1))
        Loop

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Call koneksi()
        da = New MySqlDataAdapter("Select * from tbl_absen where Nipguru like '%" & Me.TextBox6.Text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "tbl_absen")
        DataGridView1.DataSource = (ds.Tables("tbl_absen"))

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "IZIN" Then
            Label10.Visible = True
            TextBox7.Visible = True
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub
End Class