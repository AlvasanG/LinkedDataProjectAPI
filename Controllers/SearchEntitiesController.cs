using LinkedDataProjectAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchEntitiesController
    {
        private readonly ISearchEntitiesService _searchSvc;

        public SearchEntitiesController(ISearchEntitiesService searchEntitiesService)
        {
            _searchSvc = searchEntitiesService;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult GetSearchEntities([FromQuery] string search, [FromQuery] string language, [FromQuery] bool strict, [FromQuery] string type = "item",
            [FromQuery] int limit = 7, [FromQuery] int continueFrom = 0, [FromQuery] string props = "url")
        {
            return null;
        }
    }
}
