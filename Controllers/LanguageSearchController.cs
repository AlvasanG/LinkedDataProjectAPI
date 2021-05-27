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
    public class LanguageSearchController : ControllerBase
    {
        private readonly ILanguageSearchService _langSvc;

        public LanguageSearchController(ILanguageSearchService langSvc)
        {
            _langSvc = langSvc;
        }

        [HttpGet]
        [Route("")]
        public void GetSingleEntity([FromQuery] string lang)
        {
            var result = _langSvc.GetLanguagesStartingWith(lang);
            // construct an ok with result = result
            // check how to return an Ok dto and define it within []
        }
    }
}
