using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScholarlySoftwareSearch.Models;
using System.Net;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Pages.Softwares {
    [Authorize]
    public class CreateModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        /// <summary>
        /// Creates an instance of CreateModel with ModelContext.
        /// </summary>
        /// <param name="context"></param>
        public CreateModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        /// <summary>
        /// Called when the user requests the create page.
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet() {
            return Page();
        }

        // The software entry for the page.
        [BindProperty]
        public Software Software { get; set; }

        /// <summary>
        /// Upon getting the user's information about software entry, adds that to the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync() {
            // Whether the model state is valid or not.
            if (!ModelState.IsValid) {
                return Page();
            }

            WebRequest webRequest = WebRequest.Create(Software.DownloadURL);
            WebResponse webResponse;
            try {
                webResponse = webRequest.GetResponse();
            } catch (System.Exception) {
                return RedirectToPage("./Error");
            }

            // Adds the software to ModelContext.
            _context.Software.Add(Software);

            // Waits till changes are saved.
            await _context.SaveChangesAsync();

            // Returns to the Software index page.
            return RedirectToPage("./Index");
        }
    }
}
