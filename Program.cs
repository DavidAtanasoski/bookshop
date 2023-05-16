//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using bookshop.Data;
//using bookshop.Models;
//using bookshop.Interfaces;
//using Microsoft.AspNetCore.Identity;
//using bookshop.Areas.Identity.Data;
////using bookshop.Areas.Identity.Data;

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<BookshopContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("bookshopContext") ?? throw new InvalidOperationException("Connection string 'bookshopContext' not found.")));

////builder.Services.AddDefaultIdentity<bookshopUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<bookshopContextIdentity>();

//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//    options.CheckConsentNeeded = context => true;
//    options.MinimumSameSitePolicy = SameSiteMode.None;
//});

//builder.Services.AddRazorPages();
//builder.Services.AddIdentity<bookshopUser, IdentityRole>().AddEntityFrameworkStores<BookshopContext>().AddDefaultTokenProviders();

//// Add services to the container.
//builder.Services.AddControllersWithViews()
//    .AddRazorPagesOptions(options =>
//    {
//        options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
//        options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
//    });

//builder.Services.AddTransient<IBufferedFileUploadService, BufferedFileUploadLocalService>();


//// Password Strength Setting
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Password settings
//    options.Password.RequireDigit = true;
//    options.Password.RequiredLength = 8;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireLowercase = false;
//    options.Password.RequiredUniqueChars = 6;
//    // Lockout settings
//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
//    options.Lockout.MaxFailedAccessAttempts = 10;
//    options.Lockout.AllowedForNewUsers = true;
//    // User settings
//    options.User.RequireUniqueEmail = true;
//});

////Setting the Account Login page
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    // Cookie settings
//    options.Cookie.HttpOnly = true;
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
//    options.LoginPath = $"/Identity/Account/Login";
//    options.LogoutPath = $"/Identity/Account/Logout";
//    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
//    options.SlidingExpiration = true;
//});


//var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    SeedData.Initialize(services);
//}

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Books}/{action=Index}/{id?}");
//app.MapRazorPages();

//app.Run();



using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;
using bookshop.Models;
using bookshop.Data;
using bookshop.Areas.Identity.Data;
using bookshop.Interfaces;

namespace bookshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BookshopContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("bookshopContext") ?? throw new InvalidOperationException("Connection string 'WorkshopImprovedContext' not found.")));

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            builder.Services.AddRazorPages();
            builder.Services.AddIdentity<bookshopUser, IdentityRole>().AddEntityFrameworkStores<BookshopContext>().AddDefaultUI().AddDefaultTokenProviders();
            builder.Services.AddHttpContextAccessor();

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
            });

            //Password Strength Setting
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;
                // User settings
                options.User.RequireUniqueEmail = true;
            });
            //Setting the Account Login page
            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            builder.Services.AddTransient<IBufferedFileUploadService, BufferedFileUploadLocalService>();
            
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initialize(services);
                // SeedData.CreateRolesAndAdminUser(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Books}/{action=Index}/{id?}");

            app.MapRazorPages();
            app.Run();
        }
    }
}