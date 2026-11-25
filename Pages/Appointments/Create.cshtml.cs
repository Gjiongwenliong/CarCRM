using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarCRM.Pages.Appointments;

public class CreateModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    [BindProperty]
    public Appointment Appointment { get; set; } = new();

    public SelectList CustomerList { get; set; } = default!;
    public SelectList MaintenanceItemList { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        Appointment.DueDate = DateTime.Today;
        await LoadSelectListsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadSelectListsAsync();
            return Page();
        }

        _context.Appointments.Add(Appointment);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }

    private async Task LoadSelectListsAsync()
    {
        CustomerList = new SelectList(
            await _context.Customers
                .Select(c => new { c.Id, Name = c.Name ?? "Unknown customer" })
                .ToListAsync(),
            "Id",
            "Name");

        MaintenanceItemList = new SelectList(
            await _context.MaintenanceItems
                .Select(m => new { m.Id, m.Name })
                .ToListAsync(),
            "Id",
            "Name");
    }
}
