namespace UFAR.AM.WPF.Data {
    public class Order {
        public int OrderId { get; set; }
        public int ShipVia { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}