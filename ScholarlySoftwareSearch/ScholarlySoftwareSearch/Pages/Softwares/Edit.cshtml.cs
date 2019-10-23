using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ScholarlySoftwareSearch.Pages.Softwares {
    [Authorize]
    public class EditModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        public EditModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        [BindProperty]
        public Software Software { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            Software = await _context.Software.FirstOrDefaultAsync(m => m.Id == id);

            if (Software == null) {
                return NotFound();
            }

            if (Software.UploaderID != User.Identity.Name && !(User.IsInRole("Manager") || User.IsInRole("Admin"))) {
                return Forbid();
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
                if (!SoftwareExists(Software.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SoftwareExists(int id) {
            return _context.Software.Any(e => e.Id == id);
        }
    }
}
