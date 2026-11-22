using Microsoft.AspNetCore.Mvc.RazorPages;
using CarCRM.Data;
using CarCRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarCRM.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarCRMContext _context;

        public IndexModel(CarCRMContext context)
        {
            _context = context;
        }

        public IList<Car> Cars { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Cars = await _context.Cars
                .Include(c => c.Customer)
                .ToListAsync();
        }
    }
}
