using CarCRM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCRM.Pages.Reminder;

public class DeleteModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    [BindProperty]
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

    public IActionResult OnPost()
    {
        try
        {
            global::Reminder.DeleteRecord(_context, Reminder.Id);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }

        return RedirectToPage("./Index");
    }
}
