Public Class addCustomer

    'declare instance variables
    Private customerName, customerContact As String
    Private managerUserName As String

    Public Sub New(ByRef manager_user_name As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        managerUserName = manager_user_name
    End Sub

    Private Sub addCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'when the form loads
        'set the serial number
        setSerialLabel()
        'set the data grid view
        setCustomerDataGrid()
        'set the manager label
        setManagerLabel()
    End Sub

    'void method
    Private Sub setCustomerDataGrid()
        'set or update customer data gridview
        customerDB.getAllCustomer(customer_data_grid)
    End Sub

    'void method
    Private Sub setSerialLabel()
        'set serial number in the label

        Dim newSerial As Integer = customerDB.getNewSerial() 'get from db

        'update serial number label
        serial_label.Text = newSerial.ToString()
    End Sub

    'void method
    Private Sub setManagerLabel()
        'set manager label username
        manager_label.Text = managerUserName
    End Sub

    Private Sub add_customer_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_customer_button.Click
        'when add customer button is clicked
        Dim last_name, first_name, middle_i As String
        'add comma to the lastname
        last_name = last_name_txtbox.Text & ", "
        'add space to the first name
        first_name = first_name_txtbox.Text & " "
        'add period to the middle initial
        middle_i = middle_i_txtbox.Text & "."

        'main variable
        customerName = last_name & first_name & middle_i
        customerContact = contact_txtbox.Text

        'create new instance/object
        Dim newCustomer As customerDB = New customerDB(customerName, customerContact)
        Dim sameName As Boolean = newCustomer.sameName()
        Dim sameCustomer As Boolean = newCustomer.sameCustomer()

        If sameName = False Then
            'has no name match in DB
            If sameCustomer = False Then
                'has no same name and contact in DB
                newCustomer.addCustomer()
            End If
        ElseIf sameName Then
            'has same name match in DB
            If sameCustomer = False Then
                'has same name but different number
                'prompt user if he is adding a new or same customer.
                Dim confirm As Object = MessageBox.Show(newCustomer.confirmName, "Same Customer Name", MessageBoxButtons.YesNo)
                If confirm = DialogResult.No Then
                    'user is adding a different customer. they just happen to have same names
                    newCustomer.addCustomer()
                Else
                    'user is adding the same customer but different number
                    MsgBox(newCustomer.wrongCustomer)
                End If
            Else
                'has same name and contact in DB
                MsgBox(newCustomer.wrongCustomer)
            End If
        End If

        'update customer table
        setCustomerDataGrid()
    End Sub
End Class