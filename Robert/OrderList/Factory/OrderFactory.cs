namespace OrderList.Factory
{
    using Model;

    public class OrderFactory
    {
        private OrderFactory() { }

        public static IOrder GetOrderInstance(OrderTypes orderType)
        {
            switch (orderType)
            {
                case OrderTypes.Asc:
                    return new OrderAsc();                                   
                default:
                    return new OrderDesc();                    
            }
        }
    }
}
