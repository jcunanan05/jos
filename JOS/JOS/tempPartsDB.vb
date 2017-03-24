Imports MySql.Data.MySqlClient
Public Class tempPartsDB
    'in charge of the temp_part_tb

    'class variables
    Private jobItemID As String
    Private jobItemPrice As Decimal = 0.0
    Private pickItemQuantity As Integer = 0
    Private windowID As String = ""

    'DB class variables
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter

    'initialization constructor MAIN constructor
    Public Sub New(ByRef job_part_id As String, ByRef pick_part_quantity As Integer, ByRef window_id As String)
        'initialize variables
        jobItemID = job_part_id
        ' quantity
        pickItemQuantity = pick_part_quantity
        'window id
        windowID = window_id
    End Sub


    'boolean function
    Public Function partExist()
        'check if selected part id exists in the databse
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
            Dim sql_query As String = "SELECT item_id FROM inventory_tb WHERE item_id ='" & jobItemID & "';"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count  'count sql results

            If count = 1 Then
                'if part is found
                isExist = True ' set isExist to false
            Else
                'if part not found
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

    'boolean function
    Public Function partPlenty()
        'check if item quantity is plenty
        'return false if the quantity added is less than in DB
        Dim isPlenty As Boolean = False
        Dim data_table As New DataTable 'sql data table container

        'count result
        Dim count As Integer = 0

        Try
            'try to connect to DB
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT item_id FROM inventory_tb WHERE item_id ='" & jobItemID & "' AND item_quantity >= " & pickItemQuantity & ";"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count  'count sql results

            If count = 1 Then
                'if part is found
                isPlenty = True ' set isPlenty to false
            Else
                'if part not found
                isPlenty = False
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
        Return isPlenty
    End Function

    'void method
    Public Sub addTempPart()
        'add parts to temp_part_tb
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'select query
            Dim select_query As String = "SELECT inventory.item_id, inventory.item_price, " & pickItemQuantity.ToString() & ", '" & windowID & "' FROM inventory_tb inventory WHERE inventory.item_id = '" & jobItemID & "'"
            'sql query
            Dim sql_query As String = "INSERT INTO temp_part_tb (item_id, item_price, item_quantity, window_id) " & select_query & " ;"
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
    Public Sub removeTempPart()
        'delete selected service from add temp_svc_tb
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql_query
            Dim sql_query As String = "DELETE FROM temp_part_tb WHERE item_id = '" & jobItemID & "' AND item_quantity = " & pickItemQuantity.ToString() & " AND window_id='" & windowID & "';"
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
    Public Shared Sub emptyTempPart(ByRef window_id As String)
        'empty the temp table in DB 'temp_part_tb

        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_reader As MySqlDataReader

        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "DELETE FROM temp_part_tb WHERE window_id = '" & window_id & "';"
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
    Public Shared Sub getSomeItem(ByRef itemDataGrid As DataGridView, ByRef window_id As String)
        'This is a global function
        'displays recentlyAdded inventory in a DataGridView. as of now first 15 rows
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
            'sql query
            'for left join part_id
            Dim part_id As String = "part_tb part ON inventory.part_id = part.part_id"
            'for left join category_id
            Dim category_id As String = "category_tb category ON inventory.category_id = category.category_id"
            'for left join supplier_id
            Dim supplier_id As String = "supplier_tb supplier ON inventory.supplier_id = supplier.supplier_id"
            'rows to be displayed/selected
            Dim selected_row As String = "inventory.item_id, part.part_name, category.category_name, inventory.item_model, inventory.item_quantity, inventory.item_price, inventory.critical_amount, supplier.supplier_name"
            'where query
            Dim where_query As String = "inventory.item_id NOT IN (SELECT item_id FROM temp_part_tb WHERE window_id='" & window_id & "')"
            'main sql query
            Dim sql_query As String = "SELECT " & selected_row & " FROM inventory_tb inventory LEFT JOIN " & part_id & " LEFT JOIN " & category_id & " LEFT JOIN " & supplier_id & " WHERE " & where_query & " ORDER BY part.part_name, category.category_name, inventory.item_model;"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            sql_bind.DataSource = data_table 'set data_table as the source of data for sql_bind
            itemDataGrid.DataSource = sql_bind 'set sql_bind as source of data for the DataGridView
            sql_data_adapter.Update(data_table) 'update sql_data_adapter with data_table

            'set up data grid view
            With itemDataGrid
                .RowHeadersVisible = False 'hide row header
                .Columns(0).HeaderCell.Value = "Item ID"
                .Columns(1).HeaderCell.Value = "Watch Part"
                .Columns(2).HeaderCell.Value = "Brand Category"
                .Columns(3).HeaderCell.Value = "Item Model"
                .Columns(4).HeaderCell.Value = "Stock Qty"
                .Columns(5).HeaderCell.Value = "Item Price"
                .Columns(6).HeaderCell.Value = "Critical Stock #"
                .Columns(7).HeaderCell.Value = "Supplier Name"

                'auto size columns
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
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
    Public Shared Sub getTempPart(ByRef part_datagrid As DataGridView, ByRef window_id As String)
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
            Dim inventory_join As String = "inventory_tb inventory ON temp.item_id = inventory.item_id"
            'join
            Dim category_join As String = "category_tb category ON inventory.category_id = category.category_id"
            'join
            Dim part_join As String = "part_tb part ON inventory.part_id = part.part_id"
            'join
            Dim supplier_join As String = "supplier_tb supplier ON inventory.supplier_id = supplier.supplier_id"
            'selected_row
            Dim selected_row As String = "temp.item_id, inventory.item_model, category.category_name, part.part_name, temp.item_quantity,temp.item_price, supplier.supplier_name"
            'order by
            Dim order_by As String = "part.part_name, inventory.item_model, category.category_name"
            'sql query display items in temp_svc_tb
            Dim sql_query As String = "SELECT " & selected_row & " FROM temp_part_tb temp LEFT JOIN " & inventory_join & " LEFT JOIN " & category_join & " LEFT JOIN " & part_join & " LEFT JOIN " & supplier_join & " WHERE window_id = '" & window_id & "' ORDER BY " & order_by & ";"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            sql_bind.DataSource = data_table 'set data_table as the source of data for sql_bind
            part_datagrid.DataSource = sql_bind 'set sql_bind as source of data for the DataGridView
            sql_data_adapter.Update(data_table) 'update sql_data_adapter with data_table

            'set up data grid view
            With part_datagrid
                .RowHeadersVisible = False 'hide row header
                .Columns(0).HeaderCell.Value = "Item ID"
                .Columns(1).HeaderCell.Value = "Item Model"
                .Columns(2).HeaderCell.Value = "Brand Category"
                .Columns(3).HeaderCell.Value = "Watch Part"
                .Columns(4).HeaderCell.Value = "Needed Qty"
                .Columns(5).HeaderCell.Value = "Item Price"
                .Columns(6).HeaderCell.Value = "Supplier Name"

                'auto size columns
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
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
    'inserts to repair_svc_tb data from temp_svc_tb
    '@param repair_job_id
    '@param window_id
    Public Shared Sub addAllRepairPart(ByRef repair_job_id As String, ByRef window_id As String)
        'variables for db
        Dim server_string As String = serverStringDB.getServerString()
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_reader As MySqlDataReader
        Dim sql_command As MySqlCommand
        Dim sql_bind As New BindingSource

        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'select query
            Dim select_query As String = "SELECT '" & repair_job_id & "', temp.item_id, temp.item_quantity, temp.item_price, temp.item_quantity * temp.item_price  FROM temp_part_tb temp WHERE temp.window_id = '" & window_id & "'"
            'columns included
            Dim part_columns As String = "job_id, item_id, item_quantity, price_each, items_price"
            'sql query
            Dim sql_query As String = "INSERT INTO repair_part_tb (" & part_columns & ") " & select_query & ";"
            'connect to database
            sql_command = New MySqlCommand(sql_query, connection)
            'execute query
            sql_reader = sql_command.ExecuteReader


            'empty temp_part_tb at DB
            tempPartsDB.emptyTempPart(window_id)
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            'dispose and close connection
            connection.Close()
            connection.Dispose()
        End Try
    End Sub

End Class
