using EmployeesManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DbContextClass _dbContext;
        public EmployeeController(DbContextClass dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var empList = _dbContext.Employees.ToList();
            return Ok(empList);
        }
    }
}
