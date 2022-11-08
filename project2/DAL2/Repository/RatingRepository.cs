using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL2.Repository;

public class RatingRepository : GenericRepository<Rating>, IRatingRepository
{
    public RatingRepository(DBContext dbContext) : base(dbContext) {}

    public async Task<int> GetBallByBookIdAsync(int bookId)
    {
        var balls = await Items.Where(r => r.BookId == bookId).ToListAsync();
        var sum = balls.Sum(x => x.Ball);
        return (int)(sum / balls.Count());
    }

    public async Task<int> GetCountOfBallsByBookIdAsync(int bookId)
    => Items.Count(r => r.BookId == bookId);
    
}