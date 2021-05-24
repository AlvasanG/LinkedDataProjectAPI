using LinkedDataProjectAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Services.Implementatios
{

    public interface IGetEntitiesService
    {

    }

    public class GetEntitiesService : IGetEntitiesService
    {
        private const string OPERATION = "wbgetentities";
        private WikidataRepository _wikiRepo;

        public GetEntitiesService(WikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }
    }
}
