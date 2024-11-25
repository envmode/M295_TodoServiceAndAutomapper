using M295_TodoServiceAndAutomapper.Repositories.Abstract;

namespace M295_TodoServiceAndAutomapper.UoW.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoItemRepository TodoItemRepository { get; }
        ITodoPriorityRepository TodoPriorityRepository { get; }
        ITodoStatusRepository TodoStatusRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
