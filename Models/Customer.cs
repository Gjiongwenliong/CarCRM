using System.ComponentModel.DataAnnotations;

namespace CarCRM.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        [Phone]
        [StringLength(20)]
        public string? Phone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        public ICollection<Vehicle>? Vehicles { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<Car>? Cars { get; set; }
        public ICollection<ServiceRecord>? ServiceRecords { get; set; }
    }
}
