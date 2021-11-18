namespace Core.Base
{
    public class EntityWithCreation : Entity, IHaveCreatedTime
    {
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
