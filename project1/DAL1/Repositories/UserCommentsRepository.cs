using System.Data;
using DAL1.Interface;
using DAL1.Model;
using Dapper;

namespace DAL1.Repositories;

public class UserCommentsRepository :RepositoryBase, IUserCommentsRepository
{
    public UserCommentsRepository(IDbTransaction transaction) :base(transaction)
    {
    }
    
    public async Task<UserComments> GetAllAsync()
    {
        var result = await Connection.QuerySingleOrDefaultAsync<UserComments>(
            $"SELECT * FROM usersComments", transaction: Transaction);
        if (result == null)
            throw new KeyNotFoundException($"data in usersComments could not be found.");
    
        return result;
    }
    
    public async Task<UserComments> GetAsync(string id)
    {
        var result = await Connection.QuerySingleOrDefaultAsync<UserComments>(
            $"SELECT * FROM usersComments WHERE Id=@Id", new { Id = id }, transaction: Transaction);
        if (result == null)
            throw new KeyNotFoundException($"usersComments with id [{id}] could not be found.");
    
        return result;
    }
    
    public async Task DeleteAsync(string id)
    {
        await Connection.ExecuteAsync(
            $"DELETE FROM usersComments WHERE Id=@Id", new { Id = id }, transaction: Transaction);
    }
    
    public async Task<string> AddAsync(UserComments userComments)
    {
        var insertQuery = $"insert into usersComments (id, firstname, lastname) values ('{userComments.Id}', '{userComments.Firstname}', '{userComments.Lastname}');";
        var newId = await Connection.ExecuteScalarAsync<string>(
            insertQuery, transaction: Transaction);
        return newId;
    }
    
}