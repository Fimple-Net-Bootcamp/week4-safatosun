using FluentValidation;

namespace virtualPetCare.Application.SocialInteractionOperations.Command.CreateSocialInteractionForPets
{
    public class CreateSocialInteractionForPetModelDtoValidator : AbstractValidator<CreateSocialInteractionForPetModelDto>
    {
        public CreateSocialInteractionForPetModelDtoValidator()
        {
            RuleFor(command=>command.PetId).GreaterThan(0);
            RuleFor(command => command.FriendPetId).GreaterThan(0);
        }
    }
}
