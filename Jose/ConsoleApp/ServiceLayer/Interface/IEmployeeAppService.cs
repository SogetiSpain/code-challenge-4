
namespace CodeChallenge4.ServiceLayer.Interface
{
    using CodeChallenge4.ConsoleApp.DataAccessLayer;
    using CodeChallenge4.ServiceLayer.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEmployeeAppService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        List<EmployeeDto> GetAllEmployeesBy(string propertyName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmployeeDbData"></param>
        void SetData(List<EmployeeDto> EmployeeDbData);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<EmployeeDto>> GetRestData();

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //List<EmployeeDto> GetAllEmployeesByLastName();

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //List<EmployeeDto> GetAllEmployeesByName();

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //List<EmployeeDto> GetAllEmployeesByPosition();

    }
}
