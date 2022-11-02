using Domain.QueryMapper;

namespace Domain.Interfaces;

public interface IReadRepository<T, TEntity>
{
    IEnumerable<TEntity> GetAll(QueryOptions options);
    TEntity Get(T id);
}