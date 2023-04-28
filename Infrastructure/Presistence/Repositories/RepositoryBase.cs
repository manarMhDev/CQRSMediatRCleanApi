﻿using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
      where T : class
    {
        protected ApplicationDbContext _applicationDbContext;

        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Delete(T entity)
        {
            _applicationDbContext.Set<T>().Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _applicationDbContext.Set<T>().Find(id);
        }

        public async Task<T> Insert(T entity)
        {
            var result = _applicationDbContext.Set<T>().Add(entity);
            await _applicationDbContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task UpdateEntity(T entity)
        {
            if (entity != null)
            {
                _applicationDbContext.Entry(entity).State = EntityState.Modified;
                await _applicationDbContext.SaveChangesAsync();
            }
         
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate = null, string include = null)
        {

            IQueryable<T> query;
                if (predicate == null)
                {
                    query = _applicationDbContext.Set<T>();
                }
                else
                {
                    query = _applicationDbContext.Set<T>().Where(predicate);
                }
            
            if (include != null)
            {
                foreach (var tbl in include.Split(','))
                {
                    query = query.Include(tbl);
                }
            }
            return  query.AsNoTracking();
          
        }

        private static Expression<Func<T, bool>> BuildPredicate<T>(string propertyName, string comparison, string value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var left = propertyName.Split('.').Aggregate((Expression)parameter, Expression.Property);
            var body = MakeComparison(left, comparison, value);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
        private static Expression MakeComparison(Expression left, string comparison, string value)
        {
            switch (comparison)
            {
                case "==":
                    return MakeBinary(ExpressionType.Equal, left, value);
                case "!=":
                    return MakeBinary(ExpressionType.NotEqual, left, value);
                case ">":
                    return MakeBinary(ExpressionType.GreaterThan, left, value);
                case ">=":
                    return MakeBinary(ExpressionType.GreaterThanOrEqual, left, value);
                case "<":
                    return MakeBinary(ExpressionType.LessThan, left, value);
                case "<=":
                    return MakeBinary(ExpressionType.LessThanOrEqual, left, value);
                case "Contains":
                case "StartsWith":
                case "EndsWith":
                    return Expression.Call(MakeString(left), comparison, Type.EmptyTypes, Expression.Constant(value, typeof(string)));
                default:
                    throw new NotSupportedException($"Invalid comparison operator '{comparison}'.");
            }
        }

        private static Expression MakeString(Expression source)
        {
            return source.Type == typeof(string) ? source : Expression.Call(source, "ToString", Type.EmptyTypes);
        }

        private static Expression MakeBinary(ExpressionType type, Expression left, string value)
        {
            object typedValue = value;
            if (left.Type != typeof(string))
            {
                if (string.IsNullOrEmpty(value))
                {
                    typedValue = null;
                    if (Nullable.GetUnderlyingType(left.Type) == null)
                        left = Expression.Convert(left, typeof(Nullable<>).MakeGenericType(left.Type));
                }
                else
                {
                    var valueType = Nullable.GetUnderlyingType(left.Type) ?? left.Type;
                    typedValue = valueType.IsEnum ? Enum.Parse(valueType, value) :
                        valueType == typeof(Guid) ? Guid.Parse(value) :
                        Convert.ChangeType(value, valueType);
                }
            }
            var right = Expression.Constant(typedValue, left.Type);
            return Expression.MakeBinary(type, left, right);
        }

    }
}
