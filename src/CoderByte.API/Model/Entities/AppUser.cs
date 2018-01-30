using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CoderByte.API.Model.Entities
{
    public class AppUser : IdentityUser
    {
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
    }
}
