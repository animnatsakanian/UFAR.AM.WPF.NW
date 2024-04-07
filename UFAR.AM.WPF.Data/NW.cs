using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace UFAR.AM.WPF.Data {
    public class NW : DbContext {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shipper> Shippers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder op) {
            op.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind");
        }
    }
}