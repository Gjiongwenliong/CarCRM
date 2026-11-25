using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarCRM.Pages.Appointments;

public class EditModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    [BindProperty]
    public Appointment Appointment { get; set; } = default!;

    public SelectList CustomerList { get; set; } = default!;
    public SelectList MaintenanceItemList { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }

        Appointment = appointment;
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

        _context.Attach(Appointment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Appointments.AnyAsync(a => a.Id == Appointment.Id))
            {
                return NotFound();
            }
            throw;
        }

        return RedirectToPage("./Index");
    }

    private async Task LoadSelectListsAsync()
    {
        CustomerList = new SelectList(
            await _context.Customers
                .Select(c => new { c.Id, Name = c.Name ?? "Unknown customer" })
                .ToListAsync(),
            "Id",
            "Name",
            Appointment.CustomerId);

        MaintenanceItemList = new SelectList(
            await _context.MaintenanceItems
                .Select(m => new { m.Id, m.Name })
                .ToListAsync(),
            "Id",
            "Name",
            Appointment.MaintenanceItemId);
    }
}
