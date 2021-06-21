using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;

namespace LinkedDataProjectAPI.Controllers.DTOs
{
    public class ResponseDto<T>
    {
        public T Result { get; set; }
        public bool Succeeded { get; set; }
        public ErrorMessage Error { get; set; }
        public Warnings Warning { get; set; }
    }
}
