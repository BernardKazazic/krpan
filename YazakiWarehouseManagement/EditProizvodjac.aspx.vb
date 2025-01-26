Imports System.Data.SqlClient

Public Class EditProizvodjac
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if we have a Proizvodjac ID in the query string
            If Request.QueryString("Id") IsNot Nothing Then
                Dim proizvodjacId As Integer = Convert.ToInt32(Request.QueryString("Id"))
                BindProizvodjacData(proizvodjacId)
            Else
                ' Handle the case where no Proizvodjac ID is provided in the query string
                Response.Redirect("Proizvodjac.aspx") ' or show an error message
            End If
        End If
    End Sub

    ' Method to fetch the Proizvodjac data from the database
    Private Sub BindProizvodjacData(proizvodjacId As Integer)
        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", proizvodjacId)
        }

        ' Execute stored procedure to fetch Proizvodjac data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectProizvodjacById", parameters)

        If dt.Rows.Count > 0 Then
            ' Bind data to form controls
            Dim row As DataRow = dt.Rows(0)
            lblProizvodjacId.Text = row("Id").ToString()
            txtIme.Text = row("Ime").ToString()
        Else
            ' Handle case where Proizvodjac is not found
            Response.Redirect("Proizvodjac.aspx") ' or show an error message
        End If
    End Sub

    ' Update the Proizvodjac information in the database
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the values from the form
        Dim proizvodjacId As Integer = Convert.ToInt32(lblProizvodjacId.Text)
        Dim ime As String = txtIme.Text

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", proizvodjacId),
            New SqlParameter("@Ime", ime)
        }

        ' Execute stored procedure to update Proizvodjac data
        DatabaseHelper.ExecuteStoredProcedure("UpdateProizvodjac", parameters)

        ' Redirect back to the main page or the list of Proizvodjac
        Response.Redirect("Proizvodjac.aspx")
    End Sub

    ' Cancel the editing and redirect back to the list
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Proizvodjac.aspx")
    End Sub
End Class