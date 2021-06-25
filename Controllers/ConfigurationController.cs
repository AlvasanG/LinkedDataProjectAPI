using LinkedDataProjectAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        /// Changes the data source. Must suffice https://www.example.org/w/api.php format.
        /// </summary>
        /// <param name="newDataSource">New data source.</param>
        /// <returns>True if the new data supplier is valid. False otherwise.</returns>
        [HttpPost]
        [Route("/ChangeDataUrl")]
        public bool SetUrl([FromQuery][Required] string newDataSource)
        {
            return _wikidata.SetUrl(newDataSource);
        }
    }
}
