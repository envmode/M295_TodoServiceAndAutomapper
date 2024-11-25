using AutoMapper;
using M295_TodoServiceAndAutomapper.Models;
using M295_TodoServiceAndAutomapper.Models.DTO;
using M295_TodoServiceAndAutomapper.Repositories.Abstract;
using M295_TodoServiceAndAutomapper.Services.Abstract;

namespace M295_TodoServiceAndAutomapper.Services
{
    public class TodoPriorityService : GenericService<TodoPriority, TodoPriorityDTO>, ITodoPriorityService
    {
        public TodoPriorityService(IGenericRepository<TodoPriority> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}