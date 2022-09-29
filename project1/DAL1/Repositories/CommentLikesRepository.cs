using System.Data;
using DAL1.Interface;
using DAL1.Model;

namespace DAL1.Repositories;

public class CommentLikesRepository : GenericRepository<CommentLikes>, ICommentLikesRepository
{
    public CommentLikesRepository(IDbTransaction transaction) : base("commentLikes", transaction)
    {
    }
}