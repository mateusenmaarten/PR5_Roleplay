using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Roleplay.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Roleplay.Areas.Identity.Data;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using FluentValidation.AspNetCore;
using PR5_Roleplay.Models;
using FluentValidation;
using Roleplay.Validator;

namespace Roleplay
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<CustomUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews()
                .AddFluentValidation();

            services.AddTransient<IValidator<Character>, CharacterValidator>();

            services.AddRazorPages();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }

            CultureInfo cultureInfoDutchBelgium = new CultureInfo("nl-BE");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfoDutchBelgium;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfoDutchBelgium;

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                //redirect when a user tries to access the register page
                endpoints.MapGet("/Identity/Account/Register", context => Task.Factory.StartNew(() => context.Response.Redirect("/Identity/Account/Login", true, true)));

                endpoints.MapPost("/Identity/Account/Register", context => Task.Factory.StartNew(() => context.Response.Redirect("/Identity/Account/Login", true, true)));

            });

            //CreateUserRoles(serviceProvider).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            ApplicationDbContext Context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            IdentityResult roleResult;

            //bool roleCheck = await RoleManager.RoleExistsAsync("Admin");
            //if (!roleCheck)
            //{
            //    roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            //}

            //bool roleCheck = await RoleManager.RoleExistsAsync("GameMaster");
            //if (!roleCheck)
            //{
            //    roleResult = await RoleManager.CreateAsync(new IdentityRole("GameMaster"));
            //}

            bool roleCheck = await RoleManager.RoleExistsAsync("Player");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Player"));
            }
            IdentityUser user = Context.Users.FirstOrDefault(u => u.Email == "jan@fake.com");
            if (user != null)
            {
                DbSet<IdentityUserRole<string>> roles = Context.UserRoles;
                IdentityRole role = Context.Roles.FirstOrDefault(r => r.Name == "Player");
                if (role != null)
                {
                    if (!roles.Any(Ur => Ur.UserId == user.Id && Ur.RoleId == role.Id))
                    {
                        roles.Add(new IdentityUserRole<string>() { UserId = user.Id, RoleId = role.Id });
                        Context.SaveChanges();
                    }
                }
            }
        }
    }
}
