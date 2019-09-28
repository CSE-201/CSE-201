using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Scholary_Software_Search.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scholary_Software_Search.Pages.Softwares {
    public class IndexModel : PageModel {
        private readonly Scholary_Software_Search.Data.DataContext _context;

        public IndexModel(Scholary_Software_Search.Data.DataContext context) {
            _context = context;
        }

        public IList<Software> Software { get; set; }

        public async Task OnGetAsync() {
            Software = await _context.Software.ToListAsync();
        }
    }
}
