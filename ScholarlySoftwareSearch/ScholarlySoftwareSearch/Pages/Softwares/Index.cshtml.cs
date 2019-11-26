using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        // The fields a user can search by.
        public SelectList SearchBy { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchByString { get; set; }
        private string[] searchByStrings = { "Software Name", "Author(s)", "Upload Date", "Publisher", "Tag" };

        // Fields a user can sort by.
        public SelectList SortBy { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortByString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UploaderString { get; set; }

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
                // Gets all software that contains the search string.
                switch (SearchByString) {
                    case "Software Name":
                        // If the string is not empty, find entries that contain the string in the name.
                        softwares = softwares.Where(s => s.SoftwareName.Contains(SearchString));
                        break;
                    case "Author(s)":
                        // If the string is not empty, find entries that contain the string in the name.
                        softwares = softwares.Where(s => s.Authors.Contains(SearchString));
                        break;
                    case "Upload Date":
                        // If the string is not empty, find entries that contain the string in the name.
                        softwares = softwares.Where(s => s.UploadDate.ToString().Contains(SearchString));
                        break;
                    case "Publisher":
                        // If the string is not empty, find entries that contain the string in the name.
                        softwares = softwares.Where(s => s.Publisher.Contains(SearchString));
                        break;
                    case "Tag":
                        // If the string is not empty, find entries that contain the string in the name.
                        softwares = softwares.Where(s => s.Tag.Contains(SearchString));
                        break;
                    default:
                        break;
                }
            }


            // Checks whether the search string is empty or not.
            if (!string.IsNullOrEmpty(UploaderString)) {
                softwares = softwares.Where(s => s.UploaderID.Equals(UploaderString));
            }

            // Checks whether the search string is empty or not.
            if (!string.IsNullOrEmpty(SortByString)) {
                // Orders all software that contains by sort by string.
                switch (SortByString) {
                    case "Software Name":
                        softwares = softwares.OrderBy(s => s.SoftwareName);
                        break;
                    case "Author(s)":
                        softwares = softwares.OrderBy(s => s.Authors);
                        break;
                    case "Upload Date":
                        softwares = softwares.OrderBy(s => s.UploadDate);
                        break;
                    case "Publisher":
                        softwares = softwares.OrderBy(s => s.Publisher);
                        break;
                    case "Tag":
                        softwares = softwares.OrderBy(s => s.Tag);
                        break;
                }
            }

            // Returns to the user the search by strings.
            SearchBy = new SelectList(searchByStrings.ToList());

            // Set the list of software equal to the list of software found in the query.
            Software = await softwares.ToListAsync();
        }
    }
}
