Imports MySql.Data.MySqlClient
Public Class inventoryDB

    'declare instance variables
    Private partName, partBrand, partCategory, partSupplier As String
    Private partPrice As Decimal
    Private partQuantity As Integer
    Private partCritical As Integer

    'DB class variables
    Private server_string As String = "Server=localhost;UserId=root;Password=;Database=jobdb"
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter
    Private data_table As New DataTable 'sql data container


    'initialization constructor
    Public Sub New(ByRef part_name As String, ByRef brand As String, ByRef category As String, ByRef supplier As String, ByRef price As Decimal, ByRef quantity As Integer, ByRef critical_amount As Integer)
        'initialization
        partName = part_name
        partBrand = brand
        partCategory = category
        partSupplier = supplier
        partPrice = price
        partQuantity = quantity
        partCritical = critical_amount
    End Sub

    Public Function wrongItem()
        'string function that returns a text saying that you have the same item
        Return "You are adding the same item."
    End Function

    Public Function wrongNewSupplier()
        'String function that returns a text that same supplier when it is the same in the database
        Return "Same Supplier. Select from the Existing Suppliers."
    End Function

    'boolean function
    Public Function supplierTaken(ByRef new_chbox As CheckBox)
        'this method returns boolean
        'returns true if the new supplier name has one match in the database
        Dim isTaken As Boolean = True

        'count results
        Dim count As Integer = 0
        If new_chbox.Checked Then
            'if the user wants to add new supplier
            Try
                connection.ConnectionString = server_string
                connection.Open() 'open connection
                'sql query
                Dim sql_query As String = "SELECT supplier_id,supplier_name FROM supplier_tb WHERE supplier_name='" & partSupplier & "'"
                'connect to database and bind query
                sql_command = New MySqlCommand(sql_query, connection)
                sql_command.CommandText = sql_query 'execute command
                'get data from database
                sql_data_adapter.SelectCommand = sql_command
                sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

                count = data_table.Rows.Count 'count sql results

                If count = 0 Then
                    'if no supplier name is found
                    isTaken = False ' set isTaken to false
                End If

            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                'dispose and close connection
                sql_data_adapter.Dispose()
                connection.Close()
                connection.Dispose()
            End Try
        Else
            'if the user won't add new Supplier
            'set isTaken to false
            isTaken = False
        End If

        'return
        Return isTaken
    End Function

    'boolean function
    Public Function itemTaken()
        'this method returns boolean
        'returns true if the item with the same supplier, category, and kind has match on DB
        Dim isTaken As Boolean = True

        'count results
        Dim count As Integer = 0
            'if the user wants to add new supplier
            Try
                connection.ConnectionString = server_string
                connection.Open() 'open connection
            'select queries for ids
            Dim select_supplier As String = "SELECT supplier_id FROM supplier_tb WHERE supplier_name='" & partSupplier & "'"
            Dim select_category As String = "SELECT category_id FROM category_tb WHERE category_name='" & partCategory & "'"
            Dim select_part As String = "SELECT part_id FROM part_tb WHERE part_name = '" & partName & "'"
            'sql query
            Dim sql_query As String = "SELECT item_id,item_name FROM inventory_tb WHERE item_name='" & partBrand & "' AND supplier_id =(" & select_supplier & ") AND category_id =(" & select_category & ") AND part_id =(" & select_part & ");"
                'connect to database and bind query
                sql_command = New MySqlCommand(sql_query, connection)
                sql_command.CommandText = sql_query 'execute command
                'get data from database
                sql_data_adapter.SelectCommand = sql_command
                sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

                count = data_table.Rows.Count 'count sql results

                If count = 0 Then
                'if no same item is found
                    isTaken = False ' set isTaken to false
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
    Public Sub addItem(ByRef new_supplier_chbox As CheckBox)
        'add new item to the inventory
        Dim new_supplier As String = ""
        'this method will add the new item.
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim select_supplier As String = "SELECT supplier_id FROM supplier_tb WHERE supplier_name='" & partSupplier & "'"
            Dim select_category As String = "SELECT category_id FROM category_tb WHERE category_name='" & partCategory & "'"
            Dim select_part As String = "SELECT part_id FROM part_tb WHERE part_name = '" & partName & "'"

            If new_supplier_chbox.Checked Then
                new_supplier = "INSERT INTO supplier_tb (supplier_name) VALUES ('" & partSupplier & "');"
            End If

            Dim sql_query As String = new_supplier & "INSERT INTO inventory_tb (part_id, item_name, category_id, supplier_id, item_price, item_quantity, critical_amount) VALUES ((" & select_part & "),'" & partBrand & "',(" & select_category & "),(" & select_supplier & "),'" & partPrice.ToString & "','" & partQuantity & "','" & partCritical.ToString & "');"
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


    'GLOBAL FUNCTIONS
    Public Shared Function getPartRemark()
        'this global function returns a string ARRAY
        ' of standard watch part names. E.G. battery. right hand, left hand, etc

        'variables for db
        Dim server_string As String = "Server=localhost;UserId=root;Password=;Database=jobdb"
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container


        Dim remarkArray(0) As String 'declare array
        'variable for part name count
        Dim part_count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT part_id,part_name FROM part_tb ORDER BY part_name"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            part_count = data_table.Rows.Count 'count parts

            If part_count > 0 Then
                'if any part_name is found in the database

                'call method set counter for position type count
                'setPartNameCount(part_count)

                ReDim remarkArray(part_count - 1) 'declare size of the remarkArray

                'use for loop to input part_name from DB
                For i = 0 To part_count - 1
                    remarkArray(i) = data_table.Rows(i).Item(1) 'part_name STRING
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
    Public Shared Function getCategoryRemark()
        'this global function returns a string ARRAY
        ' of watch categories. 

        'variables for db
        Dim server_string As String = "Server=localhost;UserId=root;Password=;Database=jobdb"
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container


        Dim remarkArray(0) As String 'declare array
        'variable for part name count
        Dim category_count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT category_id,category_name FROM category_tb ORDER BY category_name"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            category_count = data_table.Rows.Count 'count categories

            If category_count > 0 Then
                'if any part_name is found in the database

                'call method set counter for position type count
                'setCategoryNameCount(category_count)

                ReDim remarkArray(category_count - 1) 'declare size of the remarkArray

                'use for loop to input part_name from DB
                For i = 0 To category_count - 1
                    remarkArray(i) = data_table.Rows(i).Item(1) 'category_name STRING
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


    Public Shared Function getSupplierRemark()
        'this global function returns a string ARRAY
        ' of suppliers. 

        'variables for db
        Dim server_string As String = "Server=localhost;UserId=root;Password=;Database=jobdb"
        Dim connection As MySqlConnection = New MySqlConnection
        Dim sql_command As MySqlCommand
        Dim sql_data_adapter As New MySqlDataAdapter
        Dim data_table As New DataTable 'sql data container


        Dim remarkArray(0) As String 'declare array
        'variable for supplier count
        Dim supplier_count As Integer = 0

        'try to connect to DB
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT supplier_id,supplier_name FROM supplier_tb ORDER BY supplier_name"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            supplier_count = data_table.Rows.Count 'count categories

            If supplier_count > 0 Then
                'if any part_name is found in the database

                'call method set counter for position type count
                'setCategoryNameCount(category_count)

                ReDim remarkArray(supplier_count - 1) 'declare size of the remarkArray

                'use for loop to input part_name from DB
                For i = 0 To supplier_count - 1
                    remarkArray(i) = data_table.Rows(i).Item(1) 'category_name STRING
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
    Public Shared Function getNewSerial()
        'returns latest serial number for add inventory
        'returns Integer
        Dim newSerial As Integer = 0
        Dim tableName As String = "inventory_tb" 'table name
        'create new object/instance
        Dim autoIncrement As autoIncrementDB = New autoIncrementDB(tableName)
        newSerial = autoIncrement.getSerial() 'get serial number

        If newSerial = 0 Then
            'set serial number to one when the result is zero
            newSerial = 1
        End If

        Return newSerial
    End Function

    Public Shared Sub getRecentlyAdded(ByRef itemDataGrid As DataGridView)
        'This is a global function
        'displays recentlyAdded inventory in a DataGridView. as of now first 15 rows
        'requires @param DataGridView
        'variables for db
        Dim server_string As String = "Server=localhost;UserId=root;Password=;Database=jobdb"
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
            Dim selected_row As String = "inventory.item_id, part.part_name, inventory.item_name, inventory.item_quantity, inventory.item_price, inventory.critical_amount, supplier.supplier_name, category.category_name"
            'main sql query
            Dim sql_query As String = "SELECT " & selected_row & " FROM inventory_tb inventory LEFT JOIN " & part_id & " LEFT JOIN " & category_id & " LEFT JOIN " & supplier_id & " ORDER BY inventory.item_AI DESC LIMIT 15;"
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
                .Columns(2).HeaderCell.Value = "Item Name"
                .Columns(3).HeaderCell.Value = "Stock Qty"
                .Columns(4).HeaderCell.Value = "Item Price"
                .Columns(5).HeaderCell.Value = "Critical Stock #"
                .Columns(6).HeaderCell.Value = "Supplier Name"
                .Columns(7).HeaderCell.Value = "Watch Category"
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
End Class
