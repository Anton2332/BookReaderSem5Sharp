using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DBContext dbContext) : base(dbContext) {}
}