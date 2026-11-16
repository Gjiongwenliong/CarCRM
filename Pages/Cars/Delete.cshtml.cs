using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarCRM.Data;
using CarCRM.Models;
using System.Threading.Tasks;

namespace CarCRM.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly CarCRMContext _context;

        public DeleteModel(CarCRMContext context)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
