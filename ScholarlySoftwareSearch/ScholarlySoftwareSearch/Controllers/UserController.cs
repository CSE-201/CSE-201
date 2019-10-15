using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScholarlySoftwareSearch.Data;
using ScholarlySoftwareSearch.Models;
using System;
using System.Threading.Tasks;

namespace ScholarlySoftwareSearch.Controllers {
    public class UserController {

        // Project default properties.
        private readonly string[] roles = { "admin", "manager", "member" };
        private readonly IdentityUser admin = new IdentityUser { UserName = "root@email.com", Email = "root@email.com" };
        private readonly string admin_password = "Password_test201";

        public async Task CreateAdmin(IServiceProvider serviceProvider) {
            // Adding admin.
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = admin;
            var result = await userManager.CreateAsync(user, admin_password);
            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await userManager.ConfirmEmailAsync(user, token);
            await userManager.AddToRoleAsync(user, roles[0]);
        }

        public async Task CreateRolesAsync(IServiceProvider serviceProvider) {
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
