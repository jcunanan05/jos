Public Class managerHome
    Private userName As String 'declare username variable
    Private userType As Integer = 2 'based on the user_type_tb, 2 is Manager

    'initalization constructor, has 1 parameter user_name
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

    Private Sub managerHome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'when the form loads
        setUserNameLabel() 'set username label


    End Sub


    Private Sub test_details()
        'for testing employee details
        Dim manager As employeeDB = New employeeDB(userName)
        manager.getEmployee()
        MsgBox(manager.getEmpID())
        MsgBox(manager.getEmpFullName())
        MsgBox("Position Type: " & manager.getPositionType.ToString())
    End Sub

    Private Sub add_emp_label_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles add_emp_label.LinkClicked
        'when add employee link label is clicked

        'create new object/instance
        Dim registerEmp As regEmployee = New regEmployee(userName, userType) 'arguments username and usertype
        registerEmp.Show() ' show regEmployee form
    End Sub

    Private Sub add_product_label_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles add_product_label.LinkClicked
        'when add product is clicked

        'create new object/instance
        Dim addInventory As addInv = New addInv(userName)
        addInventory.Show() 'show addInv form
    End Sub

    Private Sub add_service_label_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles add_service_label.LinkClicked
        'when add job service is clicked

        'create new object/instance
        Dim addJobService As addService = New addService(userName)
        addJobService.Show()
    End Sub


    Private Sub add_customer_label_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles add_customer_label.LinkClicked
        'when add customer is clicked

        'create new object/instance
        Dim addCustomerForm As addCustomer = New addCustomer(userName)
        addCustomerForm.Show()
    End Sub

    Private Sub see_employee_label_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles see_employee_label.LinkClicked
        'when see customer is clicked

        'create new object/instance
        Dim seeEmployees As seeEmployee = New seeEmployee()
        seeEmployees.Show()
    End Sub
End Class