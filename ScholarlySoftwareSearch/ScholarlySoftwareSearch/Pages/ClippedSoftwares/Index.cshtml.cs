using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Pages.ClippedSoftwares {
    public class IndexModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        public IndexModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        public IList<ClippedSoftware> ClippedSoftware { get; set; }

        public async Task OnGetAsync() {
            ClippedSoftware = await _context.ClippedSoftware.ToListAsync();
        }
    }
}
