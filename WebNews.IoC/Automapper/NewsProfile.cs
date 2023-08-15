using AutoMapper;
using WebNews.Domain.Dtos;
using WebNews.Domain.Entities;

namespace WebNews.Service.Automapper
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<NewsDTO, News>();
            CreateMap<News, NewsDTO>();
        }
    }
}
