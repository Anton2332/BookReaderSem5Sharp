using System.Data;
using DAL1.Interface;
using DAL1.Model;

namespace DAL1.Repositories;

public class UserCommentsRepository : GenericRepository<UserComments>, IUserCommentsRepository
{
    public UserCommentsRepository(IDbTransaction transaction) : base("usersComments", transaction)
    {
    }
}