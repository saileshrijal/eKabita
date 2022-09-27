﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.Repsitories.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAllBy(Expression<Func<T, bool>> predicate);
        Task<T?> GetBy(Expression<Func<T, bool>> predicate);
        Task Create(T t);
        Task Delete(Guid id);
        void Edit(T t);
        Task<bool> CheckExistBy(Expression<Func<T, bool>> predicate);
        int TotalCount();
    }
}
