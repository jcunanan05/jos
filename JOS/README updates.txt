Updates
-added codes for loginMain.vb
-loginDB.vb
-employeeDB.vb
-managerHome.vb
-regEmployee.vb
-registerDB.vb

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

--try to test if there are bugs just let me know
