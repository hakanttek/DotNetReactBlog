using AutoMapper;
using ReactWebBlogger.Contracts;
using ReactWebBlogger.Contracts.Services;
using ReactWebBlogger.Contracts.Repositories;
using ReactWebBlogger.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReactWebBlogger.Application.DTOs;

namespace ReactWebBlogger.Application.Services
{
    public class UserService : IUserService<UserDto>, ICRUDService<UserDto> // Update interface to use BlogDto
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper; // Add AutoMapper

        public UserService(IUserRepository userRepository, IMapper mapper) // Inject IMapper
        {
            _userRepository = userRepository;
            _mapper = mapper; // Initialize IMapper
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user); // Map Blog to BlogDto
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var user = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(user); // Map IEnumerable<Blog> to IEnumerable<BlogDto>
        }

        public async Task AddAsync(UserDto userDto) // Update parameter to use BlogDto
        {
            var user = _mapper.Map<User>(userDto); // Map BlogDto to Blog
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task UpdateAsync(UserDto userDto) // Update parameter to use BlogDto
        {
            var existingBlog = await _userRepository.GetByIdAsync(userDto.Id);
            if (existingBlog == null)
            {
                // Handle not found scenario
                return;
            }

            _mapper.Map(userDto, existingBlog); // Map BlogDto properties to existingBlog
            _userRepository.Update(existingBlog);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
            await _userRepository.SaveAsync();
        }

        public async Task<UserDto?> GetUserByUsernameAsync(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            return _mapper.Map<UserDto>(user);
        }
    }
}
