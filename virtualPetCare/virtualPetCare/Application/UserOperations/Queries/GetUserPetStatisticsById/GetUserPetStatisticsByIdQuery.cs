using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.Application.PetOperations.Queries.GetPetStatisticsById;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.UserOperations.Queries.GetUserPetStatisticsById
{
    public class GetUserPetStatisticsByIdQuery
    {
        public int UserId { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly GetPetStatisticsByIdQuery _getPetStatistics;

        public GetUserPetStatisticsByIdQuery(VirtualPetCareDbContext dbContext, GetPetStatisticsByIdQuery getPetStatistics)
        {
            _dbContext = dbContext;
            _getPetStatistics = getPetStatistics;
        }

        public List<PetStatisticViewModel> Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == UserId);
            
            if(user is null)
            {
                throw new InvalidOperationException("User could not found.");
            }
            
            var userPets = _dbContext.Pets.Include(p => p.User).Where(p => p.User.Id == UserId).ToList();

            if (userPets is null)
            {
                throw new InvalidOperationException("The user does not has any pets");
            }

            List<PetStatisticViewModel> userPetsVm = new List<PetStatisticViewModel>();

            foreach (var p in userPets) 
            {
                
                _getPetStatistics.PetId = p.Id;
                var pet = _getPetStatistics.Handle();
                
                userPetsVm.Add(pet);

            }

            return userPetsVm;
        }

    }


}
