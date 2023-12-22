using FluentValidation;

namespace virtualPetCare.Application.ActivityOperations.Commands.CreateActivity
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityModelDto>
    {
        public CreateActivityCommandValidator() 
        {
            RuleFor(command=>command.Name).NotEmpty().NotNull();
        }
    }
}
