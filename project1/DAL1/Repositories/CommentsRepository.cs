using System.Data;
using DAL1.Interface;
using DAL1.Model;

namespace DAL1.Repositories;

public class CommentsRepository : GenericRepository<Comments>, ICommentsRepository
{
    public CommentsRepository(IDbTransaction transaction) : base("comments", transaction)
    {
    }
}