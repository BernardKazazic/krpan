Imports System.Data.SqlClient

Public Class DatabaseHelper
    Private Shared ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("DbConnectionString").ConnectionString

    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function

    Public Shared Function ExecuteStoredProcedure(storedProcedureName As String, parameters As SqlParameter()) As DataTable
        Dim dt As New DataTable()
        Using con As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(storedProcedureName, con)
                cmd.CommandType = CommandType.StoredProcedure
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters)
                End If
                con.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        Return dt
    End Function
End Class
