using BLL2.DTO;

namespace BLL2.Interfaces;

public interface ITestService
{
    Task AddAsync(TestDTO test);
    Task UpdateAsync(TestDTO test);
    Task DeleteAsync(int id);
    Task<IEnumerable<TestDTO>> GetAllAsync();
}