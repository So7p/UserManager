using FluentValidation;
using UserManager.Business.DTOs.Role;

namespace UserManager.Business.Validators.RoleValidators
{
    public class RoleForManipulationDtoValidator<T> : AbstractValidator<T> where T : RoleForManipulationDto
    {
        public RoleForManipulationDtoValidator()
        {
            RuleFor(r => r.RoleName)
                .NotNull().WithMessage("Role name cannot be null.");

            When(r => r.RoleName is not null, () =>
            {
                RuleFor(r => r.RoleName.Length)
                    .LessThan(16).WithMessage("The length of the role name cannot be more than 15 characters.");

                RuleFor(r => r.RoleName)
                    .Must(r => r.All(char.IsLetter)).WithMessage("Role name can only contain letters.");
            });
        }
    }
}