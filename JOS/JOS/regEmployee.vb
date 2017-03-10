Public Class regEmployee
    Private managerUserName As String 'manager's username variable
    Private managerUserType As Integer 'manager's user type

    'initialization constructor, has 2 parameters user_name and user_type
    Public Sub New(ByRef user_name As String, ByRef user_type As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        managerUserName = user_name 'initialization of username
        managerUserType = user_type 'initialization usertype
    End Sub

    Private Sub setUserNameLabel()
        'set username label 
        manager_label.Text = managerUserName
    End Sub

    Private Sub regEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'set username label
        setUserNameLabel()
        'set emp_position_combo
        setEmpPositionCombo()
    End Sub

    'void method
    Private Sub setEmpPositionCombo()
        'this method sets the combobox employee position. it gets from the database
        'get array of strings in the database from employeeDB.vb class
        Dim arrayRemark() As String = employeeDB.getPositionTypeRemark()
        'get the max length of array and set it equal to max drop down of the combo box
        emp_position_combo.MaxDropDownItems = arrayRemark.Length

        'do for loop in array and add it to the combo box
        For Each positionType As String In arrayRemark
            emp_position_combo.Items.Add(positionType)
        Next
    End Sub

    Private Sub register_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles register_button.Click
        'when register button is clicked

        'assign to variables
        Dim firstName As String = first_name_textbox.Text
        Dim middleInitial As String = middle_i_textbox.Text
        Dim lastName As String = last_name_textbox.Text

        'declare variable for argument in newEmployee()
        Dim fullName As String = firstName & " " & middleInitial & " " & lastName
        Dim userName As String = new_user_name_textbox.Text
        Dim passWord As String = new_password_textbox.Text
        Dim passWordConfirm As String = new_confirm_textbox.Text
        Dim positionTypeRemark As String = emp_position_combo.SelectedItem.ToString()

        'create new object/instance registerDB
        Dim newEmployee As registerDB = New registerDB(fullName, userName, passWord, passWordConfirm, positionTypeRemark)
        'check if username is taken
        Dim isTaken As Boolean = newEmployee.usernameTaken()
        'check if password and confirm matches
        Dim isMatch As Boolean = newEmployee.matchPassword()

        If isTaken = False Then
            'if username is available

            If isMatch Then
                'if password and confirm matches
                newEmployee.register() 'register employee
                MsgBox(newEmployee.success()) 'generate success message
            Else
                'if password and confirm doesn't match
                MsgBox(newEmployee.wrongPassWord()) 'generate message password doesn't match
            End If
        Else
            'if username is taken
            MsgBox(newEmployee.wrongUserName()) 'generate message username is taken
        End If
    End Sub
End Class