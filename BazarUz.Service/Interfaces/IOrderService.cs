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
    public interface IOrderService
    {
        Task<Response<Order>> CreateAsync(Order order);
        Task<Response<Order>> UpdateAsync(long id, OrderDto orderDto);
        Task<Response<Order>> DeleteAsync(long id);
        Task<Response<Order>> GetByIdAsync(long id);
        Task<Response<Order>> UpdateToNextProcessAsync(long id);
        Task<Response<List<Order>>> GetAllAsync(Predicate<Order> predicate);
    }
}
