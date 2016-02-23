namespace OrderList.Factory
{
    using OrderList.Model;
    using System.Collections.Generic;

    public interface IOrder
    {
        IEnumerable<T> Order<T>(IEnumerable<T> list, string field);
        IEnumerable<T> ThenByOrder<T>(IEnumerable<T> list, string field);
    }
}
