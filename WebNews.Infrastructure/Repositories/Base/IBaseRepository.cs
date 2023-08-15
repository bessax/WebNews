namespace WebNews.Infrastructure.Repositories.Base;

public interface IBaseRepository<T>
        where T : class
{
    Task AlteraAsync(int id, T obj);

    Task<T?> BuscaPorIdAsync(int id);

    Task<List<T>> BuscaTodosAsync();

    Task CriarAsync(T obj);

    Task DeletaAsync(int id);

    Task<IEnumerable<T>> BuscaTodosPaginadoAsync(int page, int pageSize);
}
