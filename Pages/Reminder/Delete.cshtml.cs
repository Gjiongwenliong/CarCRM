using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCRM.Pages.Reminders;

public class DeleteModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    [BindProperty]
    public CarCRM.Models.Reminder Reminder { get; set; } = default!;

    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        try
        {
            Reminder = global::CarCRM.Models.Reminder.ReadRecord(_context, id.Value);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        try
        {
            global::CarCRM.Models.Reminder.DeleteRecord(_context, Reminder.Id);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }

        return RedirectToPage("./Index");
    }
}
