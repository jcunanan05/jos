Imports MySql.Data.MySqlClient
Public Class jobOrderDB

    'DB class variables
    Private server_string As String = serverStringDB.getServerString()
    Private connection As MySqlConnection = New MySqlConnection
    Private sql_command As MySqlCommand
    Private sql_reader As MySqlDataReader
    Private sql_bind As New BindingSource
    Private sql_data_adapter As New MySqlDataAdapter

    'initialization constructor
    Public Sub New()

    End Sub

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
