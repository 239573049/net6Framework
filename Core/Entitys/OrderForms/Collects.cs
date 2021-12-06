using Core.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Entitys.OrderForms
{
    /// <summary>
    /// 收藏
    /// </summary>
    [Index(nameof(UserId),nameof(UserFormsId))]
    public class Collects:EntityWithAll
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public Guid UserFormsId { get; set; }
        public User? User { get; set; }
        public UserForms? UserForms { get; set; }
    }
}
