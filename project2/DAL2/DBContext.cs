using DAL2.Configuration;
using DAL2.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DAL2;

public class DBContext : DbContext
{
    public DbSet<Test> Tests { get; set; }

    public DBContext() : base()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
    }
}