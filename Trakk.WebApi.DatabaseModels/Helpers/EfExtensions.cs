
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Trakk.WebApi.Models;

namespace Trakk.WebApi.DatabaseModels.Helpers
{
    public static class EfExtensions
    {
        public static IQueryable<TEntity> If<TEntity, TProperty>(
            this IQueryable<TEntity> source, bool condition, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, TProperty>> includeFunc)
            where TEntity : class =>
            condition ? includeFunc(source) : source;
        public static IQueryable<TEntity> If<TEntity>(
            this IQueryable<TEntity> source, bool condition, Func<IQueryable<TEntity>, IQueryable<TEntity>> queryFunc)
            where TEntity : class =>
            condition ? queryFunc(source) : source;
        
        public static IQueryable<TEntity> IfWhere<TEntity>(
            this IQueryable<TEntity> source, bool condition, Expression<Func<TEntity,bool>> queryFunc)
            where TEntity : class =>
            condition ? source.Where(queryFunc): source;

        public static IQueryable<TEntity> OrderQuery<TEntity, TProperty>(this IQueryable<TEntity> src,
            Enums.SortOrder sortOrder, Expression<Func<TEntity, TProperty>> propertySelector)
            => sortOrder switch
            {
                Enums.SortOrder.Descending => src.OrderByDescending(propertySelector),
                _ => src.OrderBy(propertySelector)
            };

    }
}
