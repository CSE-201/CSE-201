using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Scholary_Software_Search.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Scholary_Software_Search.Pages.Softwares {
    public class EditModel : PageModel {
        private readonly Scholary_Software_Search.Data.DataContext _context;

        public EditModel(Scholary_Software_Search.Data.DataContext context) {
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(Software).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!SoftwareExists(Software.UrlAddress)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SoftwareExists(string id) {
            return _context.Software.Any(e => e.UrlAddress == id);
        }
    }
}
