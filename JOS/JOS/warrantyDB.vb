Imports MySql.Data.MySqlClient

Public Class warrantyDB

    'global function
    Public Shared Function getWarrantyTypeRemark()
        'global function
        'return an array containing warranty type remark

        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container


        Dim remarkArray(0) As String 'declare array
        'variable for position type
        Dim remark_count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT warranty_type,warranty_type_remark FROM warranty_type_tb ORDER BY warranty_day"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            remark_count = data_table.Rows.Count 'count position type

            If remark_count > 0 Then

                ReDim remarkArray(remark_count - 1) 'declare size of the remarkArray

                'use for loop to input position_type_remark from DB
                For i = 0 To remark_count - 1
                    remarkArray(i) = data_table.Rows(i).Item(1) 'warranty_type_remark STRING
                Next i
            End If
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            'dispose and close connection
            sql_data_adapter.Dispose()
            connection.Close()
            connection.Dispose()
        End Try

        'return array
        Return remarkArray
    End Function
End Class
