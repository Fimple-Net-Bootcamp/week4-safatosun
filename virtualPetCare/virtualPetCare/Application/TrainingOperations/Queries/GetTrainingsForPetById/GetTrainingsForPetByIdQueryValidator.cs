using FluentValidation;

namespace virtualPetCare.Application.TrainingOperations.Queries.GetTrainingsForPetById
{
    public class GetTrainingsForPetByIdQueryValidator : AbstractValidator<GetTrainingsForPetByIdQuery>
    {
        public GetTrainingsForPetByIdQueryValidator()
        {
            RuleFor(query => query.PetId).GreaterThan(0);
        }
    }
}
