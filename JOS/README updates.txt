Updates
-set item_name to item_model in the database and in inventoryDB.vb
-added new brand category functionality
-refactored server string into one string source only

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



-notes: no edit function on inventory
--try to test if there are bugs just let me know
