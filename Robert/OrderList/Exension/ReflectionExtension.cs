
namespace OrderList.Exension
{
    using System;
    using System.Linq.Expressions;

    public static class ReflectionExtension
    {
        public static string GetPropertyName<T, TReturn>(this Expression<Func<T, TReturn>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            return body.Member.Name;
        }
        public static object GetPropertyValue(object obj, string name)
        {
            return obj == null ? null : obj.GetType().GetProperty(name).GetValue(obj, null);
        }

    }
}
