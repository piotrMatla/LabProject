using LabProject.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }

public DbSet<LabProject.Models.Transaction> Transaction { get; set; } = default!;

}