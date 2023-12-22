using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.DBOperations;
using virtualPetCare.Entities;

namespace virtualPetCare.Application.PetOperations.Queries.GetPets
{    
    public class GetPetsQuery
    {
        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPetsQuery(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<PetsViewModel> Handle()
        {
            var petList = _dbContext.Pets.Include(p => p.User).ToList();

            List<PetsViewModel> petsViewModels = _mapper.Map<List<PetsViewModel>>(petList);

            return petsViewModels;

        }

    }
     
    public class PetsViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
    }

}
