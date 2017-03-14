Imports MySql.Data.MySqlClient
Public Class tempServiceDB
    'in charge of the temp_svc_tb

    'class variables
    Private jobServiceID As String
    Private jobServicePrice As Decimal = 0

    'DB class variables
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter

    'initialization constructor
    Public Sub New(ByRef job_service_id As String)
        jobServiceID = job_service_id
    End Sub

    'string function
    Public Function wrongJobService()
        Return "Job service doesn't exist."
    End Function

    'boolean function
    Public Function jobServiceExist()
        'check if selected job service id exists in the databse
        'return true if exist
        Dim isExist As Boolean = False
        Dim data_table As New DataTable 'sql data table container

        'count result
        Dim count As Integer = 0

        Try
            'try to connect to DB
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT job_desc_id FROM job_desc_tb WHERE job_desc_id = '" & jobServiceID & "' "
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count  'count sql results

            If count = 1 Then
                'if job service is found
                isExist = True ' set isExist to false
            Else
                'if job service not found
                isExist = False
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

        'return
        Return isExist
    End Function

    'void method
    Public Sub addTempSvc()
        'add job svc to db

        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'select query
            Dim select_query As String = "SELECT job_desc_id, job_desc_price FROM job_desc_tb WHERE job_desc_id = '" & jobServiceID & "'"
            'sql query
            Dim sql_query As String = "INSERT INTO temp_svc_tb (job_desc_id, job_desc_price) " & select_query & " ;"
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

    'void method
    Public Sub removeTempSvc()
        'delete selected service from add temp_svc_tb
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql_query
            Dim sql_query As String = "DELETE FROM temp_svc_tb WHERE job_desc_id = '" & jobServiceID & "';"
            'connect to database
            sql_command = New MySqlCommand(sql_query, connection)
            'execute query
            sql_reader = sql_command.ExecuteReader
        Catch ex As MySqlException
            'dispose and close connection
            connection.Close()
            connection.Dispose()
        End Try
    End Sub

    'global method
    Public Shared Sub emptyTempService()
        'empty the temp table in DB 'temp_svc_tb

        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_reader As MySqlDataReader

        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "DELETE FROM temp_svc_tb;"
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
    Public Shared Sub getSomeJobService(ByRef job_service_datagrid As DataGridView)
        'This is a global function
        'displays all job services EXCEPT selected in temp_svc_tb
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
            'where clause
            Dim where_query As String = "WHERE job_desc_id NOT IN (SELECT job_desc_id FROM temp_svc_tb)"
            'sql query arrange alphabetical by job service name
            Dim sql_query As String = "SELECT job_desc_id,job_desc,job_desc_price FROM job_desc_tb " & where_query & " ORDER BY job_desc;"
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

    'global function
    Public Shared Sub getTempJobService(ByRef job_service_datagrid As DataGridView)
        'This is a global function
        'displays temp storage for job service
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
            'join
            Dim job_desc_join As String = "LEFT JOIN job_desc_tb jobDesc ON temp.job_desc_id = jobDesc.job_desc_id"
            'selected_row
            Dim selected_row As String = "temp.job_desc_id, jobDesc.job_desc, temp.job_desc_price"
            'sql query display items in temp_svc_tb
            Dim sql_query As String = "SELECT " & selected_row & " FROM temp_svc_tb temp " & job_desc_join & " ORDER BY job_desc;"
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
