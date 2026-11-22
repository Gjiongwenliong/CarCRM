using System.ComponentModel.DataAnnotations;
using System;

namespace CarCRM.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int? MaintenanceItemId { get; set; }
        public MaintenanceItem? MaintenanceItem { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        [StringLength(200)]
        public string? Remark { get; set; }
    }
}
