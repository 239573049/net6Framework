using AutoMapper;
using Core.Entitys;
using Core.Entitys.Roles;
using MongoDBCore.Entitys.Chat;
using Service.Dto;
using Service.Dto.Roles;

namespace Service
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(a=>a.RoleFunctions,l=>l.MapFrom(a=>a.UserRole!.Role!.RoleFunctions));
            CreateMap<UserDto,User>();
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleDto, UserRole>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<RoleFunction, RoleFunctionDto>();
            CreateMap<RoleFunctionDto, RoleFunction>();
            CreateMap<LogDto, Log>().ReverseMap();
        }
    }
}
