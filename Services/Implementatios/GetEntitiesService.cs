using LinkedDataProjectAPI.Infraestructure.Exceptions;
using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Services.Implementatios
{

    public interface IGetEntitiesService
    {
        public IDictionary<string, Entity> GetEntities(string[] ids, string[] languages, string[] props);
        
    }

    public class GetEntitiesService : IGetEntitiesService
    {
        private const string OPERATION = "wbgetentities";
        private WikidataRepository _wikiRepo;

        public GetEntitiesService(WikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public IDictionary<string, Entity> GetEntities(string[] ids, string[] languages, string[] props)
        {
            string qs = ConcatenateToUrl("ids", ids);
            qs += ConcatenateToUrl("languages", languages);
            qs += ConcatenateToUrl("props", props);
            var stringData = _wikiRepo.PerformAction(OPERATION, qs);
            var data = JsonConvert.DeserializeObject<Data>(stringData);
            if (data.entities != null) //improve by checking warnings and successes
            {
                return data.entities;
            }
            else
            {
                throw new EntityNotFoundException(ids[0]);
            }
        }

        private string ConcatenateToUrl(string propName, string[] props)
        {
            var qs = "&" + propName + "=";
            for (var i = 0; i < props.Length; i++)
            {
                if (i == 0 && props.Length > 1)
                {
                    qs += props[i] + "|";
                }
                else if (i == props.Length - 1)
                {
                    qs += props[i];
                }
                else
                {
                    qs += props[i] + "|";
                }
            }
            return qs;
        }
    }
}
