using DAL2.Entitys;
using DAL2.Helpers;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Repository;

public class BookCategoryRepository : GenericRepository<BookCategory>, IBookCategoryRepository
{
    public BookCategoryRepository(DBContext dbContext) : base(dbContext) {}
    
    public async Task<IEnumerable<BookCategory>> GetAllCategoriesByBookIdAsync(int bookId,string? orderBy = null)
    {
        var query = Items.Where(x => x.BookId == bookId);
        return orderBy != null ? query.Order(orderBy) : await query.ToListAsync();
    }
}