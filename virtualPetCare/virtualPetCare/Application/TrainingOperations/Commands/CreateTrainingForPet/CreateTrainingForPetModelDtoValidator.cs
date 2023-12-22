using FluentValidation;

namespace virtualPetCare.Application.TrainingOperations.Commands.CreateTrainingForPet
{
    public class CreateTrainingForPetModelDtoValidator : AbstractValidator<CreateTrainingForPetModelDto>
    {
        public CreateTrainingForPetModelDtoValidator() 
        {
            RuleFor(command=>command.PetId).GreaterThan(0);
            RuleFor(command=>command.TrainingId).GreaterThan(0);
        }

    }
}
