using BazarUz.Domain.Entities;
using BazarUz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarUz.Service.DTOs
{
    public class OrderDto
    {
        public List<Product> Items { get; set; }
        public long UserId { get; set; }
        public string Address { get; set; }
        public OrderProcess Progress { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
