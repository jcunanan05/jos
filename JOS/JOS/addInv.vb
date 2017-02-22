Public Class addInv
    'instance variables
    Private partName, partBrand, partCategory, partSupplier As String
    Private partPrice As Decimal
    Private partQuantity As Integer
    Private partCritical As Integer

    Private Sub addInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'set combo box Part Name
        setPartNameCombo()
        'set combo box Category
        setCategoryCombo()
        'set combo box Supplier
        setSupplierCombo()
        'set serial number label
        setSerialLabel()
        'set data grid view
        setItemDataGrid()
    End Sub

    'void method
    Private Sub setPartNameCombo()
        'this method sets the combobox Part Name. it gets from the database
        'get array of strings in the database from inventoryDB.vb class
        Dim arrayName() As String = inventoryDB.getPartRemark()
        'get the max length of array and set it equal to max drop down of the combo box
        part_name_combo.MaxDropDownItems = arrayName.Length

        'do for loop in array and add it to the combo box
        For Each stringName As String In arrayName
            part_name_combo.Items.Add(stringName)
        Next
    End Sub

    'void method
    Private Sub setCategoryCombo()
        'this method sets the combobox Category. it gets from the database
        'get array of strings in the database from inventoryDB.vb class
        Dim arrayCategory() As String = inventoryDB.getCategoryRemark()
        'get the max length of array and set it equal to max drop down of the combo box
        category_combo.MaxDropDownItems = arrayCategory.Length

        'do for loop in array and add it to the combo box
        For Each stringCategory As String In arrayCategory
            category_combo.Items.Add(stringCategory)
        Next
    End Sub

    'void method
    Private Sub setSupplierCombo()
        'this method sets the combobox Category. it gets from the database
        'get array of strings in the database from inventoryDB.vb class
        Dim arraySupplier() As String = inventoryDB.getSupplierRemark()
        'get the max length of array and set it equal to max drop down of the combo box
        supplier_combo.MaxDropDownItems = arraySupplier.Length

        'do for loop in array and add it to the combo box
        For Each stringSupplier As String In arraySupplier
            supplier_combo.Items.Add(stringSupplier)
        Next
    End Sub

    'void method
    Private Sub setSerialLabel()
        'this method sets a serial number for the product
        Dim newSerial As Integer = inventoryDB.getNewSerial()

        'update serial number label
        serial_label.Text = newSerial.ToString()
    End Sub

    'void method
    Private Sub setItemDataGrid()
        'updates the datagridview
        inventoryDB.getRecentlyAdded(item_data_grid)

    End Sub

    Private Sub new_supplier_chbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles new_supplier_chbox.CheckedChanged
        'When new supplier checkbox is checked
        If new_supplier_chbox.Checked Then
            'if new supplier is checked
            'change combo box to simple
            supplier_combo.DropDownStyle = ComboBoxStyle.Simple
        Else
            'change back to dropdownlist
            supplier_combo.DropDownStyle = ComboBoxStyle.DropDownList
        End If
    End Sub

    Private Sub add_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_button.Click
        'when add button is clicked
        'this method event checks if the new supplier has same name, and if the item has a same supplier and category and part.
        partName = part_name_combo.SelectedItem 'get value from part name combo box
        partBrand = brand_textbox.Text ' get value from brand combo box
        partCategory = category_combo.SelectedItem ' get value from category combo box

        If new_supplier_chbox.Checked Then
            'if new supplier is checked
            partSupplier = supplier_combo.Text
        Else
            'if new supplier is not checked
            partSupplier = supplier_combo.SelectedItem
        End If

        partPrice = price_updown.Value 'get price
        partQuantity = quantity_updown.Value 'get quantity
        partCritical = critical_updown.Value 'get critical value

        'create new object/instance
        Dim newItem As inventoryDB = New inventoryDB(partName, partBrand, partCategory, partSupplier, partPrice, partQuantity, partCritical)
        Dim supplierTaken As Boolean = newItem.supplierTaken(new_supplier_chbox) 'check if new supplier or not and if new supplier is taken
        Dim itemTaken As Boolean = newItem.itemTaken() 'check if same item is in database

        If supplierTaken = False Then
            'if supplier is not taken
            If itemTaken = False Then
                'if item has no match in db
                newItem.addItem(new_supplier_chbox)
                'update data grid view: recently added
                setItemDataGrid()
            Else
                'if item exist in database
                MsgBox(newItem.wrongItem) 'generate error message
            End If
        Else
            'if new supplier exists in db
            MsgBox(newItem.wrongNewSupplier) 'generate error message
        End If

    End Sub

    Private Sub reset_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset_button.Click

    End Sub
End Class