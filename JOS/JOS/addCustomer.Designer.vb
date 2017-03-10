<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addCustomer
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
        Me.Label14 = New System.Windows.Forms.Label()
        Me.middle_i_txtbox = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.first_name_txtbox = New System.Windows.Forms.TextBox()
        Me.last_name_txtbox = New System.Windows.Forms.TextBox()
        Me.contact_txtbox = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.serial_label = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.add_customer_button = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.customer_data_grid = New System.Windows.Forms.DataGridView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.manager_label = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.customer_data_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(450, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Middle I."
        '
        'middle_i_txtbox
        '
        Me.middle_i_txtbox.Location = New System.Drawing.Point(503, 44)
        Me.middle_i_txtbox.Name = "middle_i_txtbox"
        Me.middle_i_txtbox.Size = New System.Drawing.Size(49, 20)
        Me.middle_i_txtbox.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(236, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "First Name:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Last Name:"
        '
        'first_name_txtbox
        '
        Me.first_name_txtbox.Location = New System.Drawing.Point(302, 44)
        Me.first_name_txtbox.Name = "first_name_txtbox"
        Me.first_name_txtbox.Size = New System.Drawing.Size(142, 20)
        Me.first_name_txtbox.TabIndex = 27
        '
        'last_name_txtbox
        '
        Me.last_name_txtbox.Location = New System.Drawing.Point(74, 44)
        Me.last_name_txtbox.Name = "last_name_txtbox"
        Me.last_name_txtbox.Size = New System.Drawing.Size(158, 20)
        Me.last_name_txtbox.TabIndex = 26
        '
        'contact_txtbox
        '
        Me.contact_txtbox.Location = New System.Drawing.Point(74, 80)
        Me.contact_txtbox.Name = "contact_txtbox"
        Me.contact_txtbox.Size = New System.Drawing.Size(166, 20)
        Me.contact_txtbox.TabIndex = 25
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 83)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 13)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Contact #:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.serial_label)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.contact_txtbox)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.middle_i_txtbox)
        Me.GroupBox1.Controls.Add(Me.last_name_txtbox)
        Me.GroupBox1.Controls.Add(Me.first_name_txtbox)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 197)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(563, 126)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Customer Details"
        '
        'serial_label
        '
        Me.serial_label.Location = New System.Drawing.Point(119, 20)
        Me.serial_label.Name = "serial_label"
        Me.serial_label.Size = New System.Drawing.Size(177, 13)
        Me.serial_label.TabIndex = 33
        Me.serial_label.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Customer Serial No:"
        '
        'add_customer_button
        '
        Me.add_customer_button.Location = New System.Drawing.Point(225, 339)
        Me.add_customer_button.Name = "add_customer_button"
        Me.add_customer_button.Size = New System.Drawing.Size(133, 23)
        Me.add_customer_button.TabIndex = 33
        Me.add_customer_button.Text = "Add Customer"
        Me.add_customer_button.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.customer_data_grid)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(563, 179)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Customer List"
        '
        'customer_data_grid
        '
        Me.customer_data_grid.AllowUserToAddRows = False
        Me.customer_data_grid.AllowUserToDeleteRows = False
        Me.customer_data_grid.AllowUserToOrderColumns = True
        Me.customer_data_grid.AllowUserToResizeColumns = False
        Me.customer_data_grid.AllowUserToResizeRows = False
        Me.customer_data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.customer_data_grid.Location = New System.Drawing.Point(13, 19)
        Me.customer_data_grid.Name = "customer_data_grid"
        Me.customer_data_grid.ReadOnly = True
        Me.customer_data_grid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.customer_data_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.customer_data_grid.Size = New System.Drawing.Size(539, 154)
        Me.customer_data_grid.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(476, 388)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 17)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Add Customer"
        '
        'manager_label
        '
        Me.manager_label.AutoSize = True
        Me.manager_label.Location = New System.Drawing.Point(78, 390)
        Me.manager_label.Name = "manager_label"
        Me.manager_label.Size = New System.Drawing.Size(35, 13)
        Me.manager_label.TabIndex = 36
        Me.manager_label.Text = "Guest"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 390)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Employee:"
        '
        'addCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 412)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.manager_label)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.add_customer_button)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "addCustomer"
        Me.Text = "Add Customer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.customer_data_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents middle_i_txtbox As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents first_name_txtbox As System.Windows.Forms.TextBox
    Friend WithEvents last_name_txtbox As System.Windows.Forms.TextBox
    Friend WithEvents contact_txtbox As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents serial_label As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents add_customer_button As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents customer_data_grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents manager_label As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
