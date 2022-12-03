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

    public async Task<List<int>> GetMostPopularBookIdAsync()
    {
        var bookIds = await Items.GroupBy(r => r.BookId).Select(r => r.Key).ToListAsync();

        var allBooks = new List<PopularBook>();
        foreach (var i in bookIds)
        {
            var ball = await GetBallByBookIdAsync(i);
            allBooks.Add(new PopularBook()
            {
                BookId = i,
                Ball = ball
            });
        }

        var result = allBooks.OrderBy(p => p.Ball).Take(15).Select(p => p.BookId).ToList();
        return result;
    }

    private class PopularBook
    {
        public int BookId { get; set; }
        public int Ball { get; set; }
    }
    
}