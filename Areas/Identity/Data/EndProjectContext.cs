using EndProject.Areas.Identity.Data;
using EndProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EndProject.Data;

public class EndProjectContext : IdentityDbContext<EndProjectUser>
{
    public EndProjectContext(DbContextOptions<EndProjectContext> options)
        : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }

    public DbSet<EngineType> EngineTypes { get; set; }

    public DbSet<Vehicle> Vehicles { get; set; }

}

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //    // Customize the ASP.NET Identity model and override the defaults if needed.
    //    // For example, you can rename the ASP.NET Identity table names and more.
    //    // Add your customizations after calling base.OnModelCreating(builder);
      
    //}

