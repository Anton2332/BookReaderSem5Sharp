using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class PageRepository : GenericRepository<Page>, IPageRepository
{
    public PageRepository(DBContext dbContext) : base(dbContext) {}
}