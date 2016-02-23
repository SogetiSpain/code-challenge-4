
namespace OrderListTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OrderList.Exension;
    using OrderList.Model;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class Test
    {
        private List<Employee> employeeList;
        private List<FilterOrder> filterOrderList;

        [TestInitialize]
        public void TestInitialize()
        {
            //Se debería crear una Interface que llame al servicio y hacer un mock.
            this.employeeList = new Employee().GetEmployeeList();
            this.filterOrderList = new List<FilterOrder>();
        }

        [TestMethod]
        public void LastNameAsc()
        {
            var orderlistOrigin = this.employeeList.OrderBy(x => x.LastName).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.LastName), orderType = OrderTypes.Asc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

        [TestMethod]
        public void LastNameDesc()
        {
            var orderlistOrigin = this.employeeList.OrderByDescending(x => x.LastName).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.LastName), orderType = OrderTypes.Desc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

        [TestMethod]
        public void NameAsc()
        {
            var orderlistOrigin = this.employeeList.OrderBy(x => x.FirstName).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.FirstName), orderType = OrderTypes.Asc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

        [TestMethod]
        public void NameDesc()
        {
            var orderlistOrigin = this.employeeList.OrderByDescending(x => x.FirstName).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.FirstName), orderType = OrderTypes.Desc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

        [TestMethod]
        public void PositionAsc()
        {
            var orderlistOrigin = this.employeeList.OrderBy(x => x.Position).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.Position), orderType = OrderTypes.Asc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

        [TestMethod]
        public void PositionDesc()
        {
            var orderlistOrigin = this.employeeList.OrderByDescending(x => x.Position).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.Position), orderType = OrderTypes.Desc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

        [TestMethod]
        public void SeparationAsc()
        {
            var orderlistOrigin = this.employeeList.OrderBy(x => x.SeparationDate).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.SeparationDate), orderType = OrderTypes.Asc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

        [TestMethod]
        public void SeparationDesc()
        {
            var orderlistOrigin = this.employeeList.OrderByDescending(x => x.SeparationDate).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.SeparationDate), orderType = OrderTypes.Desc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

        [TestMethod]
        public void OrderByNameAndLastNameAsc()
        {
            var orderlistOrigin = this.employeeList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.FirstName), orderType = OrderTypes.Asc });
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.LastName), orderType = OrderTypes.Asc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

        [TestMethod]
        public void OrderByNameAndLastNameDesc()
        {
            var orderlistOrigin = this.employeeList.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.FirstName), orderType = OrderTypes.Desc });
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.LastName), orderType = OrderTypes.Desc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

        [TestMethod]
        public void OrderByNameAscAndLastNameDesc()
        {
            var orderlistOrigin = this.employeeList.OrderBy(x => x.FirstName).ThenByDescending(x => x.LastName).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.FirstName), orderType = OrderTypes.Asc });
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.LastName), orderType = OrderTypes.Desc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }
       
        [TestMethod]
        public void OrderByAllAsc()
        {
            var orderlistOrigin = this.employeeList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ThenBy(x => x.Position).ThenBy(x => x.SeparationDate).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.FirstName), orderType = OrderTypes.Asc });
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.LastName), orderType = OrderTypes.Asc });
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.Position), orderType = OrderTypes.Asc });
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.SeparationDate), orderType = OrderTypes.Asc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

        [TestMethod]
        public void OrderByAllDesc()
        {
            var orderlistOrigin = this.employeeList.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName).ThenByDescending(x => x.Position).ThenByDescending(x => x.SeparationDate).ToList();
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.FirstName), orderType = OrderTypes.Desc });
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.LastName), orderType = OrderTypes.Desc });
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.Position), orderType = OrderTypes.Desc });
            this.filterOrderList.Add(new FilterOrder() { field = ReflectionExtension.GetPropertyName((Employee x) => x.SeparationDate), orderType = OrderTypes.Desc });
            this.employeeList = this.employeeList.CustomOrder(this.filterOrderList).ToList();
            CollectionAssert.AreEqual(orderlistOrigin, employeeList);
        }

    }
}
