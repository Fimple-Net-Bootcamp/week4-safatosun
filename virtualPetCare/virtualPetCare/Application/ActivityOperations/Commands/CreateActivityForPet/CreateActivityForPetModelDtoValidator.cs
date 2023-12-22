using FluentValidation;
using static virtualPetCare.Application.ActivityOperations.Commands.CreateActivityForPet.CreateActivityForPetCommand;

namespace virtualPetCare.Application.ActivityOperations.Commands.CreateActivityForPet
{
    public class CreateActivityForPetModelDtoValidator : AbstractValidator<CreateActivityForPetModelDto>
    {
        public CreateActivityForPetModelDtoValidator()
        {
            RuleFor(command => command.ActivityId).GreaterThan(0);
        }

    }
}
