using FluentValidation;

namespace CoderByte.API.ViewModels.Validations
{
  public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
  {
    public RegistrationViewModelValidator()
    {
      RuleFor(vm => vm.EmployeeName).NotEmpty().WithMessage("EmployeeName cannot be empty");
      RuleFor(vm => vm.EmployeeNumber).NotEmpty().WithMessage("EmployeeNumber cannot be empty");
      RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password cannot be empty");
      RuleFor(vm => vm.Password).Length(6, 12).WithMessage("Password must be between 6 and 12 characters");
      RuleFor(vm => vm.Designation).NotEmpty().WithMessage("Designation cannot be empty");
      RuleFor(vm => vm.ServiceLine).NotEmpty().WithMessage("ServiceLine cannot be empty");
      RuleFor(vm => vm.Role).NotEmpty().WithMessage("Role cannot be empty");
    }
  }
}

