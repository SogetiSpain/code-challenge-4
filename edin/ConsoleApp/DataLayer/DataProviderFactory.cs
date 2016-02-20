using DataLayer.Implementations;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProviderFactory
    {
        public static IEmployeeData Create(bool isRemote)
        {
            if (isRemote)
            {
                return new RemoteDataProvider("http://codechallenge4.azurewebsites.net/api/employees");
            }
            else
            {
                return new LocalDataProvider();
            }
        }
    }
}
