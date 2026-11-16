namespace CarCRM.Models;

public class MaintenanceItem
{
    public int Id { get; set; }
    // insert two field for maintenance item raw cost and human cost these variable cost //
    public decimal RawCost { get; set; }
    public decimal HumanCost { get; set; }
    // 維修項目名稱（例如：機油更換、火星塞、皮帶）
    public string Name { get; set; } = null!;

    // 建議里程（例如：每 5000 km 換機油）
    public int? IntervalMileage { get; set; }

    // 建議月份（例如：每 6 個月換機油）
    public int? IntervalMonths { get; set; }
}
