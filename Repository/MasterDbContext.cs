global using Microsoft.EntityFrameworkCore;
using Core.Base;
using System.Linq.Expressions;
using System.Reflection;

namespace Repository
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new TaggedQueryCommandInterceptor());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))//判断是否继承了软删除类
                {//软删除的操作逻辑
                    modelBuilder.Entity(entityType.ClrType).Property<bool>("IsDeleted");
                    var parameter = Expression.Parameter(entityType.ClrType, "del");
                    var body = Expression.Equal(
                        Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(bool) }, parameter, Expression.Constant("IsDeleted")),
                    Expression.Constant(false));
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
                }
            }
        }
    }

}