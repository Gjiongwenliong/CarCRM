using System.ComponentModel.DataAnnotations;

namespace CarCRM.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string PlateNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Model { get; set; } = string.Empty;

        public int Year { get; set; }

        // 外鍵
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
