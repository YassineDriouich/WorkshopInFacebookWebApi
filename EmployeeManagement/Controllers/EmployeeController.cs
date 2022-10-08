using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // Add New Action in Repo
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet("GetAllEmployees")]
        public IEnumerable<Employee> Get()
        {
            return _employeeService.GetAllEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeService.GetById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost("Add Employee")]
        public void Post([FromBody] Employee employee)
        {
            if(employee != null)
                _employeeService.AddEmployee(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public void Put([FromBody] Employee employee)
        {
            if (employee != null)
                _employeeService.UpdateEmployee(employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
        }
    }
}
