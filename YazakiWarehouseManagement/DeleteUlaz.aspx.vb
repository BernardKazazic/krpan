Imports System.Data.SqlClient

Public Class DeleteUlaz
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if we have a Ulaz ID in the query string
            If Request.QueryString("Id") IsNot Nothing Then
                Dim ulazId As Integer = Convert.ToInt32(Request.QueryString("Id"))
                BindUlazData(ulazId)
            Else
                ' Handle the case where no Ulaz ID is provided in the query string
                Response.Redirect("Ulaz.aspx") ' or show an error message
            End If
        End If
    End Sub

    ' Method to fetch the Ulaz data from the database
    Private Sub BindUlazData(ulazId As Integer)
        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", ulazId)
        }

        ' Execute stored procedure to fetch Ulaz data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectUlazById", parameters)

        If dt.Rows.Count > 0 Then
            ' Bind data to labels
            Dim row As DataRow = dt.Rows(0)
            lblUlazId.Text = "ID: " & row("Id").ToString()
            lblDatum.Text = "Datum: " & Convert.ToDateTime(row("Datum")).ToString("yyyy-MM-dd")
            lblArtikl.Text = "Artikl: " & row("IdArtikla").ToString() ' Display the Artikl Id
            lblKolicina.Text = "Kolicina: " & row("Kolicina").ToString()
            lblProizvodjac.Text = "Proizvodjac: " & row("IdProizvodjaca").ToString() ' Display the Proizvodjac Id
        Else
            ' Handle case where Ulaz is not found
            Response.Redirect("Ulaz.aspx") ' or show an error message
        End If
    End Sub

    ' Delete the Ulaz information from the database
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the Ulaz ID from the label
        Dim ulazId As Integer = Convert.ToInt32(lblUlazId.Text.Replace("ID: ", ""))

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", ulazId)
        }

        ' Execute stored procedure to delete the Ulaz data
        DatabaseHelper.ExecuteStoredProcedure("DeleteUlaz", parameters)

        ' Redirect back to the main page or the list of Ulaz
        Response.Redirect("Ulaz.aspx")
    End Sub

    ' Cancel the deletion and redirect back to the list
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Ulaz.aspx")
    End Sub

End Class