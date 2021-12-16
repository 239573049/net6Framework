using Core.Base;
namespace Core.Entitys.Roles
{
    public class Role: EntityWithAll
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Remark { get; set; }
        public long Index { get; set; }
        public List<RoleFunction> RoleFunctions { get; set; } = new List<RoleFunction>();
    }
}
