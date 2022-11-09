using BLL2.DTO.Request;
using BLL2.DTO.Response;

namespace BLL2.Interfaces;

public interface ICategoryService
{
    Task AddAsync(CategoryRequestDTO сategoryRequestDto);
    Task UpdateAsync(CategoryRequestDTO categoryRequestDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<CategoryResponseDTO>> GetAllAsync();
    Task<CategoryResponseDTO> GetByIdAsync(int id);
}