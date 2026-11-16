using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarCRM.Pages.ServiceRecords;

public class EditModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    [BindProperty]
    public ServiceRecord ServiceRecord { get; set; } = default!;

    public SelectList CarList { get; set; } = default!;
    public SelectList MaintenanceItemList { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var serviceRecord = await _context.ServiceRecords.FindAsync(id);
        if (serviceRecord == null)
        {
            return NotFound();
        }

        ServiceRecord = serviceRecord;
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

        _context.Attach(ServiceRecord).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            var exists = await _context.ServiceRecords.AnyAsync(e => e.Id == ServiceRecord.Id);
            if (!exists)
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private async Task LoadSelectListsAsync()
    {
        var cars = await _context.Cars.ToListAsync();
        CarList = new SelectList(
            cars.Select(c => new
            {
                c.Id,
                Display = c.DisplayName
            }),
            "Id",
            "Display",
            ServiceRecord.CarId
        );

        MaintenanceItemList = new SelectList(
            await _context.MaintenanceItems
                .Select(m => new
                {
                    m.Id,
                    Display = m.Name
                })
                .ToListAsync(),
            "Id",
            "Display",
            ServiceRecord.MaintenanceItemId
        );
    }
}
