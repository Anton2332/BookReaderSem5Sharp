namespace DAL2.Interfaces;

public interface IRepository<T> where T: class, new()
{
    IQueryable<T> Items { get; }
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id, CancellationToken cancel = default);
    Task<int> AddAsync(T entity, CancellationToken cancel = default);
    Task UpdateAsync(T entity, CancellationToken cancel = default);
    Task RemoveAsync(int id, CancellationToken cancel = default);

}