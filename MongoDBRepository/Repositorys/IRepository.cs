using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBCore.Base;
using System.Linq.Expressions;

namespace MongoDBRepository.Repositorys
{
    public interface IRepository<TDbContext, TEntity> where TEntity : Entity where TDbContext : MongoClient
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity);
        /// <summary>
        /// 添加多个
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddManyAsync(IList<TEntity> entities);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Delete(ObjectId entity);
        /// <summary>
        /// 删除多个
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task DeleteMany(IList<ObjectId> entities);
        /// <summary>
        /// 根据指定条件返回集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据条件获取单个
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<bool> IsExist(Expression<Func<TEntity, bool>> whereLambda);
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        Task<Tuple<IList<TEntity>, long>> GetPageAsync(Expression<Func<TEntity, bool>> whereCondition,
            Expression<Func<TEntity, object>> orderBy,
            int pageNo,
            int pageSize,
            bool isAsc);
        /// <summary>
        /// 分页查询指定字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="scalar"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="isAsc">true：升序；false：降序</param>
        /// <returns></returns>
        Task<Tuple<IList<T>, long>> GetFieldQuery<T>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, T>> scalar,
            Expression<Func<TEntity, object>> orderBy, int pageNo, int pageSize, bool isAsc = true);
    }
    public abstract class Repository<TDbContext, TEntity> : IRepository<TDbContext, TEntity>
        where TEntity : Entity
        where TDbContext : MongoClient
    {
        private readonly TDbContext Context;
        private readonly IMongoCollection<TEntity> DbSet;
        public Repository(TDbContext context)
        {
            Context=context;
            DbSet = context.GetDatabase(typeof(TEntity).Name).GetCollection<TEntity>(typeof(TEntity).Name);//创建类名称的库
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityObj = entity;
            if (entityObj is IHaveCreatedTime time)
            {
                time.CreatedTime = DateTime.Now;
            }
            await DbSet.InsertOneAsync(entityObj);
            return entityObj;
        }
        public virtual async  Task  AddManyAsync(IList<TEntity> entities)
        {
            await DbSet.InsertManyAsync(entities);
        }

        public async Task Delete(ObjectId entity)
        {
           await DbSet.DeleteOneAsync(a => a.Id == entity);
        }

        public async Task DeleteMany(IList<ObjectId> entities)
        {
            await DbSet.DeleteManyAsync(a => entities.Contains(a.Id));
        }

        public async Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
           return await DbSet.Find(predicate).ToListAsync() ;
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<Tuple<IList<T>, long>> GetFieldQuery<T>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, T>> scalar, Expression<Func<TEntity, object>> orderBy, int pageNo, int pageSize, bool isAsc = true)
        {
            var count = DbSet.CountDocumentsAsync(predicate);
            var entities = isAsc ? await DbSet.Find(predicate).SortBy(orderBy)
            .Skip((pageNo - 1) * pageSize)
            .Limit(pageSize)
            .Project(scalar)
            .ToListAsync() :
             await DbSet.Find(predicate).SortByDescending(orderBy)
            .Skip((pageNo - 1) * pageSize)
            .Limit(pageSize)
            .Project(scalar)
            .ToListAsync();
            return new Tuple<IList<T>, long>(entities, await count);
        }

        public async Task<Tuple<IList<TEntity>, long>> GetPageAsync(Expression<Func<TEntity, bool>> whereCondition, Expression<Func<TEntity, object>> orderBy, int pageNo, int pageSize, bool isAsc)
        {
            var count =  DbSet.CountDocumentsAsync(whereCondition);
            var entities = isAsc ?await DbSet.Find(whereCondition)
                .SortBy(orderBy)
                .Skip((pageNo - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync() :
                await DbSet.Find(whereCondition)
                .SortByDescending(orderBy)
                .Skip((pageNo - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();
            return new Tuple<IList<TEntity>, long>(entities, await count);
        }

        public async Task<bool> IsExist(Expression<Func<TEntity, bool>> whereLambda)
        {
            return await DbSet.Find(whereLambda).AnyAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await DbSet.ReplaceOneAsync(a=>a.Id==entity.Id,entity);
            return entity;  
        }
        public async Task UpdateMany(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await DbSet.ReplaceOneAsync(a => a.Id == entity.Id, entity);
            }
        }
    }
}
