using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Repository;

public class PageRepository : GenericRepository<Page>, IPageRepository
{
    public PageRepository(DBContext dbContext) : base(dbContext) {}
    
    public async Task<IEnumerable<Page>> GetAllPagesByBookIdAsync(int chapterId)
    {
        var query = Items.Where(x => x.ChapterId == chapterId);
        return await query.ToListAsync();
    }
}