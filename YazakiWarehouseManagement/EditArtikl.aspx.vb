Imports System.Data.SqlClient

Public Class EditArtikl
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if we have an Artikl ID in the query string
            If Request.QueryString("Id") IsNot Nothing Then
                Dim artiklId As Integer = Convert.ToInt32(Request.QueryString("Id"))
                BindArtiklData(artiklId)
                BindProizvodjacDropdown()
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
            ' Bind data to form controls
            Dim row As DataRow = dt.Rows(0)
            lblArtiklId.Text = row("Id").ToString()
            txtIme.Text = row("Ime").ToString()
            ddlProizvodjac.SelectedValue = row("IdProizvodjaca").ToString() ' Set the selected Proizvodjac
            txtDatumDolaska.Text = Convert.ToDateTime(row("DatumDolaska")).ToString("yyyy-MM-dd")
            txtKolicina.Text = row("Kolicina").ToString()
        Else
            ' Handle case where Artikl is not found
            Response.Redirect("Artikl.aspx") ' or show an error message
        End If
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

    ' Update the Artikl information in the database
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the values from the form
        Dim artiklId As Integer = Convert.ToInt32(lblArtiklId.Text)
        Dim ime As String = txtIme.Text
        Dim proizvodjacId As Integer = Convert.ToInt32(ddlProizvodjac.SelectedValue)
        Dim datumDolaska As DateTime = Convert.ToDateTime(txtDatumDolaska.Text)
        Dim kolicina As Integer = Convert.ToInt32(txtKolicina.Text)

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", artiklId),
            New SqlParameter("@Ime", ime),
            New SqlParameter("@IdProizvodjaca", proizvodjacId),
            New SqlParameter("@DatumDolaska", datumDolaska),
            New SqlParameter("@Kolicina", kolicina)
        }

        ' Execute stored procedure to update Artikl data
        DatabaseHelper.ExecuteStoredProcedure("UpdateArtikl", parameters)

        ' Redirect back to the main page or the list of Artikli
        Response.Redirect("Artikl.aspx")
    End Sub

    ' Cancel the editing and redirect back to the list
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Artikl.aspx")
    End Sub

End Class