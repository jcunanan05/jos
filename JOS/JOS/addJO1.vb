Public Class addJO1
    'Instance Variables
    'new WindowMaker Instance/object
    Dim newWindow As windowNamer = New windowNamer()
    'form windowID
    Dim windowID As String = newWindow.getWindowID()

    'TAB1
    Private oldCustomerID As String = ""
    Private jobRepairType As Integer = 0
    Private isNewCustomer As Boolean = False
    'TAB2
    '  jobservice
    Private pickJobSvcID As String = ""
    Private pickJobSvcPrice As Decimal = 0.0
    Private pickTempSvcID As String = ""
    Private pickTempSvcPrice As Decimal = 0.0

    Private tempSvcCount As Integer = 0
    'will be a decimal variable
    Private WithEvents tempSvcPrice As New priceEvent

    '  parts
    Private pickPartID As String = ""
    Private pickPartPrice As Decimal = 0.0
    Private pickPartQuantity As Integer = 0

    Private pickTempPartID As String = ""
    Private pickTempPartPrice As Decimal = 0.0
    Private pickTempPartQty As Integer = 0

    Private tempPartCount As Integer = 0
    'will be a decimal variable later
    Private WithEvents tempPartPrice As New priceEvent

    ' grand total
    Private grandTotal As Decimal = 0.0
    Private addCharge As Decimal = 0.0

    'TAB 3
    Private repairDate As Date = Date.Now()
    Private repairDay As Integer = 0
    Private claimDate As Date = Date.Now()
    Private warrantyDay As Integer = 0
    Private warrantyDate As Date = Date.Now()

    'tabpage index
    Private tabNumber As Integer = 0

    'form onClose
    Private Sub addJO1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'when form is closed
        'empty temp_svc_tb in DB
        tempServiceDB.emptyTempService(windowID)
        'empty temp_part_tb in DB
        tempPartsDB.emptyTempPart(windowID)
        'delete entry from window_maker_tb in DB
        newWindow.deleteWindowID(windowID)
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
        'set tempSvcPrice 0
        tempSvcPrice.DecimalVariable = 0
        'set tempPartPrice 0
        tempPartPrice.DecimalVariable = 0

        'TAB 3
        'set warranty type combo box
        setWarrantyCombo()
        'set repair date datetimepicker
        repair_datepicker.Value = Date.Now()
        'disable repair_day_updown
        repairDayEnabled(False)
        'set repair_date_label
        setRepairDateLabel()
        'setRepairDay
        setRepairDay(0)
        'set claimDate
        setClaimDate()
        'set claim date label
        setExcpectClaimLabel()
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
        Dim addService As tempServiceDB = New tempServiceDB(pickJobSvcID, windowID)
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
        tempServiceDB.getSomeJobService(job_service_datagrid, windowID)
    End Sub

    ''''''''' ALL TEMP SVC

    'void method
    Private Sub setTempSvcDataGrid()
        'set datagrid of temporary chosen services
        tempServiceDB.getTempJobService(temp_svc_datagrid, windowID)
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
        tempSvcPrice.DecimalVariable = temp_svc_price
        'update label
        temp_svc_price_label.Text = getTempSvcPrice()
    End Sub
    'getter method
    'returns Decimal
    Private Function getTempSvcPrice()
        'returns decimal format
        Return tempSvcPrice.DecimalVariable
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
            Dim deleteSvc As tempServiceDB = New tempServiceDB(pickTempSvcID, windowID)
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
        tempServiceDB.emptyTempService(windowID)
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

    'update table with restriction from temp_part_tb
    Private Sub setSomePartsDatagrid()
        'set datagridview for job parts
        tempPartsDB.getSomeItem(parts_data_grid, windowID)
    End Sub

    'cell onClick
    Private Sub parts_data_grid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles parts_data_grid.CellClick
        'when parts datagrid is clicked
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.parts_data_grid.Rows(e.RowIndex)
            'assign to instance variable
            setPartsIDLabel(row.Cells(0).Value, row.Cells(5).Value)
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
        setSomePartsDatagrid()
    End Sub

    'reset parts_id_label
    Private Sub resetPartsIDLabel()
        'empty pickPartID variable
        setPickPartID("")
        'empty pickPartPrice variable
        setPickPartPrice(0.0)
        'empty pickPartQuantity variable
        setPickPartQuantity(1)
        'set updown
        part_qty_updown.Value = getPickPartQuantity()
        'display select above text
        part_id_label.Text = "Select Above"
    End Sub
    'void method
    Private Sub setPartsIDLabel(ByRef part_id As String, ByRef part_price As Decimal)
        'set parts label text and update selectedPartID
        'update instance variable selectedPartID
        setPickPartID(part_id)
        'update pickPartPrice
        setPickPartPrice(part_price)
        'update pickPartQuantity
        setPickPartQuantity(part_qty_updown.Value) 'updown value
        'update label
        part_id_label.Text = getPickPartID()
    End Sub
    'setter for pickPartID()
    Private Sub setPickPartID(ByRef part_id As String)
        'set value for pickPartID
        pickPartID = part_id
    End Sub
    'getter for pickPartID()
    Private Function getPickPartID()
        'return string
        Return pickPartID
    End Function

    'setter for pickPartPrice
    Private Sub setPickPartPrice(ByRef part_price As Decimal)
        'set value for pickPartPrice
        pickPartPrice = part_price
    End Sub
    'getter for pickPartPrice
    Private Function getPickPartPrice()
        'return Decimal
        Return pickPartPrice
    End Function

    'setter for pickPartQuantity
    Private Sub setPickPartQuantity(ByRef part_quantity As Integer)
        'set value for pickPartQuantity
        pickPartQuantity = part_quantity
    End Sub
    'getter for pickPartQuantity
    Private Function getPickPartQuantity()
        'return Integer
        Return pickPartQuantity
    End Function

    'clear_part_datagrid_button onClick event
    Private Sub clear_part_datagrid_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clear_part_datagrid_button.Click
        'when clear selection button is clicked
        'reset part_id_label
        resetPartsIDLabel()
        'clear selection for datagrid
        parts_data_grid.ClearSelection()
    End Sub

    'add_part_button onClick event
    Private Sub add_part_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_part_button.Click
        'when add part button is clicked
        'create new object/instance 
        Dim addPart As tempPartsDB = New tempPartsDB(pickPartID, pickPartQuantity, windowID)
        'check item if exist in database 
        Dim isExist As Boolean = addPart.partExist()
        'check item has plenty parts in db
        Dim isPlenty As Boolean = addPart.partPlenty()

        'if
        If isExist Then
            'if job item exist in DB
            'add to temp_part_db
            addPart.addTempPart()
            'update job item datagrid view
            setSomePartsDatagrid()
            'update temp part service datagrid view
            setTempPartDatagrid()

            'update tempPartCount
            setTempPartCount(getTempPartCount() + 1)
            'compute pickPartPrice*pickPartQuantity
            Dim price_quantity As Decimal = pickPartQuantity * pickPartPrice
            'update tempPartPrice
            setTempPartPrice(getTempPartPrice() + price_quantity)
            'reset job part label
            resetPartsIDLabel()
        Else
            MsgBox("Select a Part.")
        End If
    End Sub

    'part_qty_updown ValueChanged event
    Private Sub part_qty_updown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles part_qty_updown.ValueChanged
        'when part_qty_updown is clicked
        setPickPartQuantity(part_qty_updown.Value)
    End Sub

    ''''''' ALL TEMP PARTS METHODS

    'void method
    Private Sub setTempPartDatagrid()
        'set datagrid of temporary chosen parts
        tempPartsDB.getTempPart(temp_part_datagrid, windowID)
    End Sub

    'temp_part_datagrid CellClick event()
    Private Sub temp_part_datagrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles temp_part_datagrid.CellClick
        'when datagrid is clicked
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.temp_part_datagrid.Rows(e.RowIndex)
            'assign to instance variable, and display text
            setTempPartIDLabel(row.Cells(0).Value, row.Cells(5).Value, row.Cells(4).Value)
        End If
    End Sub

    'setter for temp_part_id_label
    Private Sub setTempPartIDLabel(ByRef temp_part_id As String, ByRef temp_part_price As Decimal, ByRef temp_part_qty As Integer)
        'set displayed text and update tempPartID
        'set pickPartTempID
        setPickTempPartID(temp_part_id)
        'set pickTempPartPrice
        setPickTempPartPrice(temp_part_price)
        'set pickTempPartQty
        setPickTempPartQty(temp_part_qty)

        'display text
        temp_part_id_label.Text = getPickTempPartID()
    End Sub

    'setter for pickTempPartID 
    Private Sub setPickTempPartID(ByRef temp_part_id As String)
        'set value for pickTempPartID
        pickTempPartID = temp_part_id
    End Sub
    'getter for pickTempPartID
    Private Function getPickTempPartID()
        'return string
        Return pickTempPartID
    End Function


    'setter for pickTempPartPrice
    Private Sub setPickTempPartPrice(ByRef temp_part_price As String)
        'set value for pickTempPartPrice
        pickTempPartPrice = temp_part_price
    End Sub
    'getter for pickTempPartPrice
    Private Function getPickTempPartPrice()
        'return Decimal
        Return pickTempPartPrice
    End Function


    'setter for pickTempPartQty
    Private Sub setPickTempPartQty(ByRef temp_part_qty As String)
        'set value for pickTempPartQty
        pickTempPartQty = temp_part_qty
    End Sub
    'getter for pickTempPartQty
    Private Function getPickTempPartQty()
        'return Integer
        Return pickTempPartQty
    End Function


    'setter for tempPartCount
    '@param temp_part_count
    Private Sub setTempPartCount(ByRef temp_part_count As Integer)
        'set value for tempPartCount
        tempPartCount = temp_part_count
        'update temp_part_count_label
        temp_part_count_label.Text = getTempPartCount()
    End Sub
    'getter for tempPartCount
    Private Function getTempPartCount()
        'return Integer
        Return tempPartCount
    End Function

    'setter for tempPartPrice
    '@param temp_part_qty
    '@param temp_part_price
    Private Sub setTempPartPrice(ByRef temp_part_price As Decimal)
        'set value for tempPartPrice
        tempPartPrice.DecimalVariable = temp_part_price
        'update temp_part_price_label
        temp_part_price_label.Text = getTempPartPrice()
    End Sub
    'getter for tempPartPrice
    Private Function getTempPartPrice()
        'return Decimal
        Return tempPartPrice.DecimalVariable
    End Function

    'temp_part_id_label
    Private Sub resetTempPartIDLabel()
        'sets display text for temp_part_id_label
        'reset pickPartID
        setPickPartID("")
        'reset pickTempPartPrice
        setPickTempPartPrice(0.0)
        'reset pickTempPartQuantity
        setPickPartQuantity(0)
        'reset display
        temp_part_id_label.Text = "Select Above"
    End Sub

    'remove_part_button onClick Event
    Private Sub remove_part_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles remove_part_button.Click
        'when remove part button is clicked
        'remove selected part from temp_part_tb
        If Not pickTempPartID = "" Then
            'if pickTempPartID is not empty
            'create new instance/object
            Dim deletePart As tempPartsDB = New tempPartsDB(pickTempPartID, pickTempPartQty, windowID)
            deletePart.removeTempPart()

            'update temp_part_datagrid
            setTempPartDatagrid()
            'update list of parts
            setSomePartsDatagrid()
            'set minus 1 in tempPartCount
            setTempPartCount(getTempPartCount() - 1)
            'pickTempPartPrice * pickPartTempQty
            Dim temp_price_quantity As Decimal = pickTempPartQty * pickTempPartPrice
            'subtract price from pickTempPartPrice
            setTempPartPrice(getTempPartPrice() - temp_price_quantity)
            'reset pickTempPartID
            resetTempPartIDLabel()
        Else
            MsgBox("No Part Selected.")
        End If
    End Sub

    'reset_temp_part_button onClick event
    Private Sub reset_temp_part_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset_temp_part_button.Click
        'when reset parts is clicked
        resetTempPartIDLabel()
        'empty temp_part_tb
        tempPartsDB.emptyTempPart(windowID)
        'update temp_part_datagrid
        setTempPartDatagrid()
        'update parts_datagrid
        setSomePartsDatagrid()
        'reset tempPartCount
        resetTempPartCountLabel()
        'reset tempPartPrice
        resetTempPartPriceLabel()
    End Sub

    'reset temp_part_count_label
    Private Sub resetTempPartCountLabel()
        'reset label and count
        setTempPartCount(0)
    End Sub

    'reset temp_part_price_label
    Private Sub resetTempPartPriceLabel()
        'reset label and count
        setTempPartPrice(0.0)
    End Sub
    



    ''''''' ALL GRAND TOTAL METHODS

    'additional_updown ValueChanged Event
    Private Sub additional_updown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles additional_updown.ValueChanged
        'when updown is pressed by up or down key
        setAdditionalUpDown()
    End Sub

    'setter for addtional_updown
    Private Sub setAdditionalUpDown()
        'get value for addtional_updown
        setAddCharge(additional_updown.Value)
        'set grandTotal
        setGrandTotal(getAddCharge() + getTempSvcPrice() + getTempPartPrice())
    End Sub

    'setter for addCharge
    '@param add_charge
    Private Sub setAddCharge(ByRef add_charge As Decimal)
        'set value for addCharge
        addCharge = add_charge
    End Sub
    'getter for addCharge
    Private Function getAddCharge()
        'return Decimal
        Return addCharge
    End Function

    'setter for grandTotal
    Private Sub setGrandTotal(ByRef grand_total As Decimal)
        'set value for grandTotal
        grandTotal = grand_total
        'update display text for grand_total_label
        grand_total_label.Text = getGrandTotal()
    End Sub
    'getter for grandTotal
    Private Function getGrandTotal()
        'return Decimal
        Return grandTotal
    End Function

    'when tempSvcPrice Value is Changed
    Private Sub tempSvcPrice_priceChanged(ByVal temp_svc_price As Decimal) Handles tempSvcPrice.priceChanged
        'update grand total variable
        setAdditionalUpDown()
    End Sub

    'when tempPartPrice Value is Changed
    Private Sub tempPartPrice_priceChanged(ByVal temp_svc_price As Decimal) Handles tempPartPrice.priceChanged
        'update grand total variable
        setAdditionalUpDown()
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

    'getter for oldCustomerID
    Private Function getOldCustomerID()
        'return String
        Return oldCustomerID
    End Function

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
            setIsNewCustomer(True)
        Else
            'disable new customer groupbox
            enableNewCustomerGrpbx(False)
            'enable customer data grid
            enableOldCustomerGrpbx(True)
            'set class variable isNewCustomer
            setIsNewCustomer(False)
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

    'setter for isNewCustomer
    Private Sub setIsNewCustomer(ByRef is_new_customer As Boolean)
        'set value for isNewCustomer
        isNewCustomer = is_new_customer
    End Sub

    'getter for isNewCustomer
    Private Function getIsNewCustomer()
        'return boolean
        Return isNewCustomer
    End Function



    '''''''' ALL WARRANTY METHODS

    'setter for repairDate
    Private Sub setRepairDate(ByRef repair_date As Date)
        'set value for repairDate
        repairDate = repair_date
    End Sub

    'getter for repairDate
    Private Function getRepairDate()
        'return Date
        Return repairDate
    End Function

    'repair_datepicker ValueChanged Event
    Private Sub repair_datepicker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles repair_datepicker.ValueChanged
        'get value from datepicker
        setRepairDate(repair_datepicker.Value())
        setRepairDateLabel()
        'set claim date
        setClaimDate()
        setExcpectClaimLabel()
        'set warrantyDate
        setWarrantyDate()
        'display Text
        setExpectWarrantyLabel()
    End Sub

    'set display text for repair_date_label
    Private Sub setRepairDateLabel()
        'display text
        Dim display_date As Date = getRepairDate()
        Dim string_date As String = display_date.ToString("dddd MMMM dd, yyyy")
        repair_date_label.Text = string_date
    End Sub

    'setter for repairDay
    Private Sub setRepairDay(ByRef repair_day As Integer)
        'set value for repairDay
        repairDay = repair_day
    End Sub

    'getter for repairDay
    Private Function getRepairDay()
        'return Integer
        Return repairDay
    End Function

    'setter for claimDate
    Private Sub setClaimDate()
        'set value for repairDate
        claimDate = getRepairDate().AddDays(getRepairDay())
    End Sub

    'getter for claimDate
    Private Function getClaimDate()
        'return Date
        Return claimDate
    End Function

    'set display text for expect_claim_label
    Private Sub setExcpectClaimLabel()
        'set display text for expected claim date
        'display text
        Dim display_date As Date = getClaimDate()
        Dim string_date As String = display_date.ToString("dddd MMMM dd, yyyy")
        expect_claim_label.Text = string_date
    End Sub

    'repair_day_updown ValueChanged event
    Private Sub repair_day_updown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles repair_day_updown.ValueChanged
        'set repair day and claim date
        'when repair days is changed
        setRepairDay(repair_day_updown.Value())
        'set claimDate
        setClaimDate()
        'display text
        setExcpectClaimLabel()
        'set warrantyDate
        setWarrantyDate()
        'display Text
        setExpectWarrantyLabel()
    End Sub

    'repair_day_updown Enabled
    Private Sub repairDayEnabled(ByRef is_enabled As Boolean)
        'sets enable or not for repair_day_updown
        repair_day_updown.Enabled = is_enabled
    End Sub

    'setter for warrantyDate
    Private Sub setWarrantyDate()
        'set value for warrantyDate
        warrantyDate = getClaimDate().AddDays(getWarrantyDay())
    End Sub

    'getter for warrantyDate
    Private Function getWarrantyDate()
        'return Date
        Return warrantyDate
    End Function

    'setter for warrantyDay
    Private Sub setWarrantyDay(ByRef warranty_day As Integer)
        'set value for warrantyDay
        warrantyDay = warranty_day
    End Sub

    'getter for warrantyDay
    Private Function getWarrantyDay()
        'return Integer
        Return warrantyDay
    End Function

    'set display text for expect_warranty_label
    Private Sub setExpectWarrantyLabel()
        'set warranty date based on claim date and warranty day
        Dim display_date As Date = getWarrantyDate()
        'to string
        Dim string_date As String = display_date.ToString("dddd MMMM dd, yyyy")
        'set label
        expect_warranty_label.Text = string_date
    End Sub

    'warranty_combo SelectedIndexChanged Event
    Private Sub warranty_combo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles warranty_combo.SelectedIndexChanged
        Dim warranty_day As Integer = 0
        'get text from combo box
        warranty_day = warrantyDB.getWarrantyDay(warranty_combo.SelectedItem.ToString())
        'update warrantyDay
        setWarrantyDay(warranty_day)
        'set warrantyDate
        setWarrantyDate()
        'display Text
        setExpectWarrantyLabel()
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

            'set disabled for days of repair
            repairDayEnabled(False)
            'set repairDay to zero
            setRepairDay(0)
            'set claimDate
            setClaimDate()
            'display text for expected claim
            setExcpectClaimLabel()
            'set warrantyDate
            setWarrantyDate()
            'display text for warranty label
            setExpectWarrantyLabel()

            
        End If
    End Sub

    'admit_radio onClick
    Private Sub admit_radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles admit_radio.CheckedChanged
        'when admit radio button is checked
        If admit_radio.Checked Then
            'if admit radio button is checked
            setJobRepairType(2)

            'set disabled for days of repair
            repairDayEnabled(True)
            'when repair days is changed
            setRepairDay(repair_day_updown.Value())
            'set claimDate
            setClaimDate()
            'display text
            setExcpectClaimLabel()
            'set warrantyDate
            setWarrantyDate()
            'display Text
            setExpectWarrantyLabel()
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

    ''''''''''' ALL TAB PAGES METHODS

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


    ''''''' WINDOW ID
    Public ReadOnly Property getWindowID() As String
        Get
            Return windowID
        End Get
    End Property


    '''''' SUBMIT BUTTON

    'submit_button onClick event
    Private Sub submit_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submit_button.Click
        'Dim addJobOrder As jobOrderDB = New jobOrderDB(getIsNewCustomer(), getJobRepairType(), , getGrandTotal(), , )

        'check if fields are all filled
        Dim fieldEmpty As Boolean = isFieldEmpty()

        'if
        If fieldEmpty = False Then
            'generate are you sure message
            Dim confirmAddJobOrder As Object = MessageBox.Show("Add Job Order?", "Confirm Add Job Order", MessageBoxButtons.YesNo)
            'if confirm add job order
            If confirmAddJobOrder = DialogResult.No Then
                'proceed
                Exit Sub
            End If
            'if fields are correctly filled

            Dim job_order_id As String = "" ' JOB ORDER ID
            'TAB 1 LOCAL VARIABLES
            '  new customer details
            Dim new_customer_id As String = "" ' new customerID
            Dim customer_name As String = ""
            Dim customer_contact As String = ""
            ' old customer details
            Dim old_customer_id As String = getOldCustomerID()
            ' job order details
            Dim job_customer_id As String = "" ' new_customer_id or old_customer_id
            Dim job_repair_type As Integer = getJobRepairType()
            Dim job_item_name As String = item_name_txtbox.Text
            Dim total_price As Decimal = getGrandTotal()
            Dim watch_serial_no As String = watch_serial_no_txtbox.Text
            Dim watch_remark As String = watch_desc_txtbox.Text
            ' technician
            Dim technician_id As String = ""
            Dim watch_build_id As Integer = 0
            Dim watch_kind_id As Integer = 0
            'TAB 3 LOCAL Variables
            Dim start_repair_date As Date = getRepairDate()
            Dim expected_claim_date As Date = getClaimDate()
            Dim warranty_id As String = ""
            Dim warranty_remark As String = warranty_remark_txtbox.Text
            Dim warranty_expire_date As Date = getWarrantyDate()

            'TAB 2 LOCAL VARIABLES


            ' TAB 1 PROCESSES
            Dim new_customer As Boolean = getIsNewCustomer()
            If new_customer Then
                'if new customer is true

                'declare variables
                Dim first_name, last_name, middle_i As String
                'add comma to the lastname
                last_name = last_name_txtbox.Text & ", "
                'add space to the first name
                first_name = first_name_txtbox.Text & " "
                'add period to the middle initial
                middle_i = middle_i_txtbox.Text & "."

                'main variable
                customer_name = last_name & first_name & middle_i 'concatenated
                customer_contact = contact_no_txtbox.Text

                'CREATE NEW OBJECT/INSTANCE for customerDB
                Dim newCustomer As customerDB = New customerDB(customer_name, customer_contact)
                Dim sameCustomerName As Boolean = newCustomer.sameName()
                Dim sameCustomer As Boolean = newCustomer.sameCustomer()

                'SAME NAME CHECK
                If sameCustomerName = False Then
                    'has no name match in DB
                    If sameCustomer = False Then
                        'has no same name and contact in DB
                        newCustomer.addCustomer()
                    End If
                ElseIf sameCustomerName Then
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

                        'BREAK out of method
                        Exit Sub
                    End If
                End If

                'get newCustomerID
                new_customer_id = newCustomer.getCustomerID()
                ' equip to job_customer_id
                job_customer_id = new_customer_id
            Else
                'if old customer
                job_customer_id = getOldCustomerID()
            End If


            'ALL Technician Details
            Dim technician_name As String = technician_combo.SelectedItem.ToString()
            'create new instance/object
            Dim newTechnician As technicianDB = New technicianDB(technician_name)
            Dim sameTechnicianName As Boolean = newTechnician.sameName()
            'SAME NAME check
            If sameTechnicianName Then
                'has name match in db
                'get technician_id from DB
                technician_id = newTechnician.getTechnicianID()
            Else
                'has no match in db
                MsgBox(newTechnician.wrongName())
                'BREAK FROM METHOD
                Exit Sub
            End If

            'watch_serial_no get text. check above

            'get watch_build_combo SelectedItem
            Dim watch_build_remark As String = watch_build_combo.SelectedItem.ToString()
            'get watch build ID from DB
            watch_build_id = watchDB.getWatchBuildID(watch_build_remark)

            'get watch_kind_combo Selected Item
            Dim watch_kind_remark As String = watch_kind_combo.SelectedItem.ToString()
            'escape string for watch_kind_remark
            watch_kind_remark = Replace$(watch_kind_remark, "'", "''")
            'get watch kind ID from DB
            watch_kind_id = watchDB.getWatchKindID(watch_kind_remark)


            'TAB 3 PROCESSES
            Dim warranty_type_remark As String = warranty_combo.SelectedItem.ToString()
            'create new instance/object for warranty
            Dim checkWarranty As warrantyDB = New warrantyDB(warranty_type_remark)
            ' check if warranty exist in DB
            Dim warrantyExist As Boolean = checkWarranty.warrantyTypeRemarkExist()
            'if
            If warrantyExist Then
                'if warranty type remark exists in DB
                warranty_id = checkWarranty.getWarrantyID()
            Else
                'if warranty type remark doesn't exist in DB
                MsgBox(checkWarranty.wrongTypeRemark()) 'error message
                'BREAK out FROM THE METHOD
                Exit Sub
            End If


            'ADD JOB ORDER
            'create new instance/object for jobOrderDb
            Dim addJobOrder As jobOrderDB = New jobOrderDB(job_repair_type, job_item_name, watch_remark, total_price, watch_serial_no)
            Dim sameJobOrder As Boolean = addJobOrder.sameJobOrder(job_customer_id, watch_kind_id, watch_build_id, technician_id, start_repair_date, expected_claim_date, warranty_id)
            'if
            If sameJobOrder = False Then
                'if job order doesn't exist
                'add Job order
                addJobOrder.addJobOrder()
                'get job_order_id from DB
                job_order_id = addJobOrder.getJobOrderID()
            Else
                'if job order exist
                MsgBox(addJobOrder.wrongJobOrder())
                'BREAK out FROM Method
                Exit Sub
            End If

            'TAB 2 PROCESSES
            'temp_job_svc_datagrid must have atleast 1 row
            'add data from temp_job_svc to repair_svc_tb
            tempServiceDB.addAllRepairService(job_order_id, getWindowID())


            'get parts chosen count
            Dim parts_chosen As Integer = getTempPartCount()
            'if the user added parts in the job order
            If parts_chosen > 0 Then
                'add all temp to repair_part_tb
                tempPartsDB.addAllRepairPart(job_order_id, getWindowID())

                'create new instance/object for repairPartDB
                Dim newRepairPart As repairPartDB = New repairPartDB(job_order_id)
                'update quantity_exist to false when exceed quantity from job
                newRepairPart.setAllLackQty()
                'subtract inventory based on the added parts
                newRepairPart.setAllGoodQty()
            End If

            'TAB 3 PROCESSES
            'create new instance/object for warrantyDB
            Dim addWarrantyJob As warrantyDB = New warrantyDB(job_order_id, warranty_expire_date, warranty_remark)
            'check if exists in db
            Dim warrantyJobExist As Boolean = addWarrantyJob.sameWarrantyJobID()
            'if
            If warrantyJobExist = False Then
                'if job_id wasn't found in DB
                'add to warranty_job_tb
                addWarrantyJob.addWarrantyJob()
            Else
                'generate error msgbox
                MsgBox(addWarrantyJob.wrongWarrantyJob())
            End If


            MsgBox("Correct")
        Else
            'if other fields are empty
            MsgBox("Please fill out all the forms.")
        End If
    End Sub


    ' checks all field if empty
    Private Function isFieldEmpty()
        'returns boolean
        'must be True for the form to continue
        Dim isEmpty As Boolean = True

        'TAB 1
        'technician
        Dim technician As Boolean = (technician_combo.SelectedIndex = -1)

        'isNewCustomer
        Dim is_new_customer As Boolean = getIsNewCustomer()

        'if isNewCustomer is true
        Dim customer As Boolean = True
        If is_new_customer Then
            'check if forms are empty
            Dim first_name As Boolean = (first_name_txtbox.Text = "")
            Dim last_name As Boolean = (last_name_txtbox.Text = "")
            Dim middle_i As Boolean = (middle_i_txtbox.Text = "")
            'return flase if values are not empty
            customer = (first_name And last_name And middle_i)
        ElseIf is_new_customer = False Then
            'return false if not empty
            customer = (getOldCustomerID() = "")
        End If

        'item name
        Dim item_name As Boolean = (item_name_txtbox.Text = "")

        'watch serial no
        Dim watch_serial_no As Boolean = (watch_serial_no_txtbox.Text = "")

        'watch description
        Dim watch_desc As Boolean = (watch_desc_txtbox.Text = "")

        'watch kind combo
        Dim watch_kind As Boolean = (watch_kind_combo.SelectedIndex = -1)

        'watch build combo
        Dim watch_build As Boolean = (watch_build_combo.SelectedIndex = -1)

        'TAB 2
        'job service
        Dim job_service As Boolean = (getTempSvcCount() = 0)

        'TAB 3
        'warranty combo
        Dim warranty As Boolean = (warranty_combo.SelectedIndex = -1)

        'warranty description/remark
        Dim warranty_desc As Boolean = (warranty_remark_txtbox.Text = "")

        isEmpty = (customer Or item_name Or watch_serial_no Or watch_desc Or watch_kind Or watch_build Or job_service Or warranty Or warranty_desc)
        'Return
        Return isEmpty
    End Function


    
End Class


'NEW CLASS
Public Class priceEvent
    'create instance variable 'price
    Private price As Decimal
    'create public event 'priceChanged
    Public Event priceChanged(ByVal price_value As Decimal)

    'define property
    Public Property DecimalVariable() As Decimal
        'initialize DecimalVariable
        Get
            DecimalVariable = price
        End Get
        'set New Value
        '@param price_value
        Set(ByVal price_value As Decimal)
            price = price_value
            'raise event
            RaiseEvent priceChanged(price)
        End Set
    End Property

    'getter for price
    Public Function getPrice()
        'return Decimal
        Return price
    End Function
End Class