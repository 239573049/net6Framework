using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Token.Core.Base
{
    public abstract class Entity : Entity<Guid> { }

    [Index(nameof(Id))]
    public abstract class Entity<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }
    }
}
