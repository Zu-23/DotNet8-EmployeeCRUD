using EmployeesManagement.Data;
using EmployeesManagement.Models;
using EmployeesManagement.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetOneEmployee(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult PostEmployees(EmployeeDto PostEmployeeDto)
        {
            var employee = new Employee()
            {
                Email = PostEmployeeDto.Email,
                FirstName = PostEmployeeDto.FirstName,
                LastName = PostEmployeeDto.LastName,
                Department = PostEmployeeDto.Department,
                PhoneNumber = PostEmployeeDto.PhoneNumber,
                Position = PostEmployeeDto.Position,
            };
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return Ok(employee);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, EmployeeDto updateEmployeeDto)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.FirstName = updateEmployeeDto.FirstName;
            employee.LastName = updateEmployeeDto.LastName;
            employee.PhoneNumber = updateEmployeeDto.PhoneNumber;
            employee.Position = updateEmployeeDto.Position;
            employee.Department = updateEmployeeDto.Department;
            _dbContext.SaveChanges();
            return Ok(employee);

        }
    }
}
