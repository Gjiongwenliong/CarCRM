using CarCRM.Data;
using CarCRM.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CarCRM.Pages.MaintenanceItems
{
    public class IndexModel : PageModel
    {
        private readonly CarCRMContext _context;

        public IndexModel(CarCRMContext context)
        {
            _context = context;
        }

        public IList<MaintenanceItem> MaintenanceItems { get; set; } = new List<MaintenanceItem>();

        public void OnGet()
        {
            MaintenanceItems = _context.MaintenanceItems.ToList();
        }
    }
}
