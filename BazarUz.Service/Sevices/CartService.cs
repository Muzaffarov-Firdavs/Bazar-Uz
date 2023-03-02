using BazarUz.Data.IRepositories;
using BazarUz.Data.Repositories;
using BazarUz.Domain.Entities;
using BazarUz.Service.Helpers;
using BazarUz.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BazarUz.Service.Sevices
{
    public class CartService : ICartService
    {

        private IRepository<Cart> cartRepository = new Repository<Cart>();

        public async Task<Response<Cart>> CreateAsync(long userId)
        {
            var model = (await cartRepository.GetAllAsync(x => x.UserId == userId)).FirstOrDefault();

            if (model is not null)
            {
                return new Response<Cart>
                {
                    StatusCode = 405,
                    Message = "Already created",
                    Result = null
                };
            }

            var result = await cartRepository.CreateAsync(
                new Cart
                {
                    UserId = userId,
                    CreatedAt = DateTime.Now,
                    Items = new List<Product>()
                });

            return new Response<Cart>
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }

        public async Task<Response<List<Cart>>> GetAllAsync(Predicate<Cart> predicate)
        {
            var models = await cartRepository.GetAllAsync();

            return new Response<List<Cart>>
            {
                StatusCode = 200,
                Message = "Success",
                Result = models
            };
        }

        public async Task<Response<Cart>> GetAsync(long userId)
        {
            var model = (await cartRepository.GetAllAsync(x => x.UserId == userId)).FirstOrDefault();

            if (model is null)
            {
                return new Response<Cart>();
            }

            return new Response<Cart>
            {
                StatusCode = 200,
                Message = "Success",
                Result = model
            };
        }

        public async Task<Response<decimal>> GetTotalPriceAsync(Cart cart)
        {
            decimal shippingPrice = 100;
            decimal totalPrice = 0;

            foreach (var pro in cart.Items)
            {
                totalPrice += pro.Price;
            }

            decimal result = totalPrice + shippingPrice;

            return new Response<decimal>
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }

        public async Task<Response<Cart>> UpdateAsync(Cart cart)
        {
            var cartUpdate = (await cartRepository.GetAllAsync(x => x.Id == cart.Id)).FirstOrDefault();

            if (cartUpdate is null)
            {
                return new Response<Cart>();
            }

            cart.CreatedAt = cartUpdate.CreatedAt;
            cart.UpdatedAt = DateTime.Now;

            var result = await cartRepository.UpdateAsync(cart);

            return new Response<Cart>
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }
    }
}
