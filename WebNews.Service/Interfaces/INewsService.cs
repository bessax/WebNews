using WebNews.Domain.Dtos;
using WebNews.Domain.Entities;

namespace WebNews.Service.Interfaces
{
    public interface INewsService
    {       
        Task<News?> BuscaNewPorIdAsync(int id);

        Task<List<News>?> BuscaNewssAsync();

        Task<News> CriaNewsAsync(News? news);

        //Task<bool> DeletaNewsAsync(int id);
        //Task<IEnumerable<News>> NewsPaginadoAsync(int pagina, int tamanhoPagina);
        //Task<bool> AlteraNewsAsync(int id, News news);
    }
}
