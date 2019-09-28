using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Scholary_Software_Search.Models;
using System.Threading.Tasks;

namespace Scholary_Software_Search.Pages.Softwares {
    public class DeleteModel : PageModel {
        private readonly Scholary_Software_Search.Data.DataContext _context;

        public DeleteModel(Scholary_Software_Search.Data.DataContext context) {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id) {
            if (id == null) {
                return NotFound();
            }

            Software = await _context.Software.FindAsync(id);

            if (Software != null) {
                _context.Software.Remove(Software);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
