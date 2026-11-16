using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarCRM.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly CarCRMContext _context;

        public CreateModel(CarCRMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            _context.SaveChanges();

            return RedirectToPage("/Customers/Index");
        }
    }
}
