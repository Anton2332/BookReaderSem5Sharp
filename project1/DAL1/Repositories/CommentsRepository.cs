using System.Data;
using DAL1.Interface;
using DAL1.Model;
using Dapper;

namespace DAL1.Repositories;

public class CommentsRepository : GenericRepository<BaseComments>, ICommentsRepository
{
    public CommentsRepository(IDbTransaction transaction) : base("comments",  transaction)
    {
    }
    
    public async Task<IEnumerable<Comments>> GetAllByBookIdButNotRepliesAsync(int id)
    {
        var comments = await Connection.QueryAsync<Comments, UserComments, Comments
        >(
            "select * from comments c inner join usersComments u on c.userId = u.Id where c.BookId = @Id and c.repliesId = null",
            (comments, user) =>
            {
                comments.User = user;
                return comments;
            },
            param:new{Id = id},
            transaction:Transaction);

        return comments;
    }

    public async Task<IEnumerable<Comments>> GetAllByBookIdAsync(int id)
    {
        var comments = await Connection.QueryAsync<Comments, UserComments, Comments
        >(
            "select * from comments c inner join usersComments u on c.userId = u.Id where c.BookId = @Id",
            (comments, user) =>
            {
                comments.User = user;
                return comments;
            },
            param:new{Id = id},
            transaction:Transaction);

        return comments;
    }
    
    public async Task<IEnumerable<Comments>> GetAllByCommentsIdAsync(int id)
    {
        var comments = await Connection.QueryAsync<Comments, UserComments, Comments
        >(
            "select * from comments c inner join usersComments u on c.userId = u.Id where c.repliesId = @Id",
            (comments, user) =>
            {
                comments.User = user;
                return comments;
            },
            param:new{Id = id},
            transaction:Transaction);

        return comments;
    }
}