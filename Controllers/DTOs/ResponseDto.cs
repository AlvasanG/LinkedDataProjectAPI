using LinkedDataProjectAPI.Infraestructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Controllers.DTOs
{
    public class ResponseDto<T>
    {
        public T Result { get; set; }
        public bool Succeeded { get; set; }
        public ErrorMessage Error { get; set; }
        public Warning Warning { get; set; }
    }
}
