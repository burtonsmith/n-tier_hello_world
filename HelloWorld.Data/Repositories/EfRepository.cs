using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using HelloWorld.Data.DbContext;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.Repositories;

namespace HelloWorld.Data.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly HelloWorldDataContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public EfRepository(HelloWorldDataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public TEntity Insert(TEntity entity)
        {
            if (entity == null)
                throw new NullReferenceException(nameof(entity));

            try
            {
                _dbSet.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ThrowValidationError(e);
            }

            return entity;
        }

        public void Update(TEntity entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ThrowValidationError(e);
            }
        }

        public void Delete(int id)
        {
            if(id == default(int))
                throw new ArgumentNullException(nameof(id));

            try
            {
                var entity = _dbSet.Find(id);
                _dbContext.Entry(entity).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public TEntity GetById(int id)
        {
            if(id == default(int))
                throw new ArgumentNullException(nameof(id));

            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> Data => _dbSet;

        #region Helper Methods
        public Exception ThrowValidationError(DbEntityValidationException ex)
        {
            var msg = String.Empty;

            foreach (var validationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    msg += String.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                }
            }

            throw new Exception(msg, ex);
        }
        #endregion
    }
}
