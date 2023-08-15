using WebNews.Domain.Entities;
using WebNews.Infrastructure.Repositories.Base;

namespace WebNews.Infrastructure.Repositories.Interface
{
    public interface INewsRepository:IBaseRepository<News>
    {
    }
}
