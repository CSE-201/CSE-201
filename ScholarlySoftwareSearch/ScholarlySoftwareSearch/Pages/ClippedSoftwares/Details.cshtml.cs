using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;

namespace ScholarlySoftwareSearch.Pages.ClippedSoftwares
{
    public class DetailsModel : PageModel
    {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        public DetailsModel(ScholarlySoftwareSearch.Models.ModelContext context)
        {
            _context = context;
        }

        public ClippedSoftware ClippedSoftware { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClippedSoftware = await _context.ClippedSoftware.FirstOrDefaultAsync(m => m.Id == id);

            if (ClippedSoftware == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
