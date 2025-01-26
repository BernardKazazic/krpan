Imports System.Data.SqlClient

Public Class Ulaz
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Bind the table with Ulaz data
            BindUlazTable()
            ' Bind the Artikl and Proizvodjac dropdown lists
            BindArtiklDropdown()
            BindProizvodjacDropdown()
        End If
    End Sub

    ' Bind Ulaz data to the table
    Private Sub BindUlazTable()
        ' Execute stored procedure to fetch Ulaz data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectAllUlaz", Nothing)

        ' Clear any existing rows in the table
        ulazTable.Rows.Clear()

        ' Add the header row again
        Dim headerRow As New TableHeaderRow()
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "ID"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Datum"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Artikl"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Kolicina"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Proizvodjac"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Actions"})
        ulazTable.Rows.Add(headerRow)

        ' Loop through the DataTable and add each row to the table
        For Each row As DataRow In dt.Rows
            Dim tableRow As New TableRow()
            tableRow.Cells.Add(New TableCell() With {.Text = row("Id").ToString()})
            tableRow.Cells.Add(New TableCell() With {.Text = Convert.ToDateTime(row("Datum")).ToString("yyyy-MM-dd")})
            tableRow.Cells.Add(New TableCell() With {.Text = row("IdArtikla").ToString()}) ' Display Artikl Id
            tableRow.Cells.Add(New TableCell() With {.Text = row("Kolicina").ToString()})
            tableRow.Cells.Add(New TableCell() With {.Text = row("IdProizvodjaca").ToString()}) ' Display Proizvodjac Id

            ' Actions column with Edit and Delete buttons
            Dim actionsCell As New TableCell()
            actionsCell.Controls.Add(New Button() With {
                .Text = "Edit",
                .CommandArgument = row("Id").ToString(),
                .OnClientClick = "window.location.href='EditUlaz.aspx?Id=" & row("Id").ToString() & "'; return false;"
            })
            actionsCell.Controls.Add(New LiteralControl(" &nbsp;"))
            actionsCell.Controls.Add(New Button() With {
                .Text = "Delete",
                .CommandArgument = row("Id").ToString(),
                .OnClientClick = "window.location.href='DeleteUlaz.aspx?Id=" & row("Id").ToString() & "'; return false;"
            })
            tableRow.Cells.Add(actionsCell)

            ulazTable.Rows.Add(tableRow)
        Next
    End Sub

    ' Bind Artikl dropdown
    Private Sub BindArtiklDropdown()
        ' Execute stored procedure to fetch Artikl data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectAllArtikli", Nothing)

        ddlArtikl.DataSource = dt
        ddlArtikl.DataTextField = "Ime"
        ddlArtikl.DataValueField = "Id"
        ddlArtikl.DataBind()

        ' Optionally, you can add a default "Select" option
        ddlArtikl.Items.Insert(0, New ListItem("Select Artikl", ""))
    End Sub

    ' Bind Proizvodjac dropdown
    Private Sub BindProizvodjacDropdown()
        ' Execute stored procedure to fetch Proizvodjac data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectAllProizvodjac", Nothing)

        ddlProizvodjac.DataSource = dt
        ddlProizvodjac.DataTextField = "Ime"
        ddlProizvodjac.DataValueField = "Id"
        ddlProizvodjac.DataBind()

        ' Optionally, you can add a default "Select" option
        ddlProizvodjac.Items.Insert(0, New ListItem("Select Proizvodjac", ""))
    End Sub

    ' Show the form for adding a new Ulaz
    Protected Sub btnAddNew_Click(ByVal sender As Object, ByVal e As EventArgs)
        newUlazForm.Style("display") = "block"
    End Sub

    ' Handle the form submission for adding a new Ulaz
    Protected Sub btnSubmitNewUlaz_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the values from the form
        Dim datum As DateTime = Convert.ToDateTime(txtDatum.Text)
        Dim artiklId As Integer = Convert.ToInt32(ddlArtikl.SelectedValue)
        Dim kolicina As Integer = Convert.ToInt32(txtKolicina.Text)
        Dim proizvodjacId As Integer = Convert.ToInt32(ddlProizvodjac.SelectedValue)

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Datum", datum),
            New SqlParameter("@IdArtikla", artiklId),
            New SqlParameter("@Kolicina", kolicina),
            New SqlParameter("@IdProizvodjaca", proizvodjacId)
        }

        ' Execute stored procedure to add new Ulaz
        DatabaseHelper.ExecuteStoredProcedure("InsertUlaz", parameters)

        ' Redirect back to the main page to see the updated list
        Response.Redirect("Ulaz.aspx")
    End Sub

    ' Handle the cancel button click to hide the form
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        newUlazForm.Style("display") = "none"
    End Sub

End Class