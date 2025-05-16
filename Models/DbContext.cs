using Microsoft.EntityFrameworkCore;

namespace SavorSpace.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Comment> Comments {get; set;}
}