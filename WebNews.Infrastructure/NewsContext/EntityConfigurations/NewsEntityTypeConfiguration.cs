using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebNews.Domain.Entities;

namespace WebNews.Infrastructure.NewsContext.EntityConfigurations;

internal class NewsEntityTypeConfiguration : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x=> x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Descricao);
        builder.Property(x => x.Titulo);
        builder.Property(x => x.Autor);
        builder.Property(x => x.Chapeu);
        builder.Property(x => x.DataPublicacao);        
    }
}
