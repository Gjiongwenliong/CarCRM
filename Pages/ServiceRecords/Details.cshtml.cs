using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarCRM.Data;
using CarCRM.Models;

namespace CarCRM.Pages.ServiceRecords;

public class DetailsModel : PageModel
{
    private readonly CarCRMContext _context;

    public DetailsModel(CarCRMContext context)
    {
        _context = context;
    }

    public ServiceRecord ServiceRecord { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var serviceRecord = await _context.ServiceRecords
            .Include(s => s.Car)
            .Include(s => s.MaintenanceItem)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (serviceRecord == null)
        {
            return NotFound();
        }

        ServiceRecord = serviceRecord;

        return Page();
    }
}