Imports System.Data.SqlClient

Public Class EditUlaz
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if we have a Ulaz ID in the query string
            If Request.QueryString("Id") IsNot Nothing Then
                Dim ulazId As Integer = Convert.ToInt32(Request.QueryString("Id"))
                BindUlazData(ulazId)
                BindArtiklDropdown()
                BindProizvodjacDropdown()
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
            ' Bind data to form controls
            Dim row As DataRow = dt.Rows(0)
            lblUlazId.Text = row("Id").ToString()
            txtDatum.Text = Convert.ToDateTime(row("Datum")).ToString("yyyy-MM-dd")
            ddlArtikl.SelectedValue = row("IdArtikla").ToString() ' Set the selected Artikl
            txtKolicina.Text = row("Kolicina").ToString()
            ddlProizvodjac.SelectedValue = row("IdProizvodjaca").ToString() ' Set the selected Proizvodjac
        Else
            ' Handle case where Ulaz is not found
            Response.Redirect("Ulaz.aspx") ' or show an error message
        End If
    End Sub

    ' Bind the Artikl dropdown
    Private Sub BindArtiklDropdown()
        ' Execute stored procedure to fetch Artikl data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectAllArtikli", Nothing)

        ddlArtikl.DataSource = dt
        ddlArtikl.DataTextField = "Ime"
        ddlArtikl.DataValueField = "Id"
        ddlArtikl.DataBind()
    End Sub

    ' Bind the Proizvodjac dropdown
    Private Sub BindProizvodjacDropdown()
        ' Execute stored procedure to fetch Proizvodjac data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectAllProizvodjac", Nothing)

        ddlProizvodjac.DataSource = dt
        ddlProizvodjac.DataTextField = "Ime"
        ddlProizvodjac.DataValueField = "Id"
        ddlProizvodjac.DataBind()
    End Sub

    ' Update the Ulaz information in the database
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the values from the form
        Dim ulazId As Integer = Convert.ToInt32(lblUlazId.Text)
        Dim datum As DateTime = Convert.ToDateTime(txtDatum.Text)
        Dim artiklId As Integer = Convert.ToInt32(ddlArtikl.SelectedValue)
        Dim kolicina As Integer = Convert.ToInt32(txtKolicina.Text)
        Dim proizvodjacId As Integer = Convert.ToInt32(ddlProizvodjac.SelectedValue)

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", ulazId),
            New SqlParameter("@Datum", datum),
            New SqlParameter("@IdArtikla", artiklId),
            New SqlParameter("@Kolicina", kolicina),
            New SqlParameter("@IdProizvodjaca", proizvodjacId)
        }

        ' Execute stored procedure to update Ulaz data
        DatabaseHelper.ExecuteStoredProcedure("UpdateUlaz", parameters)

        ' Redirect back to the main page or the list of Ulaz
        Response.Redirect("Ulaz.aspx")
    End Sub

    ' Cancel the editing and redirect back to the list
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Ulaz.aspx")
    End Sub

End Class