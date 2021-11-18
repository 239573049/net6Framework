namespace Core.Base
{
    public class EntityWithSoftDelete : ISoftDelete
    {
        public bool IsDeleted { get ; set; }
        public DateTime? DeletedTime { get; set ; }
    }
}
