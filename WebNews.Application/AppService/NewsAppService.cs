using AutoMapper;
using WebNews.Application.Interface;
using WebNews.Domain.Dtos;
using WebNews.Domain.Entities;
using WebNews.Service.Interfaces;

namespace WebNews.Application.AppService
{
    public class NewsAppService : INewsAppService
    {
        private readonly INewsService service;
        private readonly IMapper _mapper;

        public NewsAppService(INewsService service, IMapper mapper)
        {
            this.service = service;
            _mapper = mapper;
        }
        public async Task<NewsDTO> AddNewsAsync(NewsDTO obj)
        {
            var _obj = _mapper.Map<NewsDTO,News>(obj);
            var result = await service.CriaNewsAsync(_obj);
            return _mapper.Map<News,NewsDTO>(result);
        }

        public async Task<IEnumerable<NewsDTO?>> FindNewsAsync()
        {
            var listNews = await this.service.BuscaNewssAsync();
            return _mapper.Map<List<NewsDTO?>>(listNews);
        }

        public async Task<NewsDTO?> FindNewsIdAsync(int id)
        {
            return _mapper.Map<News,NewsDTO>(await service.BuscaNewPorIdAsync(id));
        }
    }
}
