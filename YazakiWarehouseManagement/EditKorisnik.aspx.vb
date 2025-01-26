Imports System.Data.SqlClient

Public Class EditKorisnik
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
            ' Bind data to form controls
            Dim row As DataRow = dt.Rows(0)
            lblUserId.Text = row("Id").ToString()
            txtIme.Text = row("Ime").ToString()
            txtPrezime.Text = row("Prezime").ToString()
        Else
            ' Handle case where user is not found
            Response.Redirect("Korisnik.aspx") ' or show an error message
        End If
    End Sub

    ' Update the user information in the database
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the values from the form
        Dim userId As Integer = Convert.ToInt32(lblUserId.Text)
        Dim ime As String = txtIme.Text
        Dim prezime As String = txtPrezime.Text

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", userId),
            New SqlParameter("@Ime", ime),
            New SqlParameter("@Prezime", prezime)
        }

        ' Execute stored procedure to update user data
        DatabaseHelper.ExecuteStoredProcedure("UpdateKorisnik", parameters)

        ' Redirect back to the main page or the list of users
        Response.Redirect("Korisnik.aspx")
    End Sub

    ' Cancel the editing and redirect back to the list
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Korisnik.aspx")
    End Sub

End Class