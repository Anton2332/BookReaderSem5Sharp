using DAL2.Entitys;

namespace DAL2.Interfaces;

public interface IBookAuthorRepository : IRepository<BookAuthor>
{
    Task<IEnumerable<BookAuthor>> GetAllAuthorsByBookIdAsync(int bookId, string? orderBy = null);
}