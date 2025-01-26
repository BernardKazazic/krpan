Imports System.Data.SqlClient

Public Class Izlaz
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Bind the table with Izlaz data
            BindIzlazTable()
            ' Bind the Artikl dropdown list
            BindArtiklDropdown()
        End If
    End Sub

    ' Bind Izlaz data to the table
    Private Sub BindIzlazTable()
        ' Execute stored procedure to fetch Izlaz data
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectAllIzlaz", Nothing)

        ' Clear any existing rows in the table
        izlazTable.Rows.Clear()

        ' Add the header row again
        Dim headerRow As New TableHeaderRow()
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "ID"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Datum"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Kolicina"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Artikl"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Actions"})
        izlazTable.Rows.Add(headerRow)

        ' Loop through the DataTable and add each row to the table
        For Each row As DataRow In dt.Rows
            Dim tableRow As New TableRow()
            tableRow.Cells.Add(New TableCell() With {.Text = row("Id").ToString()})
            tableRow.Cells.Add(New TableCell() With {.Text = Convert.ToDateTime(row("Datum")).ToString("yyyy-MM-dd")})
            tableRow.Cells.Add(New TableCell() With {.Text = row("Kolicina").ToString()})
            tableRow.Cells.Add(New TableCell() With {.Text = row("IdArtikla").ToString()}) ' Display Artikl Id

            ' Actions column with Edit and Delete buttons
            Dim actionsCell As New TableCell()

            ' Edit button with redirect to EditIzlaz.aspx page
            actionsCell.Controls.Add(New Button() With {
                .Text = "Edit",
                .CommandArgument = row("Id").ToString(),
                .OnClientClick = "window.location.href='EditIzlaz.aspx?Id=" & row("Id").ToString() & "'; return false;"
            })

            ' Delete button with redirect to DeleteIzlaz.aspx page
            actionsCell.Controls.Add(New Button() With {
                .Text = "Delete",
                .CommandArgument = row("Id").ToString(),
                .OnClientClick = "window.location.href='DeleteIzlaz.aspx?Id=" & row("Id").ToString() & "'; return false;"
            })
            tableRow.Cells.Add(actionsCell)

            izlazTable.Rows.Add(tableRow)
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

    ' Show the form for adding a new Izlaz
    Protected Sub btnAddNew_Click(ByVal sender As Object, ByVal e As EventArgs)
        newIzlazForm.Style("display") = "block"
    End Sub

    ' Handle the form submission for adding a new Izlaz
    Protected Sub btnSubmitNewIzlaz_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the values from the form
        Dim datum As DateTime = Convert.ToDateTime(txtDatum.Text)
        Dim kolicina As Integer = Convert.ToInt32(txtKolicina.Text)
        Dim artiklId As Integer = Convert.ToInt32(ddlArtikl.SelectedValue)

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Datum", datum),
            New SqlParameter("@Kolicina", kolicina),
            New SqlParameter("@IdArtikla", artiklId)
        }

        ' Execute stored procedure to add new Izlaz
        DatabaseHelper.ExecuteStoredProcedure("InsertIzlaz", parameters)

        ' Redirect back to the main page to see the updated list
        Response.Redirect("Izlaz.aspx")
    End Sub

    ' Handle the cancel button click to hide the form
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        newIzlazForm.Style("display") = "none"
    End Sub

End Class