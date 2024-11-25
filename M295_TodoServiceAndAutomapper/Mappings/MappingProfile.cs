using AutoMapper;
using M295_TodoServiceAndAutomapper.Models;
using M295_TodoServiceAndAutomapper.Models.DTO;

namespace M295_TodoServiceAndAutomapper.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping von TodoStatus zu TodoStatusDTO
            CreateMap<TodoStatus, TodoStatusDTO>().ReverseMap(); 

            // Mapping von TodoPriority zu TodoPriorityDTO
            CreateMap<TodoPriority, TodoPriorityDTO>().ReverseMap(); 


            // Mapping von TodoItem zu TodoItemDTO
            CreateMap<TodoItem, TodoItemDTO>().ReverseMap()
                .ForMember(dest => dest.PriorityId, opt => opt.MapFrom(src => src.PriorityId))

            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId));


        }
    }
}