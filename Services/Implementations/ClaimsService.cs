using LinkedDataProjectAPI.Infraestructure;
using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Infraestructure.Types.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Data;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;
using LinkedDataProjectAPI.Repository;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Services.Implementations
{
    public interface IClaimsService
    {
        public SearchValuesDto<IDictionary<string, IList<Claim>>> GetClaims(string entity = null, string claim = null, string property = null, string rank = null, string props = null);
    }

    public class ClaimsService : IClaimsService
    {
        private const string OPERATION = "wbgetclaims";
        private readonly IWikidataRepository _wikiRepo;

        public ClaimsService(IWikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public SearchValuesDto<IDictionary<string, IList<Claim>>> GetClaims (string entity = null, string claim = null, string property = null, string rank = null, string props = null)
        {
            if (entity != null)
            {
                return GetClaimsForId("entity", entity, property, rank, props);
            }
            else if (claim != null)
            {
                return GetClaimsForId("claim", claim, property, rank, props);
            }
            return new SearchValuesDto<IDictionary<string, IList<Claim>>>();         
        }


        private SearchValuesDto<IDictionary<string, IList<Claim>>> GetClaimsForId (string propName, string id, string property = null, string rank = null, string props = null)
        {
            string qs = Utils.ConcatenateToUrl(propName, id);
            qs += Utils.ConcatenateToUrl("property", property);
            qs += Utils.ConcatenateToUrl("rank", rank);
            qs += Utils.ConcatenateToUrl("props", props);
            var stringData = _wikiRepo.PerformAction(OPERATION, qs);
            try
            {
                var data = JsonConvert.DeserializeObject<ClaimList>(stringData);
                Utils.SplitDataValue(ref data);
                var warnings = JsonConvert.DeserializeObject<WarningEntities>(stringData);
                var errors = JsonConvert.DeserializeObject<ErrorMessage>(stringData);
                return new SearchValuesDto<IDictionary<string, IList<Claim>>>(data.claims, warnings, errors);
            }
            catch (JsonException)
            {
                Log.Error("Something went wrong parsing the query response.");
                return new SearchValuesDto<IDictionary<string, IList<Claim>>>();
            }
        }

    }
}
