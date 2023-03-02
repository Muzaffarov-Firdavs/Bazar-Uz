using BazarUz.Domain.Entities;
using BazarUz.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarUz.Service.Interfaces
{
    public interface ICartService
    {
        Task<Response<Cart>> CreateAsync(long userId);
        Task<Response<Cart>> UpdateAsync(Cart cart);
        Task<Response<Cart>> GetAsync(long userId);
        Task<Response<List<Cart>>> GetAllAsync(Predicate<Cart> predicate);
        Task<Response<decimal>> GetTotalPriceAsync(Cart cart);
    }
}
