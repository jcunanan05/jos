Updates
-edited form addJO1
-added tempServiceDB.vb
-added jobDescDB.vb
-added add job service and remove temporary job service functionality


i'll explain that these classes do
loginMain.vb
login_button_click
-checks if username and password is correct 
- if wrong it generates error message
- creates object that belongs to 'loginDB.class'
- checks userType (1 if employee,2 for Admin) method isEmployee()
- checks employee position type (1 if technician, 2 if manager) just created 3 just for testing which is the cashier
- checks which dashboard to display (techHome for 1, managerHome for 2)


loginDB.vb
-requires parameter(username and password)
-handles login in database
-getLogin() checks username and password
- gets userType


employeeDB.vb
-requires paramater(username)
-getEmployee() gets the employee details (full name, position type, username)
-getPositionTypeRemark() is a global function that returns string array that gets from the position_type_tb in DB
-global means you don't need to create objects
-getPositionTypeCount returns how many employee positions are there


techHome.vb
-needs parameter(username)
-displays username in the label


managerHome.vb
-needs parameter(username)
-added add employee that just creates a new object for regEmployee.vb


regEmployee.vb
-needs parameter(username)
-displays manager's username in the label
-setEmpPositionCombo() gets values from employeeDB.getPositionTypeRemark()
-register_button_click - just register new employee when 1)username is available 2) password and confirm matches


registerDB.vb
-requires parameter(full name, username, password, confirm password, position type remark)
-handles registration in DB
-usernameTaken() returns true if username is taken
-matchPassword() returns true if password and confirm password does match


autoIncrementDB.vb
-requires parameter(table name)
-getSerial() returns an integer of the next auto increment number
-used for serial numbers


inventoryDB.vb
-requires parameter(part name, brand, category, supplier, price, quantity, critical_amount)
-handles inventory commands such as add inventory
-supplierTaken(new_checkbox) checks if supplier exists when 'new_supplier' is checked. returns True if supplier exist
-categoryTaken(new_checkbox) checks if category exists when 'new_checkbox' is checked. returns True if category exist
-itemTaken() - checks if an inventory item has the same brand, supplier, category, and partname. returns true if the same item exist.
-addItem(supplier_chbox,category_chbox) - this will add the new item to the inventory with the parameter checkbox if new supplier or not and for category also.
-getPartRemark() - this is a global function that returns a 'string array' of part names
-getCategoryRemark() - this is a global function that returns a 'string array' of watch categories
-getSupplierRemark() - this is a global function that returns a 'string array' of supplier list
-getNewSerial() - this is a global function that returns what will be the next serial number for add inventory
-getRecentlyAdded - this is a global function that requires a DataGridView to display recently added items in the inventory. as of now it will display the first 15 items.


addInv.vb
-setPartNameCombo() - updates combobox for part name. gets from inventoryDB.getPartRemark()
-setCategoryCombo() - updates combobox for Category. gets from inventoryDB.getCategoryRemark()
-setSupplierCombo() - updates combobox for Supplier name. gets from inventoryDB.getSupplierRemark()
-setSerialLabel() - updates serial number label. gets from inventoryDB.getNewSerial()
-add_button_click - in charge of adding inventory. performs same item and same supplier checks before proceeding


customerDB.vb
-requres parameter (customer name, customer contact)
-sameCustomer() - returns true if the customer being added has the same name and number in DB
-sameName() - returns true if the customer being added has the same name in DB
-addCustomer() - adds customer to DB
-getNewSerial() - get latest serial no of customer being added
-getAllCustomer(datagridview) - displays all customers in datagridview


jobDescDB.vb
-requires parameter (job_name, job_price)
-serviceTaken() - returns true if job service has match on database
-addService() - adds Job service into Database
- getNewSerial() - global function that gets the latest serial number
- getAllJobService(datagridview) - displays job services offered to job order


tempServiceDB.vb
-requires parameter (job_service_id)
-jobServiceExist() - return true if job service exists in DB
-addTempSvc() - add job service into temp_svc_tb in DB
-removeTempSvc() - global method. remove job service from temp_svc_tb
- emptyTempSvc() - global method. empty temp_svc_tb table
- getSomeJobService(datagridview) - global method. displays all Job services EXCEPT  selected in temp_svc_tb
- getTempJobService(datagridview) - global method. displays contents of temp_svc_tb from DB


