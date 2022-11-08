using DAL2.Entitys;
using DAL2.Helpers;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Repository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DBContext dbContext) : base(dbContext) {}
    
    public async Task<IEnumerable<Category>> GetAllWithoutIdsAsync(int?[] ids,string? orderBy = null)
    {
        var query = Items.Where(x => ids.Contains(x.Id));
        return orderBy != null ? query.Order(orderBy) : await query.ToListAsync();;
    }
}