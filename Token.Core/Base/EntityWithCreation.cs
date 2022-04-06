namespace Token.Core.Base
{
    public class EntityWithCreation : Entity, IHaveCreated
    {
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
