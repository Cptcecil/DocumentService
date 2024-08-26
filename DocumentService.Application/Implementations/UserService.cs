using DocumentService.Application.DTOs;
using DocumentService.Application.Interfaces;
using DocumentService.Domain.Entities;
using DocumentService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentService.Application.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuditLogService _auditLogService;

        public UserService(IUserRepository userRepository, IAuditLogService auditLogService)
        {
            _userRepository = userRepository;
            _auditLogService = auditLogService;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> AddUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Email = createUserDto.Email,
                OrganizationId = createUserDto.OrganizationId
            };

            var newUser = await _userRepository.AddAsync(user);

            var auditLog = new AuditLog
            {
                Action = "Create",
                EntityName = nameof(User),
                EntityId = user.Id.ToString(),
                Username = "CurrentUsername",
                Changes = $"Created user with email: {user.Email}"
            };

            await _auditLogService.LogAsync(auditLog);

            return newUser;
        }

        public async Task UpdateUserAsync(int id, CreateUserDto createUserDto)
        {
            var user = await _userRepository.GetByIdAsync(id);

            user.Email = createUserDto.Email;
            user.OrganizationId = createUserDto.OrganizationId;

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
