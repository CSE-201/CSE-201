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

namespace ScholarlySoftwareSearch {
    public class Startup {

        // Project default properties.
        private readonly string[] roles = { "admin", "manager", "member" };
        private readonly IdentityUser admin = new IdentityUser { UserName = "root@email.com", Email = "root@email.com" };
        private readonly string admin_password = "Password_test201";

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();

            services.AddDbContext<ModelContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ModelContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, UserManager<IdentityUser> userManager) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
            });

            // Creates the default roles.
            CreateRolesAsync(serviceProvider).Wait();

            // Creates the default admin.
            CreateAdmin(serviceProvider).Wait();
        }

        private async Task CreateAdmin(IServiceProvider serviceProvider) {
            // Adding admin.
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = admin;
            var result = await userManager.CreateAsync(user, admin_password);
            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await userManager.ConfirmEmailAsync(user, token);
            await userManager.AddToRoleAsync(user, roles[0]);
        }

        private async Task CreateRolesAsync(IServiceProvider serviceProvider) {
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
