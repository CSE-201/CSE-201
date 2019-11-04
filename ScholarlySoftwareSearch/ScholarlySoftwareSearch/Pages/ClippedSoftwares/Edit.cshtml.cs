using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Pages.ClippedSoftwares {
    public class EditModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        public EditModel(ScholarlySoftwareSearch.Models.ModelContext context) {
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(ClippedSoftware).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!ClippedSoftwareExists(ClippedSoftware.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClippedSoftwareExists(int id) {
            return _context.ClippedSoftware.Any(e => e.Id == id);
        }
    }
}
