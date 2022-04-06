namespace Token.Core.Base
{
    public interface IHaveCreated:IHaveCreatedTime
    {
        public Guid? CreatedBy { get; set; }
    }

    public interface IHaveCreatedTime
    {
        DateTime? CreatedTime { get; set; }
    }
}
