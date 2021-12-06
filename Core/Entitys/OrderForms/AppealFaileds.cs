using Core.Base;

namespace Core.Entitys.OrderForms
{
    /// <summary>
    /// 申述表
    /// </summary>
    public class AppealFaileds: EntityWithAll
    {
        /// <summary>
        /// 申述原因
        /// </summary>
        public string? Cause { get; set; }
        /// <summary>
        /// 申述状态
        /// </summary>
        public AppealEnum AppealStatus { get; set; }
        /// <summary>
        /// 申述处理人
        /// </summary>
        public Guid? AllegedlyDecidedId { get; set; }
        /// <summary>
        /// 申述处理完成时间
        /// </summary>
        public DateTime? ProcessingTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
        public User? AllegedlyDecided { get; set; }
    }
}
