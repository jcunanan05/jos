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


    'global function
    '@param watch_build_remark
    Public Shared Function getWatchBuildID(ByRef watch_build_remark As String)
        'global function
        'return the integer id of watch build based on watch_build_remark
        Dim watch_build_id As Integer = 0
        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container


        'count results
        Dim count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT watch_build, watch_build_remark FROM watch_build_tb WHERE watch_build_remark = '" & watch_build_remark & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count 'count result

            If count = 1 Then
                'if result is found in db
                watch_build_id = data_table.Rows(0).Item(0) ' watch_build INTEGER
            End If
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            'dispose and close connection
            sql_data_adapter.Dispose()
            connection.Close()
            connection.Dispose()
        End Try

        'return INteger
        Return watch_build_id
    End Function


    'global function
    '@param watch_kind_remark
    Public Shared Function getWatchKindID(ByRef watch_kind_remark As String)
        'global function
        'return the integer id of watch build based on watch_build_remark
        Dim watch_kind_id As Integer = 0
        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container


        'count results
        Dim count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT watch_kind, watch_kind_desc FROM watch_kind_tb WHERE watch_kind_desc = '" & watch_kind_remark & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count 'count result

            If count = 1 Then
                'if result is found in db
                watch_kind_id = data_table.Rows(0).Item(0) ' watch_kind INTEGER
            End If
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            'dispose and close connection
            sql_data_adapter.Dispose()
            connection.Close()
            connection.Dispose()
        End Try

        'return INteger
        Return watch_kind_id
    End Function
End Class
