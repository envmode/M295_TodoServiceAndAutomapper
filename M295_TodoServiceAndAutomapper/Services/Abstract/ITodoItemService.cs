using M295_TodoServiceAndAutomapper.Models;
using M295_TodoServiceAndAutomapper.Models.DTO;

namespace M295_TodoServiceAndAutomapper.Services.Abstract
{
    public interface ITodoItemService : IGenericService<TodoItem, TodoItemDTO>
    {
       
    }
}