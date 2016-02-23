namespace OrderListConsole
{
    using OrderList.DataLayer;
    using OrderList.Model;
    using System;
    using System.Linq;
    using OrderList.Exension;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var employeeList = new Employee().GetEmployeeList();
                var filterList = new List<FilterOrder>();
                filterList.Add(new FilterOrder() { field = "LastName", orderType = OrderTypes.Desc });
                var ienum = employeeList.CustomOrder(filterList);
                Console.WriteLine("ok"); 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}