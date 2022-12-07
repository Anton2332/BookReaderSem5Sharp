using System.Data;
using DAL1.Interface;
using DAL1.Model;
using Dapper;

namespace DAL1.Repositories;

public class CommentsRepository : GenericRepository<BaseComments>, ICommentsRepository
{
    public CommentsRepository(IDbTransaction transaction) : base("Comments",  transaction)
    {
    }
    
    public async Task<IEnumerable<Comments>> GetCommentsByBookIdAsync(int id)
    {
        var comments = await Connection.QueryAsync<Comments
        >(
            "select * from Сomments where BookId = @Id and repliesId = null",
            param:new{Id = id},
            transaction:Transaction);
    
        return comments;
    }
    
    public async Task<IEnumerable<Comments>> GetAllByBookIdAsync(int id)
    {
        var comments = await Connection.QueryAsync<Comments
        >(
            "select * from Comments where BookId = @Id",
            param:new{Id = id},
            transaction:Transaction);
    
        return comments;
    }
    
    public async Task<IEnumerable<Comments>> GetRepliesByCommentsIdAsync(int id)
    {
        var comments = await Connection.QueryAsync<Comments
        >(
            "select * from Сomments where repliesId = @Id",
            param:new{Id = id},
            transaction:Transaction);
    
        return comments;
    }
}