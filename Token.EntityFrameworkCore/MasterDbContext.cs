global using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using Token.Core.Base;
using Token.Core.Entitys;
using Token.Core.Entitys.Roles;
using Token.Infrastructure;

namespace Token.EntityFrameworkCore
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

            #region 数据库默认参数
            var adminId = Guid.NewGuid();
                        var roleId= Guid.NewGuid();
                        modelBuilder.Entity<User>()
                            .HasData(new User {Id= adminId, AccountCode="admin",Password="Aa123456".MD5Encrypt(),HeadPortrait= "https://ts1.cn.mm.bing.net/th?id=OIP-C.79smi7hB-2AHPbroJr8rnwAAAA&w=204&h=204&c=8&rs=1&qlt=90&o=6&pid=3.1&rm=2",ContactWay="239573049@qq.com",IsDeleted=false,Name="管理员"});
                        modelBuilder.Entity<Role>()
                            .HasData(new Role { Id = roleId, Code = "admin", Name = "管理员", Index = 0, Remark = "超级牛皮的权限管理员", IsDeleted = false });
                        modelBuilder.Entity<UserRole>()
                            .HasData(new UserRole { Id = Guid.NewGuid(),RoleId= roleId, UserId=adminId });
                        var roleFunctions = new List<RoleFunction>();
                        var i = 0;
                        foreach (var d in RouteReflection.GetPathAll())
                        {
                            var roleFunction=new RoleFunction()
                            {
                                Id=Guid.NewGuid(),
                                Index= i++,
                                ParentId=null,
                                Title=d.Description,
                                RoleId=roleId,
                                Route=d.Path,
                                IsDeleted=false
                            };
                            var s = 0;
                            foreach (var a in d.Children)
                            {
                                var children = new RoleFunction()
                                {
                                    Id = Guid.NewGuid(),
                                    Index = s++,
                                    ParentId = roleFunction.Id,
                                    Title = d.Description,
                                    RoleId = roleId,
                                    Route = a.Path,
                                    IsDeleted = false
                                };
                                roleFunctions.Add(children);
                            }
                            roleFunctions.Add(roleFunction);
                        }
                        modelBuilder.Entity<RoleFunction>().HasData(roleFunctions);
            #endregion
            
        }
    }

}