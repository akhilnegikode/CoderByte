using System.Collections.Generic;
using CoderByte.API.Data;
using CoderByte.API.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoderByte.API.Controllers
{
  [Authorize(Policy = "CoderByte")]
  [Route("api/[controller]")]
  public class EmployeesController : Controller
  {
    private readonly EmployeeDbContext _employeeDbContext;

    public EmployeesController(EmployeeDbContext employeeDbContext)
    {
      _employeeDbContext = employeeDbContext;
    }

    // GET api/employees
    [HttpGet("home")]
    public IEnumerable<Employee> Get()
    {
      var employeeList = _employeeDbContext.Employees;
      return employeeList;
    }

    // GET api/employees/1
    [HttpGet("{id}", Name = "GetEmployee")]
    public IActionResult Get(int id)
    {
      var employee = _employeeDbContext.Employees.Find(id);
      if (employee == null)
      {
        return NotFound();
      }
      return new ObjectResult(employee);
    }

    // POST api/employees
    /*  [HttpPost]
      public IActionResult Post([FromBody]Employee employee)
      {
          if (employee == null)
          {
              return BadRequest();
          }
          _employeeDbContext.Employees.Add(employee);
          _employeeDbContext.SaveChanges();
          return CreatedAtRoute("GetEmployee", new { id = employee.EmployeeNumber }, employee);
      }*/

    /* // PUT api/employees/1
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
     }*/

    // DELETE api/employees/1
    /* [HttpDelete("{id}")]
     public IActionResult Delete(int id)
     {
         var employee = _employeeDbContext.Employees.Find(id);
         if (employee == null)
         {
             return NotFound();
         }
         _employeeDbContext.Employees.Remove(employee);
         _employeeDbContext.SaveChanges();
         return new NoContentResult();
     }*/
  }
}
