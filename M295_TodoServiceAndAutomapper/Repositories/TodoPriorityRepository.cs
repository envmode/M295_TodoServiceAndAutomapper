using M295_TodoServiceAndAutomapper.Models;
using M295_TodoServiceAndAutomapper.Repositories.Abstract;

namespace M295_TodoServiceAndAutomapper.Repositories
{
    public class TodoPriorityRepository : GenericRepository<TodoPriority>, ITodoPriorityRepository
    {
        public TodoPriorityRepository(TodoContext context) : base(context)
        {
        }
    }
}