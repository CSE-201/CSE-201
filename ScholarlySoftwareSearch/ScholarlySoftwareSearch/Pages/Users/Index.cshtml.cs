using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScholarlySoftwareSearch.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Pages.Users {
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel {
        private readonly ScholarlySoftwareSearch.Data.ApplicationDbContext _context;

        public SelectList Roles { get; set; }
        [BindProperty(SupportsGet = true)]
        public string RoleString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserString { get; set; }

        public IdentityUser[] users;
        public UserController.Roles[] roles;
        public Dictionary<IdentityUser, UserController.Roles> dictionary;

        private IServiceProvider serviceProvider;

        public IndexModel(ScholarlySoftwareSearch.Data.ApplicationDbContext context, IServiceProvider serviceProvider) {
            _context = context;

            this.serviceProvider = serviceProvider;
        }

        public async Task OnGetAsync() {
            UserController userController = new UserController(serviceProvider);

            Roles = new SelectList(UserController.Roles.GetValues(typeof(UserController.Roles)).Cast<UserController.Roles>().ToList());

            users = _context.Users.ToArray();
            dictionary = new Dictionary<IdentityUser, UserController.Roles>();

            for (int i = 0; i < users.Length; i++) {
                dictionary.Add(users[i], await userController.GetRole(users[i]));
            }
        }

        public async Task<IActionResult> OnPostAsync() {
            // Checks the ensure the model state is valid, if not returns the page and doesn't process anything.
            if (!ModelState.IsValid) {
                return Page();
            }

            UserController userController = new UserController(serviceProvider);

            if (!string.IsNullOrEmpty(UserString)) {
                IdentityUser user = await userController.FindUser(UserString);
                if (!string.IsNullOrEmpty(RoleString)) {
                    UserController.Roles role = (UserController.Roles)Enum.Parse(typeof(UserController.Roles), RoleString);

                    await userController.AddUserToRole(user, role);
                }
            }

            return RedirectToPage("./Index");
        }

    }
}
