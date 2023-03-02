using BazarUz.Domain.Commons;
using BazarUz.Domain.Enums;

namespace BazarUz.Domain.Entities
{
    public class Order : Auditable
    {
        public List<Product> Items { get; set; }
        public long UserId { get; set; }
        public string Address { get; set; }
        public OrderProcess Progress { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
