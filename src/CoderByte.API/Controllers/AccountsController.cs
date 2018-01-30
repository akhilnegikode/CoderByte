using System.Threading.Tasks;
using AutoMapper;
using CoderByte.API.Data;
using CoderByte.API.Helpers;
using CoderByte.API.Model.Entities;
using CoderByte.API.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoderByte.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly EmployeeDbContext _employeeDbContext;

        public AccountsController(UserManager<AppUser> userManager, IMapper mapper, EmployeeDbContext employeeDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _employeeDbContext = employeeDbContext;
        }


        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AppUser userIdentity = _mapper.Map<AppUser>(model);

            IdentityResult result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _employeeDbContext.Employees.AddAsync(new Employee { IdentityId = userIdentity.Id, EmployeeNumber = model.EmployeeNumber, EmployeeName = model.EmployeeName, Designation = model.Designation, Role = model.Role, ServiceLine = model.ServiceLine });
            await _employeeDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}
