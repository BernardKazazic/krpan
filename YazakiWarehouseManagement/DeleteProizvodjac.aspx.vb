Imports System.Data.SqlClient

Public Class DeleteProizvodjac
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
            ' Bind data to labels
            Dim row As DataRow = dt.Rows(0)
            lblProizvodjacId.Text = "ID: " & row("Id").ToString()
            lblIme.Text = "Ime: " & row("Ime").ToString()
        Else
            ' Handle case where Proizvodjac is not found
            Response.Redirect("Proizvodjac.aspx") ' or show an error message
        End If
    End Sub

    ' Delete the Proizvodjac information from the database
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the Proizvodjac ID from the label
        Dim proizvodjacId As Integer = Convert.ToInt32(lblProizvodjacId.Text.Replace("ID: ", ""))

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", proizvodjacId)
        }

        ' Execute stored procedure to delete the Proizvodjac data
        DatabaseHelper.ExecuteStoredProcedure("DeleteProizvodjac", parameters)

        ' Redirect back to the main page or the list of Proizvodjac
        Response.Redirect("Proizvodjac.aspx")
    End Sub

    ' Cancel the deletion and redirect back to the list
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Proizvodjac.aspx")
    End Sub
End Class