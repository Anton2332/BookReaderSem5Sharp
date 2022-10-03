using System.Data;
using DAL1.Interface;
using DAL1.Model;
using Dapper;

namespace DAL1.Repositories;

public class LikeRepository : GenericRepository<Like>, ILikeRepository
{
    public LikeRepository(IDbTransaction transaction) : base("likeDislike", transaction)
    {
    }

    public async Task<int> GetIdByBodyAsync(string str)
    {
        var Id = await Connection.QueryAsync<int>(
            "select id from likeDislike where body = @Body",
            param: new { Body = str },
            transaction: Transaction);
        return Id.FirstOrDefault();
    }
}