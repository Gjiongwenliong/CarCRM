using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarCRM.Pages.ServiceRecords;

public class IndexModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    public IList<ServiceRecord> ServiceRecords { get; set; } = new List<ServiceRecord>();

    public async Task OnGetAsync()
    {
        ServiceRecords = await _context.ServiceRecords
            .Include(s => s.Car)
            .Include(s => s.MaintenanceItem)
            .OrderByDescending(s => s.ServiceDate)
            .ToListAsync();
    }
}
