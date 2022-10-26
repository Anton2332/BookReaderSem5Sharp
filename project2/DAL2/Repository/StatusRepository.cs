using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class StatusRepository : GenericRepository<Status>, IStatusRepository
{
    public StatusRepository(DBContext dbContext) : base(dbContext) {}
}