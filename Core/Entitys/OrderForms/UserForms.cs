using Core.Base;

namespace Core.Entitys.OrderForms
{
    /// <summary>
    /// 订单任务
    /// </summary>
    public class UserForms: EntityWithAll
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string? ContactWay { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string? DetailedAddress { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
        /// <summary>
        /// 接单人
        /// </summary>
        public Guid? OrderId { get; set; }
        /// <summary>
        /// 接单时间
        /// </summary>
        public DateTime? OrderTime { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public decimal? OriginalPrice { get; set; }
        /// <summary>
        /// 审核
        /// </summary>
        public AuditEnum Audit { get; set; } = AuditEnum.ToAaudit;
        /// <summary>
        /// 未通过原因
        /// </summary>
        public string? NotAuditCause { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public UserFormStatusEnum UserFormStatus { get; set; } = UserFormStatusEnum.Await;
        /// <summary>
        /// 通过时间
        /// </summary>
        public DateTime? AuditTime{ get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public Guid? AuditId { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public Guid FormTypeId { get; set; }
        /// <summary>
        /// 接单人评价
        /// </summary>
        public string? OrderEvaluate { get; set; }
        /// <summary>
        /// 发起人评价
        /// </summary>
        public string? SponsorEvaluate { get; set; }
        public FormType? FormType { get; set; }
        public User? Order { get; set; }
        public List<AccessNumberForm> AccessNumber { get; set; } = new List<AccessNumberForm>();
    }
}
