using Microsoft.EntityFrameworkCore;
using TodoList.DAL.Configurations;
using TodoList.Domain;

namespace TodoList.DAL;

public class AppDbContext : DbContext
{
    public DbSet<Assignment> Assignments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AssignmentConfiguration());

        base.OnModelCreating(modelBuilder);
        base.Database.Migrate();
    }
}

// public class MyDbContext : DbContext, IAppDbContext
// {
//     public IQueryable<Assignment> Assignments { get; set; }
// }