Imports System.Windows

Namespace UFAR_AM_WPF
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            ' Retrieve data from the database and bind it to UI controls
            PopulateData()
        End Sub

        Private Sub PopulateData()
            ' Create an instance of your DbContext
            Using context As New UFAR.AM.WPF.Data.NW()
                ' Retrieve data from the Order, Shipper, and Employee tables
                Dim orders = context.Orders.ToList() ' Assuming Order entity is referred to as Product
                Dim shippers = context.Shippers.ToList()
                Dim employees = context.Employees.ToList()

                ' Bind the data to UI controls
                dataGridOrders.ItemsSource = orders
                dataGridShippers.ItemsSource = shippers
                dataGridEmployees.ItemsSource = employees
            End Using
        End Sub
    End Class
End Namespace
