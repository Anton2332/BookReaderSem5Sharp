using DAL2.Interfaces;

namespace DAL2;

public class UnitOfWork : IUnitOfWork
{
    public readonly DBContext _dbContext;
    
    public ITestRepository TestRepository { get; }

    public UnitOfWork(DBContext dbContext, ITestRepository testRepository)
    {
        _dbContext = dbContext;
        TestRepository = testRepository;
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