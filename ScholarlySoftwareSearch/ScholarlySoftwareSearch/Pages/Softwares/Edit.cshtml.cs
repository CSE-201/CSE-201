using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Pages.Softwares {
    [Authorize]
    public class EditModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        /// <summary>
        /// Creates an instance of EditModel with ModelContext.
        /// </summary>
        /// <param name="context"></param>
        public EditModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        // The software entry for the page.
        [BindProperty]
        public Software Software { get; set; }

        /// <summary>
        /// Called when the user requests the edit page for an entry.
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
            if (Software.UploaderID != User.Identity.Name && !(User.IsInRole("Manager") || User.IsInRole("Admin"))) {
                return Forbid();
            }

            //Return the delete page to the user.
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            // Checks the ensure the model state is valid, if not returns the page and doesn't process anything.
            if (!ModelState.IsValid) {
                return Page();
            }

            // Gets the modified state of the software.
            _context.Attach(Software).State = EntityState.Modified;

            WebRequest webRequest = WebRequest.Create(Software.DownloadURL);
            WebResponse webResponse;
            try {
                webResponse = webRequest.GetResponse();
            } catch (System.Exception) {
                return RedirectToPage("./Error");
            }

            // Saves the changes if the software still exists.
            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!SoftwareExists(Software.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            // Redirects the user to software index page.
            return RedirectToPage("./Index");
        }

        /// <summary>
        /// Checks to see if a software entry exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool SoftwareExists(int id) {
            return _context.Software.Any(e => e.Id == id);
        }
    }
}
