using DAL2.Entitys;

namespace DAL2.Interfaces;

public interface IChapterRepository : IRepository<Chapter>
{
    Task<IEnumerable<Chapter>> GetAllChaptersByBookIdAsync(int bookId);

    Task<int> GetCountOfChaptersByBookIdAsync(int bookId);
}