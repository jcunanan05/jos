Imports MySql.Data.MySqlClient
Public Class watchDB

    'global function
    Public Shared Function getWatchBuildRemark()
        'global function
        'return an array of string containing watch build remark

        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container


        Dim remarkArray(0) As String 'declare array
        'variable for position type
        Dim watch_build_count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT watch_build, watch_build_remark FROM watch_build_tb ORDER BY watch_build_remark;"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            watch_build_count = data_table.Rows.Count 'count position type

            If watch_build_count > 0 Then
                'if any position type is found in the database

                ReDim remarkArray(watch_build_count - 1) 'declare size of the remarkArray

                'use for loop to input position_type_remark from DB
                For i = 0 To watch_build_count - 1
                    remarkArray(i) = data_table.Rows(i).Item(1) 'watch_build_remark STRING
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

    'global function
    Public Shared Function getWatchKindRemark()
        'global function
        'return an array of string containing watch kind remark

        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container


        Dim remarkArray(0) As String 'declare array
        'variable for position type
        Dim watch_kind_count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT watch_kind, watch_kind_desc FROM watch_kind_tb ORDER BY watch_kind_desc;"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            watch_kind_count = data_table.Rows.Count 'count position type

            If watch_kind_count > 0 Then
                'if any position type is found in the database

                ReDim remarkArray(watch_kind_count - 1) 'declare size of the remarkArray

                'use for loop to input position_type_remark from DB
                For i = 0 To watch_kind_count - 1
                    remarkArray(i) = data_table.Rows(i).Item(1) 'watch_kind_remark STRING
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
