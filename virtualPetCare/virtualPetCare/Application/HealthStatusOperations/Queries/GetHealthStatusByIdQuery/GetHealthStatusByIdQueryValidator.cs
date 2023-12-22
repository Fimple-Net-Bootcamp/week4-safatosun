using FluentValidation;

namespace virtualPetCare.Application.HealthStatusOperations.Queries.GetHealthStatusByIdQuery
{
    public class GetHealthStatusByIdQueryValidator : AbstractValidator<GetHealthStatusByIdQuery>
    {
        public GetHealthStatusByIdQueryValidator()
        {
            RuleFor(query=>query.PetId).GreaterThan(0);
        }
    }
}
