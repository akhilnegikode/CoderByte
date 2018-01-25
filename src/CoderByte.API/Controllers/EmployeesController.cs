using System.Collections.Generic;
using CoderByte.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace CoderByte.API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly ApiContext _context;

        public EmployeesController(ApiContext context)
        {
            _context = context;
        }

        // GET api/employees
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var employeeList = _context.Employees;
            return employeeList;
        }

        // GET api/employees/1
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var employee = _context.Employees.Find(id);
            return employee;
        }

        // POST api/employees
        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        // PUT api/employees/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Employee employee)
        {
            var emp = _context.Employees.Find(id);
            emp.EmployeeName = employee.EmployeeName;
            emp.EmployeeNumber = employee.EmployeeNumber;
            emp.Designation = employee.Designation;
            emp.Password = employee.Password;
            emp.Role = employee.Role;
            emp.ServiceLine = employee.ServiceLine;
            _context.SaveChanges();
        }

        // DELETE api/employees/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return;
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
