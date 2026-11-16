using System.ComponentModel.DataAnnotations;

public class Car
{
    public int Id { get; set; }

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
