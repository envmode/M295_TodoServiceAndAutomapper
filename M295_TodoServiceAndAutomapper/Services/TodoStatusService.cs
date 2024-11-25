using AutoMapper;
using M295_TodoServiceAndAutomapper.Models;
using M295_TodoServiceAndAutomapper.Models.DTO;
using M295_TodoServiceAndAutomapper.Services.Abstract;
using M295_TodoServiceAndAutomapper.Repositories.Abstract;

namespace M295_TodoServiceAndAutomapper.Services
{
    public class TodoStatusService : GenericService<TodoStatus, TodoStatusDTO>, ITodoStatusService
    {
        public TodoStatusService(IGenericRepository<TodoStatus> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}