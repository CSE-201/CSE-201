using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Scholary_Software_Search.Models;
using System.Threading.Tasks;

namespace Scholary_Software_Search.Pages.Softwares {
    public class DetailsModel : PageModel {
        private readonly Scholary_Software_Search.Data.DataContext _context;

        public DetailsModel(Scholary_Software_Search.Data.DataContext context) {
            _context = context;
        }

        public Software Software { get; set; }

        public async Task<IActionResult> OnGetAsync(string id) {
            if (id == null) {
                return NotFound();
            }

            Software = await _context.Software.FirstOrDefaultAsync(m => m.UrlAddress == id);

            if (Software == null) {
                return NotFound();
            }
            return Page();
        }
    }
}
