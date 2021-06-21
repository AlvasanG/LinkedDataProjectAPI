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
        public ClaimSearchValuesDto GetClaims(string entity = null, string claim = null, string property = null, string rank = null, string props = null);
    }

    public class ClaimsService : IClaimsService
    {
        private const string OPERATION = "wbgetclaims";
        private readonly IWikidataRepository _wikiRepo;

        public ClaimsService(IWikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public ClaimSearchValuesDto GetClaims (string entity = null, string claim = null, string property = null, string rank = null, string props = null)
        {
            if (entity != null && entity.Trim() != "")
            {
                return GetClaimsForId("entity", entity, property, rank, props);
            }
            else if (claim != null && claim.Trim() != "")
            {
                return GetClaimsForId("claim", claim, property, rank, props);
            }
            return new ClaimSearchValuesDto();         
        }


        private ClaimSearchValuesDto GetClaimsForId (string propName, string id, string property = null, string rank = null, string props = null)
        {
            string qs = Utils.ConcatenateToUrl(propName, id);
            if (property != null && (property.First() == 'P' || property.First() == 'p'))
            {
                qs += Utils.ConcatenateToUrl("property", property);
            }
            if (rank != null)
            {
                if(Utils.CheckCorrectParameters(new string[] { rank }, Utils._supportedClaimsRanks))
                {
                    qs += Utils.ConcatenateToUrl("rank", rank);
                }
            }
            if(props != null)
            {
                if (Utils.CheckCorrectParameters(new string[] { props }, Utils._supportedClaimsProps))
                {
                    qs += Utils.ConcatenateToUrl("props", props);
                }
            }
            var stringData = _wikiRepo.PerformAction(OPERATION, qs);
            try
            {
                var data = JsonConvert.DeserializeObject<ClaimList>(stringData);
                Utils.SplitDataValue(ref data);
                var warnings = JsonConvert.DeserializeObject<WarningEntities>(stringData);
                var errors = JsonConvert.DeserializeObject<ErrorMessage>(stringData);
                return new ClaimSearchValuesDto(data.claims, warnings, errors);
            }
            catch (JsonException)
            {
                Log.Error("Something went wrong parsing the query response.");
                return new ClaimSearchValuesDto();
            }
        }

    }
}
