using CoderByte.API.ViewModels.Validations;
using FluentValidation.Attributes;

namespace CoderByte.API.ViewModels
{

    [Validator(typeof(RegistrationViewModelValidator))]
    public class RegistrationViewModel
    {
        public int EmployeeNumber { get; set; }

        public string EmployeeName { get; set; }

        public string Password { get; set; }

        public string Designation { get; set; }

        public string ServiceLine { get; set; }

        public string Role { get; set; }
    }
}
