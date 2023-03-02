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
    public interface ICategoryService
    {
        Task<Response<Category>> CreateAsync(CategoryDto categoryDto);
        Task<Response<Category>> UpdateAsync(long id, CategoryDto categoryDto);
        Task<Response<Category>> DeleteAsync(long id);
        Task<Response<Category>> GetByIdAsync(long id);
        Task<Response<List<Category>>> GetAllAsync(Predicate<Category> predicate);   
    }
}
