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

            services.AddDbContext<SoftwareContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SoftwareContext")));
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

            CreateRolesAsync(serviceProvider).Wait();
            //CreateSuperUser(userManager).Wait();
        }

        // NOT WORKING YET... :(
        private async Task CreateSuperUser(UserManager<IdentityUser> userManager) {
            IdentityUser superUser = new IdentityUser { UserName = Configuration["root"], Email = Configuration["root"] };
            await userManager.CreateAsync(superUser, Configuration["Password"]);
            string token = await userManager.GenerateEmailConfirmationTokenAsync(superUser);
            await userManager.ConfirmEmailAsync(superUser, token);
            await userManager.AddToRoleAsync(superUser, "admin");
        }

        private async Task CreateRolesAsync(IServiceProvider serviceProvider) {
            // Adding roles.
            RoleManager<IdentityRole> RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "admin", "member" };
            IdentityResult roleResult;

            foreach (string roleName in roleNames) {
                // Creating the roles and adding them to the database.
                bool roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist) {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
