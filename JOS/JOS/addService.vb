Public Class addService
    'declare instance variables
    Private managerUserName As String

    Private jobServiceName As String
    Private jobPrice As Decimal

    Public Sub New(ByRef user_name As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        managerUserName = user_name 'initialize managerUserName
    End Sub


    Private Sub addService_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'set manager label
        setManagerLabel()
        'set Serial number
        setSerialLabel()
        'set Job service Data grid view
        setJobServiceDatagrid()
    End Sub

    'void method
    Private Sub setManagerLabel()
        'set manager label
        manager_label.Text = managerUserName
    End Sub

    'void method
    Private Sub setSerialLabel()
        'set serial number in the label

        Dim newSerial As Integer = jobDescDB.getNewSerial() 'get from db

        'update serial number label
        serial_label.Text = newSerial.ToString()
    End Sub

    'void method
    Private Sub setJobServiceDatagrid()
        'set datagridview for job service
        jobDescDB.getAllJobService(job_service_datagrid) 'function call other class
    End Sub

    Private Sub add_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_button.Click
        'when add button is clicked
        'equip variables with values inputted by the user
        jobServiceName = service_name_textbox.Text 'get service name
        jobPrice = price_updown.Value ' get price

        'create new instance/object
        Dim newService As jobDescDB = New jobDescDB(jobServiceName, jobPrice)
        Dim serviceTaken As Boolean = newService.serviceTaken() 'check if service name is taken

        If serviceTaken = False Then
            'if service name is not taken
            'add service to database
            newService.addService()
            'update table
            setJobServiceDatagrid()
        Else
            'if service name is taken
            MsgBox(newService.wrongService())
        End If
    End Sub
End Class