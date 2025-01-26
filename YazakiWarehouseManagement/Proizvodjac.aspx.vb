Imports System.Data.SqlClient

Public Class Proizvodjac
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindProizvodjacTable()
        End If
    End Sub

    ' Bind data to the table
    Private Sub BindProizvodjacTable()
        ' Execute the stored procedure to get all Proizvodjac
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectAllProizvodjac", Nothing)

        ' Clear existing rows from the table
        proizvodjacTable.Rows.Clear()

        ' Create the header row
        Dim headerRow As New TableHeaderRow()
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "ID"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Ime"})
        headerRow.Cells.Add(New TableHeaderCell() With {.Text = "Actions"})
        proizvodjacTable.Rows.Add(headerRow)

        ' Add rows to the table for each Proizvodjac
        For Each row As DataRow In dt.Rows
            Dim dataRow As New TableRow()

            ' Add ID, Ime columns
            dataRow.Cells.Add(New TableCell() With {.Text = row("Id").ToString()})
            dataRow.Cells.Add(New TableCell() With {.Text = row("Ime").ToString()})

            ' Add actions (Edit, Delete)
            Dim actionsCell As New TableCell()
            actionsCell.Controls.Add(New HyperLink() With {
                .Text = "Edit",
                .NavigateUrl = "EditProizvodjac.aspx?Id=" & row("Id").ToString()
            })
            actionsCell.Controls.Add(New LiteralControl(" | "))
            actionsCell.Controls.Add(New HyperLink() With {
                .Text = "Delete",
                .NavigateUrl = "DeleteProizvodjac.aspx?Id=" & row("Id").ToString()
            })
            dataRow.Cells.Add(actionsCell)

            ' Add the row to the table
            proizvodjacTable.Rows.Add(dataRow)
        Next
    End Sub

    ' Show the "Add New" form when the button is clicked
    Protected Sub btnAddNew_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Show the new Proizvodjac form
        newProizvodjacForm.Style("display") = "block"
    End Sub

    ' Insert the new Proizvodjac into the database and refresh the table
    Protected Sub btnSubmitNewProizvodjac_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the values from the form
        Dim ime As String = txtIme.Text

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Ime", ime)
        }

        ' Execute stored procedure to insert the new Proizvodjac
        DatabaseHelper.ExecuteStoredProcedure("InsertProizvodjac", parameters)

        ' Rebind the table to show the updated list
        BindProizvodjacTable()

        ' Hide the form after submission
        newProizvodjacForm.Style("display") = "none"
    End Sub

    ' Hide the "Add New" form if the user cancels
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        newProizvodjacForm.Style("display") = "none"
    End Sub

End Class