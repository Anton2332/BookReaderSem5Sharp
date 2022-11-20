using DAL2.Entitys;
using DAL2.Helpers;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Repository;

public class BookTagRepository : GenericRepository<BookTag>, IBookTagRepository
{
    public BookTagRepository(DBContext dbContext) : base(dbContext) {}
    
    public async Task<IEnumerable<BookTag>> GetAllTagsByBookIdAsync(int bookId,string? orderBy = null)
    {
        var query = Items
            .Where(x => x.BookId == bookId)
            .Include(x => x.Tag);
        return orderBy != null ? query.Order(orderBy) : await query.ToListAsync();
    }
}