﻿
using Microsoft.EntityFrameworkCore;
namespace HomeServices.Model
{
    public class HomeServiceContext : DbContext
    {
        public HomeServiceContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Service> Services { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public  DbSet<Status> Status { get; set; }

        public DbSet<WokerPayment> WorkerPayments { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Admin> AdminTable { get; set; }
    }
}
