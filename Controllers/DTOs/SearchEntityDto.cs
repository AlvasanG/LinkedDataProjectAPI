using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Controllers.DTOs
{
    public class SearchEntityDto
    {
        public string[] ids { get; set; }
        public string[] languages { get; set; }
        public string[] props { get; set; }
    }
}
