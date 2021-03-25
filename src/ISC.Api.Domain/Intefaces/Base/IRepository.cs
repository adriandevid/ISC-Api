using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Api.Domain.Intefaces.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);
        void Delete(long id);
        IQueryable<TEntity> Get();
        Task<TEntity> GetByIdAsync(long id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
