using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarCRM.Data;
using CarCRM.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarCRM.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly CarCRMContext _context;

        public DetailsModel(CarCRMContext context)
        {
            _context = context;
        }

        public Car? Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Car = await _context.Cars
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (Car == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
