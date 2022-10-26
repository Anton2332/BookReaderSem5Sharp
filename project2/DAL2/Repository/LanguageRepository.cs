using DAL2.Entitys;
using DAL2.Interfaces;

namespace DAL2.Repository;

public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
{
    public LanguageRepository(DBContext dbContext) : base(dbContext) {}
}