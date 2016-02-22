/*
Necesito ordenar los resultados de una consulta.
    Primero tengo que obtener los resultados de una consulta
        Tengo que hacer una llamada a un repositorio para obtener los datos
        Para hacer la llamada a un repositorio lo tengo que hacer con alguna cosa (un service o algo parecido).
    Si tengo mas de 0 resultados, ordenarlos. 
    Mostar el resultado ordenador por pantalla
*/


using System.Linq;
using ServiceLayer;
using DataAccesLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        private Service _service;
        private EmployeeService _employeeService;

        [TestInitialize]
        public void Initialize()
        {
            _employeeService = new EmployeeService();
            _service = new Service();
        }

        [TestMethod]
        public void GetEmployees_test()
        {
            var result = _employeeService.GetEmployees();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetEmployeesOrderedByFirstName_test()
        {
            var result = _service.ObtenerEmpleadosOrdenados("N");
            var employeeList = _employeeService.GetEmployees();
            var expectedList = employeeList.OrderBy(x => x.FirstName);

            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedList.ElementAt(i).FirstName, result.ElementAt(i).FirstName);
                Assert.AreEqual(expectedList.ElementAt(i).LastName, result.ElementAt(i).LastName);
                Assert.AreEqual(expectedList.ElementAt(i).Position, result.ElementAt(i).Position);
                Assert.AreEqual(expectedList.ElementAt(i).SeparationDate, result.ElementAt(i).SeparationDate);
            }
        }

        [TestMethod]
        public void GetEmployeesOrderedByLastName_test()
        {
            var result = _service.ObtenerEmpleadosOrdenados("A");
            var employeeList = _employeeService.GetEmployees();
            var expectedList = employeeList.OrderBy(x => x.LastName);

            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedList.ElementAt(i).FirstName, result.ElementAt(i).FirstName);
                Assert.AreEqual(expectedList.ElementAt(i).LastName, result.ElementAt(i).LastName);
                Assert.AreEqual(expectedList.ElementAt(i).Position, result.ElementAt(i).Position);
                Assert.AreEqual(expectedList.ElementAt(i).SeparationDate, result.ElementAt(i).SeparationDate);
            }
        }

        [TestMethod]
        public void GetEmployeesOrderedByPosition_test()
        {
            var result = _service.ObtenerEmpleadosOrdenados("P");
            var employeeList = _employeeService.GetEmployees();
            var expectedList = employeeList.OrderBy(x => x.Position);

            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedList.ElementAt(i).FirstName, result.ElementAt(i).FirstName);
                Assert.AreEqual(expectedList.ElementAt(i).LastName, result.ElementAt(i).LastName);
                Assert.AreEqual(expectedList.ElementAt(i).Position, result.ElementAt(i).Position);
                Assert.AreEqual(expectedList.ElementAt(i).SeparationDate, result.ElementAt(i).SeparationDate);
            }
        }

        [TestMethod]
        public void GetEmployeesOrderedByDate_test()
        {
            var result = _service.ObtenerEmpleadosOrdenados("F");
            var employeeList = _employeeService.GetEmployees();
            var expectedList = employeeList.OrderBy(x => x.SeparationDate);

            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedList.ElementAt(i).FirstName, result.ElementAt(i).FirstName);
                Assert.AreEqual(expectedList.ElementAt(i).LastName, result.ElementAt(i).LastName);
                Assert.AreEqual(expectedList.ElementAt(i).Position, result.ElementAt(i).Position);
                Assert.AreEqual(expectedList.ElementAt(i).SeparationDate, result.ElementAt(i).SeparationDate);
            }
        }

        [TestMethod]
        public void GetEmployeesOrderedByNothing_test()
        {
            var result = _service.ObtenerEmpleadosOrdenados("");
            var expectedList = _employeeService.GetEmployees();

            for (var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedList.ElementAt(i).FirstName, result.ElementAt(i).FirstName);
                Assert.AreEqual(expectedList.ElementAt(i).LastName, result.ElementAt(i).LastName);
                Assert.AreEqual(expectedList.ElementAt(i).Position, result.ElementAt(i).Position);
                Assert.AreEqual(expectedList.ElementAt(i).SeparationDate, result.ElementAt(i).SeparationDate);
            }
        }
    }
}