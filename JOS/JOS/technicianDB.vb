Imports MySql.Data.MySqlClient
Public Class technicianDB

    'global function
    Public Shared Function getTechnicianNames()
        'global function
        'return an array containing technician names

        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container


        Dim remarkArray(0) As String 'declare array
        'variable for position type
        Dim emp_count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim position_type As Integer = 1 'Techinician
            Dim sql_query As String = "SELECT emp_id,full_name FROM employee_tb WHERE position_type = " & position_type & " ORDER BY full_name"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            emp_count = data_table.Rows.Count 'count position type

            If emp_count > 0 Then

                ReDim remarkArray(emp_count - 1) 'declare size of the remarkArray

                'use for loop to input position_type_remark from DB
                For i = 0 To emp_count - 1
                    remarkArray(i) = data_table.Rows(i).Item(1) 'full_name STRING
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
