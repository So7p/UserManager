using FluentValidation;
using UserManager.Business.DTOs.User;

namespace UserManager.Business.Validators.UserValidators
{
    public class UserForManipulationDtoValidator<T> : AbstractValidator<T> where T : UserForManipulationDto
    {
        public UserForManipulationDtoValidator()
        {
            RuleFor(u => u.Name)
                .NotNull().WithMessage("Username cannot be null.");

            When(u => u.Name is not null, () => 
            {
                RuleFor(u => u.Name.Length)
                    .LessThan(31).WithMessage("The length of the username cannot be more than 30 characters.");

                RuleFor(u => u.Name)
                    .Must(u => u.All(char.IsLetter)).WithMessage("Username can only contain letters.");
            });

            RuleFor(u => u.Age)
                .NotNull().WithMessage("Age cannot be null.");

            RuleFor(u => u.Age)
                .GreaterThan(0).LessThan(100).WithMessage("Age must be a number greater then 0 and less then 100.");

            RuleFor(u => u.Email)
                .NotNull().WithMessage("Email cannot be null.");

            When(u => u.Email is not null, () => 
            {
                RuleFor(u => u.Email)
                    .EmailAddress().WithMessage("The entered value is not an Email.");

                RuleFor(u => u.Email.Length)
                    .LessThan(41).WithMessage("The length of the Email cannot be more than 40 characters.");
            });
        }
    }
}