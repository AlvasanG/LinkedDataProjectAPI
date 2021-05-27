using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types.DTOs
{
    public class SearchValuesDto
    {
        public Data data { get; set; }
        public Warning warnings { get; set; }
        public Error errors { get; set; }

        public SearchValuesDto()
        {
            data = new Data();
            warnings = new Warning();
            errors = new Error();
        }

        public SearchValuesDto(Data data, Warning warnings, Error errors)
        {
            this.data = data;
            this.warnings = warnings;
            this.errors = errors;
        }
    }
}
