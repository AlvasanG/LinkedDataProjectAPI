using LinkedDataProjectAPI.Controllers.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Infraestructure.Types.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;
using LinkedDataProjectAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseEntitiesDto))]
        public IActionResult GetSingleEntity([FromQuery] string id)
        {
            var result = _entitySvc.GetSingleEntity(id);
            return Ok(new ResponseEntitiesDto
            {
                Result = result.data,
                Error = result.errors,
                Warning = result.warnings,
                Succeeded = true
            });
        }

        [HttpGet]
        [Route("/multiple")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseEntitiesDto))]
        public IActionResult GetMultipleEntities([FromQuery] SearchEntityDto search)
        {
            var result = _entitySvc.GetEntities(search.ids, search.languages, search.props);
            return Ok(new ResponseEntitiesDto
            {
                Result = result.data,
                Error = result.errors,
                Warning = result.warnings,
                Succeeded = true
            });
        }
    }
}
