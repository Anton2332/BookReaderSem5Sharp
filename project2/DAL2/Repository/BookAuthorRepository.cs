using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class BookAuthorRepository : GenericRepository<BookAuthor>, IBookAuthorRepository
{
    public BookAuthorRepository(DBContext dbContext) : base(dbContext) {}
}