Imports System.Data.SqlClient

Public Class DeleteIzlaz
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if we have an Izlaz ID in the query string
            If Request.QueryString("Id") IsNot Nothing Then
                Dim izlazId As Integer = Convert.ToInt32(Request.QueryString("Id"))
                BindIzlazData(izlazId)
            Else
                ' Redirect back if no ID is provided
                Response.Redirect("Izlaz.aspx")
            End If
        End If
    End Sub

    ' Fetch and display the Izlaz data
    Private Sub BindIzlazData(izlazId As Integer)
        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", izlazId)
        }

        ' Execute stored procedure to fetch Izlaz data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectIzlazById", parameters)

        If dt.Rows.Count > 0 Then
            ' Display data on the page
            Dim row As DataRow = dt.Rows(0)
            lblIzlazId.Text = "ID: " & row("Id").ToString()
            lblDatum.Text = "Datum: " & Convert.ToDateTime(row("Datum")).ToString("yyyy-MM-dd")
            lblKolicina.Text = "Kolicina: " & row("Kolicina").ToString()
            lblArtikl.Text = "Artikl ID: " & row("IdArtikla").ToString()
        Else
            ' Handle case where the Izlaz record is not found
            Response.Redirect("Izlaz.aspx")
        End If
    End Sub

    ' Handle the Delete button click
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the Izlaz ID from the label
        Dim izlazId As Integer = Convert.ToInt32(lblIzlazId.Text.Replace("ID: ", ""))

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", izlazId)
        }

        ' Execute the stored procedure to delete the Izlaz
        DatabaseHelper.ExecuteStoredProcedure("DeleteIzlaz", parameters)

        ' Redirect back to the main Izlaz page
        Response.Redirect("Izlaz.aspx")
    End Sub

    ' Handle the Cancel button click
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Redirect back to the main Izlaz page
        Response.Redirect("Izlaz.aspx")
    End Sub

End Class