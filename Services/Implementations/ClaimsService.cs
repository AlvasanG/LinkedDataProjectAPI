using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Services.Implementations
{
    public interface IClaimsService
    {
        public IDictionary<string, IList<Claim>> GetClaims(string entity = null, string claim = null, string property = null, string rank = null, string props = null);
    }

    public class ClaimsService : IClaimsService
    {
        private const string OPERATION = "wbgetclaims";
        private readonly IWikidataRepository _wikiRepo;

        public ClaimsService(IWikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public IDictionary<string, IList<Claim>> GetClaims (string entity = null, string claim = null, string property = null, string rank = null, string props = null)
        {
            if (entity != null || entity.Trim() != "")
            {
                return GetClaimsForId(entity, property, rank, props);
            }
            else if (claim != null || claim.Trim() != "")
            {
                return GetClaimsForId(claim, property, rank, props);
            }
            return new Dictionary<string, IList<Claim>>();
            
        }


        private IDictionary<string, IList<Claim>> GetClaimsForId (string id, string property = null, string rank = null, string props = null)
        {
            //rank has to be between -> deprecated, normal, preferredç
            //props has to be -> references
            //property has to start with -> pP
            return null;
        }

    }
}
