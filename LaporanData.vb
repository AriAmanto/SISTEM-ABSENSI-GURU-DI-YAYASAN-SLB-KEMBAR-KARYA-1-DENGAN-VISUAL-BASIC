Imports MySql.Data.MySqlClient
Public Class LaporanData

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AxCrystalReport1.ReportFileName = "datapengurusKP.rpt"
        AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport1.RetrieveDataFiles()
        AxCrystalReport1.Action = 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AxCrystalReport2.ReportFileName = "DataGuruKP.rpt"
        AxCrystalReport2.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport2.RetrieveDataFiles()
        AxCrystalReport2.Action = 1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AxCrystalReport3.ReportFileName = "Dataabsensi.rpt"
        AxCrystalReport3.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport3.RetrieveDataFiles()
        AxCrystalReport3.Action = 1

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AxCrystalReport4.ReportFileName = "Laporanabsenperbulan.rpt"
        AxCrystalReport4.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport4.RetrieveDataFiles()
        AxCrystalReport4.Action = 1
    End Sub
End Class