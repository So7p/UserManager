using FluentValidation;
using UserManager.Business.DTOs.User;

namespace UserManager.Business.Validators.UserValidators
{
    public class UserForUpdateDtoValidator : UserForManipulationDtoValidator<UserForUpdateDto>
    {
        public UserForUpdateDtoValidator() 
        {
            RuleFor(u => u.Id)
                .NotNull().WithMessage("Id cannot be null.");
        }
    }
}