using FluentValidation;

namespace virtualPetCare.Application.PetOperations.Queries.GetPetById
{
    public class GetPetByIdQueryValidator : AbstractValidator<GetPetByIdQuery>  
    {
        public GetPetByIdQueryValidator()
        {
            RuleFor(query=> query.PetId).GreaterThan(0);
        }
    }
}
