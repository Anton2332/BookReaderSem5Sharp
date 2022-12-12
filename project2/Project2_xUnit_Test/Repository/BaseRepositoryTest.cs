using DAL2;
using DAL2.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Project2_xUnit_Test.Repository;

public class BaseRepositoryTest
{
    protected readonly DbContextOptions<DBContext> _dbOptions;

    public BaseRepositoryTest()
    {
        _dbOptions = new DbContextOptionsBuilder<DBContext>()
            .UseInMemoryDatabase(databaseName: "in-memory")
            .Options;

        using var dbContext = new DBContext(_dbOptions);
        dbContext.AddRange(GetFakeAuthors());
        dbContext.SaveChanges();
    }

    public List<Author> GetFakeAuthors()
    {
        return new List<Author>()
        {
            new ()
            {
                BookAuthor = null,
                Id = 1,
                Name = "Author 1"
            },
            new ()
            {
                BookAuthor = null,
                Id = 2,
                Name = "Author 2"
            }
        };
    }
}