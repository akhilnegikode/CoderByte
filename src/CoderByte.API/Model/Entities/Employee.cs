using System.ComponentModel.DataAnnotations;

namespace CoderByte.API.Model.Entities
{
    public class Employee
    {
        [Key]
        public string EmployeeNumber { get; set; }

        public string EmployeeName { get; set; }

        public string IdentityId { get; set; }

        public AppUser Identity { get; set; }  // navigation property

        public string Designation { get; set; }

        public string ServiceLine { get; set; }

        public string Role { get; set; }
    }
}
