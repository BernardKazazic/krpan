Imports System.Data.SqlClient

Public Class Korisnik
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindKorisniciTable()
        End If
    End Sub

    Private Sub BindKorisniciTable()
        ' Execute the stored procedure to get all users
        Dim dt As DataTable = DatabaseHelper.ExecuteStoredProcedure("SelectAllKorisnici", Nothing)

        ' Clear existing rows from the table
        korisniciTable.Rows.Clear()

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
            korisniciTable.Rows.Add(dataRow)
        Next
    End Sub

    ' Show the "Add New" user form when the button is clicked
    Protected Sub btnAddNew_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Show the new user form
        newUserForm.Style("display") = "block"
    End Sub

    ' Insert the new user into the database and refresh the table
    Protected Sub btnSubmitNewUser_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the values from the form
        Dim ime As String = txtIme.Text
        Dim prezime As String = txtPrezime.Text

        ' Prepare the parameters for the stored procedure
        Dim parameters As SqlParameter() = {
            New SqlParameter("@Ime", ime),
            New SqlParameter("@Prezime", prezime)
        }

        ' Execute stored procedure to insert the new user
        DatabaseHelper.ExecuteStoredProcedure("InsertKorisnik", parameters)

        ' Rebind the table to show the updated list
        BindKorisniciTable()

        ' Hide the form after submission
        newUserForm.Style("display") = "none"
    End Sub

    ' Hide the "Add New" form if the user cancels
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        newUserForm.Style("display") = "none"
    End Sub

End Class