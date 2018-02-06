using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoderByte.API.Model.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        public int EmployeeNumber { get; set; }

        public string EmployeeName { get; set; }

        public string IdentityId { get; set; }

        public AppUser Identity { get; set; }  // navigation property

        public string Designation { get; set; }

        public string ServiceLine { get; set; }

        public string Role { get; set; }
    }
}
