using DAL2.Entitys;

namespace DAL2.Interfaces;

public interface ITagRepository : IRepository<Tag>
{
    Task<IEnumerable<Tag>> GetAllWithoutIdsAsync(int[] ids, string? orderBy = null);
}