namespace UnitTest_OrderEmployeeList
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using ServiceLayer.Models;
    [TestClass]
    public class UnitTest1
    {
        private List<Employee> list;

        [TestInitialize]
        public void Initializer()
        {
            this.list = new List<Employee>();

            list.Add(new Employee() {
                FirstName = "John",
                LastName = "Johnson",
                Position = "Manager",
                SeparationDate = DateTime.Parse("2016-12-31")
            });

            list.Add(new Employee()
            {
                FirstName = "Tou",
                LastName = "Xiong",
                Position = "Software Engineer",
                SeparationDate = DateTime.Parse("2016-10-05")
            });

            list.Add(new Employee()
            {
                FirstName = "Jacquelyn",
                LastName = "Jackson",
                Position = "DBA",
                SeparationDate = DateTime.Now
            });

            list.Add(new Employee()
            {
                FirstName = "Michaela",
                LastName = "Michaelson",
                Position = "District Manager",
                SeparationDate = DateTime.Parse("2015-12-09")
            });
        }

        [TestMethod]
        public void TestMethod1()
        {
           


        }
    }
}
