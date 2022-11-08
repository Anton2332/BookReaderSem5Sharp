using DAL2.Entitys;

namespace DAL2.Interfaces;

public interface IBookCategoryRepository : IRepository<BookCategory>
{
    Task<IEnumerable<BookCategory>> GetAllCategoriesByBookIdAsync(int bookId, string? orderBy = null);
}