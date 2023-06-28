using EmployeeSearchDataAccess.Interface;
using EmployeeSearchEntities;
using EmployeeSearchDataAccess.Resources;
using Newtonsoft.Json;
using System;

namespace EmployeeSearchDataAccess.Implementation
{
    public class EmployeeDAL : IEmployeeDAL
    {
        public async Task<List<Employee>> GetAll() {
            ApiResponse response = await CallEndpoint(Resources.Resources.GetAllEmployeesUrl);
            if(response != null && response.data != null)
                return JsonConvert.DeserializeObject<List<Employee>>(response.data.ToString()!)!;
            else 
                return null;
        }
        public async Task<Employee> GetInfoAsync(int employeeId) {
            ApiResponse response = await CallEndpoint(Resources.Resources.GetEmployeeByIdUrl + employeeId.ToString());
            if (response.data != null)
                return JsonConvert.DeserializeObject<Employee>(response.data.ToString()!)!;
            else
                return null;
        }

        private async Task<ApiResponse> CallEndpoint(string url) {
            HttpClient client = new HttpClient();
            ApiResponse res = new ApiResponse();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                res = JsonConvert.DeserializeObject<ApiResponse>(response.Content.ReadAsStringAsync().Result)!;
                return res;
            }
            return null;
        }        
    }
}