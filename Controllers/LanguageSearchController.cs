using LinkedDataProjectAPI.Controllers.DTOs;
using LinkedDataProjectAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace LinkedDataProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageSearchController : ControllerBase
    {
        private readonly ILanguageSearchService _langSvc;

        public LanguageSearchController(ILanguageSearchService langSvc)
        {
            _langSvc = langSvc;
        }

        /// <summary>
        /// Search for language names in any script.
        /// </summary>
        /// <param name="lang"> String to look for languages.</param>
        /// <param name="typos"> Number of spelling mistakes allowed in the search string.</param>
        /// <returns> 
        /// Result: Information returned by the data supplier.
        /// Error: Errors ocurred while recovering the information.
        /// Warning: Warnings occurred while recovering the information.
        /// Succeeded: True if the API could respond.
        /// </returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType ((int) HttpStatusCode.OK, Type = typeof(ResponseDto<IDictionary<string, string>>))]
        public IActionResult GetSingleEntity([FromQuery] string lang, [FromQuery] int typos = 1)
        {
            var result = _langSvc.GetLanguagesStartingWith(lang, typos);
            return Ok(new ResponseDto<IDictionary<string, string>>
            {
                Result = result.result,
                Error = result.errors,
                Warning = result.warnings,
                Succeeded = true
            });
        }
    }
}
