using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;

namespace LinkedDataProjectAPI.Infraestructure.Types.DTOs
{
    public class SearchValuesDto<T>
    {
        public T result { get; set; }
        public WarningEntities warnings { get; set; }
        public ErrorMessage errors { get; set; }

        public SearchValuesDto()
        {
            this.result = default;
            this.warnings = new WarningEntities();
            this.errors = new ErrorMessage();
        }

        public SearchValuesDto(T result, WarningEntities warnings, ErrorMessage errors)
        {
            this.result = result;
            this.warnings = warnings;
            this.errors = errors;
        }
    }
}
