namespace OrderList.Exension
{
    using Factory;
    using Model;
    using System.Collections.Generic;
    using System.Linq;

    public static class OrderByExtension
    {
        public static IEnumerable<T> CustomOrder<T>(this IEnumerable<T> list, List<FilterOrder> filters)
        {
            var orderInstance = OrderFactory.GetOrderInstance(filters.First().orderType);
            list = orderInstance.Order(list, filters.First().field);
            foreach (var item in filters.Skip(1))
            {
                orderInstance = OrderFactory.GetOrderInstance(item.orderType);
                list = orderInstance.ThenByOrder(list, item.field);
            }
            return list;           
        }
    }
}
