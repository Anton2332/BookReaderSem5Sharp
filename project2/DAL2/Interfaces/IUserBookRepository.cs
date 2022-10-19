using DAL2.Entitys;

namespace DAL2.Interfaces;

public interface IUserBookRepository
{
    IQueryable<UserBook> Items { get; }
    Task<IEnumerable<UserBook>> GetAllAsync();
    Task<UserBook> GetByIdAsync(string id, CancellationToken cancel = default);
    Task AddAsync(UserBook entity, CancellationToken cancel = default);
    Task UpdateAsync(UserBook entity, CancellationToken cancel = default);
    Task RemoveAsync(string id, CancellationToken cancel = default);
}