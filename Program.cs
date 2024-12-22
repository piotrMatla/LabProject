using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LabProject.Areas.Identity.Data;
using LabProject.Models;
using System.Globalization;
namespace LabProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("LabProjectDbContextConnection") ?? throw new InvalidOperationException("Connection string 'LabProjectDbContextConnection' not found.");

            builder.Services.AddDbContext<LabProjectDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LabProjectDbContext>();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            

            builder.Services.AddTransient<UserRegistrationHandler>();
            builder.Services.AddScoped<UserRegistrationHandler>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

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

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
