using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(DBContext dbContext) : base(dbContext) {}
}