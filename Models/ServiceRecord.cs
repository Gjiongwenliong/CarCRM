using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarCRM.Models;

public class ServiceRecord
{
    public int Id { get; set; }

    // 🔗 Foreign key to Car
    public int CarId { get; set; }
    [ValidateNever]
    public Car Car { get; set; } = null!;

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
