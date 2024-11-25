using System.ComponentModel.DataAnnotations;

namespace M295_TodoServiceAndAutomapper.Models;

public class TodoItem
{
    public long Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(250)]
    public string Description { get; set; }

    public long StatusId { get; set; }
    public TodoStatus Status { get; set; }
    public long PriorityId { get; set; }
    public TodoPriority Priority { get; set; }

    public string? Secret { get; set; }
}