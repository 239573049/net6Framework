namespace Token.Application.Dto.Roles
{
    public class RoleFunctionDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public Guid RoleId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 路由
        /// </summary>
        public string? Route { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 上级id
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}
