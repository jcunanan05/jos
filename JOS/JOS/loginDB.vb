Imports MySql.Data.MySqlClient
Public Class loginDB
    
    'definition of instance variable
    Private userName, passWord As String
    Private userType As Integer 'user_type in jobdb.login_tb, in MySQL

    'DB class variables
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter
    Private data_table As New DataTable 'sql data container

    'initalization constructor, has 2 parameters user_name and pass_word
    Public Sub New(ByRef user_name As String, ByRef pass_word As String)
        'initialize variables
        userName = user_name
        passWord = pass_word
    End Sub

    'test to output hello world
    Public Shared Function helloWorld()
        Return "Hello World!"
    End Function

    'output when wrong password or username
    Public Function wrong()
        Return "Wrong username or password."
    End Function

    Public Function success()
        Return "Login Success!"
    End Function

    'set user type. 1 for technician, 2 for manager
    Public Sub setUserType(ByRef user_type As Integer)
        userType = user_type
    End Sub
    'get user type.
    Public Function getUserType()
        Return userType
    End Function

    'get username
    Public Function getUserName()
        Return userName
    End Function


    'get login details and return true if it matches
    'boolean function
    Public Function getLogin()
        Dim count As Integer = 0 'declare variable count for login matches
        Dim login_correct As Boolean = False 'variable for login match
        'try to connect to MySQL server
        Try
            connection.ConnectionString = server_string
            connection.Open() 'open connection
            'sql query
            Dim sql_query As String = "SELECT login.username,login.password,login.user_type FROM login_tb login WHERE BINARY login.username = BINARY '" & userName & "' AND login.password=MD5('" & passWord & "')"
            'connect to database and bind query
            sql_command = New MySqlCommand(sql_query, connection)
            sql_command.CommandText = sql_query 'execute command
            'get data from database
            sql_data_adapter.SelectCommand = sql_command
            sql_data_adapter.Fill(data_table) ' fill data table with rows from sql command earlier

            'get row count from database
            count = data_table.Rows.Count
            If count = 1 Then
                'this means that userName and passWord is correct
                login_correct = True
                'get employee details
                Dim user_type As Integer = data_table.Rows(0).Item(2)
                setUserType(user_type) 'declare method set user type. 1 for techinician, 2 for Admin
            End If
        Catch ex As MySqlException
            'catch errors
            MsgBox(ex.Message)
        Finally
            'dispose and close connection
            sql_data_adapter.Dispose()
            connection.Close()
            connection.Dispose()
        End Try

        'return
        Return login_correct
    End Function

End Class
