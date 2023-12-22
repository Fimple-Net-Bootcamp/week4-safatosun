using FluentValidation;

namespace virtualPetCare.Application.FoodOperations.Commands.CreateFoodForPets
{
    public class CreateFoodForPetModelDtoValidator : AbstractValidator<CreateFoodForPetModelDto>
    {
        public CreateFoodForPetModelDtoValidator()
        {
            RuleFor(command=>command.FoodId).GreaterThan(0);
        }
    }
}
