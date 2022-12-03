using DAL2.Entitys;

namespace DAL2.Interfaces;

public interface IRatingRepository : IRepository<Rating>
{
    Task<int> GetBallByBookIdAsync(int bookId);

    Task<int> GetCountOfBallsByBookIdAsync(int bookId);
    Task<List<int>> GetMostPopularBookIdAsync();
}