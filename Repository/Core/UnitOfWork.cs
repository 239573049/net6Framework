using Core.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repository.Core
{
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException($"db context nameof{nameof(dbContext)} is null");
        }

        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            ApplyChangeConventions();
            try
            {
                _dbContext.SaveChanges();
                _dbContext.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                _dbContext.Database.RollbackTransaction();
                throw ex;
            }
        }

        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public async Task<int> SaveChangesAsync()
        {
            ApplyChangeConventions();
            return await _dbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            ApplyChangeConventions();
            return _dbContext.SaveChanges();
        }

        protected void ApplyChangeConventions()
        {
            _dbContext.ChangeTracker.DetectChanges();
            var entities = _dbContext.ChangeTracker.Entries().ToList();
            foreach (var entry in entities)
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        SetDelete(entry);
                        break;

                    case EntityState.Modified:
                        break;

                    case EntityState.Added:
                        SetCreation(entry.Entity);
                        break;

                    default:
                        break;
                }
            }
        }

        private void SetCreation(object entityObj)
        {
            if (entityObj is not IHaveCreatedTime)
            {
                return;
            }
            var entity = (IHaveCreatedTime)entityObj;
            entity.CreatedTime = DateTime.Now;
        }

        private void SetDelete(EntityEntry entry)
        {
            var entityObj = entry.Entity;
            if (entityObj is not ISoftDelete)
            {
                return;
            }

            var entity = (ISoftDelete)entityObj;
            entity.IsDeleted = true;
            entity.DeletedTime = DateTime.Now;
        }
    }
}
