using FluentValidation;

namespace virtualPetCare.Application.PetOperations.Commands.UpdatePet
{
    public class UpdatePetModelDtoValidator : AbstractValidator<UpdatePetModelDto>
    {
        public UpdatePetModelDtoValidator()
        {
            RuleFor(command=>command.Name).NotNull().NotEmpty();    
            RuleFor(command=>command.UserId).GreaterThan(0);
            RuleFor(command=>command.HealthStatusId).GreaterThan(0);
        }
    }
}
