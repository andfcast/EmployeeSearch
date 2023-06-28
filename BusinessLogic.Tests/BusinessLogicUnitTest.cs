using EmployeeSearchBusinessLogic.Implementation;
using EmployeeSearchBusinessLogic.Interface;
using EmployeeSearchEntities;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class BusinessLogicUnitTest
    {
        private readonly IEmployeeBL employeeBL;

        public BusinessLogicUnitTest(IEmployeeBL _employeeBL) {
            employeeBL = _employeeBL;
        }

        [TestMethod]
        public async Task TestAnnualSalary()
        {
            EmployeeApiResponse response = await employeeBL.GetInfo(1);
            Employee employee = response.data as Employee;
            Assert.IsTrue(employee.employee_salary * 12 == employee.employee_anual_salary);
        }
    }
}