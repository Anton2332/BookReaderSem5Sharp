using System.Linq;
using System.Linq.Expressions;

using DAL2.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Helpers;

public static class Linq
{
    public static async Task<Page<T>> ToPagedAsync<T>(this IQueryable<T> src,
        QueryStringParameters queryStringParameters) where T : class
    {
        var queryExpression = src.Expression;
        queryExpression = queryExpression.OrderBy(queryStringParameters.OrderBy);

        if (queryExpression.CanReduce)
            queryExpression = queryExpression.Reduce();

        src = src.Provider.CreateQuery<T>(queryExpression);

        var skip = (queryStringParameters.PageNumber - 1) * queryStringParameters.PageSize;

        var results = new Page<T>
        {
            TotalItemCount = await src.CountAsync(),
            
            Items = await src.Skip(skip).Take(queryStringParameters.PageSize).ToListAsync()
        };

        return results;
    }
    
    private static Expression OrderBy(this Expression source, string orderBy)
    {
        if (!string.IsNullOrWhiteSpace(orderBy))
        {
            var orderBys = orderBy.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < orderBys.Length; i++)
            {
                source = AddOrderBy(source, orderBys[i], i);
            }
        }

        return source;
    }
    
    private static Expression AddOrderBy(Expression source, string orderBy, int index)
    {
        var orderByParams = orderBy.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string orderByMethodName = index == 0 ? "OrderBy" : "ThenBy";
        string parameterPath = orderByParams[0];
        if (orderByParams.Length > 1 && orderByParams[1].Equals("desc", StringComparison.OrdinalIgnoreCase))
            orderByMethodName += "Descending";

        var sourceType = source.Type.GetGenericArguments().First();
        var parameterExpression = Expression.Parameter(sourceType, "p");
        var orderByExpression = BuildPropertyPathExpression(parameterExpression, parameterPath);
        var orderByFuncType = typeof(Func<,>).MakeGenericType(sourceType, orderByExpression.Type);
        var orderByLambda = Expression.Lambda(orderByFuncType, orderByExpression, new ParameterExpression[] { parameterExpression });

        source = Expression.Call(typeof(Queryable), orderByMethodName, new Type[] { sourceType, orderByExpression.Type }, source, orderByLambda);
        return source;
    }
    
    private static Expression BuildPropertyPathExpression(this Expression rootExpression, string propertyPath)
    {
        var parts = propertyPath.Split(new[] { '.' }, 2);
        var currentProperty = parts[0];
        var propertyDescription = rootExpression.Type.GetProperty(currentProperty, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        if (propertyDescription == null)
            throw new KeyNotFoundException($"Cannot find property {rootExpression.Type.Name}.{currentProperty}. The root expression is {rootExpression} and the full path would be {propertyPath}.");

        var propExpr = Expression.Property(rootExpression, propertyDescription);
        if (parts.Length > 1)
            return BuildPropertyPathExpression(propExpr, parts[1]);

        return propExpr;
    }

    public static IOrderedQueryable<T> Order<T>(this IQueryable<T> source, string orderBy)
    {
        var orderBys = orderBy.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        try
        {
            return orderBys[1].ToLower() == "desc"
                ? source.OrderByDescending(orderBys[0])
                : source.OrderBy(orderBys[0]);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
    {
        return source.OrderBy(ToLambda<T>(propertyName));
    }

    public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
    {
        return source.OrderByDescending(ToLambda<T>(propertyName));
    }

    private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
    {
        var parameter = Expression.Parameter(typeof(T));
        var property = Expression.Property(parameter, propertyName);
        var propAsObject = Expression.Convert(property, typeof(object));

        return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
    }

}