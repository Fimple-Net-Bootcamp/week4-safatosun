using FluentValidation;

namespace virtualPetCare.Application.PetOperations.Queries.GetPetStatisticsById
{
    public class GetPetStatisticsByIdQueryValidator : AbstractValidator<GetPetStatisticsByIdQuery>
    {
        public GetPetStatisticsByIdQueryValidator()
        {
            RuleFor(query=>query.PetId).GreaterThan(0);
        }
    }
}
