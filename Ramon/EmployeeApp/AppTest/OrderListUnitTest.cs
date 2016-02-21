using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IServiceLayer;
using Moq;
using System.Collections.Generic;
using EmployeeWebService.Models;
using System.Linq;
using AppTest;

namespace App
{
    [TestClass]
    public class OrderListUnitTest
    {
        private static List<Employee> employeeList;
        private static Employee employeeA;
        private static Employee employeeB;
        private static Employee employeeC;

        [ClassInitialize]
        public static void Init(TestContext ctx)
        {
            employeeA = new Employee() { FirstName = "Manolo", LastName = "Manolete", Position = "Software Engineer", SeparationDate = new DateTime(2010, 4, 29, 10, 25, 00) };
            employeeB = new Employee() { FirstName = "Pepe", LastName = "Pepito", Position = "Assistant", SeparationDate = new DateTime(2010, 1, 29, 10, 25, 00) };
            employeeC = new Employee() { FirstName = "Aberroncho", LastName = "Fernandez", Position = "Designer", SeparationDate = new DateTime(2013, 4, 12, 10, 25, 00) };
            employeeList = new List<Employee>() {
                employeeA,
                employeeB,
                employeeC
            };
        }

        [TestMethod]
        public void OrderByNameAscendingTest()
        { 
            var expextedResult = new List<Employee>() { employeeC, employeeA, employeeB}.AsQueryable();

            var result = employeeList.AsQueryable().SortListBy(x => x.FirstName, ListSortDirection.Ascending);

            Assert.IsTrue(expextedResult.ToList().SequenceEqual(result.ToList(), new EmployeeListComparer()));
        }

        [TestMethod]
        public void OrderByNameDescendingTest()
        {
            var expextedResult = new List<Employee>() { employeeB, employeeA, employeeC }.AsQueryable();

            var result = employeeList.AsQueryable().SortListBy(x => x.FirstName, ListSortDirection.Descending);

            Assert.IsTrue(expextedResult.ToList().SequenceEqual(result.ToList(), new EmployeeListComparer()));
        }

        [TestMethod]
        public void OrderByLastNameAscendingTest()
        {
            var expextedResult = new List<Employee>() { employeeC, employeeA, employeeB }.AsQueryable();

            var result = employeeList.AsQueryable().SortListBy(x => x.LastName, ListSortDirection.Ascending);

            Assert.IsTrue(expextedResult.ToList().SequenceEqual(result.ToList(), new EmployeeListComparer()));
        }

        [TestMethod]
        public void OrderByLastNameDescendingTest()
        {
            var expextedResult = new List<Employee>() { employeeB, employeeA, employeeC }.AsQueryable();

            var result = employeeList.AsQueryable().SortListBy(x => x.LastName, ListSortDirection.Descending);

            Assert.IsTrue(expextedResult.ToList().SequenceEqual(result.ToList(), new EmployeeListComparer()));
        }

        [TestMethod]
        public void OrderByPositionAscendingTest()
        {
            var expextedResult = new List<Employee>() { employeeB, employeeC, employeeA }.AsQueryable();

            var result = employeeList.AsQueryable().SortListBy(x => x.Position, ListSortDirection.Ascending);

            Assert.IsTrue(expextedResult.ToList().SequenceEqual(result.ToList(), new EmployeeListComparer()));
        }

        [TestMethod]
        public void OrderByPositionDescendingTest()
        {
            var expextedResult = new List<Employee>() { employeeA, employeeC, employeeB }.AsQueryable();

            var result = employeeList.AsQueryable().SortListBy(x => x.Position, ListSortDirection.Descending);

            Assert.IsTrue(expextedResult.ToList().SequenceEqual(result.ToList(), new EmployeeListComparer()));
        }

        [TestMethod]
        public void OrderBySepartionDateAscendingTest()
        {
            var expextedResult = new List<Employee>() { employeeB, employeeA, employeeC }.AsQueryable();

            var result = employeeList.AsQueryable().SortListBy(x => x.SeparationDate, ListSortDirection.Ascending);

            Assert.IsTrue(expextedResult.ToList().SequenceEqual(result.ToList(), new EmployeeListComparer()));
        }

        [TestMethod]
        public void OrderBySepartionDateDescendingTest()
        {
            var expextedResult = new List<Employee>() { employeeC, employeeA, employeeB }.AsQueryable();

            var result = employeeList.AsQueryable().SortListBy(x => x.SeparationDate, ListSortDirection.Descending);

            Assert.IsTrue(expextedResult.ToList().SequenceEqual(result.ToList(), new EmployeeListComparer()));
        }
    }
}
