using FluentValidation;
using UserManager.Business.DTOs.RoleUser;

namespace UserManager.Business.Validators.RoleUserValidators
{
    public class RoleUserForManipulationDtoValidator<T> : AbstractValidator<T> where T : RoleUserForManipulationDto
    {
        public RoleUserForManipulationDtoValidator()
        {
            RuleFor(r => r.UserId)
                .NotNull().WithMessage("User Id cannot be null.");

            RuleFor(r => r.RoleId)
                .NotNull().WithMessage("Role Id cannot be null.");
        }
    }
}