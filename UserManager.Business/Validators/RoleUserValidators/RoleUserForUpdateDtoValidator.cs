using FluentValidation;
using UserManager.Business.DTOs.RoleUser;

namespace UserManager.Business.Validators.RoleUserValidators
{
    public class RoleUserForUpdateDtoValidator : RoleUserForManipulationDtoValidator<RoleUserForUpdateDto>
    {
        public RoleUserForUpdateDtoValidator()
        {
            RuleFor(r => r.Id)
                .NotNull().WithMessage("Id cannot be null.");
        }
    }
}