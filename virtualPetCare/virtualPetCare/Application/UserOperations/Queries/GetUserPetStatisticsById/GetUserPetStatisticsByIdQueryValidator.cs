using FluentValidation;

namespace virtualPetCare.Application.UserOperations.Queries.GetUserPetStatisticsById
{
    public class GetUserPetStatisticsByIdQueryValidator : AbstractValidator<GetUserPetStatisticsByIdQuery>
    {
        public GetUserPetStatisticsByIdQueryValidator() 
        {
            RuleFor(query => query.UserId).GreaterThan(0);
        }
    }
}
