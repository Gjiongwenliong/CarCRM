using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCRM.Pages.MaintenanceItems
{
    public class EditModel(CarCRMContext context) : PageModel
    {
        private readonly CarCRMContext _context = context;

        [BindProperty]
        public MaintenanceItem MaintenanceItem { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            var maintenanceItem = _context.MaintenanceItems.Find(id);

            if (maintenanceItem == null)
            {
                return NotFound();
            }

            MaintenanceItem = maintenanceItem;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MaintenanceItems.Update(MaintenanceItem);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
