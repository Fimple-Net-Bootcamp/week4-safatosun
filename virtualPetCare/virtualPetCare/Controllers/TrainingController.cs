using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virtualPetCare.Application.TrainingOperations.Commands.CreateTrainingForPet;
using virtualPetCare.Application.TrainingOperations.Queries.GetTrainingsForPetById;

namespace virtualPetCare.Controllers
{
    [ApiController]
    [Route("api/trainings")]
    public class TrainingController : ControllerBase
    {

        private readonly CreateTrainingForPetCommand _createTraining;
        private readonly GetTrainingsForPetByIdQuery _getTrainingsForPet;

        public TrainingController(CreateTrainingForPetCommand createTraining, GetTrainingsForPetByIdQuery getTrainingsForPet)
        {
            _createTraining = createTraining;
            _getTrainingsForPet = getTrainingsForPet;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateTrainingForPetModelDto model)
        {
            _createTraining.Model = model;
            _createTraining.Handle();
            return StatusCode(201);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            _getTrainingsForPet.PetId = id;
            var trainings=_getTrainingsForPet.Handle();
            return Ok(trainings);
        }

    }
}
