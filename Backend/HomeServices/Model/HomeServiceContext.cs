
using Microsoft.EntityFrameworkCore;
namespace HomeServices.Model
{
    public class HomeServiceContext:DbContext
    {
        public HomeServiceContext(DbContextOptions options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Service> services { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Payment> payments { get; set; }

        public  DbSet<Status> status { get; set; }

        public DbSet<WorkerPayment> workerPayments { get; set; }

        public DbSet<Booking> bookings { get; set; }

        public DbSet<Status> statuses { get; set; }

        public DbSet<Worker> workers { get; set; }

        public DbSet<Rating> ratings { get; set; }
    }
}
