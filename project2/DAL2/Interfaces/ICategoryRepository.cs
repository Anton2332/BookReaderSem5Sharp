using DAL2.Entitys;

namespace DAL2.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<IEnumerable<Category>> GetAllWithoutIdsAsync(int?[] ids, string? orderBy = null);
}