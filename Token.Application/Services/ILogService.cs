using AutoMapper;
using MongoDB.Bson;
using MongoDBCore.Entitys.Chat;
using MongoDBRepository.Repositorys;
using Token.Application.Dto;

namespace Token.Application.Services
{
    public interface ILogService
    {
        /// <summary>
        /// 创建日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        Task<ObjectId> CreateLog(LogDto log);
    }
    public class LogService : MasterDbRepositoryBase<Log>, ILogService
    {
        private readonly IMapper _mapper;
        public LogService(
            IMapper mapper,
            MongoDBContext context) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ObjectId> CreateLog(LogDto log)
        {
            var data= _mapper.Map<Log>(log);
            data =await AddAsync(data);
            return data.Id;
        }
    }
}
