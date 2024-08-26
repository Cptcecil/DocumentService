using DocumentService.Application.DTOs;
using DocumentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentService.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(CreateUserDto user);
        Task UpdateUserAsync(int id, CreateUserDto user);
        Task DeleteUserAsync(int id);
    }
}
