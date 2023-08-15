namespace WebNews.Domain.Dtos;
public class NewsDTO
{    
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public string? Chapeu { get; set; }
    public DateTime DataPublicacao { get; set; }
    public string? Autor { get; set; }
}
