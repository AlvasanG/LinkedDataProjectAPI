using LinkedDataProjectAPI.Controllers.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LinkedDataProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntitiesController : ControllerBase
    {
        private readonly IEntitiesService _entitySvc;

        public EntitiesController(IEntitiesService entitySvc)
        {
            _entitySvc = entitySvc;
        }

        [HttpGet]
        [Route("/single")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDto<Data>))]
        public IActionResult GetSingleEntity([FromQuery] SearchSingleEntityDto search)
        {
            var result = _entitySvc.GetSingleEntity(search.id, search.languages, search.props);
            return Ok(new ResponseDto<Data>
            {
                Result = result.result,
                Error = result.errors,
                Warning = result.warnings,
                Succeeded = true
            });
        }

        [HttpGet]
        [Route("/multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDto<Data>))]
        public IActionResult GetMultipleEntities([FromQuery] SearchEntityDto search)
        {
            var result = _entitySvc.GetEntities(search.ids, search.languages, search.props);
            return Ok(new ResponseDto<Data>
            {
                Result = result.result,
                Error = result.errors,
                Warning = result.warnings,
                Succeeded = true
            });
        }
    }
}
