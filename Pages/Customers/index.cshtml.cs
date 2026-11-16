using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CarCRM.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly CarCRMContext _context;

        public IndexModel(CarCRMContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; } = new List<Customer>();

        public void OnGet()
        {
            Customers = _context.Customers.ToList();
        }
    }
}
