<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class seeEmployee
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
        Me.employee_data_grid = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.employee_data_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.employee_data_grid)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(757, 290)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "List of Employees"
        '
        'employee_data_grid
        '
        Me.employee_data_grid.AllowUserToAddRows = False
        Me.employee_data_grid.AllowUserToDeleteRows = False
        Me.employee_data_grid.AllowUserToOrderColumns = True
        Me.employee_data_grid.AllowUserToResizeColumns = False
        Me.employee_data_grid.AllowUserToResizeRows = False
        Me.employee_data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.employee_data_grid.Location = New System.Drawing.Point(6, 19)
        Me.employee_data_grid.Name = "employee_data_grid"
        Me.employee_data_grid.ReadOnly = True
        Me.employee_data_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.employee_data_grid.Size = New System.Drawing.Size(745, 265)
        Me.employee_data_grid.TabIndex = 0
        '
        'seeEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 397)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "seeEmployee"
        Me.Text = "All Employees"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.employee_data_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents employee_data_grid As System.Windows.Forms.DataGridView
End Class
