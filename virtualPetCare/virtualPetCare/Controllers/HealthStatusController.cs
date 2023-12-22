using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using virtualPetCare.Application.HealthStatus.Commands.PatchHealthStatus;
using virtualPetCare.Application.HealthStatusOperations.Queries.GetHealthStatusByIdQuery;

namespace virtualPetCare.Controllers
{    
    [ApiController]
    [Route("api/v1/healthStatuses")]
    public class HealthStatusController : ControllerBase
    {
        private readonly GetHealthStatusByIdQuery _healthStatusByIdQuery;
        private readonly PatchHealthStatusCommand _patchHealthStatusCommand;

        public HealthStatusController(GetHealthStatusByIdQuery healthStatusByIdQuery, PatchHealthStatusCommand patchHealthStatusCommand)
        {
            _healthStatusByIdQuery = healthStatusByIdQuery;
            _patchHealthStatusCommand = patchHealthStatusCommand;
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            _healthStatusByIdQuery.PetId = id;
            var healthStatus = _healthStatusByIdQuery.Handle();
            return Ok(healthStatus);
        }
        
        [HttpPatch("{id:int}")]
        public IActionResult Patch([FromRoute] int id, [FromBody] JsonPatchDocument<PatchHealthStatusModelDto> jsonPatch)
        {
            _patchHealthStatusCommand.PetId = id;
            _patchHealthStatusCommand.Model = jsonPatch;
            _patchHealthStatusCommand.Handle();
            return Ok();
        }

    }
}
 