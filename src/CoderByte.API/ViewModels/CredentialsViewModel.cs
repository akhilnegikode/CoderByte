using CoderByte.API.ViewModels.Validations;
using FluentValidation.Attributes;

namespace CoderByte.API.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel  
    {
        public string EmployeeNumber { get; set; }
        public string Password { get; set; }        
    }
}