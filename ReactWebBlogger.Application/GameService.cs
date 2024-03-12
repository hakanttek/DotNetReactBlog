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
    public class GameService : IGameService<GameDto>, ICRUDService<GameDto>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper; // Add AutoMapper

        public GameService(IGameRepository gameRepository, IMapper mapper) // Inject IMapper
        {
            _gameRepository = gameRepository;
            _mapper = mapper; // Initialize IMapper
        }

        public async Task<GameDto?> GetByIdAsync(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            return _mapper.Map<GameDto>(game); // Map Blog to BlogDto
        }

        public async Task<IEnumerable<GameDto>> GetAllAsync()
        {
            var games = await _gameRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GameDto>>(games); // Map IEnumerable<Blog> to IEnumerable<BlogDto>
        }

        public async Task AddAsync(GameDto gameDto) // Update parameter to use BlogDto
        {
            var game = _mapper.Map<Game>(gameDto); // Map BlogDto to Blog
            await _gameRepository.AddAsync(game);
            await _gameRepository.SaveAsync();
        }

        public async Task UpdateAsync(GameDto gameDto) // Update parameter to use BlogDto
        {
            var existingGame = await _gameRepository.GetByIdAsync(gameDto.Id);
            if (existingGame == null)
            {
                // Handle not found scenario
                return;
            }

            _mapper.Map(gameDto, existingGame); // Map BlogDto properties to existingBlog
            _gameRepository.Update(existingGame);
            await _gameRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _gameRepository.DeleteAsync(id);
            await _gameRepository.SaveAsync();
        }
    }
}
