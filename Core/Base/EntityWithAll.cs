namespace Core.Base
{
    public class EntityWithAll : Entity, ISoftDelete, IModified
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public Guid? ModifiedId { get ; set; }
        public DateTime? ModifiedTime { get; set; }
        public Guid? DeleteBy { get ; set ; }
    }
}
