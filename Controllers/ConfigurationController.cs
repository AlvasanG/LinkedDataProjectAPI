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
    public class ConfigurationController : ControllerBase
    {
        private readonly IWikidataService _wikidata;

        public ConfigurationController(IWikidataService wikidata)
        {
            _wikidata = wikidata;
        }

        [HttpPost]
        [Route("/ChangeUrl")]
        public bool SetUrl([FromQuery] string newUrl)
        {
            return _wikidata.SetUrl(newUrl);
        }
    }
}
