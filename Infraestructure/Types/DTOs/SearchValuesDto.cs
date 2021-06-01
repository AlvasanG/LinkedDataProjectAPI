﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types.DTOs
{
    public class SearchValuesDto
    {
        public Data data { get; set; }
        public Warning warnings { get; set; }
        public ErrorMessage errors { get; set; }

        public SearchValuesDto()
        {
            data = new Data();
            warnings = new Warning();
            errors = new ErrorMessage();
        }

        public SearchValuesDto(Data data, Warning warnings, ErrorMessage errors)
        {
            this.data = data;
            this.warnings = warnings;
            this.errors = errors;
        }
    }
}
