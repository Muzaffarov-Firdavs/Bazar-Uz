using BazarUz.Domain.Commons;

namespace BazarUz.Domain.Entities
{
    public class Category : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
