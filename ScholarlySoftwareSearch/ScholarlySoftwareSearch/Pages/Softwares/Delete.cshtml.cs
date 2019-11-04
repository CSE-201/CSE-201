using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Pages.Softwares {
    [Authorize]
    public class DeleteModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        /// <summary>
        /// Creates an instance of DeleteModel with ModelContext.
        /// </summary>
        /// <param name="context"></param>
        public DeleteModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        // The software entry for the page.
        [BindProperty]
        public Software Software { get; set; }

        /// <summary>
        /// Called when the user requests the delete page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int? id) {
            // If the id is null, return not found result.
            if (id == null) {
                return NotFound();
            }

            // Wait till the id is found in the database.
            Software = await _context.Software.FirstOrDefaultAsync(m => m.Id == id);

            // If software is null, return not found result.
            if (Software == null) {
                return NotFound();
            }

            /* If the software uploaderId is different from the user and the user is not an admin/manager.
             * return a forbid result. */
            if (Software.UploaderID != User.Identity.Name && !(User.IsInRole("Admin") || User.IsInRole("Manager"))) {
                return Forbid();
            }

            // Return the delete page to the user.
            return Page();
        }

        /// <summary>
        /// Called when the user deletes the software entry.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(int? id) {
            // If the id is null, return not found result.
            if (id == null) {
                return NotFound();
            }

            // Wait till the id is found in the database.
            Software = await _context.Software.FindAsync(id);

            // If the software is not null, delete it and save the changes.
            if (Software != null) {
                _context.Software.Remove(Software);
                await _context.SaveChangesAsync();
            }

            // Returns to the Software index page.
            return RedirectToPage("./Index");
        }
    }
}
