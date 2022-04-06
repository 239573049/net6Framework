namespace Token.Core.Base
{
    public interface IModified : IModifiedTime
    {
        Guid? ModifiedId { get; set; }
    }
    public  interface IModifiedTime
    {
        DateTime? ModifiedTime { get; set; }
    }
}
