using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarCRM.Pages.Appointments;

public class DeleteModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    [BindProperty]
    public Appointment Appointment { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var appointment = await _context.Appointments
            .Include(a => a.Customer)
            .Include(a => a.MaintenanceItem)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (appointment == null)
        {
            return NotFound();
        }

        Appointment = appointment;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var appointment = await _context.Appointments.FindAsync(Appointment.Id);
        if (appointment == null)
        {
            return NotFound();
        }

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}
