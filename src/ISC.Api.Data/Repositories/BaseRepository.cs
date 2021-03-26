using ISC.Api.Domain.Entitys;
using ISC.Api.Domain.Entitys.Base;
using ISC.Api.Domain.Intefaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Api.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> _context;
        public BaseRepository(DbContext context)
        {
            _context = context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Delete(long id)
        {
            if (_context.FindAsync(id) != null)
            {
                _context.Remove(_context.FindAsync(id).Result);
            }
        }

        public IQueryable<TEntity> Get()
            => _context.AsQueryable();

        public async Task<TEntity> GetByIdAsync(long id)
            => await _context.FindAsync(id);

        public void Insert(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
