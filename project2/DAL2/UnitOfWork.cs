using DAL2.Interfaces;

namespace DAL2;

public class UnitOfWork : IUnitOfWork
{
    public readonly DBContext _dbContext;
    
    public ITestRepository TestRepository { get; }
    public IAuthorRepository AuthorRepository { get; }
    public IBookAuthorRepository BookAuthorRepository { get; }

    public UnitOfWork(
        DBContext dbContext, 
        ITestRepository testRepository, 
        IAuthorRepository authorRepository,
        IBookAuthorRepository bookAuthorRepository
        )
    {
        _dbContext = dbContext;
        TestRepository = testRepository;
        AuthorRepository = authorRepository;
        BookAuthorRepository = bookAuthorRepository;
    }
    
    public DBContext DbContext
    {
        get { return _dbContext; }
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    
}