addJO1.vb
-variables with pick - they are variables for datagrid cell click. they are temporary storages. e.g. pickJobSvcID
-addJO1_FormClosed() - when form is closed. it will empty the temporary table
-addJO1_FormLoad() - when form loads. It set-ups customer datagrid, disables groupbox, set-ups  technician, watchkind, watch build combo boxes, set-ups the radiobutton for job types, gets the tab number, set-ups Job service datagrid and parts datagrid, set-ups warranty combo box
-setSerialLabel() - updates label with the current serial number
- ALL methods for JOB SERVICES
-setJobServiceIDLabel(job_service_id, job_service_price) - sets the variable and updates displayed text for job_service_id_label
-getPickJobSvcID() - getter for pickJobSvcID. returns pickJobSvcID
-setPickJobSvcID(String) - setter for pickJobSvcID
-getPickJobSvcPrice() - getter for pickJobSvcPrice. returns pickJobSvcPrice
-setPickJobSvcPrice(Decimal) - setter for pickJobSvcPrice
-resetPickJobServiceIDLabel - resets displayed text of job_service_id_label to "select above" and sets pickJobSvcID ="" and pickJobSvcPrice = 0.0
-add_service_button_Click() - when add service button is clicked.
-clear_svc_datagrid_button_Click() - if clear selection button is clicked. calls resetJobServiceIDLabel() and clears job_service_datagrid selection
-job_service_datagrid_CellClick() - when datagrid is clicked. and calls setJobServiceIDLabel()
-job_service_datagrid_DataBindingComplete() - clears selection for job_service_datagrid when data is refreshed.
-refresh_service_label_LinkClicked() - when refresh_service_label is clicked. calls setSomeJobServiceDatagrid()
-setJobServiceDatagrid() - updates job_service_datagrid with data from DB
-setSomeJobServiceDataGrid() - updates job_service_datagrid with filtered data from  temp_svc_tb
- ALL methods for TEMP SVC
-setTempDataGrid() - update datagrid of temporary chosen services
-temp_svc_datagrid_CellClick() - when temp_svc_datagrid is clicked.  calls setTempSvcIDLabel()
-setTempSvcIDLabel(String, Decimal) - updates display text for temp_svc_id_label and calls setPickTempSvcID() and setPickTempSvcPrice
-setTempSvcPrice(Decimal) - setter for tempSvcPrice
-getTempSvcPrice() - getter. returns tempSvcPrice as Decimal
-resetTempSvcPriceLabel() - updates display and calls setTempSvcPrice()
-setTempSvcCount(Integer) - updates display text of temp_svc_count_label
-resetTempSvcCount() - calls setTempSvcCount() and updates display text
-getPickTempSvcID() - getter for pickTempSvcID. returns String
-setPickTempSvcID() - setter for pickTempSvcID. 
-remove_service_button_Click - when remove service button is clicked. deletes selected job service id from temp_svc_id , calls setTempSvcDatagrid(), setSomeJobServiceDataGrid(), setTempSvcCount(), setTempSvcPrice(), and resetTempSvcIDLabel()
-reset_temp_button_Click() - when reset services button is clicked. empties temp_svc_tb in DB and refreshes labels and tables.
-ALL methods for PARTS
-setPartsDatagrid() - updates parts_data_grid with data from DB
-parts_data_grid_CellClick() - 
-parts_data_grid_DataBindingComplete -
-refresh_parts_label_LinkClicked() - 
-setPartsIDLabel(String) - 
- All method for CUSTOMER
-setOldCustomerDataGrid() - updates table of customers
-customer_data_grid_CellClick() - calls setOldCustomerLabel
-setOldCustomerLabel() - updates display for old_customer_label and calls setOldCustomerID()
-setOldCustomerID(String) - setter for oldCustomerID
-resetOldCustomer() - clear selection for customer_data_grid, calls setOldCustomerID(), resetOldCustomerLabel(), and disable oldCustomerGrpbx
-resetOldCustomerSearchBox() - empties search_customer_txtbox
-resetOldCustomerLabel() - displays "Select Above"
-enableOldCustomerDatagrid(boolean) - 
-enableOldCustomerGrpbx(Boolean) - 
-enableNewCustomerGrpbx(Boolean) - 
-new_customer_chbox_CheckedChanged() - when checkbox is clicked. enables or disables groupbox of new customer of old customer
-search_customer_button_Click() - updates customer datagrid with search results
-search_customer_txtbox_KeyPress() - letter or digit only allowed to prevent errors from mysql syntax
- ALL methods for JOB TYPE
-setJobTypeRadio() - set On the go as default radiobutton checked
-setJobRepairType(Integer) - setter for jobRepairType
-getJobRepairType() - returns integer. getter for jobRepairType
-otg_radio_CheckedChanged() - 
-admit_radio_CheckedChanged() - 
- ALL methods for COMBO BOX
-setTechnicianCombo()
-setWatchBuildCombo()
-setWatchKindCombo()
-setWarrantyCombo()
- ALL methods for TAB PAGES
-next_tab_button_Click()
-prev_tab_button_Click()
-getTabNumber()



-notes: no window_id yet for mulitple windows using job_order.
--try to test if there are bugs just let me know


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