Imports MySql.Data.MySqlClient
Public Class autoIncrementDB
    'declare instance variables
    Private tableName As String

    'variables for db
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_data_adapter As New MySqlDataAdapter


    'initialization constructor
    Public Sub New(ByRef table_name As String)
        tableName = table_name
    End Sub

    Public Function getSerial()
        'return integer for the latest serial number of the given table name in database
        Dim newSerial As Integer = 0
        Dim count As Integer = 0
        Dim data_table As New DataTable 'sql data container
        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT `auto_increment` FROM INFORMATION_SCHEMA.TABLES WHERE table_name = '" & tableName & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count 'count results

            If count = 1 Then
                'results found
                If IsDBNull(data_table.Rows(0).Item(0)) = False Then
                    'latest serial number
                    newSerial = data_table.Rows(0).Item(0)
                End If
            End If

        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            'dispose and close connection
            sql_data_adapter.Dispose()
            connection.Close()
            connection.Dispose()
        End Try

        Return newSerial
    End Function
End Class
