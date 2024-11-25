using M295_TodoServiceAndAutomapper.Models;
using M295_TodoServiceAndAutomapper.Repositories.Abstract;

namespace M295_TodoServiceAndAutomapper.Repositories
{
    public class TodoStatusRepository : GenericRepository<TodoStatus>, ITodoStatusRepository
    {
        public TodoStatusRepository(TodoContext context) : base(context)
        {
        }
    }
}