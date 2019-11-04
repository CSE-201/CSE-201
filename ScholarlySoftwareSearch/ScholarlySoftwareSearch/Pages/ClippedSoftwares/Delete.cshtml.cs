using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Pages.ClippedSoftwares {
    public class DeleteModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        public DeleteModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        [BindProperty]
        public ClippedSoftware ClippedSoftware { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            ClippedSoftware = await _context.ClippedSoftware.FirstOrDefaultAsync(m => m.Id == id);

            if (ClippedSoftware == null) {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            ClippedSoftware = await _context.ClippedSoftware.FindAsync(id);

            if (ClippedSoftware != null) {
                _context.ClippedSoftware.Remove(ClippedSoftware);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
