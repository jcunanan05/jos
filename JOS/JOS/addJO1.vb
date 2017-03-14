Public Class addJO1
    'Instance Variables
    'TAB1
    Private oldCustomerID As String = ""
    Private jobRepairType As Integer = 0
    Private isNewCustomer As Boolean = False
    'TAB2

    Private pickJobSvcID As String = ""
    Private pickJobSvcPrice As Decimal = 0.0
    Private pickTempSvcID As String = ""
    Private pickTempSvcPrice As Decimal = 0.0

    Private tempSvcCount As Integer = 0
    Private tempSvcPrice As Decimal = 0.0
    Private pickPartID = ""
    'tabpage index
    Private tabNumber As Integer = 0

    'form onClose
    Private Sub addJO1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'when form is closed
        'empty temp_svc_tb in DB
        tempServiceDB.emptyTempService()
    End Sub

    'form onCreate
    Private Sub addJO1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'when the form Loads

        'TAB 1
        'set customer data grid
        setOldCustomerDataGrid()
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
    Private Sub setSerialLabel()
        'display latest serial number
        Dim newSerial As Integer = 0
        newSerial = jobOrderDB.getNewSerial()
        serial_label.Text = newSerial.ToString()
    End Sub

    ''''''ALL JOB SERVICES METHODS

    'void method
    Private Sub setJobServiceIDLabel(ByRef job_service_id As String, ByRef job_service_price As Decimal)
        Try
            'set job service id label
            setPickJobSvcID(job_service_id)
            'set job service price
            setPickJobSvcPrice(job_service_price)
            'update label text
            job_service_id_label.Text = getPickJobSvcID()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    'getter for pickJobSvcID
    Private Function getPickJobSvcID()
        'return String for pickJobSvcID
        Return pickJobSvcID
    End Function
    'setter for pickJobSvcID
    Private Sub setPickJobSvcID(ByRef pick_job_svc_id As String)
        'set value for pickJobSvcID
        pickJobSvcID = pick_job_svc_id
    End Sub

    'getter for pickJobSvcPrice
    Private Function getPickJobSvcPrice()
        'return Decimal for pickJobSvcPrice
        Return pickJobSvcPrice
    End Function
    'setter for pickJobSvcPrice
    Private Sub setPickJobSvcPrice(ByRef pick_job_svc_price As Decimal)
        'set value for pickJobSvcPrice
        pickJobSvcPrice = pick_job_svc_price
    End Sub


    'void method
    Private Sub resetJobServiceIDLabel()
        'reset the label of selected job id and set instance variable to""
        setPickJobSvcID("")
        setPickJobSvcPrice(0.0)
        job_service_id_label.Text = "Select Above"
    End Sub

    'button onClick
    Private Sub add_service_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_service_button.Click
        'when add service button is clicked
        'create new object/instance
        Dim addService As tempServiceDB = New tempServiceDB(pickJobSvcID)
        'check if job service id exist in database
        Dim isExist As Boolean = addService.jobServiceExist()
        'if
        If isExist Then
            'if job service exists in DB
            'add job service to temp_svc_tb
            addService.addTempSvc()
            'update job service datagrid view
            setSomeJobServiceDataGrid()
            'update temp job service datagrid view
            setTempSvcDataGrid()

            'update tempSvcCount
            setTempSvcCount(getTempSvcCount() + 1)
            'update tempSvcPrice
            setTempSvcPrice(getTempSvcPrice() + getPickJobSvcPrice())
            'reset job service label
            resetJobServiceIDLabel()
        Else
            'if job service not found in the DB
            MsgBox(addService.wrongJobService())
        End If
    End Sub

    'clear_svc_datagrid_button onClick()
    Private Sub clear_svc_datagrid_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clear_svc_datagrid_button.Click
        'if clear selection is clicked
        'reset variable and label
        resetJobServiceIDLabel()
        'clear datagrid selection
        job_service_datagrid.ClearSelection()
    End Sub

    'job_service_datagrid onClick
    Private Sub job_service_datagrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles job_service_datagrid.CellClick
        'when job service datagrid is clicked
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.job_service_datagrid.Rows(e.RowIndex)
            'assign to instance variable selectedJobServiceID
            setJobServiceIDLabel(row.Cells(0).Value, row.Cells(2).Value)
        End If
    End Sub

    ' void method
    Private Sub job_service_datagrid_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles job_service_datagrid.DataBindingComplete
        'clear selection of job_service_datagrid
        job_service_datagrid.ClearSelection()
    End Sub

    'refresh_service_label onClick
    Private Sub refresh_service_label_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles refresh_service_label.LinkClicked
        'refresh service datagrid
        setSomeJobServiceDataGrid()
    End Sub

    'void method
    Private Sub setJobServiceDatagrid()
        'set datagridview for job service
        jobDescDB.getAllJobService(job_service_datagrid) 'function call other class
    End Sub

    'void method
    Private Sub setSomeJobServiceDataGrid()
        'set datagrid with filtered data from temp_svc_tb
        tempServiceDB.getSomeJobService(job_service_datagrid)
    End Sub

    ''''''''' ALL TEMP SVC

    'void method
    Private Sub setTempSvcDataGrid()
        'set datagrid of temporary chosen services
        tempServiceDB.getTempJobService(temp_svc_datagrid)
    End Sub

    'temp_svc_datagrid cellclick
    Private Sub temp_svc_datagrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles temp_svc_datagrid.CellClick
        'when temp_svc_datagrid is clicked
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.temp_svc_datagrid.Rows(e.RowIndex)
            'assign to label temp_svc_id_label
            setTempSvcIDLabel(row.Cells(0).Value, row.Cells(2).Value)
        End If
    End Sub

    'setter method
    Private Sub setTempSvcIDLabel(ByRef temp_svc_id As String, ByRef temp_svc_price As Decimal)
        'set temp_svc_id_label and pickTempSvcID
        setPickTempSvcID(temp_svc_id)
        'set pickTempSvcPrice
        setPickTempSvcPrice(temp_svc_price)
        'display 
        temp_svc_id_label.Text = getPickTempSvcID()
    End Sub

    'reset temp_svc_id_label
    Private Sub resetTempSvcIDLabel()
        'reset pickTempSvcID and pickTempSvcPrice and temp_svc_id_label
        setPickTempSvcID("")
        'reset pickTempSvcPrice
        setPickTempSvcPrice(0.0)
        'reset display
        temp_svc_id_label.Text = "Select Above"
    End Sub

    'setter method
    Private Sub setTempSvcPrice(ByRef temp_svc_price As Decimal)
        'set tempSvcTotal Price
        tempSvcPrice = temp_svc_price
        'update label
        temp_svc_price_label.Text = getTempSvcPrice()
    End Sub
    'getter method
    'returns Decimal
    Private Function getTempSvcPrice()
        'returns decimal format
        Return tempSvcPrice
    End Function
    'reset method
    Private Sub resetTempSvcPriceLabel()
        'reset tempSvcPrice and label
        setTempSvcPrice(0.0)
        'update label display
        temp_svc_price_label.Text = getTempSvcPrice()
    End Sub

    'setter method
    Private Sub setTempSvcCount(ByRef temp_svc_count As Integer)
        'set tempSvcCount
        tempSvcCount = temp_svc_count
        'update temp_svc_count_label
        temp_svc_count_label.Text = getTempSvcCount()
    End Sub
    'getter method
    'returns Integer
    Private Function getTempSvcCount()
        'returns integer format
        Return tempSvcCount
    End Function
    'reset method
    Private Sub resetTempSvcCountLabel()
        'reset label and count
        setTempSvcCount(0)
        'update label display
        temp_svc_count_label.Text = getTempSvcCount()
    End Sub

    'getter method
    Private Function getPickTempSvcPrice()
        'return pickTempSvcPrice
        Return pickTempSvcPrice
    End Function
    'setter method
    Private Sub setPickTempSvcPrice(ByRef pick_temp_svc_price As Decimal)
        'set pickTempSvcPrice
        pickTempSvcPrice = pick_temp_svc_price
    End Sub

    'getter method
    Private Function getPickTempSvcID()
        'return pickTempSvcID
        Return pickTempSvcID
    End Function
    'setter method
    Private Sub setPickTempSvcID(ByRef pick_temp_svc_id As String)
        'set pickTempSvcID
        pickTempSvcID = pick_temp_svc_id
    End Sub

    'remove service button onClick event
    Private Sub remove_service_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles remove_service_button.Click
        'remove selected service from temp_svc_datagrid
        If Not pickTempSvcID = "" Then
            'if pickTempSvcID is not empty
            'create new instance/object
            Dim deleteSvc As tempServiceDB = New tempServiceDB(pickTempSvcID)
            deleteSvc.removeTempSvc()

            'update temp_svc_datagrid
            setTempSvcDataGrid()
            'update list of services
            setSomeJobServiceDataGrid()
            'set minus 1 in tempSvcCount
            setTempSvcCount(getTempSvcCount() - 1)
            'subtract price from pickTempSvcPrice
            setTempSvcPrice(getTempSvcPrice() - getPickTempSvcPrice())
            'reset pickTempSvcID
            resetTempSvcIDLabel()
        Else
            MsgBox("No Job Service selected.")
        End If
    End Sub

    'reset temp svc button onClick event
    Private Sub reset_temp_svc_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset_temp_svc_button.Click
        'empty datagrid and temp_svc_tb
        resetTempSvcIDLabel()
        'empty temp_svc_tb
        tempServiceDB.emptyTempService()
        'update temp_svc_datagrid
        setTempSvcDataGrid()
        'update job_svc_datagrid
        setSomeJobServiceDataGrid()
        'reset tempSvcCount
        resetTempSvcCountLabel()
        resetTempSvcPriceLabel()
    End Sub


    ''''''''ALL PARTS METHODS

    'void method
    Private Sub setPartsDatagrid()
        'set datagridview for job parts
        inventoryDB.getAllItem(parts_data_grid)
    End Sub

    'cell onClick
    Private Sub parts_data_grid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles parts_data_grid.CellClick
        'when parts datagrid is clicked
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.parts_data_grid.Rows(e.RowIndex)
            'assign to instance variable
            setPartsIDLabel(row.Cells(0).Value)
        End If
    End Sub

    'void method
    Private Sub parts_data_grid_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles parts_data_grid.DataBindingComplete
        'clear selection of parts data grid
        parts_data_grid.ClearSelection()
    End Sub

    'label onClick
    Private Sub refresh_parts_label_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles refresh_parts_label.LinkClicked
        'refresh parts datagrid
        setPartsDatagrid()
    End Sub

    'void method
    Private Sub setPartsIDLabel(ByRef part_id As String)
        'set parts label text and update selectedPartID
        'update instance variable selectedPartID
        pickPartID = part_id
        'update label
        part_id_label.Text = pickPartID
    End Sub

    ''''''''''' ALL CUSTOMER METHODS

    'void method
    Private Sub setOldCustomerDataGrid()
        'set or update customer data gridview
        customerDB.getAllCustomer(customer_data_grid)
        'clear selection
        customer_data_grid.ClearSelection()
    End Sub

    'customer_data_grid onClick
    Private Sub customer_data_grid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles customer_data_grid.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.customer_data_grid.Rows(e.RowIndex)
            'update label and instance variable
            setOldCustomerLabel(row.Cells(0).Value, row.Cells(1).Value)
        End If
    End Sub

    'void method
    Private Sub setOldCustomerLabel(ByRef customer_id As String, ByRef customer_name As String)
        'update customer label and existing customer id instance variable
        'update existingCustomerID
        setOldCustomerID(customer_id)
        'update customer name
        old_customer_label.Text = customer_name
    End Sub

    'setter for oldCustomerID
    Private Sub setOldCustomerID(ByRef old_customer_id As String)
        'set value for oldCustomerID
        oldCustomerID = old_customer_id
    End Sub
    'void method
    Private Sub resetOldCustomer()
        'clear variable, disable the customer icon
        customer_data_grid.ClearSelection()
        'reset existing customer id
        setOldCustomerID("")
        'reset label
        resetOldCustomerLabel()
        'disable customer datagridview
        enableOldCustomerGrpbx(False)
    End Sub

    'void method
    Private Sub resetOldCustomerSearchBox()
        'empty search customer textbox
        search_customer_txtbox.Text = ""
    End Sub

    'void method
    Private Sub resetOldCustomerLabel()
        'reset the label of existing customer
        old_customer_label.Text = "Select Above"
    End Sub

    'void method
    '@param isEnabled
    Private Sub enableOldCustomerDataGrid(ByRef isEnabled As Boolean)
        'enable or disable customer data grid
        customer_data_grid.Enabled = isEnabled
    End Sub

    'void method
    Private Sub enableOldCustomerGrpbx(ByRef isEnabled As Boolean)
        'enable or disable customer list groupbox
        old_customer_grpbx.Enabled = isEnabled
    End Sub

    'void method
    '@param isEnabled
    Private Sub enableNewCustomerGrpbx(ByRef isEnabled As Boolean)
        'enable or disable groupbox of new customer
        new_customer_grpbox.Enabled = isEnabled
    End Sub

    'checkbox onCheck
    Private Sub new_customer_chbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles new_customer_chbox.CheckedChanged
        'when new customer checkbox is checked
        If new_customer_chbox.Checked Then
            'enable new customer groupbox
            enableNewCustomerGrpbx(True)
            'reset new customer
            resetOldCustomer()
            'set class variable isNewCustomer
            isNewCustomer = True
        Else
            'disable new customer groupbox
            enableNewCustomerGrpbx(False)
            'enable customer data grid
            enableOldCustomerGrpbx(True)
            'set class variable isNewCustomer
            isNewCustomer = False
        End If
    End Sub

    'search_customer_button onClick
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

    ''''''''' ALL JOB TYPE METHODS

    'void method
    Private Sub setJobTypeRadio()
        'set On the go as default radiobutton checked
        'set radio buttons
        otg_radio.Checked = True
        admit_radio.Checked = False
        'set class variable jobRepairType
        setJobRepairType(1)
    End Sub

    'setter method for jobRepairType
    Private Sub setJobRepairType(ByRef job_repair_type As Integer)
        'set Value for jobRepairType
        Select Case job_repair_type
            Case 1 To 2
                jobRepairType = job_repair_type
            Case Else
                MsgBox("jobRepairType Number not Supported.")
        End Select
    End Sub
    'getter method for jobRepairType
    Private Function getJobRepairType()
        'return Integer
        Return jobRepairType
    End Function

    'otg_radio onClick
    Private Sub otg_radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles otg_radio.CheckedChanged
        'when on the go radio button is checked
        If otg_radio.Checked Then
            'if on the go radio button is checked
            setJobRepairType(1)
        End If
    End Sub

    'admit_radio onClick
    Private Sub admit_radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles admit_radio.CheckedChanged
        'when admit radio button is checked
        If admit_radio.Checked Then
            'if admit radio button is checked
            setJobRepairType(2)
        End If
    End Sub

    ''''''''''''' ALL COMBO BOX METHODS

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

    ''''''''''' TAB PAGES METHODS

    'next_tab_button onClick
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

    'prev_tab_button onClick
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