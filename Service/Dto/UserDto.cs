using Core.Entitys;

namespace Service.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string? AccountCode { get; set; }
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
        public string? HeadPortrait { get; set; }
    }
}
