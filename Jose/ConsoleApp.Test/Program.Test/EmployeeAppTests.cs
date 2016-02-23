namespace CodeChallenge4.Program.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using CodeChallenge4.ConsoleApp.Program;
    using CodeChallenge4.ServiceLayer.DTO;
    using CodeChallenge4.ConsoleApp.Program.Code;
    using CodeChallenge4.ConsoleApp.DataAccessLayer;


    [TestClass]
    public class UnitTest1
    {
        List<EmployeeDto> _dbEmpleados;
        List<EmployeeDto> _dbEmpleadosOrderedByName;
        List<EmployeeDto> _dbEmpleadosOrderedByLastName;
        List<EmployeeDto> _dbEmpleadosOrderedByPosition;

        [TestMethod]
        public void InitValues() 
        {

            _dbEmpleados = new List<EmployeeDto>() { 
                new EmployeeDto { FirstName = "a", LastName = "e5", Position="Position c3" }, 
                new EmployeeDto { FirstName = "b", LastName = "d4", Position="Position b2" }, 
                new EmployeeDto { FirstName = "c", LastName = "c3", Position="Position a1" }, 
                new EmployeeDto { FirstName = "d", LastName = "b2", Position="Position d4" },
                new EmployeeDto { FirstName = "e", LastName = "a1", Position="Position e5" } 
            };

            _dbEmpleadosOrderedByName = new List<EmployeeDto>() { 
                new EmployeeDto { FirstName = "a", LastName = "e5", Position="Position c3" }, 
                new EmployeeDto { FirstName = "b", LastName = "d4", Position="Position b2" }, 
                new EmployeeDto { FirstName = "c", LastName = "c3", Position="Position a1" }, 
                new EmployeeDto { FirstName = "d", LastName = "b2", Position="Position d4" },
                new EmployeeDto { FirstName = "e", LastName = "a1", Position="Position e5" } 
            };

            _dbEmpleadosOrderedByLastName = new List<EmployeeDto>() { 
                new EmployeeDto { FirstName = "e", LastName = "a1", Position="Position e5" },
                new EmployeeDto { FirstName = "d", LastName = "b2", Position="Position d4" },
                new EmployeeDto { FirstName = "c", LastName = "c3", Position="Position a1" }, 
                new EmployeeDto { FirstName = "b", LastName = "d4", Position="Position b2" }, 
                new EmployeeDto { FirstName = "a", LastName = "e5", Position="Position c3" }
            };

            _dbEmpleadosOrderedByPosition = new List<EmployeeDto>() { 
                new EmployeeDto { FirstName = "c", LastName = "c3", Position="Position a1" }, 
                new EmployeeDto { FirstName = "b", LastName = "d4", Position="Position b2" }, 
                new EmployeeDto { FirstName = "a", LastName = "e5", Position="Position c3" }, 
                new EmployeeDto { FirstName = "d", LastName = "b2", Position="Position d4" },
                new EmployeeDto { FirstName = "e", LastName = "a1", Position="Position e5" } 
            };

        }

        [TestMethod]
        public void EmployeeAppTest_SearchEmployeeOp_orderByByName()
        {
            InitValues();
            EmployeeApp executionApp = new EmployeeApp();
            executionApp.SetData(_dbEmpleados);

            Utils.AppCommand orderByByNameCommand = Utils.AppCommand.OrderByName;
            List<EmployeeDto> resultEmployeeList = executionApp.SearchEmployeeOp(orderByByNameCommand);
            bool comparerResult = ListComparer(resultEmployeeList, _dbEmpleadosOrderedByName);

            Assert.AreEqual(true, comparerResult);
            executionApp.Dispose();
            resultEmployeeList.Clear();
            _dbEmpleados.Clear();
            _dbEmpleadosOrderedByName.Clear();
            _dbEmpleadosOrderedByLastName.Clear();
            _dbEmpleadosOrderedByPosition.Clear();

        }

        [TestMethod]
        public void EmployeeAppTest_SearchEmployeeOp_orderByByLastNAme()
        {
            InitValues();
            EmployeeApp executionApp = new EmployeeApp();
            executionApp.SetData(_dbEmpleados);

            Utils.AppCommand orderByByLastNameCommand = Utils.AppCommand.OrderByLastName;
            List<EmployeeDto> resultEmployeeList = executionApp.SearchEmployeeOp(orderByByLastNameCommand);
            bool comparerResult = ListComparer(resultEmployeeList, _dbEmpleadosOrderedByLastName);
            Assert.AreEqual(true, comparerResult);
            executionApp.Dispose();
            resultEmployeeList.Clear();
            resultEmployeeList.Clear();
            _dbEmpleados.Clear();
            _dbEmpleadosOrderedByName.Clear();
            _dbEmpleadosOrderedByLastName.Clear();
            _dbEmpleadosOrderedByPosition.Clear();
        }

        [TestMethod]
        public void EmployeeAppTest_SearchEmployeeOp_orderByByPosition()
        {
            InitValues();
            EmployeeApp executionApp = new EmployeeApp();
            executionApp.SetData(_dbEmpleados);

            Utils.AppCommand orderByByPositionCommand = Utils.AppCommand.OrderByPosition;
            List<EmployeeDto> resultEmployeeList = executionApp.SearchEmployeeOp(orderByByPositionCommand);
            bool comparerResult = ListComparer(resultEmployeeList, _dbEmpleadosOrderedByPosition);
            Assert.AreEqual(true, comparerResult);
            executionApp.Dispose();
            resultEmployeeList.Clear();
            resultEmployeeList.Clear();
            _dbEmpleados.Clear();
            _dbEmpleadosOrderedByName.Clear();
            _dbEmpleadosOrderedByLastName.Clear();
            _dbEmpleadosOrderedByPosition.Clear();
        }

        private bool ListComparer(List<EmployeeDto> SourceList, List<EmployeeDto> TargetList)
        {
            int it;
            for (it = 0; it < TargetList.Count; it++)
            {
                if (!((SourceList[it].FirstName == TargetList[it].FirstName) &&
                (SourceList[it].LastName == TargetList[it].LastName) &&
                (SourceList[it].Position == TargetList[it].Position) &&
                (SourceList[it].SeparationDate == TargetList[it].SeparationDate) &&
                (SourceList[it].SortBy == TargetList[it].SortBy)))
                { 
                    break;
                }

            }
            
            return (it == SourceList.Count);
        }
    }
}
