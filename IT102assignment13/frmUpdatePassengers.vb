Imports System.Data.SQLite
Imports System.IO

Public Class frmUpdatePassengers
    Private Sub frmUpdatePassengers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim databasePath As String =
            Path.GetFullPath(Path.Combine(Application.StartupPath,
                     "..\..\..\flyme2themoon.db"))

        Dim connectionString As String =
            "Data Source=" & databasePath & ";Version=3;"

        Using conn As New SQLiteConnection(connectionString)
            conn.Open()
            Dim strQuery As String = "SELECT intStateID, strState FROM TStates"
            Using command As New SQLiteCommand(strQuery, conn)
                Dim adapter As New SQLiteDataAdapter(command)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)

                cbostate.DataSource = dataTable
                cbostate.DisplayMember = "strState"
                cbostate.ValueMember = "intStateID"
            End Using
            Dim strPassengerQuery As String = "SELECT intPassengerID, strFirstName || ' ' || strLastName AS strFullName FROM TPassengers"

            Using command As New SQLiteCommand(strPassengerQuery, conn)
                Dim adapter As New SQLiteDataAdapter(command)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)

                cbopassengers.DataSource = dataTable
                cbopassengers.DisplayMember = "strFullName"
                cbopassengers.ValueMember = "intPassengerID"
            End Using
        End Using
    End Sub

    Private Sub cbopassengers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbopassengers.SelectedIndexChanged
        If TypeOf cbopassengers.SelectedValue Is DataRowView OrElse cbopassengers.SelectedValue Is Nothing Then
            Exit Sub
        End If

        Dim databasePath As String =
            Path.GetFullPath(Path.Combine(Application.StartupPath, "..\..\..\flyme2themoon.db"))

        Dim connectionString As String = "Data Source=" & databasePath & ";Version=3;"

        Using conn As New SQLiteConnection(connectionString)
            conn.Open()
            Dim strPilotQuery As String =
                $"SELECT intPassengerID, strFirstName, strLastName,  strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail
                 FROM TPassengers
                 WHERE intPassengerID = {cbopassengers.SelectedValue}"
            Using command As New SQLiteCommand(strPilotQuery, conn)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    reader.Read()
                    txtfirstname.Text = reader.GetString(1)
                    txtlastname.Text = reader.GetString(2)
                    txtaddress.Text = reader.GetString(3)
                    txtcity.Text = reader.GetString(4)
                    cbostate.SelectedValue = reader.GetInt32(5)
                    txtzipcode.Text = reader.GetString(6)
                    txtphonenumber.Text = reader.GetString(7)
                    txtemail.Text = reader.GetString(8)
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Dim strFirstName As String
        Dim strLastName As String
        Dim strPhoneNumber As String
        Dim strEmail As String
        Dim strAddress As String
        Dim strCity As String
        Dim strZip As Integer
        Dim intStateID As Integer
        Dim intPassengerID As Integer

        strFirstName = txtfirstname.Text
        strLastName = txtlastname.Text
        strPhoneNumber = txtphonenumber.Text
        strEmail = txtemail.Text
        strAddress = txtaddress.Text
        strCity = txtcity.Text
        strZip = txtzipcode.Text
        intStateID = cbostate.SelectedValue
        intPassengerID = cbopassengers.SelectedValue

        Dim strUpdateQuery As String =
            $"UPDATE TPassengers
            SET strFirstName = '{strFirstName}',
            strLastName = '{strLastName}',
            strAddress = '{strAddress}',
            strCity = '{strCity}',
            intStateID = {intStateID},
            strZip = '{strZip}',
            strPhoneNumber = '{strPhoneNumber}',
            strEmail = '{strEmail}'
            WHERE intPassengerID = {intPassengerID}"

        Dim databasePath As String =
            Path.GetFullPath(Path.Combine(Application.StartupPath,
                     "..\..\..\flyme2themoon.db"))

        Dim connectionString As String =
            "Data Source=" & databasePath & ";Version=3;"

        Using conn As New SQLiteConnection(connectionString)
            conn.Open()
            Using command As New SQLiteCommand(strUpdateQuery, conn)
                command.ExecuteNonQuery()

            End Using
        End Using
    End Sub
End Class