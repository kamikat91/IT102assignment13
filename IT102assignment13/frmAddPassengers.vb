Imports System.Data.SQLite
Imports System.IO
Public Class frmAddPassengers
    Private Sub frmAddPassengers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim intNextPrimaryKey As Integer

        strFirstName = txtfirstname.Text
        strLastName = txtlastname.Text
        strPhoneNumber = txtphonenumber.Text
        strEmail = txtemail.Text
        strAddress = txtaddress.Text
        strCity = txtcity.Text
        strZip = txtzipcode.Text
        intStateID = cbostate.SelectedValue


        Dim databasePath As String =
            Path.GetFullPath(Path.Combine(Application.StartupPath,
                     "..\..\..\flyme2themoon.db"))

        Dim connectionString As String =
            "Data Source=" & databasePath & ";Version=3;"

        Using conn As New SQLiteConnection(connectionString)
            conn.Open()
            Dim strKeyQuery As String = "SELECT MAX(intPassengerID) + 1 FROM TPassengers"
            Using command As New SQLiteCommand(strKeyQuery, conn)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    reader.Read()
                    intNextPrimaryKey = reader.GetInt32(0)
                End Using
            End Using
            '' this query get the primary key
            Dim strInsertQuery As String =
                $"INSERT INTO TPassengers VALUES 
                ({intNextPrimaryKey}, '{strFirstName}', '{strLastName}', '{strAddress}',
                '{strCity}', '{intStateID}',
                '{strZip}', '{strPhoneNumber}', '{strEmail}')"
            Using command As New SQLiteCommand(strInsertQuery, conn)
                command.ExecuteNonQuery()
            End Using
            '' this query does the insert
        End Using
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub
End Class