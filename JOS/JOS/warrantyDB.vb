Imports MySql.Data.MySqlClient

Public Class warrantyDB
    'instance variables
    Private warrantyTypeRemark As String
    Private warrantyID As String
    Private warrantyDay As Integer

    'DB class variables
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter

    'initialization constructor
    Public Sub New(ByRef warranty_type_remark As String)
        'initialize variables
        warrantyTypeRemark = warranty_type_remark
    End Sub

    'returns string
    Public Function wrongTypeRemark()
        'return wrong message
        Return "Warranty Description Doesn't Exist."
    End Function


    'checks if warranty remark exists in DB
    Public Function warrantyTypeRemarkExist()
        'return boolean
        'return true if warranty remark is found in DB
        Dim isExist As Boolean = False
        Dim data_table As New DataTable 'sql data container
        'count results
        Dim count As Integer = 0
        'try
        Try
            'try to connect to DB
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT warranty_type, warranty_type_remark FROM warranty_type_tb WHERE warranty_type_remark = '" & warrantyTypeRemark & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count 'count sql results

            If count = 1 Then
                'if warranty_type_remark is found
                isExist = True ' set isExist to True
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

        'Return boolean
        Return isExist
    End Function



    'get warranty id based on warranty remark
    Public Function getWarrantyID()
        'this function returns String
        Dim warranty_id As String = ""
        Dim data_table As New DataTable 'sql data container
        'count results
        Dim count As Integer = 0
        'try
        Try
            'try to connect to DB
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT warranty_type, warranty_type_remark FROM warranty_type_tb WHERE warranty_type_remark = '" & warrantyTypeRemark & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count 'count sql results

            If count = 1 Then
                'if warranty_type_remark is found
                warranty_id = data_table.Rows(0).Item(0) 'warranty_type String
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
        'return string
        Return warranty_id
    End Function



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
        'variable for remark type
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

            remark_count = data_table.Rows.Count 'count remark type

            If remark_count > 0 Then

                ReDim remarkArray(remark_count - 1) 'declare size of the remarkArray

                'use for loop to input warranty_type_remark from DB
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


    'global function
    '@param warranty_remark
    Public Shared Function getWarrantyDay(ByRef warranty_remark As String)
        'returns Integer
        'returns days of warranty
        Dim warranty_day As Integer = 0
        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container

        'count result
        Dim count As Integer = 0

        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT warranty_type, warranty_day FROM warranty_type_tb WHERE warranty_type_remark = '" & warranty_remark & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count 'count warranty result

            If count = 1 Then
                'if there is a result
                warranty_day = data_table.Rows(0).Item(1) 'fetch data
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
        Return warranty_day
    End Function
End Class
