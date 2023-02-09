Imports MySql.Data.MySqlClient
Public Class FormMenuUtama

    Dim I As Integer
    Sub terkunci()
        LOGINToolStripMenuItem.Visible = True
        LOGOUTToolStripMenuItem.Visible = False
        MASTERDATAToolStripMenuItem.Visible = False
        LAPORANToolStripMenuItem.Visible = False

    End Sub

    Private Sub FormMenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call terkunci()
        SLabel8.Text = Today
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DATAPENGURUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATAPENGURUSToolStripMenuItem.Click
        Datapengurus.Show()
    End Sub

    Private Sub DATAGURUToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATAGURUToolStripMenuItem.Click
        DataGuru.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SLabel10.Text = TimeOfDay
        I = I + 1
        If I = 2 Then

        End If
        If I Mod 2 = 0 Then
            Label1.Visible = True
        Else
            Label1.Visible = False

        End If
    End Sub

    Private Sub LOGINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGINToolStripMenuItem.Click
        Form1.ShowDialog()
    End Sub

    Private Sub ABSENSIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABSENSIToolStripMenuItem.Click
        AbsensiGuru.Show()
    End Sub

    Private Sub LAPORANToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LAPORANToolStripMenuItem.Click
        LaporanData.Show()
    End Sub
End Class