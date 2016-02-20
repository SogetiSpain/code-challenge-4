using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeService.Implementations;
using System.Linq;
using DataLayer.Interfaces;
using Moq;
using System.Collections.Generic;
using Entities;

namespace Tests
{
    [TestClass]
    public class ServiceTests
    {
        List<Employee> oneEmployeeList;
        List<Employee> twoEmployeeList;
        List<Employee> threeEmployeeList;

        public ServiceTests()
        {
            MakeSampleEmployeeLists();

        }



        [TestMethod]
        public void Service_OrderByDefault_Empty_ReturnsEmptyList()
        {
            var dataProvider = new Mock<IEmployeeData>();

            var svc = new EmployeeOrderingService(dataProvider.Object);
            var result = svc.OrderByDefault();

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Service_OrderByDefault_OneEmployee_ReturnsOneResultOnly()
        {
            var dataProvider = new Mock<IEmployeeData>();
            dataProvider.Setup(x => x.GetEmployees())
                .Returns(oneEmployeeList);

            var svc = new EmployeeOrderingService(dataProvider.Object);
            var result = svc.OrderByDefault();

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("John", result.ElementAt(0).FirstName);
        }

        [TestMethod]
        public void Service_OrderByDefault_TwoEmployees_ReturnsOrderedByLastName()
        {
            var dataProvider = new Mock<IEmployeeData>();
            dataProvider.Setup(x => x.GetEmployees())
                .Returns(twoEmployeeList);

            var svc = new EmployeeOrderingService(dataProvider.Object);
            var result = svc.OrderByDefault();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Jacquelyn", result.ElementAt(0).FirstName);
            Assert.AreEqual("John", result.ElementAt(1).FirstName);
        }

        [TestMethod]
        public void Service_OrderByCustomPosition_TwoEmployees_ReturnsOrderedByPosition()
        {
            var dataProvider = new Mock<IEmployeeData>();
            dataProvider.Setup(x => x.GetEmployees())
                .Returns(twoEmployeeList);

            var svc = new EmployeeOrderingService(dataProvider.Object);
            var result = svc.OrderBy(x=>x.Position);

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("DBA", result.ElementAt(0).Position);
            Assert.AreEqual("Manager", result.ElementAt(1).Position);
        }

        [TestMethod]
        public void Service_OrderByCustomDate_ThreeEmployees_ReturnsOrderedByDate()
        {
            var dataProvider = new Mock<IEmployeeData>();
            dataProvider.Setup(x => x.GetEmployees())
                .Returns(threeEmployeeList);

            var svc = new EmployeeOrderingService(dataProvider.Object);
            var result = svc.OrderBy(x => x.Position);

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Jacquelyn", result.ElementAt(0).FirstName);
            Assert.AreEqual("Michaela", result.ElementAt(1).FirstName);
        }

        private void MakeSampleEmployeeLists()
        {
            this.oneEmployeeList = new List<Employee>();
            this.oneEmployeeList.Add(new Employee()
            {
                FirstName = "John",
                LastName = "Johnson",
                Position = "Manager",
                SeparationDate = new DateTime(2016,12,31)
            });
            
            this.twoEmployeeList = new List<Employee>();
            this.twoEmployeeList.Add(new Employee()
            {
                FirstName = "John",
                LastName = "Johnson",
                Position = "Manager",
                SeparationDate = new DateTime(2016, 12, 31)
            });
            this.twoEmployeeList.Add(new Employee()
            {
                FirstName = "Jacquelyn",
                LastName = "Jackson",
                Position = "DBA"                
            });

            this.threeEmployeeList = new List<Employee>();
            this.threeEmployeeList.Add(new Employee()
            {
                FirstName = "John",
                LastName = "Johnson",
                Position = "Manager",
                SeparationDate = new DateTime(2016, 12, 31)
            });
            this.threeEmployeeList.Add(new Employee()
            {
                FirstName = "Jacquelyn",
                LastName = "Jackson",
                Position = "DBA"    
            });
            this.threeEmployeeList.Add(new Employee()
            {
                FirstName = "Michaela",
                LastName = "Michaelson",
                Position = "District Manager",
                SeparationDate = new DateTime(2016, 12, 09)
            });
        }
    }
}
