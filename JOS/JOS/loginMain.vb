Public Class loginMain
    'create user type, username, password variable for employee who will login
    Private positionType As Integer = 0
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
        Dim newUser As loginDB = New loginDB(userName, passWord) 'arguments are userName and passWord variable
        Dim loginCorrect As Boolean = newUser.getLogin()

        If loginCorrect Then
            'if login is correct

            'update variable userType
            userType = newUser.getUserType()

            'generate success message
            MsgBox(newUser.success())

            Dim isEmp As Boolean = isEmployee(userType) 'check if user is an 1) employee or 2) admin
            If isEmp Then
                'if the user is an employee
                Dim employee As employeeDB = New employeeDB(userName) 'create new object/instance for employeeDB
                employee.getEmployee() 'get employee details

                'update variable positionType
                positionType = employee.getPositionType()

                'call method whichHome
                whichHome(positionType) 'choose which dashboard will appear. 1 for technician, 2 for manager
            Else
                'show admin window
                'wala pa ko nun haha di ko pa alam gagawin ng admin
                showAdmin()
            End If

        Else
            MsgBox(newUser.wrong()) 'Generates Message box wrong username or password
        End If
    End Sub

    'boolean Function
    Public Function isEmployee(ByRef user_type As Integer)
        'check whether user type is employee. if not, then he is admin
        Dim yeah As Boolean = False
        If user_type = 1 Then
            'set yeah to true if user_type = 1 (employee) check user_type_tb at DB
            yeah = True
        End If
        'return
        Return yeah
    End Function

    'void method
    Private Sub whichHome(ByRef position_type As Integer)
        'choose which dashboard home will appear depending on the user type(employee/manager) 
        Select Case position_type
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
                MsgBox("No Position Type: " + position_type.ToString() + " found.")
        End Select
    End Sub

    'void method
    Private Sub showAdmin()
        'show admin window
        MsgBox("Hello Admin")
    End Sub

    Private Sub username_textbox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles username_textbox.KeyPress
        'keypress event
        'handle other characters besides letter, digit, spacebar, and backspace
        If Char.IsLetterOrDigit(e.KeyChar) = False Then
            If e.KeyChar = CChar(ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub username_textbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles username_textbox.TextChanged

    End Sub
End Class