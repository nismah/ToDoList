using AutoMapper;
using ToDoListApp.Data.Models;

namespace ToDoListApp.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Member, MemberViewModel>().ReverseMap();
        }
    }
}
