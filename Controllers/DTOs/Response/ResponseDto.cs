using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;

namespace LinkedDataProjectAPI.Controllers.DTOs
{
    public class ResponseDto<T>
    {
        public WarningEntities Warning { get; set; }
        public T Result { get; set; }
        public ErrorMessage Error { get; set; }
        public bool Succeeded { get; set; }
    }
}
