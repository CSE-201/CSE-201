using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Scholary_Software_Search.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Pages.Softwares {
    public class IndexModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        public IndexModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        public IList<Software> Software { get; set; }

        public async Task OnGetAsync() {
            Software = await _context.Software.ToListAsync();
        }
    }
}
