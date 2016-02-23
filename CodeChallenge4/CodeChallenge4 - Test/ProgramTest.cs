

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

            List<EmployeeDTO> result = employeeService.OrderByCriteria<EmployeeDTO>(employeeService.Mapper(list), x => x.FirstName).ToList();
            List<EmployeeDTO> auxList = employeeService.Mapper(list.OrderBy(x => x.FirstName).ToList());
            Assert.IsTrue(CompareTwoList(result, auxList));
        }

        [TestMethod]
        public void OrderByCriteriaLastName()
        {

            List<EmployeeDTO> result = employeeService.OrderByCriteria<EmployeeDTO>(employeeService.Mapper(list), x => x.LastName).ToList();
            List<EmployeeDTO> auxList = employeeService.Mapper(list.OrderBy(x => x.LastName).ToList());

            Assert.IsTrue(CompareTwoList(result, auxList));
        }

        [TestMethod]
        public void OrderByCriteriaPosition()
        {

            List<EmployeeDTO> result = employeeService.OrderByCriteria<EmployeeDTO>(employeeService.Mapper(list), x => x.Position).ToList();
            List<EmployeeDTO> auxList = employeeService.Mapper(list.OrderBy(x => x.Position).ToList());

            Assert.IsTrue(CompareTwoList(result,auxList));
        }


        private bool CompareTwoList(List<EmployeeDTO> list1, List<EmployeeDTO> list2)
        {

            int i = 0;
            bool areEqual = true;
            while (i < list1.Count && areEqual)
            {
                if (
                    list1.ElementAt(i).FirstName.Equals(list2.ElementAt(i).FirstName) &&
                    list1.ElementAt(i).LastName.Equals(list2.ElementAt(i).LastName) &&
                    list1.ElementAt(i).Position.Equals(list2.ElementAt(i).Position) &&
                    list1.ElementAt(i).FirstName.Equals(list2.ElementAt(i).FirstName) &&
                    list1.ElementAt(i).SeparationDate.Equals(list2.ElementAt(i).SeparationDate))
                {
                    areEqual = true;
                    i++;
                }
                else
                {
                    areEqual = false;
                }
            }

            return areEqual;
        }

 

       
       
    }
}
