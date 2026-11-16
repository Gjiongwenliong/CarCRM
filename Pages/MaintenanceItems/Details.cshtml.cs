using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCRM.Pages.MaintenanceItems
{
    public class DetailsModel : PageModel
    {
        private readonly CarCRMContext _context;

        public DetailsModel(CarCRMContext context)
        {
            _context = context;
        }

        public MaintenanceItem MaintenanceItem { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            MaintenanceItem? maintenanceItem = _context.MaintenanceItems.Find(id);

            if (maintenanceItem == null)
            {
                return NotFound();
            }

            MaintenanceItem = maintenanceItem;
            return Page();
        }
    }
}
