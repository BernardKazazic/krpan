Imports System.Data.SqlClient

Public Class Artikl
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Bind the table with Artikl data
            BindArtikliTable()
            ' Bind the Proizvodjac dropdown list
            BindProizvodjacDropdown()
        End If
    End Sub

    ' Bind Artikl data to the table
    Private Sub BindArtikliTable()
        ' Execute stored procedure to fetch Artikl data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectAllArtikli", Nothing)

        ' Clear any existing rows in the table
        artikliTable.Rows.Clear()

        ' Add the header row again
        Dim headerRow As New TableHeaderRow()
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "ID"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Ime"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Proizvodjac"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Datum Dolaska"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Kolicina"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Actions"})
        artikliTable.Rows.Add(headerRow)

        ' Loop through the DataTable and add each row to the table
        For Each row As DataRow In dt.Rows
            Dim tableRow As New TableRow()
            tableRow.Cells.Add(New TableCell() With {.Text = row("Id").ToString()})
            tableRow.Cells.Add(New TableCell() With {.Text = row("Ime").ToString()})
            tableRow.Cells.Add(New TableCell() With {.Text = row("IdProizvodjaca").ToString()}) ' Display Proizvodjac Id
            tableRow.Cells.Add(New TableCell() With {.Text = Convert.ToDateTime(row("DatumDolaska")).ToString("yyyy-MM-dd")})
            tableRow.Cells.Add(New TableCell() With {.Text = row("Kolicina").ToString()})

            ' Actions column with Edit and Delete buttons
            Dim actionsCell As New TableCell()
            actionsCell.Controls.Add(New Button() With {
                .Text = "Edit",
                .CommandArgument = row("Id").ToString(),
                .OnClientClick = "window.location.href='EditArtikl.aspx?Id=" & row("Id").ToString() & "'; return false;"
            })
            actionsCell.Controls.Add(New LiteralControl(" &nbsp;"))
            actionsCell.Controls.Add(New Button() With {
                .Text = "Delete",
                .CommandArgument = row("Id").ToString(),
                .OnClientClick = "window.location.href='DeleteArtikl.aspx?Id=" & row("Id").ToString() & "'; return false;"
            })
            tableRow.Cells.Add(actionsCell)

            artikliTable.Rows.Add(tableRow)
        Next
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

    ' Show the form for adding a new Artikl
    Protected Sub btnAddNew_Click(ByVal sender As Object, ByVal e As EventArgs)
        newArtiklForm.Style("display") = "block"
    End Sub

    ' Handle the form submission for adding a new Artikl
    Protected Sub btnSubmitNewArtikl_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the values from the form
        Dim ime As String = txtIme.Text
        Dim proizvodjacId As Integer = Convert.ToInt32(ddlProizvodjac.SelectedValue)
        Dim datumDolaska As DateTime = Convert.ToDateTime(txtDatumDolaska.Text)
        Dim kolicina As Integer = Convert.ToInt32(txtKolicina.Text)

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Ime", ime),
            New SqlParameter("@IdProizvodjaca", proizvodjacId),
            New SqlParameter("@DatumDolaska", datumDolaska),
            New SqlParameter("@Kolicina", kolicina)
        }

        ' Execute stored procedure to add new Artikl
        DatabaseHelper.ExecuteStoredProcedure("InsertArtikl", parameters)

        ' Redirect back to the main page to see the updated list
        Response.Redirect("Artikl.aspx")
    End Sub

    ' Handle the cancel button click to hide the form
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        newArtiklForm.Style("display") = "none"
    End Sub

End Class