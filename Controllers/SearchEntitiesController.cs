using LinkedDataProjectAPI.Controllers.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types.SearchEntities.Data;
using LinkedDataProjectAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;


namespace LinkedDataProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchEntitiesController : ControllerBase
    {
        private readonly ISearchEntitiesService _searchSvc;

        public SearchEntitiesController(ISearchEntitiesService searchEntitiesService)
        {
            _searchSvc = searchEntitiesService;
        }

        /// <summary>
        /// Search for entities using labels and aliases.
        /// </summary>
        /// <param name="search">Search for this text.</param>
        /// <param name="language">Search in this language. Affects how entities are selected, not the result.</param>
        /// <param name="useLang">Search in this language. Defines the language on which the entities are returned.</param>
        /// <param name="strict">Whether to disable language fallback.</param>
        /// <param name="type">Search for this type of entity.</param>
        /// <param name="limit">Maximal number of results.</param>
        /// <param name="continueFrom">Offset where to continue a search.</param>
        /// <param name="props">Return these properties for each entity.</param>
        /// <returns> 
        /// Result: Information returned by the data source.
        /// Error: Errors ocurred while recovering the information.
        /// Warning: Warnings occurred while recovering the information.
        /// Succeeded: True if the API could respond.
        /// </returns>
        [HttpGet]
        [Route("/")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDto<SearchResultObj>))]
        public IActionResult GetSearchEntities([FromQuery][Required] string search, [FromQuery][Required] string language, [FromQuery] string useLang, [FromQuery] bool strict = false, [FromQuery] string type = "item",
            [FromQuery] int limit = 7, [FromQuery] int continueFrom = 0, [FromQuery] string props = "url")
        {
            var result = _searchSvc.GetSearchEntities(search, language, strict, type, limit, continueFrom, props, useLang);
            return Ok(new ResponseDto<SearchResultObj>
            {
                Result = result.result,
                Error = result.errors,
                Warning = result.warnings,
                Succeeded = true
            });
        }
    }
}
