Imports System.Data.SqlClient

Public Class DeleteKorisnik
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if we have a user ID in the query string
            If Request.QueryString("Id") IsNot Nothing Then
                Dim userId As Integer = Convert.ToInt32(Request.QueryString("Id"))
                BindUserData(userId)
            Else
                ' Handle the case where no user ID is provided in the query string
                Response.Redirect("Korisnik.aspx") ' or show an error message
            End If
        End If
    End Sub

    ' Method to fetch the user data from the database
    Private Sub BindUserData(userId As Integer)
        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", userId)
        }

        ' Execute stored procedure to fetch user data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectKorisnikById", parameters)

        If dt.Rows.Count > 0 Then
            ' Bind data to labels
            Dim row As DataRow = dt.Rows(0)
            lblUserId.Text = "ID: " & row("Id").ToString()
            lblIme.Text = "Ime: " & row("Ime").ToString()
            lblPrezime.Text = "Prezime: " & row("Prezime").ToString()
        Else
            ' Handle case where user is not found
            Response.Redirect("Korisnik.aspx") ' or show an error message
        End If
    End Sub

    ' Delete the user information from the database
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the user ID from the label
        Dim userId As Integer = Convert.ToInt32(lblUserId.Text.Replace("ID: ", ""))

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", userId)
        }

        ' Execute stored procedure to delete the user data
        DatabaseHelper.ExecuteStoredProcedure("DeleteKorisnik", parameters)

        ' Redirect back to the main page or the list of users
        Response.Redirect("Korisnik.aspx")
    End Sub

    ' Cancel the deletion and redirect back to the list
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Korisnik.aspx")
    End Sub
End Class