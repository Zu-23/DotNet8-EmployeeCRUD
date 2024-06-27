using EmployeesManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagement.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}