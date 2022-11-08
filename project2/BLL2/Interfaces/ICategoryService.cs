using BLL2.DTO.Request;

namespace BLL2.Interfaces;

public interface ICategoryService
{
    Task AddAsync(CategoryRequestDTO сategoryRequestDto);
    Task UpdateAsync(CategoryRequestDTO categoryRequestDto);
    Task DeleteAsync(int id);
}