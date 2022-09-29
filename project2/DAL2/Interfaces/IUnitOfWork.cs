namespace DAL2.Interfaces;

public interface IUnitOfWork
{
    public ITestRepository TestRepository { get; }
    
    public DBContext DbContext { get; }

    Task SaveChangesAsync();
}