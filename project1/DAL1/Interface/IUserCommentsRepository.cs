using DAL1.Model;

namespace DAL1.Interface;

public interface IUserCommentsRepository
{
    Task<UserComments> GetAllAsync();

    Task<UserComments> GetAsync(string id);

    Task DeleteAsync(string id);

    Task<string> AddAsync(UserComments userComments);
}