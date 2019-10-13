using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScholarlySoftwareSearch.Models;

namespace ScholarlySoftwareSearch.Pages.Softwares
{
    public class CreateModel : PageModel
    {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        public CreateModel(ScholarlySoftwareSearch.Models.ModelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Software Software { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Software.Add(Software);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
