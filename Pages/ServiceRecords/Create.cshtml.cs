using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarCRM.Data;
using CarCRM.Models;

public class CreateModel(CarCRMContext context) : PageModel
{
    private readonly CarCRMContext _context = context;

    [BindProperty]
    public ServiceRecord ServiceRecord { get; set; } = new();

    public SelectList CarList { get; set; } = default!;
    public SelectList MaintenanceItemList { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        ServiceRecord.ServiceDate = DateTime.Today;
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

        _context.ServiceRecords.Add(ServiceRecord);
        await _context.SaveChangesAsync();

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
            "Display"
        );

        MaintenanceItemList = new SelectList(
            await _context.MaintenanceItems
                .Select(m => new {
                    m.Id,
                    Display = m.Name
                })
                .ToListAsync(),
            "Id",
            "Display"
        );
    }
}
