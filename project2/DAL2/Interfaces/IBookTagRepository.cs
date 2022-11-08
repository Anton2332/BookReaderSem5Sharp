using DAL2.Entitys;

namespace DAL2.Interfaces;

public interface IBookTagRepository : IRepository<BookTag>
{
    Task<IEnumerable<BookTag>> GetAllTagsByBookIdAsync(int bookId, string? orderBy = null);
}