using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Repository;

public class ChapterRepository : GenericRepository<Chapter>, IChapterRepository
{
    public ChapterRepository(DBContext dbContext) : base(dbContext) {}
    
    public async Task<IEnumerable<Chapter>> GetAllChaptersByBookIdAsync(int bookId)
    {
        var query = Items.Where(x => x.BookId == bookId);
        return await query.ToListAsync();
    }

    public async Task<int> GetCountOfChaptersByBookIdAsync(int bookId)
    {
        var result = await GetAllChaptersByBookIdAsync(bookId);
        return result.Count();
    }
}