namespace Token.Application.Dto.Roles
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Remark { get; set; }
        public long Index { get; set; }
    }
}
