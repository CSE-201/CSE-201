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

        /// <summary>
        /// Creates an instance of IndexModel with ModelContext.
        /// </summary>
        /// <param name="context"></param>
        public IndexModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        // The list of all software entries on the page.
        public IList<Software> Software { get; set; }

        // The user search string.
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // The tags a user can search by.
        public SelectList Tags { get; set; }
        [BindProperty(SupportsGet = true)]

        // The string of the tag that user has selected.
        public string SoftwareTag { get; set; }

        /// <summary>
        /// Called when the user requests the index page.
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync() {
            // Selects all software entries in the database.
            var softwares = from s in _context.Software select s;

            // Generates list of tags from the tags present in the database.
            IQueryable<string> tagQuery = from s in _context.Software orderby s.Tag select s.Tag;

            // Checks whether the search string is empty or not.
            if (!string.IsNullOrEmpty(SearchString)) {
                // If the string is not empty, find entries that contain the string in the name.
                softwares = softwares.Where(s => s.SoftwareName.Contains(SearchString));
            }

            // Checks whether the search tag is empty or not.
            if (!string.IsNullOrEmpty(SoftwareTag)) {
                // If the tag is not empty, grab only entries with that tag.
                softwares = softwares.Where(s => s.Tag == SoftwareTag);
            }

            // Set the list of tags equal to the distinct tags in the datbase.
            Tags = new SelectList(await tagQuery.Distinct().ToListAsync());

            // Set the list of software equal to the list of software found in the query.
            Software = await softwares.ToListAsync();
        }
    }
}
