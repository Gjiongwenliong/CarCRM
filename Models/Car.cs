using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarCRM.Models;

public class Car
{
    public int Id { get; set; }

    public int? IdCustomer { get; set; }

    [ForeignKey(nameof(IdCustomer))]
    public Customer? Customer { get; set; }

    [Required]
    [StringLength(20)]
    public required string PlateNumber { get; set; }

    [Required]
    public required string Brand { get; set; }

    [Required]
    public required string Model { get; set; }

    public int Year { get; set; }

    public string DisplayName
    {
        get
        {
            var plate = PlateNumber?.Trim();
            if (!string.IsNullOrWhiteSpace(plate))
            {
                return $"{Brand} {Model} ({plate})";
            }

            return $"{Brand} {Model} ({Year})";
        }
    }
}
