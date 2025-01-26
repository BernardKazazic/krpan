Imports System.Data.SqlClient

Public Class EditIzlaz
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if we have an Izlaz ID in the query string
            If Request.QueryString("Id") IsNot Nothing Then
                Dim izlazId As Integer = Convert.ToInt32(Request.QueryString("Id"))
                BindIzlazData(izlazId)
                BindArtiklDropdown()
            Else
                Response.Redirect("Izlaz.aspx")
            End If
        End If
    End Sub

    ' Method to fetch the Izlaz data from the database
    Private Sub BindIzlazData(izlazId As Integer)
        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", izlazId)
        }

        ' Execute stored procedure to fetch Izlaz data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectIzlazById", parameters)

        If dt.Rows.Count > 0 Then
            ' Bind data to form controls
            Dim row As DataRow = dt.Rows(0)
            lblIzlazId.Text = row("Id").ToString()
            txtDatum.Text = Convert.ToDateTime(row("Datum")).ToString("yyyy-MM-dd")
            txtKolicina.Text = row("Kolicina").ToString()
            ddlArtikl.SelectedValue = row("IdArtikla").ToString()
        Else
            Response.Redirect("Izlaz.aspx")
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

    ' Update the Izlaz information in the database
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the values from the form
        Dim izlazId As Integer = Convert.ToInt32(lblIzlazId.Text)
        Dim datum As DateTime = Convert.ToDateTime(txtDatum.Text)
        Dim kolicina As Integer = Convert.ToInt32(txtKolicina.Text)
        Dim artiklId As Integer = Convert.ToInt32(ddlArtikl.SelectedValue)

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Id", izlazId),
            New SqlParameter("@Datum", datum),
            New SqlParameter("@Kolicina", kolicina),
            New SqlParameter("@IdArtikla", artiklId)
        }

        ' Execute stored procedure to update Izlaz data
        DatabaseHelper.ExecuteStoredProcedure("UpdateIzlaz", parameters)

        ' Redirect back to the list of Izlaz records
        Response.Redirect("Izlaz.aspx")
    End Sub

    ' Cancel the editing and redirect back to the list
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("Izlaz.aspx")
    End Sub

End Class