using Core.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Entitys.OrderForms
{
    /// <summary>
    /// 订单浏览人
    /// </summary>
    [Index(nameof(UserFormsId))]
    public class AccessNumberForm: Entity
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public Guid UserFormsId { get; set; }
        /// <summary>
        /// 访问id
        /// </summary>
        public Guid UserId { get; set; }
        public UserForms? UserForms { get; set; }
        public User? User { get; set; }
    }
}
