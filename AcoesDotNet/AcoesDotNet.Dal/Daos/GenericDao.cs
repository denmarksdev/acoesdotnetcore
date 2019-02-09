using AcoesDotNet.Dal.Helpers;
using AcoesDotNet.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcoesDotNet.Dal.Daos
{
    public class GenericDao<TEntity> : IGenericDao<TEntity> where TEntity : class
    {
        protected DbContext _context;
        protected DbSet<TEntity> _dbSet;

        public GenericDao()
        {
            _context = new AcoesDataContext();
            _dbSet = _context.Set<TEntity>();
        }
               
        public async Task<IEnumerable<TEntity>> GetAllAsyc(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await SetIncludeProperties(includeProperties)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public Task<TEntity> GetById(object id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return SetIncludeProperties(includeProperties)
                     .AsNoTracking()
                     .SingleOrDefaultAsync(DataContextHelper.BuildLambdaForFindByKey<TEntity>(id));
        }

        public Task<TEntity> GetByExpression(
            Expression<Func<TEntity, bool>> predicate,
            string campoOrdenacao = nameof(BaseModel.Id),
            bool desc = false,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return SetIncludeProperties(includeProperties)
                     .AsNoTracking()
                     .OrderBy(campoOrdenacao, desc)
                     .FirstOrDefaultAsync(predicate);
        }


        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet
                     .AsNoTracking()
                     .AnyAsync(predicate);
        }


        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            _dbSet.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var info =  _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity).State = EntityState.Detached;
        }

        private IQueryable<TEntity> SetIncludeProperties(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> seed = _dbSet.AsNoTracking();
            return ((IEnumerable<Expression<Func<TEntity, object>>>)includeProperties)
                .Aggregate(seed, (current, includeProperty) =>
                               current.Include(includeProperty));
        }
    }
}
