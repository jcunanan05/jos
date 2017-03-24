Imports MySql.Data.MySqlClient
Public Class repairPartDB
    'declare instance variables
    Private repairJobID As String

    'DB class variables
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter

    'initialization constructor
    Public Sub New(ByRef repair_job_id As String)
        repairJobID = repair_job_id
    End Sub

    'check if part is insufficient
    'return a string array of item_id that is insufficient
    '@param job_repair_id
    Public Function getAllLackQtyItemID()
        'declare array
        Dim item_id_array(0) As String
        Dim data_table As New DataTable 'sql data container
        'result count
        Dim result_count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'where query
            Dim inventory_select As String = "SELECT inventory.item_quantity FROM inventory_tb inventory WHERE inventory.item_id = rep.item_id"
            'sql query
            Dim sql_query As String = "SELECT rep.item_id FROM repair_part_tb rep WHERE rep.item_quantity > (" & inventory_select & ") AND rep.job_id = '" & repairJobID & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            result_count = data_table.Rows.Count 'count position type

            If result_count > 0 Then
                'if item greater than inventory count is found in DB

                ReDim item_id_array(result_count - 1) 'declare size of the array

                'use for loop to push items into array
                For i = 0 To result_count - 1
                    item_id_array(i) = data_table.Rows(i).Item(0) 'item_id STRING
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

        'return string array
        Return item_id_array
    End Function


    'update quantity_exist to false
    '@param item_id
    '@param boolean_value
    Public Sub setLackQtyItemID(ByRef item_id As String, ByRef boolean_value As Boolean)
        'set quantity_exist to true or false
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection

            'sql query
            Dim sql_query As String = "UPDATE repair_part_tb SET quantity_exist = " & boolean_value.ToString() & " WHERE job_id = '" & repairJobID & "' AND item_id = '" & item_id & "';"
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


    'update all item_id on repair_part_tb that exceeds quantity based on inventory
    Public Sub setAllLackQty()
        'set quantity exist to false
        Dim item_id_array() As String = getAllLackQtyItemID()

        'if array is not empty
        If item_id_array IsNot Nothing Then
            'loop update based on the array
            For Each item_id As String In item_id_array
                'set quantity_exist to false in DB
                setLackQtyItemID(item_id, False)
            Next
        End If
    End Sub


    'update all item_id on repair_part_tb that 
    Public Sub setAllGoodQty()
        'subtract inventory_tb quantity from repair_part_tb
        Dim item_id_array() As String = getAllGoodQtyItemID()

        'if array is not empty
        If item_id_array IsNot Nothing Then
            'loop update based on the array
            For Each item_id As String In item_id_array
                'subtract inventory_tb quantity
                setInventoryQty(item_id)
            Next
        End If
    End Sub

    'check if part is sufficient
    'return a string array of item_id that is insufficient
    '@param job_repair_id
    Public Function getAllGoodQtyItemID()
        'declare array
        Dim item_id_array(0) As String
        Dim data_table As New DataTable 'sql data container
        'result count
        Dim result_count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'where query
            Dim inventory_select As String = "SELECT inventory.item_quantity FROM inventory_tb inventory WHERE inventory.item_id = rep.item_id"
            'sql query
            Dim sql_query As String = "SELECT rep.item_id FROM repair_part_tb rep WHERE rep.item_quantity <= (" & inventory_select & ") AND rep.job_id = '" & repairJobID & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            result_count = data_table.Rows.Count 'count position type

            If result_count > 0 Then
                'if item greater than inventory count is found in DB

                ReDim item_id_array(result_count - 1) 'declare size of the array

                'use for loop to push items into array
                For i = 0 To result_count - 1
                    item_id_array(i) = data_table.Rows(i).Item(0) 'item_id STRING
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

        'return string array
        Return item_id_array
    End Function

    'update all item_id on inventory_tb
    'subtract quantity from inventory_tb
    '@param item_id
    Public Sub setInventoryQty(ByRef item_id As String)
        'subtract quantity to inventory_tb from repair_part_tb
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection

            'sql query
            Dim sql_query As String = "UPDATE inventory_tb inv LEFT JOIN repair_part_tb rep ON inv.item_id = rep.item_id SET inv.item_quantity = (inv.item_quantity - rep.item_quantity) WHERE rep.item_id = '" & item_id & "' AND rep.job_id = '" & repairJobID & "';"
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
End Class
