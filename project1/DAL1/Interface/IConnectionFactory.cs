using System.Data;

namespace DAL1.Interface;

public interface IConnectionFactory
{
    IDbConnection GetSqlConnection { get; }
    void SetConnection(string connectionString);
}