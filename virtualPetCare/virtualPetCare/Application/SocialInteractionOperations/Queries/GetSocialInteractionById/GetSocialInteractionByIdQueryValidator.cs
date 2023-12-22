using FluentValidation;

namespace virtualPetCare.Application.SocialInteractionOperations.Queries.GetSocialInteractionById
{
    public class GetSocialInteractionByIdQueryValidator : AbstractValidator<GetSocialInteractionByIdQuery>
    {
        public GetSocialInteractionByIdQueryValidator()
        {
            RuleFor(query=>query.petId).GreaterThan(0);
        }
    }
}
