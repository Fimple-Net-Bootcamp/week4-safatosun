using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virtualPetCare.Application.UserOperations.Commands.CreateUser;
using virtualPetCare.Application.UserOperations.Queries.GetUserById;
using virtualPetCare.Application.UserOperations.Queries.GetUserPetStatisticsById;

namespace virtualPetCare.Controllers
{   
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly CreateUserCommand _createUserCommand;
        private readonly GetUserByIdQuery _getUserByIdQuery;
        private readonly GetUserPetStatisticsByIdQuery _getUserPetStatistics;

        public UserController(CreateUserCommand createUserCommand, GetUserByIdQuery getUserByIdQuery, GetUserPetStatisticsByIdQuery getUserPetStatistics)
        {
            _createUserCommand = createUserCommand;
            _getUserByIdQuery = getUserByIdQuery;
            _getUserPetStatistics = getUserPetStatistics;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            _getUserByIdQuery.UserId= id;
            var user = _getUserByIdQuery.Handle();
            return Ok(user);
            
        }

        [HttpGet("statistics/{id:int}")]
        public IActionResult GetPetsStatisticsById([FromRoute]int id)
        {
            _getUserPetStatistics.UserId= id;
            var userPetsVm = _getUserPetStatistics.Handle();
            return Ok(userPetsVm);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody]CreateUserModelDto userModel )
        {
            _createUserCommand.Model = userModel;
            var user =_createUserCommand.Handle();

            return CreatedAtAction(nameof(GetById), new {id=user.Id},user);
        }

    }
}
