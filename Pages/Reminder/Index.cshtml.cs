using CarCRM.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCRM.Pages.Reminder;

public class IndexModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    public IList<global::Reminder> Reminders { get; set; } = new List<global::Reminder>();

    public void OnGet()
    {
        Reminders = global::Reminder.Index(_context);
    }
}
