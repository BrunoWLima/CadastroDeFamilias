﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CadastroDeFamilias.Infra
{
    public interface IRepository<T> where T : class
    {
        Exception ProcessException(Exception ex);

        IQueryable<T> GetAll();

        IQueryable<T> GetBy(Expression<Func<T, bool>> expression);

        T GetById(int id, bool noTracking = false);

        IQueryable<T> GetQueryableById(int id, bool noTracking = false);

        bool Add(T entity);

        bool Add(IEnumerable<T> items);

        void Attatch(T obj);

        void Attatch<TType>(TType obj) where TType : class;

        bool Delete(T entity);

        bool Delete(IEnumerable<T> entities);

        bool Update(T entity);

        bool Update(IEnumerable<T> entity);

        void SetAsModified(T obj);
    }
}
