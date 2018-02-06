using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderByte.API.Data;
using CoderByte.API.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoderByte.API.Controllers
{
    [Authorize(Policy = "CoderByte")]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeesController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET api/employees
        [HttpGet("home")]
        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees;
        }

        // GET api/employees/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST api/employees
        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtRoute("GetEmployee", new { id = employee.EmployeeNumber }, employee);
        }

        // PUT api/employees/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeNumber)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeAlreadyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/employees/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.Employees.SingleOrDefaultAsync(m => m.EmployeeNumber == id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        private bool EmployeeAlreadyExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeNumber == id);
        }

        //private void MethodCommentedPurposefullyForSonar()
        //{
        //    // Some Logic
        //}

    }
}
