using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace M295_TodoServiceAndAutomapper.Models;

/// <summary>
///   <br />
/// </summary>
/// TODO Edit XML Comment Template for TodoContext
public class TodoContext : IdentityDbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<TodoStatus> TodoStatuses { get; set; }
    public DbSet<TodoPriority> TodoPriorities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().Property(b => b.Description).IsRequired(false);
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }
}