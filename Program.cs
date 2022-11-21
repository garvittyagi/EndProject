using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EndProject.Data;
using EndProject.Areas.Identity.Data;

namespace EndProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("EndProjectContextConnection") ?? throw new InvalidOperationException("Connection string 'EndProjectContextConnection' not found.");

                                    builder.Services.AddDbContext<EndProjectContext>(options =>
                options.UseSqlServer(connectionString));

                                                builder.Services.AddDefaultIdentity<EndProjectUser>()
                .AddEntityFrameworkStores<EndProjectContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
           app.MapRazorPages();
            app.Run();
        }
    }
}