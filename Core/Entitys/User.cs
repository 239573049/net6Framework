using Core.Base;

namespace Core.Entitys
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User: EntityWithCreation
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string? AccountCode{ get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string? HeadPortrait  { get; set; }
    }
}
