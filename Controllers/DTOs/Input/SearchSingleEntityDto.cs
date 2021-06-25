namespace LinkedDataProjectAPI.Controllers.DTOs
{
    public class SearchSingleEntityDto
    {
        /// <summary>
        /// Id of the entity to get data from.
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Filter languages on which the returned values will be available.
        /// </summary>
        public string[] languages { get; set; }
        /// <summary>
        /// The names of the properties to get back from each entity.
        /// </summary>
        public string[] props { get; set; }
    }
}
