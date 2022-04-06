namespace Token.Core.Base
{
    public class EntityWithSoftDelete : ISoftDelete
    {
        public bool IsDeleted { get ; set; }
        public DateTime? DeletedTime { get; set ; }
        public Guid? DeleteBy { get; set; }
    }
}
