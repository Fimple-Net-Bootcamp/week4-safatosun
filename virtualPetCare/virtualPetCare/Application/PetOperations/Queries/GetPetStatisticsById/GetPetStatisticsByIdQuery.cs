using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.DBOperations;
using virtualPetCare.Entities;

namespace virtualPetCare.Application.PetOperations.Queries.GetPetStatisticsById
{
    public class GetPetStatisticsByIdQuery
    {

        public int PetId { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPetStatisticsByIdQuery(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public PetStatisticViewModel Handle()
        {

            var pet = _dbContext.Pets.Include(p=>p.HealthStatus).Include(p=>p.Activity).Include(p=>p.Foods)
                                     .Where(p=>p.Id == PetId).SingleOrDefault();
            if (pet is null)
                throw new InvalidOperationException("Pet could not found.");

            var viewModel = _mapper.Map<PetStatisticViewModel>(pet);

            return viewModel;

        }

    }

    public class PetStatisticViewModel
    {
        public string Name { get; set; }
        public string HealthStatusName { get; set; }
        public List<string> Activity { get; set; }
        public List<string> Foods { get; set; }
    }

}
