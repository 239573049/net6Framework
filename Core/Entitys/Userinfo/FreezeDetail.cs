using Core.Base;

namespace Core.Entitys.Userinfo
{
    /// <summary>
    /// 冻结金额详细
    /// </summary>
    public class FreezeDetail : EntityWithAll
    {
        /// <summary>
        /// 冻结金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 冻结原因
        /// </summary>
        public string? Cause { get; set; }
        /// <summary>
        /// 解冻时间
        /// </summary>
        public DateTime ThawingTime { get; set; }
        /// <summary>
        /// 冻结关联单据
        /// </summary>
        public Guid? FormId { get; set; }
        /// <summary>
        /// 冻结类型
        /// </summary>
        public FrozenTypeEnum FrozenType { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
