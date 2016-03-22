using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Domain.Entities;

namespace HelloWorld.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> Data { get; }
    }
}
