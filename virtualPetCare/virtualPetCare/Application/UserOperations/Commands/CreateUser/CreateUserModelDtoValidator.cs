using FluentValidation;

namespace virtualPetCare.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserModelDtoValidator : AbstractValidator<CreateUserModelDto>    
    {
        public CreateUserModelDtoValidator() 
        {
            RuleFor(command => command.Name).NotEmpty().NotNull();
            RuleFor(command => command.Surname).NotEmpty().NotNull();
            RuleFor(command => command.PhoneNumber).NotEmpty().NotNull();
        }
    }
}
