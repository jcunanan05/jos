Public Class loginMain
    'create user type, username, password variable for employee who will login
    Private userType As Integer = 0
    Private userName As String = ""
    Private passWord As String = ""

    Private Sub loginMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'when the form loads
    End Sub

    Private Sub login_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles login_button.Click
        'when login button is clicked
        userName = username_textbox.Text 'get text from username_textbox
        passWord = password_textbox.Text 'get text from password_textbox

        'create new object/instance for loginDB
        Dim employee As loginDB = New loginDB(userName, passWord) 'arguments are userName and passWord variable
        Dim loginCorrect As Boolean = employee.getLogin()

        If loginCorrect Then
            'update variable userType
            userType = employee.getUserType()
            'generate success message
            MsgBox(employee.success())
            'call method whichHome
            whichHome(userType) 'choose which dashboard will appear. 1 for technician, 2 for manager
        Else
            MsgBox(employee.wrong()) 'Generates Message box wrong username or password
        End If
    End Sub


    Private Sub whichHome(ByRef user_type As Integer)
        'choose which dashboard home will appear depending on the user type\

        'used case statement to asses user_type
        Select Case user_type
            Case 1 'for technician
                'create new object/instance for techHome
                Dim technician As techHome = New techHome(userName) 'use the userName typed by the user
                technician.Show() 'show the form
            Case 2 'for Manager
                'create new object/instance for managerHome
                Dim manager As managerHome = New managerHome(userName) 'use the userName typed by the user
                manager.Show() 'show the from
            Case Else
                'default case
                MsgBox("No User Type: " + user_type.ToString() + " found.")
        End Select
    End Sub
End Class