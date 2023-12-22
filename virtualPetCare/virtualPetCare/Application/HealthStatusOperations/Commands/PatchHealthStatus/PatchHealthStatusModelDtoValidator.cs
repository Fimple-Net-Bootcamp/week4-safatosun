using FluentValidation;
using virtualPetCare.Application.HealthStatus.Commands.PatchHealthStatus;

namespace virtualPetCare.Application.HealthStatusOperations.Commands.PatchHealthStatus
{
    public class PatchHealthStatusModelDtoValidator : AbstractValidator<PatchHealthStatusModelDto>
    {
        public PatchHealthStatusModelDtoValidator()
        {
            RuleFor(commmand=>commmand.HealthStatusId).GreaterThan(0);
        }
    }
}
