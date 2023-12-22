using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virtualPetCare.Application.FoodOperations.Commands.CreateFoodForPets;
using virtualPetCare.Application.FoodOperations.Queries.GetFoods;

namespace virtualPetCare.Controllers
{    
    [ApiController]
    [Route("api/v1/foods")]
    public class FoodController : ControllerBase
    {
        private readonly GetFoodsQuery _getFoodsQuery;
        private readonly CreateFoodForPetCommand _createFoodForPetCommand;

        public FoodController(GetFoodsQuery getFoodsQuery, CreateFoodForPetCommand createFoodForPetCommand)
        {
            _getFoodsQuery = getFoodsQuery;
            _createFoodForPetCommand = createFoodForPetCommand;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var foods = _getFoodsQuery.Handle();
            return Ok(foods);
        }
        

        [HttpPost("{id:int}")]
        public IActionResult Create([FromRoute] int id,[FromBody]CreateFoodForPetModelDto createFoodForPetModel)
        {
            _createFoodForPetCommand.PetId = id;
            _createFoodForPetCommand.Model = createFoodForPetModel;
            _createFoodForPetCommand.Handle();
            return StatusCode(201);
        }

    }
}
