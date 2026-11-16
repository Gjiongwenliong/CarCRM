using System.ComponentModel.DataAnnotations;
using System;

namespace CarCRM.Models
{
    public class Appointment
    {
    public int Id { get; set; }

    public DateTime Date { get; set; }

    [StringLength(200)]
    public string Description { get; set; } = string.Empty;

    // 外鍵
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    }
}
