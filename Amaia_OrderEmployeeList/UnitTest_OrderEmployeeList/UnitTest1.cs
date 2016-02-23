namespace UnitTest_OrderEmployeeList
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using ListOrderService.Models;
    using ListOrderService;
    using System.Linq;

    [TestClass]
    public class UnitTest1
    {
        private List<Employee> list;
        private Service service;

        [TestInitialize]
        public void Initializer()
        {
            this.list = new List<Employee>();

            list.Add(new Employee() {
                FirstName = "Jon",
                LastName = "Iriarte",
                Position = "Chofer",
                SeparationDate = DateTime.Parse("2016-12-31")
            });

            list.Add(new Employee()
            {
                FirstName = "Itsaso",
                LastName = "Arrieta",
                Position = "Ingeniera",
                SeparationDate = DateTime.Parse("2016-10-05")
            });

            list.Add(new Employee()
            {
                FirstName = "Julen",
                LastName = "Iraizoz",
                Position = "Escultor",
            });

            list.Add(new Employee()
            {
                FirstName = "Ainhoa",
                LastName = "Zubieta",
                Position = "Deportista",
                SeparationDate = DateTime.Parse("2015-12-09")
            });

            service = new Service();
        }

        [TestMethod]
        public void OrderedBy_FirstName()
        {
            var result = service.OrderList(list, x => x.FirstName);
            var expectedResult = list.OrderBy(x => x.FirstName);
            CompareList(result, expectedResult.ToList());
        }

        [TestMethod]
        public void OrderedBy_LastName()
        {
            var result = service.OrderList(list, x => x.LastName);
            var expectedResult = list.OrderBy(x => x.LastName);
            CompareList(result, expectedResult.ToList());
        }

        [TestMethod]
        public void OrderedBy_Position()
        {
            var result = service.OrderList(list, x => x.Position);
            var expectedResult = list.OrderBy(x => x.Position);
            CompareList(result, expectedResult.ToList());
        }

        [TestMethod]
        public void OrderedBy_SeparationDate()
        {
            var result = service.OrderList(list, x => x.SeparationDate);
            var expectedResult = list.OrderBy(x => x.SeparationDate);
            CompareList(result, expectedResult.ToList());
        }

        public void CompareList(List<Employee> result, List<Employee> expectedResult)
        {
            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result.ElementAt(i).LastName, expectedResult.ElementAt(i).LastName);
                Assert.AreEqual(result.ElementAt(i).LastName, expectedResult.ElementAt(i).LastName);
                Assert.AreEqual(result.ElementAt(i).Position, expectedResult.ElementAt(i).Position);
                Assert.AreEqual(result.ElementAt(i).SeparationDate, expectedResult.ElementAt(i).SeparationDate);
            }
        }
    }
}
