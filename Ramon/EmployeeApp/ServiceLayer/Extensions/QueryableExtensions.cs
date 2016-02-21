﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> SortListBy<T>(this IQueryable<T> source, Expression<Func<T, string>> inclusion, ListSortDirection sortOrder)
        {
            var type = typeof(T);
            var sortProperty = ((MemberExpression)(inclusion.Body)).Member.Name;
            var property = type.GetProperty(sortProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var typeArguments = new Type[] { type, property.PropertyType };
            var methodName = sortOrder == ListSortDirection.Ascending ? "OrderBy" : "OrderByDescending";
            var resultExp = Expression.Call(typeof(Queryable), methodName, typeArguments, source.Expression, Expression.Quote(orderByExp));

            return source.Provider.CreateQuery<T>(resultExp);
        }

        public static IQueryable<T> SortListBy<T>(this IQueryable<T> source, Expression<Func<T, DateTime?>> inclusion, ListSortDirection sortOrder)
        {
            var type = typeof(T);
            var sortProperty = ((MemberExpression)(inclusion.Body)).Member.Name;
            var property = type.GetProperty(sortProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var typeArguments = new Type[] { type, property.PropertyType };
            var methodName = sortOrder == ListSortDirection.Ascending ? "OrderBy" : "OrderByDescending";
            var resultExp = Expression.Call(typeof(Queryable), methodName, typeArguments, source.Expression, Expression.Quote(orderByExp));

            return source.Provider.CreateQuery<T>(resultExp);
        }
    }

    public enum ListSortDirection
    {
        Ascending,
        Descending
    }
}
