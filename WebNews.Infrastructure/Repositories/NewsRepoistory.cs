using WebNews.Domain.Entities;
using WebNews.Infrastructure.NewsContext;
using WebNews.Infrastructure.Repositories.Base;
using WebNews.Infrastructure.Repositories.Interface;

namespace WebNews.Infrastructure.Repositories
{
    public class NewsRepoistory:BaseRepository<News>, INewsRepository
    {
        private readonly NewsDbContext context;
        public NewsRepoistory(NewsDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
