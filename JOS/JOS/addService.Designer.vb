<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addService
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.add_button = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.price_updown = New System.Windows.Forms.NumericUpDown()
        Me.service_name_textbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.serial_label = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.job_service_datagrid = New System.Windows.Forms.DataGridView()
        Me.manager_label = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.price_updown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.job_service_datagrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.add_button)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.price_updown)
        Me.GroupBox1.Controls.Add(Me.service_name_textbox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.serial_label)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 242)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 142)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Details"
        '
        'add_button
        '
        Me.add_button.Location = New System.Drawing.Point(233, 113)
        Me.add_button.Name = "add_button"
        Me.add_button.Size = New System.Drawing.Size(110, 23)
        Me.add_button.TabIndex = 26
        Me.add_button.Text = "Add Job Service"
        Me.add_button.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 79)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Price: P"
        '
        'price_updown
        '
        Me.price_updown.DecimalPlaces = 2
        Me.price_updown.Increment = New Decimal(New Integer() {25, 0, 0, 131072})
        Me.price_updown.Location = New System.Drawing.Point(68, 77)
        Me.price_updown.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.price_updown.Name = "price_updown"
        Me.price_updown.Size = New System.Drawing.Size(100, 20)
        Me.price_updown.TabIndex = 25
        Me.price_updown.Value = New Decimal(New Integer() {100, 0, 0, 131072})
        '
        'service_name_textbox
        '
        Me.service_name_textbox.Location = New System.Drawing.Point(112, 49)
        Me.service_name_textbox.Name = "service_name_textbox"
        Me.service_name_textbox.Size = New System.Drawing.Size(444, 20)
        Me.service_name_textbox.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Job Service Name:"
        '
        'serial_label
        '
        Me.serial_label.Location = New System.Drawing.Point(68, 25)
        Me.serial_label.Name = "serial_label"
        Me.serial_label.Size = New System.Drawing.Size(166, 13)
        Me.serial_label.TabIndex = 1
        Me.serial_label.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Serial No."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.job_service_datagrid)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(561, 223)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Job Service List"
        '
        'job_service_datagrid
        '
        Me.job_service_datagrid.AllowUserToAddRows = False
        Me.job_service_datagrid.AllowUserToDeleteRows = False
        Me.job_service_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.job_service_datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.job_service_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.job_service_datagrid.Location = New System.Drawing.Point(6, 19)
        Me.job_service_datagrid.Name = "job_service_datagrid"
        Me.job_service_datagrid.ReadOnly = True
        Me.job_service_datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.job_service_datagrid.Size = New System.Drawing.Size(549, 198)
        Me.job_service_datagrid.TabIndex = 0
        '
        'manager_label
        '
        Me.manager_label.AutoSize = True
        Me.manager_label.Location = New System.Drawing.Point(81, 407)
        Me.manager_label.Name = "manager_label"
        Me.manager_label.Size = New System.Drawing.Size(35, 13)
        Me.manager_label.TabIndex = 17
        Me.manager_label.Text = "Guest"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 407)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Technician:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(472, 403)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Add Job Service"
        '
        'addService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 429)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.manager_label)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "addService"
        Me.Text = "Add Job Service"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.price_updown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.job_service_datagrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents service_name_textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents serial_label As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents price_updown As System.Windows.Forms.NumericUpDown
    Friend WithEvents add_button As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents job_service_datagrid As System.Windows.Forms.DataGridView
    Friend WithEvents manager_label As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
