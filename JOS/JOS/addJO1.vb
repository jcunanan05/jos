Public Class addJO1
    'Instance Variables
    Private existingCustomerID As String = ""
    Private jobRepairType As Integer = 0
    Private isNewCustomer As Boolean = False
    'tabpage index
    Private tabNumber As Integer = 0

    Private Sub addJO1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'when form is closed

    End Sub


    Private Sub addJO1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'when the form Loads

        'TAB 1
        'set customer data grid
        setCustomerDataGrid()
        'disable new customer groupbox
        enableNewCustomerGrpbx(False)
        'set Technician combobox
        setTechnicianCombo()
        'set serial number
        setSerialLabel()
        'set watch kind combo box
        setWatchKindCombo()
        'set watch build combo box
        setWatchBuildCombo()
        'set job repair type radio button
        setJobTypeRadio()
        'set or initialize tabNumber job tab control index
        tabNumber = getTabNumber()

        'TAB 2
        'set job service datagridview
        setJobServiceDatagrid()
        'set parts datagridview
        setPartsDatagrid()

        'TAB 3
        'set warranty type combo box
        setWarrantyCombo()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'void method
    Private Sub setJobServiceDatagrid()
        'set datagridview for job service
        jobDescDB.getAllJobService(job_service_datagrid) 'function call other class
    End Sub

    'void method
    Private Sub setPartsDatagrid()
        'set datagridview for job service
        inventoryDB.getAllItem(parts_data_grid)
    End Sub

    'void method
    Private Sub setCustomerDataGrid()
        'set or update customer data gridview
        customerDB.getAllCustomer(customer_data_grid)
    End Sub

    'void method
    Private Sub setSerialLabel()
        Dim newSerial As Integer = 0
        newSerial = jobOrderDB.getNewSerial()
        serial_label.Text = newSerial.ToString()
    End Sub

    'void method
    Private Sub setJobTypeRadio()
        'set On the go as default radiobutton checked
        'set radio buttons
        otg_radio.Checked = True
        admit_radio.Checked = False
        'set class variable jobRepairType
        jobRepairType = 1
    End Sub

    

    'void method
    Private Sub setTechnicianCombo()
        'this method sets the combobox Technician. it gets from the database
        'get array of strings in the database from technicianDB.vb class
        Dim arrayName() As String = technicianDB.getTechnicianNames()
        'get the max length of array and set it equal to max drop down of the combo box
        technician_combo.MaxDropDownItems = arrayName.Length

        'do for loop in array and add it to the combo box
        For Each technicianName As String In arrayName
            technician_combo.Items.Add(technicianName)
        Next
    End Sub

    'void method
    Private Sub setWatchBuildCombo()
        'set combo box of watch build
        Dim arrayName() As String = watchDB.getWatchBuildRemark()
        'get max length of array
        watch_build_combo.MaxDropDownItems = arrayName.Length()

        'loop into combo box
        For Each watchBuildName As String In arrayName
            watch_build_combo.Items.Add(watchBuildName)
        Next
    End Sub

    'void method
    Private Sub setWatchKindCombo()
        'set combo box of watch kind
        Dim arrayName() As String = watchDB.getWatchKindRemark()
        'get max length of array
        watch_kind_combo.MaxDropDownItems = arrayName.Length()

        'loop into combo box
        For Each watchKindName As String In arrayName
            watch_kind_combo.Items.Add(watchKindName)
        Next
    End Sub

    'void method
    Private Sub setWarrantyCombo()
        'set combo box of watch build
        Dim arrayName() As String = warrantyDB.getWarrantyTypeRemark()
        'get max length of array
        warranty_combo.MaxDropDownItems = arrayName.Length()

        'loop into combo box
        For Each warrantyRemark As String In arrayName
            warranty_combo.Items.Add(warrantyRemark)
        Next
    End Sub


    Private Sub new_customer_chbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles new_customer_chbox.CheckedChanged
        'when new customer checkbox is checked
        If new_customer_chbox.Checked Then
            'enable new customer groupbox
            enableNewCustomerGrpbx(True)
            'reset new customer
            reset_existing_customer()
            'set class variable isNewCustomer
            isNewCustomer = True
        Else
            'disable new customer groupbox
            enableNewCustomerGrpbx(False)
            'enable customer data grid
            enableCustomerListGrpbx(True)
            'set class variable isNewCustomer
            isNewCustomer = False
        End If
    End Sub

    'void method
    Private Sub customer_data_grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles customer_data_grid.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.customer_data_grid.Rows(e.RowIndex)
            'assign to existing customer id
            existingCustomerID = row.Cells(0).Value 'customer ID
            Dim customer_name As String = row.Cells(1).Value 'customer Name
            'assign to label'
            existing_customer_label.Text = customer_name
        End If
    End Sub

    'void method
    Private Sub reset_existing_customer()
        'clear variable, disable the customer icon
        customer_data_grid.ClearSelection()
        'reset existing customer id
        existingCustomerID = ""
        'reset label
        resetExistingCustomerLabel()
        'disable customer datagridview
        enableCustomerListGrpbx(False)
    End Sub

    'void method
    Private Sub resetCustomerSearchBox()
        'empty search customer textbox
        search_customer_txtbox.Text = ""
    End Sub

    'void method
    Private Sub resetExistingCustomerLabel()
        'reset the label of existing customer
        existing_customer_label.Text = "Select Above"
    End Sub

    'void method
    '@param isEnabled
    Private Sub enableCustomerDataGrid(ByRef isEnabled As Boolean)
        'enable or disable customer data grid
        customer_data_grid.Enabled = isEnabled
    End Sub

    'void method
    Private Sub enableCustomerListGrpbx(ByRef isEnabled As Boolean)
        'enable or disable customer list groupbox
        customer_list_grpbx.Enabled = isEnabled
    End Sub

    'void method
    '@param isEnabled
    Private Sub enableNewCustomerGrpbx(ByRef isEnabled As Boolean)
        'enable or disable groupbox of new customer
        new_customer_grpbox.Enabled = isEnabled
    End Sub

    'void method
    Private Sub search_customer_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles search_customer_button.Click
        'call customer function
        Dim searchText As String = search_customer_txtbox.Text
        customerDB.searchAllCustomer(customer_data_grid, searchText)
    End Sub

    Private Sub search_customer_txtbox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles search_customer_txtbox.KeyPress
        'keypress event
        'handle other characters besides letter, digit, spacebar, and backspace
        If Char.IsLetterOrDigit(e.KeyChar) = False Then
            If e.KeyChar = CChar(ChrW(Keys.Back)) Then
                e.Handled = False
            ElseIf e.KeyChar = CChar(ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub otg_radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles otg_radio.CheckedChanged
        'when on the go radio button is checked
        If otg_radio.Checked Then
            'if on the go radio button is checked
            jobRepairType = 1
        End If
    End Sub

    Private Sub admit_radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles admit_radio.CheckedChanged
        'when admit radio button is checked
        If admit_radio.Checked Then
            'if admit radio button is checked
            jobRepairType = 2
        End If
    End Sub


    Private Sub next_tab_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles next_tab_button.Click
        'when next tab button is clicked
        'initialize tabNumber
        tabNumber = getTabNumber()
        'increase tabNumber
        tabNumber += 1
        'Check if tab number is in range
        Dim maxTabNumber As Integer = job_tab_control.TabCount() 'max TabNumber
        If tabNumber >= 0 AndAlso tabNumber < maxTabNumber Then
            'if tab number is in range
            'show next tab
            job_tab_control.SelectedIndex = tabNumber
        Else
            'if tab number is out of range
            MsgBox("End of page.")
            'set tabNumber to the current tab index
            tabNumber = getTabNumber()
        End If
    End Sub

    Private Sub prev_tab_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prev_tab_button.Click
        'when prev tab button is clicked
        'initialize tabNumber
        tabNumber = getTabNumber()
        'decrease tabNumber
        tabNumber -= 1
        Dim maxTabNumber As Integer = job_tab_control.TabCount() 'max TabNumber
        'check if tab number is in range
        If tabNumber >= 0 AndAlso tabNumber < maxTabNumber Then
            'if tab number is in range
            'show next tab
            job_tab_control.SelectedIndex = tabNumber
        Else
            'if tab number is out of range
            MsgBox("Start of page.")
            'set tabNumber to the current tab index
            tabNumber = getTabNumber()
        End If
    End Sub

    'Integer method
    Private Function getTabNumber()
        'get tabNumber Selected
        Return job_tab_control.SelectedIndex()
    End Function


    Private Sub submit_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submit_button.Click

    End Sub
End Class