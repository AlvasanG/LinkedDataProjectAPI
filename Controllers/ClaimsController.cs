using LinkedDataProjectAPI.Controllers.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LinkedDataProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimsService _claimsSvc;

        public ClaimsController(IClaimsService claimsService)
        {
            _claimsSvc = claimsService;
        }

        [HttpGet]
        [Route("/entity")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IDictionary<string, IList<Claim>>))]
        public IActionResult GetClaimsByEntity([FromQuery] string entity, [FromQuery] string property, [FromQuery] string rank, [FromQuery] string props)
        {
            return Ok(new ResponseDto<IDictionary<string, IList<Claim>>>
            {
                Result = _claimsSvc.GetClaims(entity: entity, property: property, rank: rank, props: props),
                Succeeded = true
            });
        }

        [HttpGet]
        [Route("/claimGUID")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IDictionary<string, IList<Claim>>))]
        public IActionResult GetClaimsByClaimGUID([FromQuery] string claim, [FromQuery] string property, [FromQuery] string rank, [FromQuery] string props)
        {
            return Ok(new ResponseDto<IDictionary<string, IList<Claim>>>
            {
                Result = _claimsSvc.GetClaims(claim: claim, property: property, rank: rank, props: props),
                Succeeded = true
            });
        }

    }
}
