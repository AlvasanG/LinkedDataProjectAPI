using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;

namespace LinkedDataProjectAPI.Controllers.DTOs
{
    public class ResponseEntitiesDto
    {
        public Data Result { get; set; }
        public bool Succeeded { get; set; }
        public ErrorMessage Error { get; set; }
        public WarningEntities Warning { get; set; }
    }
}
