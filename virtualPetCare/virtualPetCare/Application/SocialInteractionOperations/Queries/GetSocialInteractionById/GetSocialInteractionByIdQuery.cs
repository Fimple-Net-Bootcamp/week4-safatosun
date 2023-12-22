using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.SocialInteractionOperations.Queries.GetSocialInteractionById
{
    public class GetSocialInteractionByIdQuery
    {
        public  int  petId { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSocialInteractionByIdQuery(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<PetSocialInteractionViewModel> Handle()
        {
            var interaction = _dbContext.SocialInteractions.Include(s => s.Pets).Where(s => s.Pets.Any(p => p.Id == petId)).Select(s=>s.FriendPetId).ToList();

            List<PetSocialInteractionViewModel> resultViewModel = new List<PetSocialInteractionViewModel>();

            foreach(var friendPetId in interaction)
            {
                var pet = _dbContext.Pets.Where(p => p.Id == friendPetId).SingleOrDefault();

                if (pet is null)
                    continue;
                var petSocialInteraction = new PetSocialInteractionViewModel
                {
                    Name=pet.Name
                };
                resultViewModel.Add(petSocialInteraction);

            }

            return resultViewModel;
        }

    }

    public class PetSocialInteractionViewModel
    {
        public string Name { get; set; }
    }

}
