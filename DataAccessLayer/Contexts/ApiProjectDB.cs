using DAL.Entities;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class ApiProjectDB : DbContext
    {
        public ApiProjectDB(DbContextOptions<ApiProjectDB> opt) : base(opt)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                AdminID = 1,
                Name = "Ozan",
                Surname = "Yaprak",
                Username = "admin",
                LastLoginDate = DateTime.Now,
                Password = "admin"
            });
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<SalesInvoiceLine> SalesInvoiceLines { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}