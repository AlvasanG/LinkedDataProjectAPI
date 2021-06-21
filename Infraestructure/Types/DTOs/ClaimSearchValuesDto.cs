using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types.DTOs
{
    public class ClaimSearchValuesDto
    {
        public IDictionary<string, IList<Claim>> claims { get; set; }
        public WarningEntities warnings { get; set; }
        public ErrorMessage errors { get; set; }

        public ClaimSearchValuesDto()
        {
            this.claims = new Dictionary<string, IList<Claim>>();
            this.warnings = new WarningEntities();
            this.errors = new ErrorMessage();
        }

        public ClaimSearchValuesDto(IDictionary<string, IList<Claim>> claims, WarningEntities warnings, ErrorMessage errors)
        {
            this.claims = claims;
            this.warnings = warnings;
            this.errors = errors;
        }
    }
}
