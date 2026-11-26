using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCRM.Pages.Reminders;

public class IndexModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    public IList<CarCRM.Models.Reminder> Reminders { get; set; } = new List<CarCRM.Models.Reminder>();

    public void OnGet()
    {
        Reminders = CarCRM.Models.Reminder.Index(_context);
    }
}
