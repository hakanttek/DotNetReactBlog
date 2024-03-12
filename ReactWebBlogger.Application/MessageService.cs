using AutoMapper;
using ReactWebBlogger.Application.DTOs;
using ReactWebBlogger.Contracts.Repositories;
using ReactWebBlogger.Contracts.Services;
using ReactWebBlogger.Domain.Entities;

namespace ReactWebBlogger.Application
{
    public class MessageService:IMessageService<MessageDto>, ICRUDService<MessageDto>
    {
        private readonly IMessageRepository _repository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MessageDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<MessageDto>(entity);
        }

        public async Task<IEnumerable<MessageDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MessageDto>>(entities);
        }

        public async Task AddAsync(MessageDto dto)
        {
            var entity = _mapper.Map<Message>(dto);
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(MessageDto dto)
        {
            var entity = _mapper.Map<Message>(dto);
            _repository.Update(entity);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }
    }
}
