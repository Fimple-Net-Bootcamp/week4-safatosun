using AutoMapper;
using virtualPetCare.Application.UserOperations.Queries.GetUserById;
using virtualPetCare.DBOperations;
using virtualPetCare.Entities;

namespace virtualPetCare.Application.UserOperations.Commands.CreateUser
{   
    public class CreateUserCommand
    {
        public CreateUserModelDto Model { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserCreateViewModel Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.PhoneNumber == Model.PhoneNumber);

            if (user is not null)
            {
                throw new InvalidOperationException("User already exists.");
            }

            user = _mapper.Map<User>(Model);

            _dbContext.Add(user);
            _dbContext.SaveChanges();

            var result = _mapper.Map<UserCreateViewModel>(user);
            return result;
        }

    }
     
    public record CreateUserModelDto
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public string PhoneNumber { get; init; }
    }
     
    public class UserCreateViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }

}
