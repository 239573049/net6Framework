using MongoDBCore.Entitys.Chat;

namespace MongoDBRepository.Repositorys.Chat
{
    public interface IChatLogRepository: IMasterDbRepositoryBase<Log>
    {
    }
    public class ChatLogRepository : MasterDbRepositoryBase<Log>
    {
        public ChatLogRepository(MongoDBContext context) : base(context)
        {
        }
    }
}
