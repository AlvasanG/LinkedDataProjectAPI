namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class EntityId
    {
        public string entityType { get; set; }
        public int numericId { get; set; }

        public EntityId()
        {
            entityType = string.Empty;
            numericId = 0;
        }

        public EntityId(string entity, int id)
        {
            this.entityType = entity;
            this.numericId = id;
        }
    }
}
