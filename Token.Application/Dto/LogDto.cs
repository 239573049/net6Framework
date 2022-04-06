using MongoDB.Bson;

namespace Token.Application.Dto
{
    public class LogDto
    {
        public ObjectId Id { get; set; }
        public DateTime? CreatedTime { get; set; }
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
