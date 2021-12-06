using Core.Base;

namespace Core.Entitys.Userinfo
{
    /// <summary>
    /// 用户财产
    /// </summary>
    public class UserProperty: EntityWithAll
    {
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 押金
        /// </summary>
        public decimal CashPledge { get; set; }
        /// <summary>
        /// 可用金额
        /// </summary>
        public decimal Usable { get; set; }
        /// <summary>
        /// 冻结金额
        /// </summary>
        public decimal? FreezeMoney { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
