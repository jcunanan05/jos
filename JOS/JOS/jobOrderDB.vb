Imports MySql.Data.MySqlClient
Public Class jobOrderDB
    'main instance variables
    Private jobType As Integer
    Private jobItemName As String
    Private totalPrice As Decimal
    Private watchSerialNo As String
    Private watchRemark As String

    'instance variables from other class
    Private customerID As String
    Private watchKind As Integer
    Private watchBuild As Integer
    Private technicianID As String
    Private startRepairDate As Date
    Private expectedClaimDate As Date
    Private warrantyType As String


    'DB class variables
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter

    'initialization constructor
    Public Sub New(ByRef job_type As Integer, ByRef job_item_name As String, ByRef watch_remark As String, ByRef total_price As Decimal, ByRef watch_serial_no As String)
        'initialize values
        jobType = job_type
        jobItemName = job_item_name
        totalPrice = total_price
        watchSerialNo = watch_serial_no
        watchRemark = watch_remark
    End Sub

    'when job order is already added
    Public Function wrongJobOrder()
        'return string of error message
        Return "Job order already exist."
    End Function


    'checks if what you are adding are the same job ORder
    Public Function sameJobOrder(ByRef customer_id As String, ByRef watch_kind As Integer, ByRef watch_build As Integer, ByRef technician_id As String, ByRef start_repair_date As Date, ByRef expected_claim_date As Date, ByRef warranty_type As String)
        'returns true if same job order exist in DB
        'initialize variables
        customerID = customer_id
        watchKind = watch_kind
        watchBuild = watch_build
        technicianID = technician_id
        startRepairDate = start_repair_date
        expectedClaimDate = expected_claim_date
        warrantyType = warranty_type

        'boolean value
        Dim isSame As Boolean = True
        Dim data_table As New DataTable 'sql data container
        'count results
        Dim count As Integer = 0

        'try
        Try
            'try to connect to DB
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'columns included
            Dim columns_select As String = "job_type = " & jobType.ToString() & " AND job_item_name = '" & jobItemName & "' AND total_price = " & totalPrice & " AND watch_serial_no = '" & watchSerialNo & "' AND watch_remark = '" & watchRemark & "' AND "
            columns_select &= "customer_id = '" & customerID & "' AND watch_kind = " & watchKind & " AND watch_build = " & watchBuild & " AND technician_id = '" & technicianID & "' AND start_repair_date = '" & startRepairDate.ToString("yyyy-MM-dd") & "' AND expected_claim_date = '" & expectedClaimDate.ToString("yyyy-MM-dd") & "' AND warranty_type = '" & warrantyType & "'"
            'sql query
            Dim sql_query As String = "SELECT job_id FROM repair_job_tb WHERE " & columns_select & ";"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count 'count sql results

            If count = 0 Then
                'if job order is not found
                isSame = False ' set isSame to False
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

        'return boolean
        Return isSame
    End Function


    'add job order
    Public Sub addJobOrder()
        'add jobOrder


        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'columns included
            Dim columns_select As String = "date_time_added, job_type, job_item_name, total_price, watch_serial_no, watch_remark, "
            columns_select &= "customer_id, watch_kind, watch_build, technician_id, start_repair_date, expected_claim_date, warranty_type"
            'select query
            Dim values_query As String = "(NOW()," & jobType.ToString() & ", '" & jobItemName & "', " & totalPrice & ", '" & watchSerialNo & "', '" & watchRemark & "',"
            values_query &= " '" & customerID & "', " & watchKind & ", " & watchBuild & ", '" & technicianID & "', '" & startRepairDate.ToString("yyyy-MM-dd") & "', '" & expectedClaimDate.ToString("yyyy-MM-dd") & "', '" & warrantyType & "')"
            'sql query
            Dim sql_query As String = "INSERT INTO repair_job_tb (" & columns_select & ") VALUES" & values_query & ";"
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


    'add to repair_part_tb
    '@param job_order_id
    '@param window_id
    Public Sub addRepairService(ByRef job_order_id As String, ByRef window_id As String)
        'add services from temp_svc_tb to repair_svc_tb with job_order_id
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'select query
            Dim select_query As String = "SELECT '" & job_order_id & "', temp.job_desc_id, temp.job_desc_price FROM temp_svc_tb temp WHERE temp.window_id = '" & window_id & "'"
            'sql query
            Dim sql_query As String = "INSERT INTO repair_svc_tb (job_id, job_desc_id, job_desc_price) " & select_query & " ;"
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


    'get Job Order string
    Public Function getJobOrderID()
        'this method returns string
        'get the job order ID if it has match in DB
        Dim job_order_id As String = ""
        Dim data_table As New DataTable 'sql data container
        'count results
        Dim count As Integer = 0

        'try
        Try
            'try to connect to DB
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'columns included
            Dim columns_select As String = "job_type = " & jobType.ToString() & " AND job_item_name = '" & jobItemName & "' AND total_price = " & totalPrice & " AND watch_serial_no = '" & watchSerialNo & "' AND watch_remark = '" & watchRemark & "' AND "
            columns_select &= "customer_id = '" & customerID & "' AND watch_kind = " & watchKind & " AND watch_build = " & watchBuild & " AND technician_id = '" & technicianID & "' AND start_repair_date = '" & startRepairDate.ToString("yyyy-MM-dd") & "' AND expected_claim_date = '" & expectedClaimDate.ToString("yyyy-MM-dd") & "' AND warranty_type = '" & warrantyType & "'"
            'sql query
            Dim sql_query As String = "SELECT job_id FROM repair_job_tb WHERE " & columns_select & ";"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count 'count sql results

            If count = 1 Then
                'if job order is found
                'get job order id from DB
                job_order_id = data_table.Rows(0).Item(0) 'job_id STRING
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
        'return String
        Return job_order_id
    End Function

    'global function
    Public Shared Function getNewSerial()
        'returns latest serial number for add inventory
        'returns Integer
        Dim newSerial As Integer = 0
        Dim tableName As String = "repair_job_tb" 'table name
        'create new object/instance
        Dim autoIncrement As autoIncrementDB = New autoIncrementDB(tableName)
        newSerial = autoIncrement.getSerial() 'get serial number

        If newSerial = 0 Then
            'set serial number to one when the result is zero
            newSerial = 1
        End If

        Return newSerial
    End Function
End Class
