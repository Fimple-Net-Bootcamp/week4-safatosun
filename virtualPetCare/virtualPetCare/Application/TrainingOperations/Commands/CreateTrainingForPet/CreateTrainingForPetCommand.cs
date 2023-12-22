using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.TrainingOperations.Commands.CreateTrainingForPet
{
    public class CreateTrainingForPetCommand
    {

        public CreateTrainingForPetModelDto Model { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateTrainingForPetCommand(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var pet = _dbContext.Pets.SingleOrDefault(p => p.Id == Model.PetId);

            if (pet is null)
                throw new InvalidOperationException("The pet is not valid.");

            var training = _dbContext.Trainings.Include(t=>t.Pets).SingleOrDefault(t => t.Id == Model.TrainingId);

            if (training is null)
                throw new InvalidOperationException($"The training is not valid");

            training.Pets.Add(pet);
            _dbContext.SaveChanges();
        }

    }

    public record CreateTrainingForPetModelDto
    {
        public int PetId { get; init; }
        public int TrainingId { get; init; }
    }

}
