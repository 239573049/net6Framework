namespace Token.Application.Dto.Roles
{
    public class UserRoleDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public Guid RoleId { get; set; }
        public RoleDto? Role { get; set; }
    }
}
