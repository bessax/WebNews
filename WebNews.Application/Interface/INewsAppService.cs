using WebNews.Domain.Dtos;

namespace WebNews.Application.Interface
{
    public interface INewsAppService
    {
        Task<NewsDTO> AddNewsAsync(NewsDTO obj);
        Task<NewsDTO?> FindNewsIdAsync(int id);
        Task<IEnumerable<NewsDTO?>> FindNewsAsync();
    }
}
