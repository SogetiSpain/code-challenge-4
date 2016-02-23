
namespace CodeChallenge4.ServiceLayer.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CodeChallenge4.ConsoleApp.DataAccessLayer;
    using CodeChallenge4.ServiceLayer.Code;
    using CodeChallenge4.ServiceLayer.Interface;
    using CodeChallenge4.ServiceLayer.DTO;

    public class EmployeeAppService : IEmployeeAppService
    {

        private EmployeeDbFake _dbEmployee = new EmployeeDbFake();

        public EmployeeAppService()
        {
            ObjectMapper.AddMap<EmployeeEntity, EmployeeDto>(
            (x, y) =>
            {
                y.FirstName = y.FirstName;
                x.LastName = y.LastName;
                x.Position = y.Position;
                x.SeparationDate = y.SeparationDate;
            }
            );
            ObjectMapper.AddMap<EmployeeDto, EmployeeEntity>(
            (x, y) =>
            {
                y.FirstName = y.FirstName;
                x.LastName = y.LastName;
                x.Position = y.Position;
                x.SeparationDate = y.SeparationDate;
            }
            );
        }
        public async Task<List<EmployeeDto>> GetRestData()
        {
            List<EmployeeDto> listEmployeeDto = new List<EmployeeDto>();
            List<EmployeeEntity> listEmployeeEnt = await _dbEmployee.GeResttData();
            foreach (EmployeeEntity employeeItem in listEmployeeEnt)
            {
                EmployeeDto newEmployeeDto = new EmployeeDto();
                ObjectMapper.Map(employeeItem, newEmployeeDto);
                listEmployeeDto.Add(newEmployeeDto);
            }

            return listEmployeeDto;         
        }
        public List<EmployeeDto> GetAllEmployeesBy(string propertyName)
        {
            List<EmployeeDto> listEmployeeDto = new List<EmployeeDto>();
            List<EmployeeEntity> listEmployeeEnt = _dbEmployee.GetAllItems();
            foreach (EmployeeEntity employeeItem in listEmployeeEnt)
            {
                EmployeeDto newEmployeeDto = new EmployeeDto();
                ObjectMapper.Map(employeeItem, newEmployeeDto);
                listEmployeeDto.Add(newEmployeeDto);
            }

            listEmployeeDto = listEmployeeDto.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null)).ToList();
            return (listEmployeeDto);
        }
        public void SetData(List<EmployeeDto> EmployeeDbData) 
        {
            List<EmployeeEntity> EmployeeDbDataEntity = new List<EmployeeEntity>();
            foreach (EmployeeDto employeeItemDto in EmployeeDbData) 
            {
                EmployeeEntity newEmployeeEnt = new EmployeeEntity();
                ObjectMapper.Map(employeeItemDto, newEmployeeEnt);
                EmployeeDbDataEntity.Add(newEmployeeEnt);                               
            }
            _dbEmployee.SetDbData(EmployeeDbDataEntity);
        }



        /*
        public List<EmployeeDto> GetAllEmployeesByLastName()
        {
            List<EmployeeDto> listEmployeeDto = new List<EmployeeDto>();
            List<EmployeeEntity> listEmployeeEnt = _dbEmployee.GetAllItems();
            listEmployeeEnt = listEmployeeEnt.OrderBy(x => x.LastName).ToList();

            foreach (EmployeeEntity employeeItem in listEmployeeEnt)
            {
                EmployeeDto newEmployeeDto = new EmployeeDto();
                ObjectMapper.Map(employeeItem, newEmployeeDto);
                listEmployeeDto.Add(newEmployeeDto);
            }

            return (listEmployeeDto);
            
        }

        public List<EmployeeDto> GetAllEmployeesByName()
        {
            List<EmployeeDto> listEmployeeDto = new List<EmployeeDto>();
            List<EmployeeEntity> listEmployeeEnt = _dbEmployee.GetAllItems();
            listEmployeeEnt = listEmployeeEnt.OrderBy(x => x.FirstName).ToList();

            foreach (EmployeeEntity employeeItem in listEmployeeEnt)
            {
                EmployeeDto newEmployeeDto = new EmployeeDto();
                ObjectMapper.Map(employeeItem, newEmployeeDto);
                listEmployeeDto.Add(newEmployeeDto);
            }

            return (listEmployeeDto);

        }

        public List<EmployeeDto> GetAllEmployeesByPosition()
        {
            List<EmployeeDto> listEmployeeDto = new List<EmployeeDto>();
            List<EmployeeEntity> listEmployeeEnt = _dbEmployee.GetAllItems();
            listEmployeeEnt = listEmployeeEnt.OrderBy(x => x.Position).ToList();

            foreach (EmployeeEntity employeeItem in listEmployeeEnt)
            {
                EmployeeDto newEmployeeDto = new EmployeeDto();
                ObjectMapper.Map(employeeItem, newEmployeeDto);
                listEmployeeDto.Add(newEmployeeDto);
            }

            return (listEmployeeDto);

        }*/

    }
}
