using Microsoft.EntityFrameworkCore;
using CarCRM.Models;

namespace CarCRM.Data
{
    public class CarCRMContext : DbContext
    {
        public CarCRMContext(DbContextOptions<CarCRMContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; } = null!;
        public DbSet<MaintenanceItem> MaintenanceItems { get; set; }
        // public DbSet<Appointment> Appointments { get; set; } // Dup
        //define reminder for future maintenance date DbSet additions
        public DbSet<Reminder> Reminders { get; set; }
    }
}
