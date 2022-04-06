
using MongoDBCore.Base;

namespace MongoDBCore.Entitys.Chat
{
    /// <summary>
    /// 聊天日志
    /// </summary>
    public class Log: EntityWithCreation
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string? Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Body { get; set; }
    }
}
