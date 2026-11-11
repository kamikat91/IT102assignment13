Public Class frmMain
    Private Sub btnaddpilots_Click(sender As Object, e As EventArgs) Handles btnaddpilots.Click
        Dim frmaddpassengersdisplay As New frmAddPassengers
        frmaddpassengersdisplay.ShowDialog()
    End Sub

    Private Sub btnupdatepilots_Click(sender As Object, e As EventArgs) Handles btnupdatepilots.Click
        Dim frmupdatepassengersdisplay As New frmUpdatePassengers
        frmupdatepassengersdisplay.ShowDialog()
    End Sub
End Class
