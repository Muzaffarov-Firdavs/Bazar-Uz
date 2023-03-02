using BazarUz.Data.IRepositories;
using BazarUz.Domain.Entities;
using BazarUz.Domain.Enums;
using BazarUz.Service.DTOs;
using BazarUz.Service.Helpers;
using BazarUz.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarUz.Service.Sevices
{
    public class UserService : IUserService
    {

        private readonly IRepository<User> userReository;
        private readonly ICartService cartService = new CartService();

        public async Task<Response<User>> CheckLogin(string username, string password)
        {
            var users = await userReository.GetAllAsync();

            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return new Response<User>
                    {
                        StatusCode = 200,
                        Message = "Success",
                        Result = user
                    };
                }
            }

            return new Response<User>();
        }

        public async Task<Response<User>> CreateAsync(UserDto userDto)
        {
            var user = (await userReository.GetAllAsync(x => x.Username == userDto.Username)).FirstOrDefault();

            if (user is null)
            {
                return new Response<User>
                {
                    StatusCode = 405,
                    Message = "Already created",
                    Result = null
                };
            }

            var newUser = new User
            {
                CreatedAt = DateTime.UtcNow,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password,
                Username = userDto.Username,
                Phone = userDto.Phone,
                Role = UserRole.Customer
            };

            var result = await userReository.CreateAsync(newUser);

            await cartService.CreateAsync(result.Id);

            return new Response<User>
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }

        public Task<Response<User>> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<User>>> GetAllAsync(Predicate<User> predicate)
        {
            var result = await userReository.GetAllAsync(predicate);

            return new Response<List<User>>
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }

        public async Task<Response<User>> GetByIdAsync(long id)
        {
            var model = await userReository.GetByIdAsync(id);
            if (model is null) 
            {
                return new Response<User>();
            }

            return new Response<User>
            {
                StatusCode = 200,
                Message = "Success",
                Result = model
            };
        }

        public async Task<Response<User>> UpdateAsync(long id, UserDto userDto)
        {
            var users = await userReository.GetAllAsync();
            var user = users.FirstOrDefault(x => x.Id == id);

            if (user is null)
            {
                return new Response<User>();
            }

            if (user.Username != userDto.Username)
            {
                var userWithUsername = users.FirstOrDefault(x => x.Username == userDto.Username);
                if (userWithUsername is not null) 
                {
                    return new Response<User>
                    {
                        StatusCode = 405,
                        Message = "Already taken",
                    };
                }
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Phone = userDto.Phone;
            user.Username = userDto.Username;
            user.Password = userDto.Password;
            user.UpdatedAt = DateTime.UtcNow;

            var result = await userReository.UpdateAsync(user);

            return new Response<User>
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }
    }
}
