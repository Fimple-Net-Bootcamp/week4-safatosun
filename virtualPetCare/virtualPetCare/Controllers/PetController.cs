using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virtualPetCare.Application.PetOperations.Commands.CreatePet;
using virtualPetCare.Application.PetOperations.Commands.UpdatePet;
using virtualPetCare.Application.PetOperations.Queries.GetPetById;
using virtualPetCare.Application.PetOperations.Queries.GetPets;
using virtualPetCare.Application.PetOperations.Queries.GetPetStatisticsById;

namespace virtualPetCare.Controllers
{    
    [ApiController]
    [Route("api/v1/pets")]
    public class PetController : ControllerBase
    {
        private readonly CreatePetCommand _createPetCommand;
        private readonly GetPetByIdQuery _getPetByIdQuery;
        private readonly GetPetsQuery _getPetsQuery;
        private readonly UpdatePetCommand _updatePetCommand;
        private readonly GetPetStatisticsByIdQuery _getPetStatisticsByIdQuery;

        public PetController(CreatePetCommand createPetCommand, GetPetByIdQuery getPetByIdQuery, GetPetsQuery getPetsQuery, UpdatePetCommand updatePetCommand, GetPetStatisticsByIdQuery getPetStatisticsByIdQuery)
        {
            _createPetCommand = createPetCommand;
            _getPetByIdQuery = getPetByIdQuery;
            _getPetsQuery = getPetsQuery;
            _updatePetCommand = updatePetCommand;
            _getPetStatisticsByIdQuery = getPetStatisticsByIdQuery;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pets = _getPetsQuery.Handle();
            return Ok(pets);    
        }
         

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            _getPetByIdQuery.PetId = id;
            var pet = _getPetByIdQuery.Handle();
            return Ok(pet); 
        }

        [HttpGet("statistics/{id:int}")]
        public IActionResult GetStatisticsById([FromRoute]int id)
        {
            _getPetStatisticsByIdQuery.PetId = id;
            var petStatisticsVm = _getPetStatisticsByIdQuery.Handle();    
            return Ok(petStatisticsVm);

        }


        [HttpPost]
        public IActionResult Create([FromBody]CreatePetModelDto createPetModel)
        {
            _createPetCommand.Model = createPetModel;
            var pet = _createPetCommand.Handle();
            return CreatedAtAction(nameof(GetById), new {id=pet.Id},pet);
        }
         

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute]int id,[FromBody]UpdatePetModelDto updatePetModel)
        {
            _updatePetCommand.PetId= id;    
            _updatePetCommand.Model= updatePetModel;
            _updatePetCommand.Handle();
            return Ok();

        }
        
    }
}
