Imports System.Data
Imports System.Data.SqlClient

Namespace YazakiWarehouseWebApplication
    Partial Class DeleteKorisnik
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

        ' Load the Korisnik details for confirmation
        Private Sub LoadKorisnikDetails()
            ' Set the parameters for the stored procedure
            Dim parameters As SqlParameter() = {New SqlParameter("@Id", KorisnikId)}
            ' Execute the stored procedure to get the Korisnik details
            Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectKorisnikById", parameters)

            ' If we find the Korisnik, show the name for confirmation
            If dt.Rows.Count > 0 Then
                Dim ime As String = dt.Rows(0)("Ime").ToString()
                Dim prezime As String = dt.Rows(0)("Prezime").ToString()
                lblImePrezime.Text = "Name: " & ime & " " & prezime
            Else
                lblMessage.Text = "Korisnik not found."
            End If
        End Sub

        ' Handle the Delete button click
        Protected Sub btnDelete_Click(sender As Object, e As EventArgs)
            ' Ensure that we have a valid Korisnik ID
            If KorisnikId > 0 Then
                ' Set parameters for deleting the Korisnik
                Dim parameters As SqlParameter() = {New SqlParameter("@Id", KorisnikId)}

                ' Execute the stored procedure to delete the Korisnik
                DatabaseHelper.ExecuteStoredProcedure("DeleteKorisnik", parameters)

                ' Redirect back to the Korisnici list page after deletion
                Response.Redirect("Korisnici.aspx")
            Else
                lblMessage.Text = "Invalid Korisnik ID."
            End If
        End Sub

        ' Handle the Cancel button click
        Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
            ' Redirect back to the Korisnici list page without deleting
            Response.Redirect("Korisnici.aspx")
        End Sub
    End Class
End Namespace