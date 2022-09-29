using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class TestRepository : GenericRepository<Test>, ITestRepository
{
    public TestRepository(DBContext dbContext) : base(dbContext) {}
}