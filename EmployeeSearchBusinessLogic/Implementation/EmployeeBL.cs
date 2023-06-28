using EmployeeSearchBusinessLogic.Interface;
using EmployeeSearchDataAccess.Interface;
using EmployeeSearchEntities;

namespace EmployeeSearchBusinessLogic.Implementation
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeDAL _employeeDAL;
        public EmployeeBL(IEmployeeDAL employeeDAL) {
            _employeeDAL = employeeDAL;
        }
        public async Task<EmployeeApiResponse> GetAll() {
            List<Employee> employees = await _employeeDAL.GetAll();            
            EmployeeApiResponse response = new EmployeeApiResponse();
            SetResponse(employees, ref response);
            return response;            
        }
        public async Task<EmployeeApiResponse> GetInfo(int employeeId) {
            Employee employee = await _employeeDAL.GetInfoAsync(employeeId);            
            EmployeeApiResponse response = new EmployeeApiResponse();
            List<Employee> employees = new List<Employee>();
            if(employee != null)
                employees.Add(employee);
            SetResponse(employees, ref response);            
            return response;
        }

        private double CalculateAnnualSalary(double salary) {
            return salary * 12;
        }

        private void SetResponse(List<Employee> employees,ref EmployeeApiResponse response) {
            if (employees != null) {
                foreach (var employee in employees)
                {
                    employee.employee_anual_salary = CalculateAnnualSalary(employee.employee_salary);
                }
                response.data = employees;
            }                        
            response.statusCode = response.data != null ? 200 : 400;
            response.status = response.data != null ? "success" : "failure";
            response.isSuccess = response.data != null ? true : false;
            response.message = response.data != null ? "Successfully! Record has been fetched." : "No data available";
        }
    }
}