using CarCRM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCRM.Pages.Reminder;

public class DetailsModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    public global::Reminder Reminder { get; set; } = default!;

    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        try
        {
            Reminder = global::Reminder.ReadRecord(_context, id.Value);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }

        return Page();
    }
}