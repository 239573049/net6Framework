using AutoMapper;
using Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Core;
using Repository.Repositorys;
using Service.Dto;
using Util;

namespace Service.Services
{
    public interface IUserService
    {
        Task<Guid> CreateUser(UserDto user);
        Task<List<UserDto>> GetAllUsers(string name);
        Task<UserDto> GetUserDto(string user);
    }
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IMapper _mapper;
        public UserService
            (
            IMapper mapper,
            IUnitOfWork<MasterDbContext> unitOfWork, 
            IMasterDbRepositoryBase<User> currentRepository) 
            : base(unitOfWork, currentRepository)
        {
            _mapper = mapper;
        }

        public async Task<Guid> CreateUser(UserDto user)
        {
            var data=_mapper.Map<User>(user);   
            data=await currentRepository.AddAsync(data);
            await unitOfWork.SaveChangesAsync();
            return data.Id;
        }

        public async Task<List<UserDto>> GetAllUsers(string name)
        {
            var data=await currentRepository.FindAll(a=>string.IsNullOrEmpty(name)||a.Name.ToLower().Contains(name.ToLower())).ToListAsync();
            return _mapper.Map<List<UserDto>>(data);
        }

        public async Task<UserDto> GetUserDto(string user)
        {
            var data=await currentRepository.FirstOrDefaultAsync(a=>a.AccountCode== user);
            if (data == null) throw new BusinessLogicException("账号或者密码错误");
            return _mapper.Map<UserDto>(data);
        }
    }
}
