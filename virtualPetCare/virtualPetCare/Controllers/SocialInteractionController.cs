using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virtualPetCare.Application.SocialInteractionOperations.Command.CreateSocialInteractionForPets;
using virtualPetCare.Application.SocialInteractionOperations.Queries.GetSocialInteractionById;

namespace virtualPetCare.Controllers
{
    [ApiController]
    [Route("api/socialInteractions")]
    public class SocialInteractionController : ControllerBase
    {
        private readonly CreateSocialInteractionForPetCommand _createSocialInteractionCommand;
        private readonly GetSocialInteractionByIdQuery _getSocialInteractionByIdQuery;

        public SocialInteractionController(CreateSocialInteractionForPetCommand createSocialInteractionCommand, GetSocialInteractionByIdQuery getSocialInteractionByIdQuery)
        {
            _createSocialInteractionCommand = createSocialInteractionCommand;
            _getSocialInteractionByIdQuery = getSocialInteractionByIdQuery;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateSocialInteractionForPetModelDto modelDto)
        {
            _createSocialInteractionCommand.Model = modelDto;
            _createSocialInteractionCommand.Handle();
            return StatusCode(201);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPetSocialInteractionById([FromRoute]int id)
        {
            _getSocialInteractionByIdQuery.petId = id;
            var petSocialInteractions= _getSocialInteractionByIdQuery.Handle();
            return Ok(petSocialInteractions);
        }


    }
}
