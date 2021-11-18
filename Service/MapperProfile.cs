using AutoMapper;
using Core.Entitys;
using Service.Dto;

namespace Service
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto,User>();
        }
    }
}
