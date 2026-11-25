using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarCRM.Data;
using CarCRM.Models;

namespace CarCRM.Pages.Appointments;

public class IndexModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    public IList<Appointment> Appointments { get; set; } = new List<Appointment>();

    public async Task OnGetAsync()
    {
        Appointments = await _context.Appointments
            .Include(a => a.Customer)
            .Include(a => a.MaintenanceItem)
            .OrderBy(a => a.DueDate)
            .ToListAsync();
    }
}
