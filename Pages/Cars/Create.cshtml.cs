using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarCRM.Data;
using CarCRM.Models;

namespace CarCRM.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CarCRMContext _context;

        public CreateModel(CarCRMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = new()
        {
            PlateNumber = string.Empty,
            Brand = string.Empty,
            Model = string.Empty
        };

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
