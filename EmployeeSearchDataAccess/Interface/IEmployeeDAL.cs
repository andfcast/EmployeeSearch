using EmployeeSearchEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSearchDataAccess.Interface
{
    public interface IEmployeeDAL
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetInfoAsync(int employeeId);
    }
}
