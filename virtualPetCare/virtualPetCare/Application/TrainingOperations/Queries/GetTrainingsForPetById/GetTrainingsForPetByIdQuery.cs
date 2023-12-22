using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.TrainingOperations.Queries.GetTrainingsForPetById
{
    public class GetTrainingsForPetByIdQuery
    {
        public int PetId { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTrainingsForPetByIdQuery(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TrainingsForPetViewModel> Handle()
        {
            var trainings = _dbContext.Trainings.Include(t => t.Pets).Where(t => t.Pets.Any(p => p.Id == PetId)).ToList();

            List<TrainingsForPetViewModel> trainingsForPetViewModels = _mapper.Map<List<TrainingsForPetViewModel>>(trainings);

            return trainingsForPetViewModels;

        }

    }

    public class TrainingsForPetViewModel
    {
        public string Name { get; set; }
    }

}
