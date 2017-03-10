Public Class seeEmployee

    Private Sub seeEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'when the form loads

        'set employee datagird
        setEmployeeDataGrid()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'void method
    Public Sub setEmployeeDataGrid()
        'set employee data Gird

        employeeDB.getAllEmployee(employee_data_grid)
    End Sub
End Class