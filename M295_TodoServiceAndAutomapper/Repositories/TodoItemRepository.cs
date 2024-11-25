using M295_TodoServiceAndAutomapper.Models;
using M295_TodoServiceAndAutomapper.Repositories.Abstract;

namespace M295_TodoServiceAndAutomapper.Repositories
{
    public class TodoItemRepository : GenericRepository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(TodoContext context) : base(context)
        {
        }
    }
}