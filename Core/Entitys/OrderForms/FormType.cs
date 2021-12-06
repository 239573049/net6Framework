using Core.Base;

namespace Core.Entitys.OrderForms
{
    /// <summary>
    /// 类型
    /// </summary>
    public class FormType: EntityWithAll
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string? Picture { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string? BriefIntroduction { get; set; }
        /// <summary>
        /// 是否需要审核
        /// </summary>
        public bool IsAudit { get; set; }
    }
}
