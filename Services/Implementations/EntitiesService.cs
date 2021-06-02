using LinkedDataProjectAPI.Infraestructure;
using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Infraestructure.Types.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;
using LinkedDataProjectAPI.Repository;
using Newtonsoft.Json;
using Serilog;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace LinkedDataProjectAPI.Services.Implementations
{

    public interface IEntitiesService
    {

        public SearchValuesDto GetEntities(string[] ids, string[] languages, string[] props);

        public SearchValuesDto GetSingleEntity(string id);


    }

    public class EntitiesService : IEntitiesService
    {
        private const string OPERATION = "wbgetentities";
        private readonly IWikidataRepository _wikiRepo;

        public EntitiesService(IWikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public SearchValuesDto GetSingleEntity(string id)
        {
            if(id == null || id.Trim() == "")
            {
                return new SearchValuesDto();
            }
            if(id.First() != 'Q' && id.First() != 'P' && id.First() != 'q' && id.First() != 'p')
            {
                return new SearchValuesDto();
            }
            return GetEntities(new string[] { id });
        }

        public SearchValuesDto GetEntities(string[] ids, string[] languages = null, string[] props = null)
        {
            if(ids == null || ids.Length < 1)
            {
                return new SearchValuesDto();
            }
            string qs = Utils.ConcatenateToUrl("ids", ids);
            if (languages != null)
            {
                qs += Utils.ConcatenateToUrl("languages", languages);
            }
            if(props != null)
            {
                //if (!Utils.CheckCorrectParametersGetEntities(props))
                //{
                //    throw new ArgumentException("Some parameters (props) are not supported for this operation");
                //}
                qs += Utils.ConcatenateToUrl("props", props);
            }
            var stringData = _wikiRepo.PerformAction(OPERATION, qs);
            try
            {
                //var data = Utils.BuildDataFromJson(stringData);
                var data = JsonConvert.DeserializeObject<Data>(stringData);
                var warnings = JsonConvert.DeserializeObject<WarningEntities>(stringData);
                var errors = JsonConvert.DeserializeObject<ErrorMessage>(stringData);
                return new SearchValuesDto(data, warnings, errors);
            }
            catch (JsonException)
            {
                Log.Error("Something went wrong parsing the query response.");
                return new SearchValuesDto();
            }
        }
    }
}
