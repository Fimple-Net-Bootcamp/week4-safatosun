using FluentValidation;

namespace virtualPetCare.Application.PetOperations.Commands.CreatePet
{
    public class CreatePetModelDtoValidator : AbstractValidator<CreatePetModelDto>
    {
        public CreatePetModelDtoValidator() 
        {
            RuleFor(command=>command.UserId).GreaterThan(0).When(command=> command.UserId != null);
            RuleFor(command=>command.Name).NotEmpty().NotNull();
        }
    }
}
