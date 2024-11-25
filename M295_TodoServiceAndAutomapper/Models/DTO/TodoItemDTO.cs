using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace M295_TodoServiceAndAutomapper.Models.DTO;

public class TodoItemDTO
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Geben Sie bitte einen Todo-Namen an.")]
    [MaxLength(50, ErrorMessage = "Der Todo-Name darf nicht länger als 50 Zeichen sein.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Geben Sie bitte einen Todo-Beschreibung an.")]
    [MaxLength(250, ErrorMessage = "Der Todo-Name darf nicht länger als 250 Zeichen sein.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Geben Sie bitte einen Todo-Status an.")]
    public long StatusId { get; set; }

    [Required(ErrorMessage = "Geben Sie bitte eine Todo-Priorität an.")]
    public long PriorityId { get; set; }

}

public class TodoItemDTOValidator : AbstractValidator<TodoItemDTO>
{
    public TodoItemDTOValidator(TodoContext context)
    {
        this.RuleFor(tdi => tdi.StatusId)
            .Must(StatusId => context.TodoStatuses.Any(TodoStatus => TodoStatus.Id.Equals(StatusId)))
            .WithMessage("Der Todo-Status mit dem Namen {PropertyValue} existiert nicht.");

        this.RuleFor(tdi => tdi.PriorityId)
              .Must(PriorityId => context.TodoPriorities.Any(TodoPriority => TodoPriority.Id.Equals(PriorityId)))
              .WithMessage("Die Todo-Priorität mit dem Namen {PropertyValue} existiert nicht.");
    }
}