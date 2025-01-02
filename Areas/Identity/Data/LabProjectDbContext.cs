using LabProject.Areas.Identity.Data;
using LabProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabProject.Areas.Identity.Data;

public class LabProjectDbContext : IdentityDbContext<ApplicationUser>
{
 //test
    public DbSet<Transaction> Transaction { get; set; }
    public DbSet<Category> Categories { get; set; }
//test>
    public LabProjectDbContext(DbContextOptions<LabProjectDbContext> options)
        : base(options)
    {
    }

    private class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
