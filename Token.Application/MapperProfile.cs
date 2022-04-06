using AutoMapper;
using MongoDBCore.Entitys.Chat;
using Token.Application.Dto;
using Token.Application.Dto.Roles;
using Token.Core.Entitys;
using Token.Core.Entitys.Roles;

namespace Token.Application
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
