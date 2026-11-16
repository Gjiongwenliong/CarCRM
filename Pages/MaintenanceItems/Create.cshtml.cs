using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCRM.Pages.MaintenanceItems
{
    public class CreateModel : PageModel
    {
        private readonly CarCRMContext _context;

        public CreateModel(CarCRMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MaintenanceItem MaintenanceItem { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MaintenanceItems.Add(MaintenanceItem);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
