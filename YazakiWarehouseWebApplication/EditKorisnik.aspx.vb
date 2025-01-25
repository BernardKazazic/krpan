Imports System.Data
Imports System.Data.SqlClient

Namespace YazakiWarehouseWebApplication
    Partial Class EditKorisnik
        Inherits System.Web.UI.Page

        ' This will hold the Korisnik ID from the query string
        Private KorisnikId As Integer

        ' This runs when the page is loaded
        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                ' Get the ID from the query string
                If Integer.TryParse(Request.QueryString("Id"), KorisnikId) Then
                    ' Load Korisnik details if the ID is valid
                    LoadKorisnikDetails()
                Else
                    lblMessage.Text = "Invalid Korisnik ID."
                End If
            End If
        End Sub

        ' Load the Korisnik details into the form
        Private Sub LoadKorisnikDetails()
            ' Set the parameters for the stored procedure
            Dim parameters As SqlParameter() = {New SqlParameter("@Id", KorisnikId)}
            ' Execute the stored procedure to get the Korisnik details
            Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectKorisnikById", parameters)

            ' If we find the Korisnik, populate the fields
            If dt.Rows.Count > 0 Then
                txtIme.Text = dt.Rows(0)("Ime").ToString()
                txtPrezime.Text = dt.Rows(0)("Prezime").ToString()
            Else
                lblMessage.Text = "Korisnik not found."
            End If
        End Sub

        ' Handle the Save button click
        Protected Sub btnSave_Click(sender As Object, e As EventArgs)
            ' Ensure that we have a valid Korisnik ID
            If KorisnikId > 0 Then
                ' Get the values from the form fields
                Dim ime As String = txtIme.Text
                Dim prezime As String = txtPrezime.Text

                ' Set parameters for updating the Korisnik
                Dim parameters As SqlParameter() = {
                    New SqlParameter("@Id", KorisnikId),
                    New SqlParameter("@Ime", ime),
                    New SqlParameter("@Prezime", prezime)
                }

                ' Execute the stored procedure to update the Korisnik
                DatabaseHelper.ExecuteStoredProcedure("UpdateKorisnik", parameters)

                ' Redirect back to the list page after saving
                Response.Redirect("Korisnici.aspx")
            Else
                lblMessage.Text = "Invalid Korisnik ID."
            End If
        End Sub

        ' Handle the Cancel button click
        Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
            ' Redirect back to the Korisnici list page
            Response.Redirect("Korisnici.aspx")
        End Sub
    End Class
End Namespace