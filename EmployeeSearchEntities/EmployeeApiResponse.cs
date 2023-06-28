using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSearchEntities
{
    public class EmployeeApiResponse : ApiResponse
    {
        public int statusCode { get; set; }        
        public bool isSuccess { get; set; }        
    }
}
