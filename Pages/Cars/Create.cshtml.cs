using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public SelectList CustomerList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadCustomerListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadCustomerListAsync();
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task LoadCustomerListAsync()
        {
            CustomerList = new SelectList(
                await _context.Customers
                    .Select(c => new { c.Id, Name = c.Name ?? "Unknown customer" })
                    .ToListAsync(),
                "Id",
                "Name");
        }
    }
}
