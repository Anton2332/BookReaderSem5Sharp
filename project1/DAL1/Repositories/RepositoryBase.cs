using System.Data;

namespace DAL1.Repositories;

public class RepositoryBase
{
    protected IDbTransaction Transaction { get; private set; }
    protected IDbConnection Connection {
        get { return Transaction.Connection; } }

    public RepositoryBase(IDbTransaction transaction)
    {
        Transaction = transaction;
    }
}