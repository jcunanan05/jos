Imports MySql.Data.MySqlClient
Public Class windowNamer

    Public Sub New()

    End Sub

    'public Function
    Public Function getWindowID()
        'gets a generated window_id
        Dim windowID As String = ""
        Dim count As Integer = 0
        'db variables
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_bind As New BindingSource
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container

        Try
            'insert an entry to database
            addWindowAI()

            'try to connect to DB
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT window_AI, window_id FROM window_maker_tb WHERE window_AI = (SELECT MAX(window_AI) FROM window_maker_tb);"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count  'count sql results

            If count = 1 Then
                'if window_id is found
                windowID = data_table.Rows(0).Item(1)
            End If

        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            'dispose and close connection
            data_table.Dispose()
            sql_data_adapter.Dispose()
            connection.Close()
            connection.Dispose()
        End Try

        'return windowID
        Return windowID
    End Function

    'private method
    Private Sub addWindowAI()
        'insert row in window_maker_tb
        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_reader As MySqlDataReader

        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql_query
            Dim sql_query As String = "INSERT INTO window_maker_tb VALUES();"
            'connect to DB
            sql_command = New MySqlCommand(sql_query, connection)
            'execute query
            sql_reader = sql_command.ExecuteReader
        Catch ex As MySqlException
            'dispose and close connection
            connection.Close()
            connection.Dispose()
        End Try
    End Sub

    'public method
    '@param window_id
    Public Sub deleteWindowID(ByRef window_id As String)
        'deletes an entry from the window_maker_tb
        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_reader As MySqlDataReader

        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql_query
            Dim sql_query As String = "DELETE FROM window_maker_tb WHERE window_id='" & window_id & "';"
            'connect to DB
            sql_command = New MySqlCommand(sql_query, connection)
            'execute query
            sql_reader = sql_command.ExecuteReader
        Catch ex As MySqlException
            'dispose and close connection
            connection.Close()
            connection.Dispose()
        End Try
    End Sub

    
End Class
