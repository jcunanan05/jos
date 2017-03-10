Public Class techHome
    Public userName As String 'declare username variable

    'initalization constructor
    Public Sub New(ByRef user_name As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userName = user_name 'initalize userName
    End Sub

    Private Sub setUserNameLabel()
        'set username label 
        username_label.Text = userName
    End Sub

    Private Sub techHome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'when the form loads
        setUserNameLabel() 'set username label


    End Sub

    Private Sub test_details()
        'for testing employee details
        Dim technician As employeeDB = New employeeDB(userName)
        technician.getEmployee()
        MsgBox(technician.getEmpID())
        MsgBox(technician.getEmpFullName())
        MsgBox("Position Type: " & technician.getPositionType.ToString())
    End Sub
End Class