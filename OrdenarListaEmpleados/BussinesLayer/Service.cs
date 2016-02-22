using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccesLayer;

namespace ServiceLayer
{
    public class Service : IService
    {
        private readonly IEmployeeService employeeService;

        public Service()
        {
            employeeService = new EmployeeService();
        }

        public List<EmployeeDto> ObtenerEmpleadosOrdenados(string sortOrder)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDto>());
            var mapper = config.CreateMapper();
            var employeesList = employeeService.GetEmployees();
            var emplyeeListDto = employeesList.Select(employee => mapper.Map<EmployeeDto>(employee)).ToList();

            //tratar el orderby y ordenar :)
            switch (sortOrder.ToLower())
            {
                case "n":
                    return emplyeeListDto.OrderBy(x => x.FirstName).ToList();
                case "a":
                    return emplyeeListDto.OrderBy(x => x.LastName).ToList();
                case "p":
                    return emplyeeListDto.OrderBy(x => x.Position).ToList();
                case "f":
                    return emplyeeListDto.OrderBy(x => x.SeparationDate).ToList();
                default:
                    return emplyeeListDto;
            }
        }
    }
}