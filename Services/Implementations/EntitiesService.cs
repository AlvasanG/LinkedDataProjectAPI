using LinkedDataProjectAPI.Infraestructure;
using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Infraestructure.Types.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;
using LinkedDataProjectAPI.Repository;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace LinkedDataProjectAPI.Services.Implementations
{

    public interface IEntitiesService
    {

        public EntitySearchValuesDto GetEntities(string[] ids, string[] languages, string[] props);

        public EntitySearchValuesDto GetSingleEntity(string id, string[] languages = null, string[] props = null);


    }

    public class EntitiesService : IEntitiesService
    {
        private const string OPERATION = "wbgetentities";
        private readonly IWikidataRepository _wikiRepo;

        public EntitiesService(IWikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public EntitySearchValuesDto GetSingleEntity(string id, string[] languages = null, string[] props = null)
        {
            if (id == null || id.Trim() == "")
            {
                return new EntitySearchValuesDto();
            }
            if (id.First() != 'Q' && id.First() != 'P' && id.First() != 'q' && id.First() != 'p')
            {
                return new EntitySearchValuesDto();
            }
            return GetEntities(new string[] { id }, languages, props);
        }

        public EntitySearchValuesDto GetEntities(string[] ids, string[] languages = null, string[] props = null)
        {
            if (ids == null || ids.Length < 1)
            {
                return new EntitySearchValuesDto();
            }
            string qs = Utils.ConcatenateToUrl("ids", ids);
            if (languages != null)
            {
                qs += Utils.ConcatenateToUrl("languages", languages);
            }
            if (props != null)
            {
                if (Utils.CheckCorrectParameters(props, Utils._supportedEntitiesParameters))
                {
                    qs += Utils.ConcatenateToUrl("props", props);
                }
            }
            var stringData = _wikiRepo.PerformAction(OPERATION, qs);
            try
            {
                var data = JsonConvert.DeserializeObject<Data>(stringData);
                Utils.SplitDataValue(ref data);
                var warnings = JsonConvert.DeserializeObject<WarningEntities>(stringData);
                var errors = JsonConvert.DeserializeObject<ErrorMessage>(stringData);
                return new EntitySearchValuesDto(data, warnings, errors);
            }
            catch (JsonException)
            {
                Log.Error("Something went wrong parsing the query response.");
                return new EntitySearchValuesDto();
            }
        }


    }
}
