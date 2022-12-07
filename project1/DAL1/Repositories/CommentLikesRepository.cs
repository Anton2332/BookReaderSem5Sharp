using System.Data;
using DAL1.Interface;
using DAL1.Model;
using Dapper;

namespace DAL1.Repositories;

public class CommentLikesRepository : GenericRepository<CommentLikes>, ICommentLikesRepository
{
    public CommentLikesRepository(IDbTransaction transaction) : base("CommentLikes", transaction)
    {
    }

    public async Task<int> AddLikeAsync(CommentLikes commentLikes)
    {
        var newId = await Connection.ExecuteScalarAsync<int>(
            "insert into CommentLikes (UserId, IsLike, CommentId) values (@UserId, @IsLike, @CommentId)",
            param: new
            {
                UserId = commentLikes.UserId,
                IsLike = commentLikes.IsLike,
                CommentId = commentLikes.CommentId
            },
            transaction: Transaction);
        return newId;
    }

    public async Task<int> GetCountLikesByCommentIdAsync(int id)
    {
        var count = await Connection.QueryAsync<int>(
            "select Count(*) from CommentLikes c where CommentId = @Id and IsLike = TRUE",
            param: new { Id = id },
            transaction: Transaction);
        return count.FirstOrDefault(0);
    }

    public async Task<int> GetCountDislikesByCommentIdAsync(int id)
    {
        var count = await Connection.QueryAsync<int>(
            "select Count(*) from CommentLikes where CommentId = @Id and IsLike = FALSE",
            param: new { Id = id },
            transaction: Transaction);
        return count.FirstOrDefault(null);
    }

    public async Task<int?> GetIdByUserIdAndCommentIdAndLike(string userId, int commentId)
    {
        var Id = await Connection.QueryAsync<int>(
            "select c.id from CommentLikes c  where c.CommentId = @CommentId and c.UserId = @UserId and c.IsLike = TRUE",
            param:new {UserId = userId, CommentId = commentId},
            transaction:Transaction);
        if (Id.Count() == 0)
        {
            return null;
        }
        else
        {
            return Id.First();
        }
    }
    
    public async Task<int?> GetIdByUserIdAndCommentIdAndDislike(string userId, int commentId)
    {
        var Id = await Connection.QueryAsync<int>(
            "select c.id from CommentLikes c where c.CommentId = @CommentId and c.UserId = @UserId and c.IsLike = FALSE",
            param:new {UserId = userId, CommentId = commentId},
            transaction:Transaction);
        if (Id.Count() == 0)
        {
            return null;
        }
        else
        {
            return Id.First();
        }
    }
}