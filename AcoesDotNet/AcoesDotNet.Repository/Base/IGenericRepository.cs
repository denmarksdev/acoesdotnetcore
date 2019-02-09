﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcoesDotNet.Repository.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task DeleteAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsyc(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> GetById(object id, params Expression<Func<TEntity, object>>[] includeProperties);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
