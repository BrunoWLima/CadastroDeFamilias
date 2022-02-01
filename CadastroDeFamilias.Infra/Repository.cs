using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CadastroDeFamilias.Infra
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet { get; set; }

        private IQueryable<T> DefaultQuery { get; set; }

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
            DefaultQuery = DbSet.AsQueryable<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                DbSet.Add(entity);
            }
            catch (Exception ex)
            {
                throw ProcessException(ex);
            }
            return true;
        }

        public bool Add(IEnumerable<T> items)
        {
            try
            {
                DbSet.AddRange(items);
            }
            catch (Exception ex)
            {
                throw ProcessException(ex);
            }
            return true;
        }

        public void Attatch(T obj)
        {
            Context.Attach<T>(obj);
        }

        public void Attatch<TType>(TType obj) where TType : class
        {
            Context.Attach<TType>(obj);
        }

        public bool Delete(int Id)
        {
            return Delete(GetById(Id));
        }

        public bool Delete(T entity)
        {
            try
            {
                DbSet.Remove(entity);

            }
            catch (Exception ex)
            {
                throw ProcessException(ex);
            }
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            try
            {
                DbSet.RemoveRange(entities);
            }
            catch (Exception ex)
            {
                throw ProcessException(ex);
            }
            return true;
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return DefaultQuery;
            }
            catch (Exception ex)
            {
                throw ProcessException(ex);
            }
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> expression)
        {
            try
            {
                IQueryable<T> query = DefaultQuery.Where(expression);
                return query;
            }
            catch (Exception ex)
            {
                throw ProcessException(ex);
            }
        }

        public T GetById(int id, bool noTracking = false)
        {
            try
            {
                return GetQueryableById(id, noTracking).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ProcessException(ex);
            }
        }

        public IQueryable<T> GetQueryableById(int id, bool noTracking = false)
        {
            try
            {
                var parameterExpression = Expression.Parameter(typeof(T));
                var property = Expression.Property(parameterExpression, Context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault().PropertyInfo);
                var constant = Expression.Constant(id);
                var expression = Expression.Equal(property, constant);
                var lambda = Expression.Lambda<Func<T, bool>>(expression, parameterExpression);

                IQueryable<T> result;

                if (noTracking)
                    result = DefaultQuery.Where(lambda).AsNoTracking();
                else
                    result = DefaultQuery.Where(lambda);

                return result;
            }
            catch (Exception ex)
            {
                throw ProcessException(ex);
            }
        }

        public Exception ProcessException(Exception ex)
        {
            return ex;
        }

        public void SetAsModified(T obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
        }

        public bool Update(T entity)
        {
            try
            {
                DbSet.Update(entity);
            }
            catch (Exception ex)
            {
                throw ProcessException(ex);
            }
            return true;
        }

        public bool Update(IEnumerable<T> items)
        {
            try
            {
                DbSet.UpdateRange(items);
            }
            catch (Exception ex)
            {
                throw ProcessException(ex);
            }
            return true;
        }
    }
}
