using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Scholary_Software_Search.Models;
using System.Threading.Tasks;

namespace Scholary_Software_Search.Pages.Softwares {
    public class CreateModel : PageModel {
        private readonly Scholary_Software_Search.Data.DataContext _context;

        public CreateModel(Scholary_Software_Search.Data.DataContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public Software Software { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Software.Add(Software);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
