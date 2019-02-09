using AcoesDotNet.Dal.Daos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcoesDotNet.Repository.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private GenericDao<T> _dao = new GenericDao<T>();

        public Task DeleteAsync(object id)
        {
           return _dao.DeleteAsync(id);
        }

        public Task<IEnumerable<T>> GetAllAsyc(params Expression<Func<T, object>>[] includeProperties)
        {
            return _dao.GetAllAsyc(includeProperties);
        }

        public Task<T> GetById(object id, params Expression<Func<T, object>>[] includeProperties)
        {
            return _dao.GetById(id, includeProperties);
        }

        public Task InsertAsync(T entity)
        {
            return _dao.InsertAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            return _dao.UpdateAsync(entity);
        }
    }
}
