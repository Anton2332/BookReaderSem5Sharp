using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    public TagRepository(DBContext dbContext) : base(dbContext) {}
}