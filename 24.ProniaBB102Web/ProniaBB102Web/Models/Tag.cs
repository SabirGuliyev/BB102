namespace ProniaBB102Web.Models
{
    public class Tag : BaseEntity
    {
        
        public string Name { get; set; }

        public List<ProductTag> ProductTags { get; set; }
    }
}
