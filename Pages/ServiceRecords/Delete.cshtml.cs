using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarCRM.Pages.ServiceRecords;

public class DeleteModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    [BindProperty]
    public ServiceRecord ServiceRecord { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var serviceRecord = await _context.ServiceRecords
            .Include(s => s.Car)
            .ThenInclude(c => c.Customer)
            .Include(s => s.Customer)
            .Include(s => s.MaintenanceItem)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (serviceRecord == null)
        {
            return NotFound();
        }

        ServiceRecord = serviceRecord;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var serviceRecord = await _context.ServiceRecords.FindAsync(ServiceRecord.Id);
        if (serviceRecord == null)
        {
            return NotFound();
        }

        _context.ServiceRecords.Remove(serviceRecord);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
