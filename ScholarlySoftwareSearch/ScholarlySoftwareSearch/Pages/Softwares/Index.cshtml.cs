using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ScholarlySoftwareSearch.Pages.Softwares {
    public class IndexModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        public IndexModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        public IList<Software> Software { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Tags { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SoftwareTag { get; set; }

        public async Task OnGetAsync() {
            var softwares = from s in _context.Software select s;

            // Generates list of tags
            IQueryable<string> tagQuery = from s in _context.Software orderby s.Tag select s.Tag;

            if (!string.IsNullOrEmpty(SearchString)) {
                softwares = softwares.Where(s => s.SoftwareName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SoftwareTag)) {
                softwares = softwares.Where(s => s.Tag == SoftwareTag);
            }

            Tags = new SelectList(await tagQuery.Distinct().ToListAsync());
            Software = await softwares.ToListAsync();
        }
    }
}
