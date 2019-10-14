using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Pages.Softwares {
    public class DetailsModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        public DetailsModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        public Software Software { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            Software = await _context.Software.FirstOrDefaultAsync(m => m.Id == id);

            if (Software == null) {
                return NotFound();
            }
            return Page();
        }
    }
}
