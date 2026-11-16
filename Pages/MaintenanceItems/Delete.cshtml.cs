using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCRM.Pages.MaintenanceItems
{
    public class DeleteModel : PageModel
    {
        private readonly CarCRMContext _context;

        public DeleteModel(CarCRMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MaintenanceItem MaintenanceItem { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            var item = _context.MaintenanceItems.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            MaintenanceItem = item;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (MaintenanceItem == null)
            {
                return NotFound();
            }

            var item = _context.MaintenanceItems.Find(MaintenanceItem.Id);

            if (item == null)
            {
                return NotFound();
            }

            _context.MaintenanceItems.Remove(item);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
