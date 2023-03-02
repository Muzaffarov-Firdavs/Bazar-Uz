using BazarUz.Domain.Commons;

namespace BazarUz.Domain.Entities
{
    public class Product : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> SearvhTags { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public long CategoryId { get; set; }
    }
}
