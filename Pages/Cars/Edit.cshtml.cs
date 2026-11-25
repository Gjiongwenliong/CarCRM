using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarCRM.Data;
using CarCRM.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarCRM.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly CarCRMContext _context;

        public EditModel(CarCRMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public SelectList CustomerList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            Car = car;
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

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cars.Any(e => e.Id == Car.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }

        private async Task LoadCustomerListAsync()
        {
            CustomerList = new SelectList(
                await _context.Customers
                    .Select(c => new { c.Id, Name = c.Name ?? "Unknown customer" })
                    .ToListAsync(),
                "Id",
                "Name",
                Car.IdCustomer);
        }
    }
}
