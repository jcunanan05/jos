Imports MySql.Data.MySqlClient
Public Class registerDB
    'declare variables for registration
    Private managerUserName As String
    Private fullName, userName, passWord, confirmPassWord As String
    'Private positionType As Integer
    Private positionTypeRemark As String

    'DB class variables
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter

    'initialization constructor
    Public Sub New(ByRef full_name As String, ByRef user_name As String, ByRef pass_word As String, ByRef confirm_pass_word As String, ByRef position_type_remark As String)
        'initialization of variables
        fullName = full_name
        userName = user_name
        passWord = pass_word
        confirmPassWord = confirm_pass_word
        positionTypeRemark = position_type_remark
    End Sub

    Public Function success()
        'returns string that says success
        Return "Registration Success"
    End Function

    Public Function wrongUserName()
        'returns string that says username taken
        Return "Username Taken."
    End Function

    Public Function wrongPassWord()
        'returns string that says username taken
        Return "Password doesn't match"
    End Function

    'boolean function
    Public Function matchPassword()
        'this function returns true if passWord and confirmPassword matches
        Dim isMatch As Boolean = False

        If passWord = confirmPassWord Then
            'if passWord is equal to confirm password
            isMatch = True 'set isMatch to true
        End If
        'return
        Return isMatch
    End Function

    


    'boolean function
    Public Function usernameTaken()
        'this method returns boolean. it knows if the username is already taken
        'the method must return FALSE in order to register the employee.
        Dim isTaken As Boolean = True 'declare variable true if username is taken
        Dim data_table As New DataTable 'sql data container
        Dim count As Integer = 0 'declare variable count
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT emp_id,username FROM employee_tb WHERE BINARY username= BINARY '" & userName & "'"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            count = data_table.Rows.Count 'count sql results

            If count = 0 Then
                'if no username is found
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
    Public Sub register()
        'this function will be responsible for registration of the NEW employee
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim get_position_type As String = "(SELECT position_type FROM position_type_tb WHERE position_type_remark='" & positionTypeRemark & "')"

            Dim add_employee As String = "INSERT INTO employee_tb (full_name,username,position_type) VALUES ('" & fullName & "','" & userName & "'," & get_position_type & ");"
            Dim add_login As String = "INSERT INTO login_tb (username,password) VALUES ('" & userName & "',MD5('" & passWord & "'));"

            Dim sql_query As String = add_employee & add_login
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
