using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;

namespace LinkedDataProjectAPI.Infraestructure.Types.DTOs
{
    public class SearchValuesDto
    {
        public Data data { get; set; }
        public WarningEntities warnings { get; set; }
        public ErrorMessage errors { get; set; }

        public SearchValuesDto()
        {
            this.data = new Data();
            this.warnings = new WarningEntities();
            this.errors = new ErrorMessage();
        }

        public SearchValuesDto(Data data, WarningEntities warnings, ErrorMessage errors)
        {
            this.data = data;
            this.warnings = warnings;
            this.errors = errors;
        }
    }
}
