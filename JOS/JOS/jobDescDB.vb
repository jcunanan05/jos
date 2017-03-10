Imports MySql.Data.MySqlClient
Public Class jobDescDB
    'declare instance variables
    Private jobServiceName As String
    Private jobPrice As Decimal

    'DB class variables
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter


    'initialization constructor
    Public Sub New(ByRef job_name As String, ByRef job_price As Decimal)
        jobServiceName = job_name
        jobPrice = job_price
    End Sub

    'string function
    Public Function wrongService()
        Return "Job Service is Taken."
    End Function

    'boolean function
    Public Function serviceTaken()
        'this method checks if the job service is taken.
        'returns true if service has the same name in DB
        'declare boolean variable
        Dim isTaken As Boolean = True
        Dim data_table As New DataTable 'sql data container
        'for count result
        Dim count As Integer = 0
        'lowercase job service name
        'lowercasing means to compare without being strict on the CapitaliZatiOn :)
        Dim lowerJobServiceName As String = jobServiceName.ToLower
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT job_desc_id,job_desc FROM job_desc_tb WHERE LOWER(job_desc) ='" & lowerJobServiceName & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            'count results
            count = data_table.Rows.Count

            If count = 0 Then
                'if no match is found
                isTaken = False 'set is taken to false
            End If

        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            'dispose and close connection
            sql_data_adapter.Dispose()
            connection.Close()
            connection.Dispose()
        End Try

        'return
        Return isTaken
    End Function

    'void method
    Public Sub addService()
        'this method adds Job service

        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query

            Dim sql_query As String = "INSERT INTO job_desc_tb (job_desc,job_desc_price) VALUES('" & jobServiceName & "', " & jobPrice.ToString & ")"
            'connect to database
            sql_command = New MySqlCommand(sql_query, connection)
            'execute query
            sql_reader = sql_command.ExecuteReader


        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            'dispose and close connection
            connection.Close()
            connection.Dispose()
        End Try
    End Sub

    'global function
    Public Shared Function getNewSerial()
        'returns latest serial number for add job Service
        'returns Integer
        Dim newSerial As Integer = 0
        Dim tableName As String = "job_desc_tb" 'table name
        'create new object/instance
        Dim autoIncrement As autoIncrementDB = New autoIncrementDB(tableName)
        newSerial = autoIncrement.getSerial() 'get serial number

        If newSerial = 0 Then
            'set serial number to one when the result is zero
            newSerial = 1
        End If

        Return newSerial
    End Function

    'global function
    Public Shared Sub getAllJobService(ByRef job_service_datagrid As DataGridView)
        'This is a global function
        'displays all job services offered to job order
        'requires @param DataGridView
        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_bind As New BindingSource
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container

        Try
            'try to connect to DB
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query arrange alphabetical by job service name
            Dim sql_query As String = "SELECT job_desc_id,job_desc,job_desc_price FROM job_desc_tb ORDER BY job_desc;"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            sql_bind.DataSource = data_table 'set data_table as the source of data for sql_bind
            job_service_datagrid.DataSource = sql_bind 'set sql_bind as source of data for the DataGridView
            sql_data_adapter.Update(data_table) 'update sql_data_adapter with data_table

            'set up data grid view
            With job_service_datagrid
                .RowHeadersVisible = False 'hide row header
                .Columns(0).HeaderCell.Value = "Job Service ID"
                .Columns(1).HeaderCell.Value = "Job Service Name"
                .Columns(2).HeaderCell.Value = "Price"

                'auto size columns and rows
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .ClearSelection() 'no select
            End With

        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            'dispose and close connection
            sql_data_adapter.Dispose()
            connection.Close()
            connection.Dispose()
        End Try
    End Sub
End Class
