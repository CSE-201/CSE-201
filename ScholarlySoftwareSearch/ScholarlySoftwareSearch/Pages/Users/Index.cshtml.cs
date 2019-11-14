using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScholarlySoftwareSearch.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScholarlySoftwareSearch.Controllers;

namespace ScholarlySoftwareSearch.Pages.Users {
    public class IndexModel : PageModel {
        private readonly ScholarlySoftwareSearch.Models.ModelContext _context;

        public SelectList Roles { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchByString { get; set; }

        public IndexModel(ScholarlySoftwareSearch.Models.ModelContext context) {
            _context = context;
        }

        public async Task OnGetAsync() {
            Roles = new SelectList(UserController.Roles.GetValues(typeof(UserController.Roles)).Cast<UserController.Roles>().ToList());
        }
    }
}
