using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Pages.Softwares {
    public class DetailsModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        /// <summary>
        /// Creates an instance of DetailModel with ModelContext.
        /// </summary>
        /// <param name="context"></param>
        public DetailsModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        // The software entry for the page.
        public Software Software { get; set; }

        /// <summary>
        /// Called when the user requests the detail page.
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

            // If the software is not found, return not found result.
            if (Software == null) {
                return NotFound();
            }

            // Return the detail page to the user.
            return Page();
        }
    }
}
