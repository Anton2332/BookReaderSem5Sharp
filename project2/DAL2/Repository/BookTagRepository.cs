using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class BookTagRepository : GenericRepository<BookTag>, IBookTagRepository
{
    public BookTagRepository(DBContext dbContext) : base(dbContext) {}
}