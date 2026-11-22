using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarCRM.Models;

public class ServiceRecord
{
    public int Id { get; set; }

    // 🔗 Foreign key to Car
    public int CarId { get; set; }
    [ValidateNever]
    public Car Car { get; set; } = null!;
    
    public int? IdCustomer { get; set; }
    [ValidateNever]
    [ForeignKey(nameof(IdCustomer))]
    public Customer? Customer { get; set; }
    // 🔗 Foreign key to MaintenanceItem
    public int MaintenanceItemId { get; set; }
    [ValidateNever]
    public MaintenanceItem MaintenanceItem { get; set; } = null!;

    // 🕒 Service details
    public DateTime ServiceDate { get; set; }
    public int Mileage { get; set; }
    public decimal Cost { get; set; }

    // 📝 Optional notes
    public string? Remarks { get; set; }
}
