using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarUz.Service.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> SearvhTags { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public long CategoryId { get; set; }
    }
}
