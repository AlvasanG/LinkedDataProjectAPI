using LinkedDataProjectAPI.Infraestructure;
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
        //private LanguageService _langServ;

        public GetEntitiesService(WikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public IDictionary<string, Entity> GetEntities(string[] ids, string[] languages = null, string[] props = null)
        {
            if(ids == null || ids.Length < 1)
            {
                throw new ArgumentException("Cannot find entities for an empty set of ids");
            }
            if(!Utils.CheckCorrectParametersGetEntities(props))// || !_langServ.CheckCorrectLanguages(languages))
            {
                throw new ArgumentException("Parameters are not correct to perform this operation");
            }
            string qs = ConcatenateToUrl("ids", ids);
            qs += ConcatenateToUrl("languages", languages);
            qs += ConcatenateToUrl("props", props);
            var stringData = _wikiRepo.PerformAction(OPERATION, qs);
            try
            {
                var data = JsonConvert.DeserializeObject<Data>(stringData);
                if (data.success == 1)
                {
                    return data.entities ?? throw new EntityNotFoundException(ids);
                }
            }
            catch (JsonException)
            {
                var data = JsonConvert.DeserializeObject<Error>(stringData);
                throw new UnsuccessfulOperationException(data.code, data.info);
            }
            return default;
        }


        private static string ConcatenateToUrl(string propName, string[] props)
        {
            if(props == null || props.Length < 1)
            {
                return "";
            }
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
