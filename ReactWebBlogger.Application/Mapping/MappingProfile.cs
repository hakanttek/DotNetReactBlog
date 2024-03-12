using AutoMapper;
using ReactWebBlogger.Application.DTOs;
using ReactWebBlogger.Domain.Entities;

namespace ReactWebBlogger.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogDto, Blog>();
            CreateMap<Blog, BlogDto>();            

            CreateMap<GameDto, Game>();
            CreateMap<Game, GameDto>();

            CreateMap<MessageDto, Message>();
            CreateMap<Message, MessageDto>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

        }
    }
}
