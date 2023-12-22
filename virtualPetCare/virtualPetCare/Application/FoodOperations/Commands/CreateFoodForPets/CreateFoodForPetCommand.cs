using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.FoodOperations.Commands.CreateFoodForPets
{     
    public class CreateFoodForPetCommand 
    {
        public int PetId { get; set; }
        public CreateFoodForPetModelDto Model { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateFoodForPetCommand(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var pet = _dbContext.Pets.SingleOrDefault(p=>p.Id==PetId);

            if (pet is null)
            {
                throw new InvalidOperationException("The pet not found.");
            }

            var food = _dbContext.Foods.Include(f=>f.Pets).SingleOrDefault(f =>f.Id== Model.FoodId);

            if (food is null)
            {
                throw new InvalidOperationException("The food not found.");
            }

            food.Pets.Add(pet);
            _dbContext.SaveChanges();

        }

    }
     
    public record CreateFoodForPetModelDto
    {
        public int FoodId { get; init; }
    }
    
}
