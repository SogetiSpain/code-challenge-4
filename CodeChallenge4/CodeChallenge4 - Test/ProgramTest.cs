

namespace CodeChallenge4___Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ServiceLayer;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using DataAccessLayer;
    using System.Linq;
    

    [TestClass]
    public class ProgramTest
    {
        EmployeeService employeeService = new EmployeeService();
        public static List<EmployeeEntity> list = new List<EmployeeEntity>();

        [ClassInitialize]
        public static void InitEmployeeList(TestContext ctx)
        {
            list.Add(new EmployeeEntity() { 
                
                FirstName = "John",
                LastName ="Connor",
                Position ="Web developer",
                SeparationDate = DateTime.Now
            
            });

            list.Add(new EmployeeEntity()
            {

                FirstName = "Alex",
                LastName = "Hernandez",
                Position = "Analist",
                SeparationDate = DateTime.Now

            });

            list.Add(new EmployeeEntity()
            {

                FirstName = "Peter",
                LastName = "La anguila",
                Position = "Delivery",
                SeparationDate = DateTime.Now

            });

        }

        [TestMethod]
        public void GetEmployeesFromApi()
        {
            //Act
            var employeeList = employeeService.GetEmployees();
            //Assert
            Assert.IsNotNull(employeeList);
        }

        [TestMethod]
        public void OrderByCriteriaName()
        {

            var result = employeeService.OrderByCriteria<EmployeeDTO>(employeeService.Mapper(list), x => x.FirstName);
            var auxList = list.OrderBy(x => x.FirstName);
            for (var i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(auxList.ElementAt(i).FirstName, result.ElementAt(i).FirstName);
                Assert.AreEqual(auxList.ElementAt(i).LastName, result.ElementAt(i).LastName);
                Assert.AreEqual(auxList.ElementAt(i).Position, result.ElementAt(i).Position);
                Assert.AreEqual(auxList.ElementAt(i).SeparationDate, result.ElementAt(i).SeparationDate);
            }
        }
        //TODO: refactoring funcionalidad comparar dos listas por separado

        [TestMethod]
        public void OrderByCriteriaLastName()
        {

            var result = employeeService.OrderByCriteria<EmployeeDTO>(employeeService.Mapper(list), x => x.LastName);
            var auxList = list.OrderBy(x => x.LastName);

            for (var i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(auxList.ElementAt(i).FirstName, result.ElementAt(i).FirstName);
                Assert.AreEqual(auxList.ElementAt(i).LastName, result.ElementAt(i).LastName);
                Assert.AreEqual(auxList.ElementAt(i).Position, result.ElementAt(i).Position);
                Assert.AreEqual(auxList.ElementAt(i).SeparationDate, result.ElementAt(i).SeparationDate);
            }
        }

        [TestMethod]
        public void OrderByCriteriaPosition()
        {

            var result = employeeService.OrderByCriteria<EmployeeDTO>(employeeService.Mapper(list), x => x.Position);
            var auxList = list.OrderBy(x => x.Position);

            for (var i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(auxList.ElementAt(i).FirstName, result.ElementAt(i).FirstName);
                Assert.AreEqual(auxList.ElementAt(i).LastName, result.ElementAt(i).LastName);
                Assert.AreEqual(auxList.ElementAt(i).Position, result.ElementAt(i).Position);
                Assert.AreEqual(auxList.ElementAt(i).SeparationDate, result.ElementAt(i).SeparationDate);
            }
        }

       
        //private bool CompareTwoList(List<EmployeeDTO> list1, List<EmployeeDTO> list2)
        //{

        //    int i = 0;
        //    bool areEqual = true;
        //    while (i < list1.Count && areEqual)
        //    {
        //        if (
        //            list1.ElementAt(i).FirstName.Equals(list2.ElementAt(i).FirstName) &&
        //            list1.ElementAt(i).LastName.Equals(list2.ElementAt(i).LastName) &&
        //            list1.ElementAt(i).Position.Equals(list2.ElementAt(i).Position) &&
        //            list1.ElementAt(i).FirstName.Equals(list2.ElementAt(i).FirstName) &&
        //            list1.ElementAt(i).SeparationDate.Equals(list2.ElementAt(i).SeparationDate))
        //        {
        //            areEqual = true;
        //        }
        //        else
        //        {
        //            areEqual = false;
        //        }            
        //    }

        //    return areEqual;
        //}

 

       
       
    }
}
