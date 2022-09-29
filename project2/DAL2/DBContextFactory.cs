using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL2;

public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
{
    public DBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DBContext>();

        optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=db2_Csharp_sem5;Integrated Security=True");

        return new DBContext(optionsBuilder.Options);
    }
}