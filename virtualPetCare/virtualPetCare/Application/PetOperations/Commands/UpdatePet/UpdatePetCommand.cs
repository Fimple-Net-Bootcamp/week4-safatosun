using AutoMapper;
using virtualPetCare.DBOperations;
using virtualPetCare.Entities;

namespace virtualPetCare.Application.PetOperations.Commands.UpdatePet
{    
    public class UpdatePetCommand
    {
        public int PetId { get; set; }
        public UpdatePetModelDto Model { get; set; }   

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdatePetCommand(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var pet = _dbContext.Pets.SingleOrDefault(pet=> pet.Id == PetId);   
            
            if(pet is null)
            {
                throw new InvalidOperationException("Pet not found.");
            }

            pet.Name = Model.Name;  
            pet.UserId = Model.UserId; 
            pet.HealthStatusId= Model.HealthStatusId;   
            _dbContext.SaveChanges();

        }

    }
     
    public record UpdatePetModelDto
    {
        public string Name { get; init; }
        public int UserId { get; init; }
        public int HealthStatusId { get; init; }
    }


}
