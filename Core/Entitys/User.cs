using Core.Base;
using Core.Entitys.Roles;

namespace Core.Entitys
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User: EntityWithAll
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
        /// <summary>
        /// 冻结时间
        /// </summary>
        public DateTime? FreezeTime { get; set; }
        /// <summary>
        /// 个性签名
        /// </summary>
        public string? Signature { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string? ContactWay { get; set; }
        public UserRole? UserRole { get; set; }
    }
}
