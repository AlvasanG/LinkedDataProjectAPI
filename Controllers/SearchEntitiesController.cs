using LinkedDataProjectAPI.Controllers.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types.SearchEntities.Data;
using LinkedDataProjectAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("/")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDto<SearchResultObj>))]
        public IActionResult GetSearchEntities([FromQuery] string search, [FromQuery] string language, [FromQuery] string useLang, [FromQuery] bool strict = false, [FromQuery] string type = "item",
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
