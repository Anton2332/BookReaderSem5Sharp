using System.Data;
using DAL1.Interface;
using DAL1.Model;
using Dapper;

namespace DAL1.Repositories;

public class CommentLikesRepository : GenericRepository<CommentLikes>, ICommentLikesRepository
{
    public CommentLikesRepository(IDbTransaction transaction) : base("commentLikes", transaction)
    {
    }

    public async Task<int> GetCountLikesByCommentIdAsync(int id)
    {
        var count = await Connection.QueryAsync<int>(
            "select Count(*) from commentLikes c inner join likeDislike l on c.likeId = l.id where c.commentId = @Id and l.body = 'like'",
            param: new { Id = id },
            transaction: Transaction);
        return count.FirstOrDefault(0);
    }

    public async Task<int> GetCountDislikesByCommentIdAsync(int id)
    {
        var count = await Connection.QueryAsync<int>(
            "select Count(*) from commentLikes c inner join likeDislike l on c.likeId = l.id where c.commentId = @Id and l.body = 'dislike'",
            param: new { Id = id },
            transaction: Transaction);
        return count.FirstOrDefault(0);
    }

    public async Task<int> GetIdByUserIdAndCommentIAndLike(int userId, int commentId)
    {
        var Id = await Connection.QueryAsync<int>(
            "select id from commentLikes c inner join likeDislike l on c.likeId = l.id where c.comentId = @CommentId and c.userId = @UserId and l.body = 'like'",
            param:new {UserId = userId, CommentId = commentId},
            transaction:Transaction);
            return Id.First();
    }
    
    public async Task<int> GetIdByUserIdAndCommentIAndDislike(int userId, int commentId)
    {
        var Id = await Connection.QueryAsync<int>(
            "select id from commentLikes c inner join likeDislike l on c.likeId = l.id where c.comentId = @CommentId and c.userId = @UserId and l.body = 'dislike'",
            param:new {UserId = userId, CommentId = commentId},
            transaction:Transaction);
        return Id.First();
    }
}