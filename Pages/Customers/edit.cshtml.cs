using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCRM.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly CarCRMContext _context;

        public EditModel(CarCRMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; } = null!;

        public IActionResult OnGet(int id)
        {
            Customer = _context.Customers.Find(id)!;

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Update(Customer);
            _context.SaveChanges();

            return RedirectToPage("./index");
        }
    }
}
