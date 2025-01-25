Imports System.Data
Imports System.Data.SqlClient

Partial Class Korisnici
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindKorisniciTable()
        End If
    End Sub

    Private Sub BindKorisniciTable()
        ' Execute the stored procedure to get all users
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectAllKorisnici", Nothing)

        ' Clear existing rows from the table
        korisniciTable.Controls.Clear()

        ' Create the header row
        Dim headerRow As New TableRow()
        headerRow.Cells.Add(New TableCell() With {.Text = "ID"})
        headerRow.Cells.Add(New TableCell() With {.Text = "Ime"})
        headerRow.Cells.Add(New TableCell() With {.Text = "Prezime"})
        headerRow.Cells.Add(New TableCell() With {.Text = "Actions"})
        korisniciTable.Controls.Add(headerRow)

        ' Add rows to the table for each user
        For Each row As DataRow In dt.Rows
            Dim dataRow As New TableRow()

            ' Add ID, Ime, Prezime columns
            dataRow.Cells.Add(New TableCell() With {.Text = row("Id").ToString()})
            dataRow.Cells.Add(New TableCell() With {.Text = row("Ime").ToString()})
            dataRow.Cells.Add(New TableCell() With {.Text = row("Prezime").ToString()})

            ' Add actions (Edit, Delete)
            Dim actionsCell As New TableCell()
            actionsCell.Controls.Add(New HyperLink() With {
                .Text = "Edit",
                .NavigateUrl = "EditKorisnik.aspx?Id=" & row("Id").ToString()
            })
            actionsCell.Controls.Add(New LiteralControl(" | "))
            actionsCell.Controls.Add(New HyperLink() With {
                .Text = "Delete",
                .NavigateUrl = "DeleteKorisnik.aspx?Id=" & row("Id").ToString()
            })
            dataRow.Cells.Add(actionsCell)

            ' Add the row to the table
            korisniciTable.Controls.Add(dataRow)
        Next
    End Sub
End Class