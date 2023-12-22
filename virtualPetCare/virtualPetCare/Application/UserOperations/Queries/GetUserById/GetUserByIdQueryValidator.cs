using FluentValidation;

namespace virtualPetCare.Application.UserOperations.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>    
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(query => query.UserId).GreaterThan(0);
        }
    }
}
