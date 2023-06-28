using EmployeeSearchBusinessLogic.Interface;
using EmployeeSearchEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL _employeeBL;

        public EmployeeController(IEmployeeBL employeeBL) {
            _employeeBL = employeeBL;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<EmployeeApiResponse> Get()
        {
            return await _employeeBL.GetAll();            
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeApiResponse> Get(int id)
        {
            return await _employeeBL.GetInfo(id);            
        }        
    }
}
