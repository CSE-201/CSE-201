using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Controllers {
    public class UserController {
        public static UserController instance;

        private IServiceProvider serviceProvider;

        // Default roles.
        public enum Roles { Admin, Manager, Member };

        public UserController(IServiceProvider serviceProvider) {
            // Enforces singleton pattern.
            instance = this;

            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Creates a user and adds them to the database.
        /// </summary>
        /// <param name="user">The user being added to the database.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="role">The user's default role. Can be changed later.</param>
        /// <returns></returns>
        public async Task CreateUser(IdentityUser user, string password, Roles role) {
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            await userManager.CreateAsync(user, password);
            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await userManager.ConfirmEmailAsync(user, token);
            await AddUserToRole(user, role);
        }

        /// <summary>
        /// Adds an existing user to a role.
        /// </summary>
        /// <param name="user">The existing user.</param>
        /// <param name="role">The role the user is being added to.</param>
        /// <returns></returns>
        public async Task AddUserToRole(IdentityUser user, Roles role) {
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            await userManager.AddToRoleAsync(user, role.ToString());
        }

        /// <summary>
        /// Creates new roles for users to be added to into the RoleManager.
        /// </summary>
        /// <param name="roles">The roles being added to the RoleManager.</param>
        /// <returns></returns>
        public async Task CreateRolesAsync(string[] roles) {
            // Adding roles.
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = roles;
            IdentityResult roleResult;
            
            foreach (string roleName in roleNames) {
                // Creating the roles and adding them to the database.
                bool roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist) {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

    }
}
