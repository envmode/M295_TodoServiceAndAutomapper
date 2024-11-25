using AutoMapper;
using M295_TodoServiceAndAutomapper.Models;
using M295_TodoServiceAndAutomapper.Models.DTO;
using M295_TodoServiceAndAutomapper.Repositories.Abstract;
using M295_TodoServiceAndAutomapper.Services.Abstract;

namespace M295_TodoServiceAndAutomapper.Services
{
    public class TodoItemService : GenericService<TodoItem, TodoItemDTO>, ITodoItemService
    {
        public TodoItemService(IGenericRepository<TodoItem> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}