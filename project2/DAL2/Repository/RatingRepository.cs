using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class RatingRepository : GenericRepository<Rating>, IRatingRepository
{
    public RatingRepository(DBContext dbContext) : base(dbContext) {}
}