<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class regEmployee
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
        Me.last_name_textbox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.middle_i_textbox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.emp_position_combo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.register_button = New System.Windows.Forms.Button()
        Me.new_confirm_textbox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.new_password_textbox = New System.Windows.Forms.TextBox()
        Me.new_user_name_textbox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.first_name_textbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.manager_label = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.last_name_textbox)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.middle_i_textbox)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.emp_position_combo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.register_button)
        Me.GroupBox1.Controls.Add(Me.new_confirm_textbox)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.new_password_textbox)
        Me.GroupBox1.Controls.Add(Me.new_user_name_textbox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.first_name_textbox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(622, 222)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Details"
        '
        'last_name_textbox
        '
        Me.last_name_textbox.Location = New System.Drawing.Point(422, 17)
        Me.last_name_textbox.Name = "last_name_textbox"
        Me.last_name_textbox.Size = New System.Drawing.Size(194, 20)
        Me.last_name_textbox.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(359, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Last Name:"
        '
        'middle_i_textbox
        '
        Me.middle_i_textbox.Location = New System.Drawing.Point(308, 17)
        Me.middle_i_textbox.Name = "middle_i_textbox"
        Me.middle_i_textbox.Size = New System.Drawing.Size(43, 20)
        Me.middle_i_textbox.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(255, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Middle I."
        '
        'emp_position_combo
        '
        Me.emp_position_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.emp_position_combo.FormattingEnabled = True
        Me.emp_position_combo.Location = New System.Drawing.Point(109, 46)
        Me.emp_position_combo.Name = "emp_position_combo"
        Me.emp_position_combo.Size = New System.Drawing.Size(156, 21)
        Me.emp_position_combo.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Employee Position:"
        '
        'register_button
        '
        Me.register_button.Location = New System.Drawing.Point(190, 173)
        Me.register_button.Name = "register_button"
        Me.register_button.Size = New System.Drawing.Size(195, 23)
        Me.register_button.TabIndex = 8
        Me.register_button.Text = "Register"
        Me.register_button.UseVisualStyleBackColor = True
        '
        'new_confirm_textbox
        '
        Me.new_confirm_textbox.Location = New System.Drawing.Point(76, 132)
        Me.new_confirm_textbox.Name = "new_confirm_textbox"
        Me.new_confirm_textbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.new_confirm_textbox.Size = New System.Drawing.Size(165, 20)
        Me.new_confirm_textbox.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Confirm pw:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Password:"
        '
        'new_password_textbox
        '
        Me.new_password_textbox.Location = New System.Drawing.Point(76, 105)
        Me.new_password_textbox.Name = "new_password_textbox"
        Me.new_password_textbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.new_password_textbox.Size = New System.Drawing.Size(165, 20)
        Me.new_password_textbox.TabIndex = 4
        '
        'new_user_name_textbox
        '
        Me.new_user_name_textbox.Location = New System.Drawing.Point(76, 76)
        Me.new_user_name_textbox.Name = "new_user_name_textbox"
        Me.new_user_name_textbox.Size = New System.Drawing.Size(165, 20)
        Me.new_user_name_textbox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Username:"
        '
        'first_name_textbox
        '
        Me.first_name_textbox.Location = New System.Drawing.Point(70, 17)
        Me.first_name_textbox.Name = "first_name_textbox"
        Me.first_name_textbox.Size = New System.Drawing.Size(179, 20)
        Me.first_name_textbox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name:"
        '
        'manager_label
        '
        Me.manager_label.AutoSize = True
        Me.manager_label.Location = New System.Drawing.Point(67, 237)
        Me.manager_label.Name = "manager_label"
        Me.manager_label.Size = New System.Drawing.Size(35, 13)
        Me.manager_label.TabIndex = 33
        Me.manager_label.Text = "Guest"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 237)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Manager:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label13.Location = New System.Drawing.Point(532, 237)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 17)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Add Employee"
        '
        'regEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 263)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.manager_label)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "regEmployee"
        Me.Text = "Add Employee Account"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents register_button As System.Windows.Forms.Button
    Friend WithEvents new_confirm_textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents new_password_textbox As System.Windows.Forms.TextBox
    Friend WithEvents new_user_name_textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents first_name_textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents manager_label As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents emp_position_combo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents last_name_textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents middle_i_textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
