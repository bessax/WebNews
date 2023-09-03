using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using WebNews.Domain.Entities;

namespace WebNews.Infrastructure.NewsContext;
public class NewsDbContext:DbContext
{

    public NewsDbContext(DbContextOptions<NewsDbContext> options)
        : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }
    public DbSet<News> Report { get; set; }
}
