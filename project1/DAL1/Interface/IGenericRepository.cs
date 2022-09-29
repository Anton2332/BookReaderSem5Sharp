namespace DAL1.Interface;

public interface IGenericRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task DeleteAsync(int id);
    Task<T> GetAsync(int id);
    Task ReplaceAsync(T t);
    Task<int> AddAsync(T t);
}