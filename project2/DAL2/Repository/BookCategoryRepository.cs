using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class BookCategoryRepository : GenericRepository<BookCategory>, IBookCategoryRepository
{
    public BookCategoryRepository(DBContext dbContext) : base(dbContext) {}
}