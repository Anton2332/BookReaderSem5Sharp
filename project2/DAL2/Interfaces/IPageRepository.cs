using DAL2.Entitys;

namespace DAL2.Interfaces;

public interface IPageRepository : IRepository<Page>
{
    Task<IEnumerable<Page>> GetAllPagesByChapterIdAsync(int chapterId);
}