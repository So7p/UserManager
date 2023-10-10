using FluentValidation;
using UserManager.Business.DTOs.Role;

namespace UserManager.Business.Validators.RoleValidators
{
    public class RoleForUpdateDtoValdiator : RoleForManipulationDtoValidator<RoleForUpdateDto>
    {
        public RoleForUpdateDtoValdiator() 
        {
            RuleFor(r => r.Id)
                .NotNull().WithMessage("Id cannot be null.");
        }
    }
}