using Token.Core.Base;

namespace Token.Core.Entitys.Roles
{
    public class UserRole: EntityWithAll
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid  UserId { get; set; } 
        /// <summary>
        /// 角色id
        /// </summary>
        public Guid  RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
