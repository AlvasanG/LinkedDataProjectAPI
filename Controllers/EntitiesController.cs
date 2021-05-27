using LinkedDataProjectAPI.Controllers.DTOs;
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
    public class EntitiesController : ControllerBase
    {
        private readonly IEntitiesService _entitySvc;

        public EntitiesController(IEntitiesService entitySvc)
        {
            _entitySvc = entitySvc;
        }

        [HttpGet]
        [Route("/single")]
        public void GetSingleEntity([FromQuery] string id)
        {
            var result = _entitySvc.GetSingleEntity(id);
            // construct an ok with result = result
            // check how to return an Ok dto and define it within []
        }

        [HttpGet]
        [Route("/multiple")]
        public void GetMultipleEntities([FromQuery] SearchEntityDto search)
        {
            var result = _entitySvc.GetEntities(search.ids, search.languages, search.props);
            // construct an ok with result = result
            // check how to return an Ok dto and define it within []
        }
    }
}
