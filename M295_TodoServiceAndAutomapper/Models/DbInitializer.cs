using Microsoft.EntityFrameworkCore;

namespace M295_TodoServiceAndAutomapper.Models;

public class DbInitializer
{
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        this._modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        _modelBuilder.Entity<TodoStatus>().HasData(
            new TodoStatus() { Id = 1, Name = "Planned", Description = "Is planned to do" },
            new TodoStatus() { Id = 2, Name = "Doing", Description = "Doing right now" },
            new TodoStatus() { Id = 3, Name = "Done", Description = "Finished" });
        _modelBuilder.Entity<TodoPriority>().HasData(
            new TodoPriority() { Id = 1, Name = "High", Description = "Very important" },
            new TodoPriority() { Id = 2, Name = "Medium", Description = "Not very important" },
            new TodoPriority() { Id = 3, Name = "Low", Description = "Not important at all" });
        _modelBuilder.Entity<TodoItem>().HasData(
            new TodoItem() { Id = 1, Name = "Grocery Shopping", Description = "buy some food", PriorityId = 1, StatusId = 1 },
            new TodoItem() { Id = 2, Name = "Do the loundry", Description = "Wash all clothes", PriorityId = 2, StatusId = 3 },
            new TodoItem() { Id = 3, Name = "Take a Shower", Description = "-", PriorityId = 1, StatusId = 3 });
    }
}