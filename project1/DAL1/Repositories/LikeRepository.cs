using System.Data;
using DAL1.Interface;
using DAL1.Model;

namespace DAL1.Repositories;

public class LikeRepository : GenericRepository<Like>, ILikeRepository
{
    public LikeRepository(IDbTransaction transaction) : base("likeDislike", transaction)
    {
    }
}