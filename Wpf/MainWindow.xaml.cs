using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace UFAR_AM_WPF {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            // Retrieve data from the database and bind it to UI controls
            PopulateData();
        }

        private void PopulateData() {
            // Create an instance of DbContext
            using (var context = new UFAR.AM.WPF.Data.NW()) {
                // Retrieve data from the Order, Shipper, and Employee tables
                var orders = context.Orders.ToList(); 
                var shippers = context.Shippers.ToList();
                var employees = context.Employees.ToList();

                // Bind the data to UI controls
                dataGridOrders.ItemsSource = orders;
                dataGridShippers.ItemsSource = shippers;
                dataGridEmployees.ItemsSource = employees;
            }
        }

        private DataGridRow lastHighlightedRow = null;

        private void SearchOrder(int orderId) {
            using (var context = new UFAR.AM.WPF.Data.NW()) {
                // Search for the order with the given orderId
                var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId);

                if (order != null) {
                    // Display the result in the TextBox
                    txtSearchedOrder.Text = $"Order ID: {order.OrderId}, Shipper: {order.ShipVia}, Employee: {order.EmployeeId}, Date {order.OrderDate}";
                } else {
                    // Order not found
                    txtSearchedOrder.Text = "Order not found.";
                }
            }
        }
        private void SearchShipper(int shipperId) {
            using (var context = new UFAR.AM.WPF.Data.NW()) {
                // Search for the order with the given orderId
                var shipper = context.Shippers.FirstOrDefault(s => s.ShipperId == shipperId);

                if (shipper != null) {
                    // Display the result in the TextBox
                    txtSearchedShipper.Text = $"Shipper ID: {shipper.ShipperId}, Company Name: {shipper.CompanyName}";
                } else {
                    // Order not found
                    txtSearchedShipper.Text = "Shipper not found.";
                }
            }
        }

        private void SearchEmployee(int employeeId) {
            using (var context = new UFAR.AM.WPF.Data.NW()) {
                // Search for the order with the given orderId
                var employee = context.Employees.FirstOrDefault(s => s.EmployeeId == employeeId);

                if (employee != null) {
                    // Display the result in the TextBox
                    txtSearchedEmployee.Text = $"Employee ID: {employee.EmployeeId}, First Name: {employee.FirstName}, Last Name {employee.LastName}";
                } else {
                    // Order not found
                    txtSearchedEmployee.Text = "Shipper not found.";
                }
            }
        }
        private void Button_Click_Order(object sender, RoutedEventArgs e) {
            int id;
            try {
                id = int.Parse(txtOrderId.Text);
            } catch (System.FormatException) {
                // Handle invalid input (e.g., display error message)
                MessageBox.Show("Please enter a valid integer for Order ID.");
                return;
            }
            SearchOrder(id);
        }
        private void Button_Click_Shipper(object sender, RoutedEventArgs e) {
            int id;
            try {
                id = int.Parse(txtShipperId.Text);
            } catch (System.FormatException) {
                // Handle invalid input (e.g., display error message)
                MessageBox.Show("Please enter a valid integer for Shipper ID.");
                return;
            }
            SearchShipper(id);
        }
        private void Button_Click_Employee(object sender, RoutedEventArgs e) {
            int id;
            try {
                id = int.Parse(txtEmployeeId.Text);
            } catch (System.FormatException) {
                // Handle invalid input (e.g., display error message)
                MessageBox.Show("Please enter a valid integer for Employee ID.");
                return;
            }
            SearchEmployee(id);
        }
    }
}