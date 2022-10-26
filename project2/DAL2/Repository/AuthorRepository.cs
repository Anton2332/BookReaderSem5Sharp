using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(DBContext dbContext) : base(dbContext){}
}