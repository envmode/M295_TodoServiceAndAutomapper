using System.ComponentModel.DataAnnotations;

namespace M295_TodoServiceAndAutomapper.Models.DTO;

public class TodoPriorityDTO
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Geben Sie bitte einen Namen für die Todo-Priorität an.")]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(100, ErrorMessage = "Die Beschreibung für die Todo-Beschreibung darf nicht länger als 100 Zeichen sein.")]
    public string Description { get; set; }
}