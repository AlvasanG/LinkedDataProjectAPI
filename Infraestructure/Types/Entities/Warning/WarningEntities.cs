namespace LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning
{
    public class WarningEntities
    {
        public Warnings warnings { get; set; }

        public WarningEntities()
        {
            this.warnings = new Warnings();
        }
    }
}
