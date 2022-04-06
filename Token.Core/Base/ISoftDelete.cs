namespace Token.Core.Base
{
    public interface ISoftDelete: IHaveDeleteTime
    {
        bool IsDeleted { get; set; }
    }

    public interface IHaveDeleteTime
    {
        DateTime? DeletedTime { get; set; }
        Guid? DeleteBy{ get; set; }
    }
}
