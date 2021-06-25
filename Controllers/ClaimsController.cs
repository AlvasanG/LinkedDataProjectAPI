using LinkedDataProjectAPI.Controllers.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        /// Gets Wikibase claims.
        /// </summary>
        /// <param name="entity">ID of the entity from which to obtain claims.</param>
        /// <param name="property">Optional filter to only return claims with a main snak that has the specified property.</param>
        /// <param name="rank">Optional filter to return only the claims that have the specified rank.</param>
        /// <param name="props">Controls which parts of the claim are returned.</param>
        /// <returns> 
        /// Result: Information returned by the data source.
        /// Error: Errors ocurred while recovering the information.
        /// Warning: Warnings occurred while recovering the information.
        /// Succeeded: True if the API could respond.
        /// </returns>
        [HttpGet]
        [Route("/entity")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDto<IDictionary<string, IList<Claim>>>))]
        public IActionResult GetClaimsByEntity([FromQuery][Required] string entity, [FromQuery] string property, [FromQuery] string rank, [FromQuery] string props)
        {
            var result = _claimsSvc.GetClaims(entity: entity, property: property, rank: rank, props: props);
            return Ok(new ResponseDto<IDictionary<string, IList<Claim>>>
            {
                Result = result.result,
                Error = result.errors,
                Warning = result.warnings,
                Succeeded = true
            });
        }

        /// <summary>
        /// Gets Wikibase claims
        /// </summary>
        /// <param name="claim">A GUID identifying the claim. GUID is the Globally Unique Identifier for a claim.</param>
        /// <param name="property">Optional filter to only return claims with a main snak that has the specified property.</param>
        /// <param name="rank">Optional filter to return only the claims that have the specified rank.</param>
        /// <param name="props">Controls which parts of the claim are returned.</param>
        /// <returns> 
        /// Result: Information returned by the data source.
        /// Error: Errors ocurred while recovering the information.
        /// Warning: Warnings occurred while recovering the information.
        /// Succeeded: True if the API could respond.
        /// </returns>
        [HttpGet]
        [Route("/claimGUID")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseDto<IDictionary<string, IList<Claim>>>))]
        public IActionResult GetClaimsByClaimGUID([FromQuery] string claim, [FromQuery] string property, [FromQuery] string rank, [FromQuery] string props)
        {
            var result = _claimsSvc.GetClaims(claim: claim, property: property, rank: rank, props: props);
            return Ok(new ResponseDto<IDictionary<string, IList<Claim>>>
            {
                Result = result.result,
                Error = result.errors,
                Warning = result.warnings,
                Succeeded = true
            });
        }

    }
}
