using System.Data;
using DAL1.Interface;
using DAL1.Model;

namespace DAL1.Repositories;

public class BookCommentsRepository : GenericRepository<BookComments>, IBookCommentsRepository
{
    public BookCommentsRepository(IDbTransaction transaction) : base("bookComments", transaction)
    {
    }
}