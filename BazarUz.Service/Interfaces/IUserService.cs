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
    public interface IUserService
    {
        Task<Response<User>> CreateAsync(UserDto userDto);
        Task<Response<User>> DeleteAsync(long id);
        Task<Response<User>> GetByIdAsync(long id);
        Task<Response<User>> UpdateAsync(long id,UserDto userDto);
        Task<Response<User>> CheckLogin(string username, string password);
        Task<Response<List<User>>> GetAllAsync(Predicate<User> predicate);
    }
}
