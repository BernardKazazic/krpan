Imports System.Data.SqlClient

Public Class DeleteArtikl
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if we have an Artikl ID in the query string
            If Request.QueryString("Id") IsNot Nothing Then
                Dim artiklId As Integer = Convert.ToInt32(Request.QueryString("Id"))
                BindArtiklData(artiklId)
            Else
                ' Handle the case where no Artikl ID is provided in the query string
                Response.Redirect("Artikl.aspx") ' or show an error message
            End If
        End If
    End Sub

    ' Method to fetch the Artikl data from the database
    Private Sub BindArtiklData(artiklId As Integer)
        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", artiklId)
        }

        ' Execute stored procedure to fetch Artikl data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectArtiklById", parameters)

        If dt.Rows.Count > 0 Then
            ' Bind data to labels
            Dim row As DataRow = dt.Rows(0)
            lblArtiklId.Text = "ID: " & row("Id").ToString()
            lblIme.Text = "Ime: " & row("Ime").ToString()
            lblProizvodjac.Text = "Proizvodjac: " & row("IdProizvodjaca").ToString() ' Display the Proizvodjac Id
            lblDatumDolaska.Text = "Datum Dolaska: " & Convert.ToDateTime(row("DatumDolaska")).ToString("yyyy-MM-dd")
            lblKolicina.Text = "Kolicina: " & row("Kolicina").ToString()
        Else
            ' Handle case where Artikl is not found
            Response.Redirect("Artikl.aspx") ' or show an error message
        End If
    End Sub

    ' Delete the Artikl information from the database
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the Artikl ID from the label
        Dim artiklId As Integer = Convert.ToInt32(lblArtiklId.Text.Replace("ID: ", ""))

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", artiklId)
        }

        ' Execute stored procedure to delete the Artikl data
        DatabaseHelper.ExecuteStoredProcedure("DeleteArtikl", parameters)

        ' Redirect back to the main page or the list of Artikl
        Response.Redirect("Artikl.aspx")
    End Sub

    ' Cancel the deletion and redirect back to the list
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Artikl.aspx")
    End Sub

End Class