using BazarUz.Domain.Commons;

namespace BazarUz.Domain.Entities
{
    public class Cart : Auditable
    {
        public List<Product> Items { get; set; }
        public long UserId { get; set; }
    }
}
