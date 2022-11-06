using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GraphQL;

public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
{
    public DBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DBContext>();

        optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=db2_2_Csharp_sem5;Integrated Security=True;TrustServerCertificate=True");

        return new DBContext(optionsBuilder.Options);
    }
}