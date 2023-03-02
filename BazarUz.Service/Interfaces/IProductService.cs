using BazarUz.Domain.Entities;
using BazarUz.Service.DTOs;
using BazarUz.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarUz.Service.Interfaces
{
    public interface IProductService
    {
        Task<Response<Product>> CreateAsync(ProductDto productDto);
        Task<Response<Product>> DeleteAsync(long id);
        Task<Response<Product>> UpdateAsync(long id, ProductDto productDto);
        Task<Response<Product>> GetByIdAsync(long id);
        Task<Response<List<Product>>> GetAllAsync(Predicate<Product> predicate);
        Task<Response<List<Product>>> SearchAsync(string name, string categoryName, string minPrice, string MaxPrice);
        Task<Response<List<Product>>> RecommendationsAsync(User user);
    }
}
