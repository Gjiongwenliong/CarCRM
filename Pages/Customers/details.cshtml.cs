using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarCRM.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly CarCRMContext _context;

        public DetailsModel(CarCRMContext context)
        {
            _context = context;
        }

        public Customer? Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id);

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
