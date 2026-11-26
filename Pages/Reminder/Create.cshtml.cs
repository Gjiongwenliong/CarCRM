using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarCRM.Pages.Reminders;

public class CreateModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    private static readonly string[] StatusOptions = ["Pending", "Completed", "Overdue"];

    [BindProperty]
    public CarCRM.Models.Reminder Reminder { get; set; } = new()
    {
        ReminderDate = DateTime.Today,
        ServiceItem = string.Empty,
        Status = "Pending",
        Notes = string.Empty
    };

    public SelectList CarList { get; set; } = default!;
    public SelectList ServiceItemList { get; set; } = default!;
    public SelectList StatusList { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        await LoadSelectListsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await ValidateBusinessRulesAsync();

        if (!ModelState.IsValid)
        {
            await LoadSelectListsAsync();
            return Page();
        }

        global::CarCRM.Models.Reminder.CreateRecord(_context, Reminder);
        return RedirectToPage("./Index");
    }

    private async Task ValidateBusinessRulesAsync()
    {
        if (Reminder.ReminderDate.Date < DateTime.Today)
        {
            ModelState.AddModelError("Reminder.ReminderDate", "Reminder date cannot be in the past.");
        }

        if (!await _context.Cars.AnyAsync(c => c.Id == Reminder.CarId))
        {
            ModelState.AddModelError("Reminder.CarId", "Selected car does not exist.");
        }

        if (string.IsNullOrWhiteSpace(Reminder.ServiceItem))
        {
            ModelState.AddModelError("Reminder.ServiceItem", "Please select a service item.");
        }
        else if (!await _context.MaintenanceItems.AnyAsync(m => m.Name == Reminder.ServiceItem))
        {
            ModelState.AddModelError("Reminder.ServiceItem", "Selected service item does not exist.");
        }
    }

    private async Task LoadSelectListsAsync()
    {
        var cars = await _context.Cars.ToListAsync();
        CarList = new SelectList(
            cars.Select(c => new { c.Id, Display = c.DisplayName }),
            "Id",
            "Display",
            Reminder.CarId
        );

        var serviceItems = await _context.MaintenanceItems
            .OrderBy(m => m.Name)
            .Select(m => m.Name)
            .Distinct()
            .ToListAsync();
        ServiceItemList = new SelectList(serviceItems, Reminder.ServiceItem);

        StatusList = new SelectList(StatusOptions, Reminder.Status);
    }
}
