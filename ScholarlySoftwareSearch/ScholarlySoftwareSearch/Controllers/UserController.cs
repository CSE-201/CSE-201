using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Controllers {
    public class UserController {

        public IServiceProvider serviceProvider;

        // Default roles.
        public enum Roles { Admin, Manager, Member };

        public UserController(IServiceProvider serviceProvider) {
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

            Roles currentRole = await GetRole(user);

            if (currentRole != Roles.Member) {
                await userManager.RemoveFromRoleAsync(user, currentRole.ToString());
            }

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

        /// <summary>
        /// Gets the role of a user.
        /// </summary>
        /// <param name="user">The existing user.</param>
        /// <returns></returns>
        public async Task<Roles> GetRole(IdentityUser user) {
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            foreach (Roles r in Enum.GetValues(typeof(Roles))) {
                if (await userManager.IsInRoleAsync(user, r.ToString())) {
                    return r;
                }
            }
            return Roles.Member;
        }

        /// <summary>
        /// Finds the user based on a username.
        /// </summary>
        /// <param name="userName">The user's username.</param>
        /// <returns></returns>
        public async Task<IdentityUser> FindUser(string userName) {
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            return await userManager.FindByNameAsync(userName);
        }

    }
}
