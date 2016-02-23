
namespace OrderList.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OrderList.Exension;

    public class OrderDesc : IOrder
    {
        public IEnumerable<T> Order<T>(IEnumerable<T> list, string field)
        {
            return list.OrderByDescending(x => ReflectionExtension.GetPropertyValue(x, field));
        }

        public IEnumerable<T> ThenByOrder<T>(IEnumerable<T> list, string field)
        {
            return ((IOrderedEnumerable<T>)list).ThenByDescending(x => ReflectionExtension.GetPropertyValue(x, field));
        }
    }
}
