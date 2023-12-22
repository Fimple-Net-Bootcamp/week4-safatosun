using Microsoft.EntityFrameworkCore;
using virtualPetCare.DBOperations;
using virtualPetCare.Entities;

namespace virtualPetCare.Application.SocialInteractionOperations.Command.CreateSocialInteractionForPets
{
    public class CreateSocialInteractionForPetCommand
    {
        public CreateSocialInteractionForPetModelDto Model { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;

        public CreateSocialInteractionForPetCommand(VirtualPetCareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {

            var pet = _dbContext.Pets.Include(p=>p.SocialInteractions).SingleOrDefault(p => p.Id == Model.PetId);

            if (pet is null)
                throw new InvalidOperationException("The pet could not found.");

            var friendPet= _dbContext.Pets.SingleOrDefault(p => p.Id == Model.FriendPetId);
            
            if (friendPet is null)
                throw new InvalidOperationException("The friend pet could not found.");


            SocialInteraction socialInteraction = new SocialInteraction
            {
                FriendPetId = friendPet.Id,
            };
            
            pet.SocialInteractions.Add(socialInteraction);
            _dbContext.SaveChanges();

        }
    }

    public record CreateSocialInteractionForPetModelDto
    {
        public  int PetId { get; init; }
        public int FriendPetId { get; init; }
    }
}
