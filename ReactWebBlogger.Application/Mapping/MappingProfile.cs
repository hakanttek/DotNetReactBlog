using AutoMapper;
using ReactWebBlogger.Application.DTOs;
using ReactWebBlogger.Domain.Entities;

namespace ReactWebBlogger.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Blog, BlogDto>(); // Define the mapping from Blog to BlogDto


        }
    }
}
