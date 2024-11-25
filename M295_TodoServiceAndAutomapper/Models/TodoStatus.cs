using System.ComponentModel.DataAnnotations;

namespace M295_TodoServiceAndAutomapper.Models;

/// <summary>
///   <br />
/// </summary>
/// TODO Edit XML Comment Template for TodoStatus
public class TodoStatus
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// TODO Edit XML Comment Template for Id
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// TODO Edit XML Comment Template for Name
    [MaxLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// TODO Edit XML Comment Template for Description
    [MaxLength(250)]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the todo items.
    /// </summary>
    /// TODO Edit XML Comment Template for TodoItems
    public virtual ICollection<TodoItem> TodoItems { get; set; }
}