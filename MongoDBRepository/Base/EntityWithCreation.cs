namespace MongoDBCore.Base;
public class EntityWithCreation : Entity, IHaveCreatedTime
{
    public DateTime? CreatedTime { get; set; }
}