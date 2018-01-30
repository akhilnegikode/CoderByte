using FluentValidation;

namespace CoderByte.API.ViewModels.Validations
{
    public class CredentialsViewModelValidator : AbstractValidator<CredentialsViewModel>
    {
        public CredentialsViewModelValidator()
        {
            RuleFor(vm => vm.EmployeeNumber).NotEmpty().WithMessage("EmployeeNumber cannot be empty");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(vm => vm.Password).Length(6, 8).WithMessage("Password must be between 6 and 12 characters");
        }
    }
}

