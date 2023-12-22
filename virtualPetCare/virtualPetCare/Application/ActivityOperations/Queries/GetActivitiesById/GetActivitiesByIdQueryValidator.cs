using FluentValidation;

namespace virtualPetCare.Application.ActivityOperations.Queries.GetActivitiesById
{
    public class GetActivitiesByIdQueryValidator : AbstractValidator<GetActivitiesByIdQuery>
    {
        public GetActivitiesByIdQueryValidator()
        {
            RuleFor(query=>query.PetId).GreaterThan(0);
        }
    }
}
