Imports MySql.Data.MySqlClient
Public Class customerDB

    'declare instance variables
    Private customerName, customerContact As String

    'DB class variables
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter


    'initialization constructor
    Public Sub New(ByRef customer_name As String, ByRef customer_contact As String)
        'initialize
        customerName = customer_name
        customerContact = customer_contact
    End Sub

    'string function
    Public Function wrongCustomer()
        Return "You are adding the same customer. Please Edit existing or Add another customer."
    End Function
    'string function
    Public Function confirmName()
        Return "You are adding a customer with same name in the customer list. Are they the same person?"
    End Function

    'boolean function
    Public Function sameCustomer()
        'this method returns boolean
        'returns true if same customer number and name has match in DB
        Dim isTaken As Boolean = True
        Dim data_table As New DataTable 'sql data_table

        'count result
        Dim count As Integer = 0

        Try
            'try to connect to DB
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT * FROM customer_tb WHERE customer_name = '" & customerName & "' AND customer_contact = '" & customerContact & "' "
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count  'count sql results

            If count = 0 Then
                'if no customer is found
                isTaken = False ' set isTaken to false
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
        Return isTaken
    End Function

    'boolean function
    Public Function sameName()
        'this returns boolean
        'returns true if have matches on the same name of customer only
        Dim isSame As Boolean = True
        Dim data_table As New DataTable 'sql data table container
        'count result
        Dim count As Integer = 0
        Try
            'try to connect to DB
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT customer_id,customer_name FROM customer_tb WHERE customer_name = '" & customerName & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count 'count sql results

            If count = 0 Then
                'if no supplier name is found
                isSame = False ' set isSame to false
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
        Return isSame
    End Function

    Public Sub addCustomer()
        'add customer to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query

            Dim sql_query As String = "INSERT INTO customer_tb (customer_name,customer_contact) VALUES ('" & customerName & "','" & customerContact & "');"
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


    'getter for customerID
    Public Function getCustomerID()
        'gets customerID if found in the db
        'needs customerName and customerContact

        Dim customer_id As String = ""
        Dim data_table As New DataTable 'sql data table container
        'count result
        Dim count As Integer = 0
        Try
            'try to connect to DB
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT customer_id, customer_name FROM customer_tb WHERE customer_name = '" & customerName & "' AND customer_contact = '" & customerContact & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count  'count sql results

            If count = 1 Then
                'if customerID is found
                customer_id = data_table.Rows(0).Item(0) ' customer_id STRING
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
        'Return String
        Return customer_id
    End Function

    'global function
    Public Shared Function getNewSerial()
        'returns latest serial number for add inventory
        'returns Integer
        Dim newSerial As Integer = 0
        Dim tableName As String = "customer_tb" 'table name
        'create new object/instance
        Dim autoIncrement As autoIncrementDB = New autoIncrementDB(tableName)
        newSerial = autoIncrement.getSerial() 'get serial number

        If newSerial = 0 Then
            'set serial number to one when the result is zero
            newSerial = 1
        End If

        Return newSerial
    End Function

    'global method
    Public Shared Sub getAllCustomer(ByRef customerDataGrid As DataGridView)
        'This is a global function
        'displays all customers
        'requires @param DataGridView
        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_bind As New BindingSource
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection

            'sql query
            Dim sql_query As String = "SELECT customer_id,customer_name,customer_contact FROM customer_tb ORDER BY customer_name;"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            sql_bind.DataSource = data_table 'set data_table as the source of data for sql_bind
            customerDataGrid.DataSource = sql_bind 'set sql_bind as source of data for the DataGridView
            sql_data_adapter.Update(data_table) 'update sql_data_adapter with data_table

            'set up data grid view
            With customerDataGrid
                .RowHeadersVisible = False 'hide row header
                .Columns(0).HeaderCell.Value = "customer ID"
                .Columns(1).HeaderCell.Value = "Customer Full Name"
                .Columns(2).HeaderCell.Value = "Contact No."

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


    'global method
    Public Shared Sub searchAllCustomer(ByRef customerDataGrid As DataGridView, ByRef searchText As String)
        'This is a global function
        'displays all customers
        'requires @param DataGridView
        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_bind As New BindingSource
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection

            'sql query
            Dim like_query As String = "customer_id LIKE '%" & searchText & "%' OR customer_name LIKE '%" & searchText & "%' OR customer_contact LIKE '%" & searchText & "%'"
            Dim sql_query As String = "SELECT customer_id,customer_name,customer_contact FROM customer_tb WHERE " & like_query & ";"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            sql_bind.DataSource = data_table 'set data_table as the source of data for sql_bind
            customerDataGrid.DataSource = sql_bind 'set sql_bind as source of data for the DataGridView
            sql_data_adapter.Update(data_table) 'update sql_data_adapter with data_table

            'set up data grid view
            With customerDataGrid
                .RowHeadersVisible = False 'hide row header
                .Columns(0).HeaderCell.Value = "customer ID"
                .Columns(1).HeaderCell.Value = "Customer Full Name"
                .Columns(2).HeaderCell.Value = "Contact No."

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
