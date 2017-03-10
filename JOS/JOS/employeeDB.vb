Imports MySql.Data.MySqlClient
Public Class employeeDB
    'INSTANCE VARIABLES
    'declare employee variables
    Private userName As String
    Private userType As Integer = 1

    'Employee details variables
    Private empID As String
    Private empFullName As String
    Private positionType As Integer

    'DB instance variables
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter


    'CLASS VARIABLES
    Private Shared positionTypeCount As Integer 'Declare variable position type count

    'declare initialization constructor
    Public Sub New(ByRef user_name As String)
        userName = user_name 'initialize variables
        'userType = user_type
    End Sub

    'return string wrong when employe not found
    Public Function wrong()
        Return "Employee not found."
    End Function

    'get user type.
    Public Function getUserType()
        Return userType
    End Function

    'get username
    Public Function getUserName()
        Return userName
    End Function

    'set empID variable
    Public Sub setEmpID(ByRef emp_id As String)
        empID = emp_id
    End Sub
    'get empID variable
    Public Function getEmpID()
        Return empID 'returns STRING
    End Function

    'set empFullName variable
    Public Sub setEmpFullName(ByRef emp_full_name As String)
        empFullName = emp_full_name
    End Sub
    'get empFullName variable
    Public Function getEmpFullName()
        Return empFullName 'returns STRING
    End Function

    'set positionType variable
    Public Sub setPositionType(ByRef position_type As Integer)
        positionType = position_type
    End Sub
    'get positionType variable 
    Public Function getPositionType()
        Return positionType 'returns INTEGER
    End Function


    'void method
    Public Sub getEmployee()
        'get Employee Details based on its userName
        Dim count As Integer = 0 'declare variable count for userName match
        Dim data_table As New DataTable 'sql data container
        'try to connect to MySQL server
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT emp_id,full_name,position_type FROM employee_tb WHERE BINARY username= BINARY '" & userName & "'"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            'get row count from database
            count = data_table.Rows.Count

            If count = 1 Then
                'this means that userName is found in the employee_tb DB
                'items in index order 0 emp_id, 1 full_name,2 position_type
                'get Employee details
                Dim emp_id As String = data_table.Rows(0).Item(0)
                setEmpID(emp_id) 'set employee id
                Dim full_name As String = data_table.Rows(0).Item(1)
                setEmpFullName(full_name) 'set employee full name
                Dim position_type As Integer = data_table.Rows(0).Item(2)
                setPositionType(position_type) 'set employee position type
            Else
                'this means userName is not found in the employee_tb DB
                MsgBox(wrong()) 'generate error message
            End If
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            'dispose and close connection
            sql_data_adapter.Dispose()
            connection.Close()
            connection.Dispose()
        End Try


    End Sub


    Public Shared Function getPositionTypeRemark()
        'this global function returns a string ARRAY of position type remarks.
        'As of now there are two. 1 for technician, 2 for manager

        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container


        Dim remarkArray(0) As String 'declare array
        'variable for position type
        Dim position_type_count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT position_type,position_type_remark FROM position_type_tb ORDER BY position_type"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            position_type_count = data_table.Rows.Count 'count position type

            If position_type_count > 0 Then
                'if any position type is found in the database

                'call method set counter for position type count
                setPositionTypeCount(position_type_count)

                ReDim remarkArray(position_type_count - 1) 'declare size of the remarkArray

                'use for loop to input position_type_remark from DB
                For i = 0 To position_type_count - 1
                    remarkArray(i) = data_table.Rows(i).Item(1) 'position_type_remark STRING
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


    'set position type count
    Public Shared Sub setPositionTypeCount(ByRef position_type_count As Integer)
        positionTypeCount = position_type_count
    End Sub
    'get position type count
    Public Shared Function getPositionTypeCount()
        'returns INT
        Return positionTypeCount
    End Function

    'global function
    Public Shared Sub getAllEmployee(ByRef employee_datagrid As DataGridView)
        'This is a global function
        'displays all employee
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
            'sql query arrange alphabetical by employee name
            Dim position_join As String = "LEFT JOIN position_type_tb position ON employee.position_type = position.position_type"
            Dim columns_selected As String = "employee.emp_id, employee.full_name,employee.username, position.position_type_remark"
            Dim sql_query As String = "SELECT " & columns_selected & " FROM employee_tb employee " & position_join & " ORDER BY employee.full_name;"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            sql_bind.DataSource = data_table 'set data_table as the source of data for sql_bind
            employee_datagrid.DataSource = sql_bind 'set sql_bind as source of data for the DataGridView
            sql_data_adapter.Update(data_table) 'update sql_data_adapter with data_table

            'set up data grid view
            With employee_datagrid
                .RowHeadersVisible = False 'hide row header
                .Columns(0).HeaderCell.Value = "Employee ID"
                .Columns(1).HeaderCell.Value = "Employee Name"
                .Columns(2).HeaderCell.Value = "Username"
                .Columns(3).HeaderCell.Value = "Position"

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
