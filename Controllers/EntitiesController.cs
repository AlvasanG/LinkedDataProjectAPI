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

        /// <summary>
        /// Gets the data for one Wikibase entity.
        /// </summary>
        /// <param name="search"><see cref="SearchSingleEntityDto"/></param>
        /// <returns> 
        /// Result: Information returned by the data source.
        /// Error: Errors ocurred while recovering the information.
        /// Warning: Warnings occurred while recovering the information.
        /// Succeeded: True if the API could respond.
        /// </returns>
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

        /// <summary>
        /// Gets the data for multiple Wikibase entities.
        /// </summary>
        /// <param name="search"><see cref="SearchEntityDto"/></param>
        /// <returns> 
        /// Result: Information returned by the data source.
        /// Error: Errors ocurred while recovering the information.
        /// Warning: Warnings occurred while recovering the information.
        /// Succeeded: True if the API could respond.
        /// </returns>
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
