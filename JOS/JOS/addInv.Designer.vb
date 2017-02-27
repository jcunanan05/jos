<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addInv
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.part_name_combo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.brand_textbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.category_combo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.quantity_updown = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.critical_updown = New System.Windows.Forms.NumericUpDown()
        Me.add_button = New System.Windows.Forms.Button()
        Me.reset_button = New System.Windows.Forms.Button()
        Me.item_data_grid = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.manager_label = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.supplier_combo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.price_updown = New System.Windows.Forms.NumericUpDown()
        Me.new_supplier_chbox = New System.Windows.Forms.CheckBox()
        Me.serial_label = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.new_category_chbox = New System.Windows.Forms.CheckBox()
        CType(Me.quantity_updown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.critical_updown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item_data_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.price_updown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Part Name:"
        '
        'part_name_combo
        '
        Me.part_name_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.part_name_combo.FormattingEnabled = True
        Me.part_name_combo.Location = New System.Drawing.Point(72, 53)
        Me.part_name_combo.Name = "part_name_combo"
        Me.part_name_combo.Size = New System.Drawing.Size(121, 21)
        Me.part_name_combo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Part Model:"
        '
        'brand_textbox
        '
        Me.brand_textbox.Location = New System.Drawing.Point(72, 80)
        Me.brand_textbox.Name = "brand_textbox"
        Me.brand_textbox.Size = New System.Drawing.Size(100, 20)
        Me.brand_textbox.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Brand Category:"
        '
        'category_combo
        '
        Me.category_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.category_combo.FormattingEnabled = True
        Me.category_combo.Location = New System.Drawing.Point(95, 111)
        Me.category_combo.Name = "category_combo"
        Me.category_combo.Size = New System.Drawing.Size(204, 21)
        Me.category_combo.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Quantity:"
        '
        'quantity_updown
        '
        Me.quantity_updown.Location = New System.Drawing.Point(75, 215)
        Me.quantity_updown.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.quantity_updown.Name = "quantity_updown"
        Me.quantity_updown.Size = New System.Drawing.Size(100, 20)
        Me.quantity_updown.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 247)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Critcial amount:"
        '
        'critical_updown
        '
        Me.critical_updown.Location = New System.Drawing.Point(100, 245)
        Me.critical_updown.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.critical_updown.Name = "critical_updown"
        Me.critical_updown.Size = New System.Drawing.Size(75, 20)
        Me.critical_updown.TabIndex = 9
        '
        'add_button
        '
        Me.add_button.Location = New System.Drawing.Point(9, 296)
        Me.add_button.Name = "add_button"
        Me.add_button.Size = New System.Drawing.Size(75, 23)
        Me.add_button.TabIndex = 10
        Me.add_button.Text = "Add"
        Me.add_button.UseVisualStyleBackColor = True
        '
        'reset_button
        '
        Me.reset_button.Location = New System.Drawing.Point(164, 296)
        Me.reset_button.Name = "reset_button"
        Me.reset_button.Size = New System.Drawing.Size(75, 23)
        Me.reset_button.TabIndex = 11
        Me.reset_button.Text = "Reset"
        Me.reset_button.UseVisualStyleBackColor = True
        '
        'item_data_grid
        '
        Me.item_data_grid.AllowUserToAddRows = False
        Me.item_data_grid.AllowUserToDeleteRows = False
        Me.item_data_grid.AllowUserToResizeRows = False
        Me.item_data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.item_data_grid.Location = New System.Drawing.Point(384, 28)
        Me.item_data_grid.Name = "item_data_grid"
        Me.item_data_grid.ReadOnly = True
        Me.item_data_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.item_data_grid.Size = New System.Drawing.Size(456, 249)
        Me.item_data_grid.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(381, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Recently added"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 340)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Technician:"
        '
        'manager_label
        '
        Me.manager_label.AutoSize = True
        Me.manager_label.Location = New System.Drawing.Point(82, 340)
        Me.manager_label.Name = "manager_label"
        Me.manager_label.Size = New System.Drawing.Size(35, 13)
        Me.manager_label.TabIndex = 15
        Me.manager_label.Text = "Guest"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(742, 336)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 17)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Add Inventory"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 142)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Supplier:"
        '
        'supplier_combo
        '
        Me.supplier_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.supplier_combo.FormattingEnabled = True
        Me.supplier_combo.Location = New System.Drawing.Point(72, 139)
        Me.supplier_combo.Name = "supplier_combo"
        Me.supplier_combo.Size = New System.Drawing.Size(227, 21)
        Me.supplier_combo.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.new_category_chbox)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.price_updown)
        Me.GroupBox1.Controls.Add(Me.new_supplier_chbox)
        Me.GroupBox1.Controls.Add(Me.serial_label)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.supplier_combo)
        Me.GroupBox1.Controls.Add(Me.part_name_combo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.brand_textbox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.category_combo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.quantity_updown)
        Me.GroupBox1.Controls.Add(Me.reset_button)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.add_button)
        Me.GroupBox1.Controls.Add(Me.critical_updown)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(359, 325)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Enter Product Details"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 175)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Price: P"
        '
        'price_updown
        '
        Me.price_updown.DecimalPlaces = 2
        Me.price_updown.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.price_updown.Location = New System.Drawing.Point(72, 171)
        Me.price_updown.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.price_updown.Name = "price_updown"
        Me.price_updown.Size = New System.Drawing.Size(100, 20)
        Me.price_updown.TabIndex = 23
        Me.price_updown.Value = New Decimal(New Integer() {100, 0, 0, 131072})
        '
        'new_supplier_chbox
        '
        Me.new_supplier_chbox.AutoSize = True
        Me.new_supplier_chbox.Location = New System.Drawing.Point(305, 143)
        Me.new_supplier_chbox.Name = "new_supplier_chbox"
        Me.new_supplier_chbox.Size = New System.Drawing.Size(48, 17)
        Me.new_supplier_chbox.TabIndex = 21
        Me.new_supplier_chbox.Text = "New"
        Me.new_supplier_chbox.UseVisualStyleBackColor = True
        '
        'serial_label
        '
        Me.serial_label.Location = New System.Drawing.Point(72, 28)
        Me.serial_label.Name = "serial_label"
        Me.serial_label.Size = New System.Drawing.Size(167, 13)
        Me.serial_label.TabIndex = 20
        Me.serial_label.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Serial no."
        '
        'new_category_chbox
        '
        Me.new_category_chbox.AutoSize = True
        Me.new_category_chbox.Location = New System.Drawing.Point(305, 113)
        Me.new_category_chbox.Name = "new_category_chbox"
        Me.new_category_chbox.Size = New System.Drawing.Size(48, 17)
        Me.new_category_chbox.TabIndex = 24
        Me.new_category_chbox.Text = "New"
        Me.new_category_chbox.UseVisualStyleBackColor = True
        '
        'addInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 362)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.manager_label)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.item_data_grid)
        Me.Name = "addInv"
        Me.Text = "Add Inventory"
        CType(Me.quantity_updown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.critical_updown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item_data_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.price_updown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents part_name_combo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents brand_textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents category_combo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents quantity_updown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents critical_updown As System.Windows.Forms.NumericUpDown
    Friend WithEvents add_button As System.Windows.Forms.Button
    Friend WithEvents reset_button As System.Windows.Forms.Button
    Friend WithEvents item_data_grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents manager_label As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents supplier_combo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents new_supplier_chbox As System.Windows.Forms.CheckBox
    Friend WithEvents serial_label As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents price_updown As System.Windows.Forms.NumericUpDown
    Friend WithEvents new_category_chbox As System.Windows.Forms.CheckBox
End Class
