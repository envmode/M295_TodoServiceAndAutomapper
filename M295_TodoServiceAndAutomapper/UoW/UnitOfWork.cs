using M295_TodoServiceAndAutomapper.Models;
using M295_TodoServiceAndAutomapper.Repositories;
using M295_TodoServiceAndAutomapper.Repositories.Abstract;
using M295_TodoServiceAndAutomapper.UoW.Abstract;
using Microsoft.EntityFrameworkCore;

namespace M295_TodoServiceAndAutomapper.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _context;

        private ITodoItemRepository? _todoItemRepository;
        private ITodoPriorityRepository? _todoPriorityRepository;
        private ITodoStatusRepository? _todoStatusRepository;

        public UnitOfWork(TodoContext context)
        {
            _context = context;
        }

        public ITodoItemRepository TodoItemRepository =>
            _todoItemRepository ??= new TodoItemRepository(_context);

        public ITodoPriorityRepository TodoPriorityRepository =>
            _todoPriorityRepository ??= new TodoPriorityRepository(_context);

        public ITodoStatusRepository TodoStatusRepository =>
            _todoStatusRepository ??= new TodoStatusRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
