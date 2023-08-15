using WebNews.Domain.Entities;
using WebNews.Infrastructure.Repositories.Interface;
using WebNews.Service.Interfaces;

namespace WebNews.Service.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository repository;
        public NewsService(INewsRepository repository)
        {
            this.repository = repository;
        }
    
        public async Task<News?> BuscaNewPorIdAsync(int id)
        {
            return await repository.BuscaPorIdAsync(id);
        }

        public async Task<List<News>?> BuscaNewssAsync()
        {
            return await repository.BuscaTodosAsync()!;
        }

        public async Task<News> CriaNewsAsync(News? news)
        {
            try
            {
                await repository.CriarAsync(news);
                return news;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}
