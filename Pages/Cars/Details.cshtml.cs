using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarCRM.Data;
using CarCRM.Models;
using System.Threading.Tasks;

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
            Car = await _context.Cars.FindAsync(id);

            if (Car == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
